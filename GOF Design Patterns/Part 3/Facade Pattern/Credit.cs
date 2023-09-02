using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern {
    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    class Credit {
        public bool HasGoodCredit(Student c) {
            Console.WriteLine($"Verify credit for {c.Name}");
            return true;
        }
    }
}
