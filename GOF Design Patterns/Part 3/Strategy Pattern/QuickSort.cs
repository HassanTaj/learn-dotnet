using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern {
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class QuickSort : SortStrategy {
        public override void Sort(List<string> list) {
            list.Sort();// default is QuickSort
            Console.WriteLine("QuickSorted List ");
        }
    }
}
