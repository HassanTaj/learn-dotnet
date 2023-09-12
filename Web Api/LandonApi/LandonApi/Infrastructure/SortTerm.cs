using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Infrastructure {
    public class SortTerm {
        public string Name { get; set; }
        public bool Descending { get; set; }
        public bool Default { get; set; }
    }
}
