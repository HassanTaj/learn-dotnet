using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LandonApi.Infrastructure {
    public class SearchOptionsProcessor<T, TEntity> {
        public readonly string[] _searchQuery;
        public SearchOptionsProcessor(string[] searchQuery) {
            _searchQuery = searchQuery;
        }
        public IEnumerable<SearchTerm> GetAllTerms() {
            if (_searchQuery == null) yield break;
            foreach (var expression in _searchQuery) {
                if (string.IsNullOrEmpty(expression)) continue;

                // eaach expression looks like:
                // "fieldname op value"
                var tokens = expression.Split(' ');

                if (tokens.Length == 0) {
                    yield return new SearchTerm {
                        ValidSyntax = false,
                        Name = expression
                    };

                    continue;
                }

                // tokens are less than 3
                if (tokens.Length < 3) {
                    yield return new SearchTerm {
                        ValidSyntax = false,
                        Name = tokens[0]
                    };

                    continue;
                }

                // if valid 
                yield return new SearchTerm {
                    ValidSyntax = true,
                    Name = tokens[0],
                    Operator = tokens[1],
                    Value = string.Join(" ", tokens.Skip(2))
                };
            }
        }

        public IEnumerable<SearchTerm> GetValidTerms() {
            var queryTerms = GetAllTerms()
                .Where(x => x.ValidSyntax)
                .ToArray();

            if (!queryTerms.Any()) yield break;

            var declaredTerms = GetTermsFromModel();

            foreach (var term in queryTerms) {
                var declaredTerm = declaredTerms
                    .SingleOrDefault(x => x.Name.Equals(term.Name, StringComparison.OrdinalIgnoreCase));

                if (declaredTerm == null) continue;

                yield return new SearchTerm {
                    ValidSyntax = term.ValidSyntax,
                    Name = declaredTerm.Name,
                    Operator = term.Operator,
                    Value = term.Value,
                    ExpressionProvider = declaredTerm.ExpressionProvider
                };
            }

        }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> query) {
            var terms = GetValidTerms().ToArray();
            if (!terms.Any()) return query;

            var modifiedQuery = query;

            foreach (var term in terms) {
                var proprInfo = ExpressionHelper.GetPropertyInfo<TEntity>(term.Name);

                var obj = ExpressionHelper.Parameter<TEntity>();

                // build up the linq expression backwards:
                // query = query.where(x => x.property == "Value")

                // x.prop
                var left = ExpressionHelper.GetPropertyExpression(obj, proprInfo);
                // value
                var right = term.ExpressionProvider.GetValue(term.Value);//Expression.Constant(term.Value);

                // x.prop == value
                var comparisonExpression = term.ExpressionProvider
                    .GetComparison(left,term.Operator,right);//Expression.Equal(left, right);

                // x => x.property == value
                var lambdaExpression = ExpressionHelper
                    .GetLambda<TEntity, bool>(obj, comparisonExpression);

                // query = query.where
                modifiedQuery = ExpressionHelper.CallWhere(modifiedQuery, lambdaExpression);

            }
            return modifiedQuery;
        }

        private static IEnumerable<SearchTerm> GetTermsFromModel() =>
            typeof(T).GetTypeInfo()
            .DeclaredProperties
            .Where(p => p.GetCustomAttributes<SearchableAttribute>().Any())
            .Select(p => new SearchTerm { Name = p.Name, ExpressionProvider = p.GetCustomAttribute<SearchableAttribute>().ExpressionProvider });

    }
}
