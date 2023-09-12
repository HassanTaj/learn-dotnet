using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7_Complex_Classes {
    class subClass: baseClass {

        /// override :
        ///     tells the compiler that this method is overriding the same named mehtod
        ///         in the base class
        public override void doSomething() {

            // change position if you want to call subclassthing first

            Console.WriteLine("This is the subClass saying hi!");

            /// base  : 
            ///     in the subclass, calls the base calss' method
            ///         base.myFunction();
            
            // base.doSomething(); // take thisout if you don't wanna call the base calls

            //base.doSomething();
            //Console.WriteLine("This is the subClass saying hi!");
        }
    }
}
