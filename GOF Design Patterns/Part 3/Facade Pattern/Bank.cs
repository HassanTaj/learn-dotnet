using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern {
    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    class Bank {
        public bool HasSufficientSavings(Student c,int amount) {
            Console.WriteLine($"Verify bank for {c.Name}");
            return true;
        }
    }
}
