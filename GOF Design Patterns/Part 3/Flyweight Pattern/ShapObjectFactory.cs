using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight_Pattern {
    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    class ShapObjectFactory {
        Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

        public int TotalObjectsCreated { get => shapes.Count; }

        public IShape GetShape(string shapeName) {
            IShape shape = null;
            if (shapes.ContainsKey(shapeName)) {
                shape = shapes[shapeName];
            }
            else {
                switch (shapeName) {
                    case "Triangle":
                        shape = new Triangle();
                        shapes.Add("Triangle", shape);
                        break;
                    case "Square":
                        shape = new Square();
                        shapes.Add("Square", shape);
                        break;
                    default:
                        throw new Exception("The factory can't create the object requested");
                }
            }
            return shape;
        }
    }
}
