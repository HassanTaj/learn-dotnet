using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern {
    /// <summary>
    /// The 'Context' class
    /// </summary>
    class SortedList {

        private List<string> _list = new List<string>();
        private SortStrategy _sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy) {
            this._sortStrategy = sortStrategy;
        }

        public void Add(string name) {
            this._list.Add(name);
        }
        public void Sort() {
            _sortStrategy.Sort(_list);
            // iterate over list and display results
            _list.ForEach(x => {
                Console.WriteLine($" {x}");
            });
            Console.WriteLine();
        }

    }
}
