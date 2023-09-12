using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Infrastructure {
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class SearchableDecimalAttribute :SearchableAttribute {
        public SearchableDecimalAttribute() {
            ExpressionProvider = new DecimalToIntSearchExpressionProvider();
        }
    }
}
