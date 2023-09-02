using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight_Pattern {
    class Program {
        static void Main(string[] args) {

            ShapObjectFactory factor = new ShapObjectFactory();

            IShape shape = factor.GetShape("Triangle");
            shape.Print();
            shape = factor.GetShape("Triangle");
            shape.Print();
            shape = factor.GetShape("Triangle");
            shape.Print();

            shape = factor.GetShape("Square");
            shape.Print();
            shape = factor.GetShape("Square");
            shape.Print();
            shape = factor.GetShape("Square");
            shape.Print();

            Console.WriteLine($"Total objects created  = {factor.TotalObjectsCreated }");

        }
    }
}