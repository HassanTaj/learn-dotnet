using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7_Complex_Classes {
    class InterfaceImplimentationClass : ITalkitive {
        public InterfaceImplimentationClass() {
        }

        public void SayHellow() {
            Console.WriteLine("Saying hello!");
        }

        public void SayGoodBye() {
            Console.WriteLine("Saying goodbye!");
        }

        public void SayFuckYou() {
            Console.WriteLine("Fuck it it forces me to say this shit");

        }
    }
}
