using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern {
    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    class Loan {
        public bool HasNoBadLoans(Student c) {
            Console.WriteLine($"Verify loan for {c.Name}");
            return true;
        }
    }
}
