using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern {
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class MergeSort : SortStrategy {
        public override void Sort(List<string> list) {
            // list.MergeSort(); not-implimented
            Console.WriteLine("MergeSorted List");
        }
    }
}
