using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LandonApi.Infrastructure {
    public interface ISearchExpressionProvider {

        ConstantExpression GetValue(string input);
        Expression GetComparison(
           MemberExpression left,
           string op,
           ConstantExpression right);
    }
}
