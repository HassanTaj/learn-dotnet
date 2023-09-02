using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern {
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ShellSort : SortStrategy {
        public override void Sort(List<string> list) {
            // list.ShellSort(); not-implimented
            Console.WriteLine("ShellSorted list ");
        }
    }
}
