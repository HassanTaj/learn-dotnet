using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7_Complex_Classes {
    class baseClass {
        /// virtual :
        ///     tells the compiler that the method can be overriden by the base classes
        public virtual void doSomething() {
            Console.WriteLine("This is the baseClass saying hi!");
        }
    }
}
