using LandonApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Models {
    public class Room:Resource {
        [Sortable]
        [Searchable]

        public string Name { get; set; }
        [Sortable(Default =true)]
        [SearchableDecimal]
        public decimal Rate { get; set; }

        public Form Book { get; set; }
    }
}
