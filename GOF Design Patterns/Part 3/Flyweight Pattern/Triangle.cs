using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight_Pattern {
    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class Triangle : IShape {
        public void Print() {
            Console.WriteLine("Printing Triangle");
        }
    }
}