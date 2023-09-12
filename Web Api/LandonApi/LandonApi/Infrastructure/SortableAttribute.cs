using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Infrastructure {
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class SortableAttribute: Attribute {
        public string[] OrderBy { get; set; }
        public bool Default { get; set; }
    }
}
