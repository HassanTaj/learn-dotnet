using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Models {
    public class PagedResult<T>  {
        public IEnumerable<T> Items { get; set; }
        public int TotalSize { get; set; }
    }
}
