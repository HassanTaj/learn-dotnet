using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Models {
    public class PagingOptions {
        [Range(1,9999,ErrorMessage ="Offset must be greater than zero")]
        public int? Offset { get; set; }

        [Range(1,100,ErrorMessage = "Limit must be greater than 0 and less than 100")]
        public int? Limit { get; set; }
    }
}
