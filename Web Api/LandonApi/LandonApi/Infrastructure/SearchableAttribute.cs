using System;

namespace LandonApi.Infrastructure {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SearchableAttribute : Attribute {
        public ISearchExpressionProvider ExpressionProvider { get; set; } = new DefaultSearchExpressionProvider();
    }
}
