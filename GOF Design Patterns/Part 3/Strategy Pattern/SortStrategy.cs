using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern {
    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    abstract class SortStrategy {
        public abstract void Sort(List<string> list);
    }
}
