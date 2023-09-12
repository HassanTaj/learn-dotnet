using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LandonApi.Infrastructure {
    public class SortOptionsProcessor<T, TEntity> {
        private readonly string[] _orderBy;

        public SortOptionsProcessor(string[] orderBy) {
            _orderBy = orderBy;
        }

        public IEnumerable<SortTerm> GetAllTerms() {
            if (_orderBy == null) yield break;

            foreach (var term in _orderBy) {
                if (string.IsNullOrEmpty(term)) continue;

                var tokens = term.Split(' ');

                if (tokens.Length == 0) {
                    yield return new SortTerm { Name = term };
                    continue;
                }

                var desc = tokens.Length > 1 && tokens[1].Equals("desc", StringComparison.OrdinalIgnoreCase);
                yield return new SortTerm {
                    Name = tokens[0],
                    Descending = desc,
                };
            }
        }

        public IEnumerable<SortTerm> GetValidTerms() {
            var queryTerms = GetAllTerms().ToArray();
            if (!queryTerms.Any()) yield break;

            var declaredTerms = GetTermsFromModel();
            foreach (var term in queryTerms) {
                var declaredTerm = declaredTerms.SingleOrDefault(x => x.Name.Equals(term.Name, StringComparison.OrdinalIgnoreCase));
                if (declaredTerm == null) continue;

                yield return new SortTerm {
                    Name = declaredTerm.Name,
                    Descending = term.Descending,
                    Default=  declaredTerm.Default
                };
            }
        }

        private static IEnumerable<SortTerm> GetTermsFromModel() {
            return typeof(T).GetTypeInfo()
                .DeclaredProperties
                .Where(p => p.GetCustomAttributes<SortableAttribute>().Any())
                .Select(p => new SortTerm { Name = p.Name, Default = p.GetCustomAttribute<SortableAttribute>().Default });
        }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> query) {
            var terms = GetValidTerms().ToArray();
            if (!terms.Any()) {
                terms = GetTermsFromModel().Where(t => t.Default).ToArray();
            }

            if (!terms.Any()) return query;

            var modifiedQuery = query;
            var useThenBy = false;
            foreach (var term in terms) {
                var propertyInfo = ExpressionHelper.GetPropertyInfo<TEntity>(term.Name);
                var obj = ExpressionHelper.Parameter<TEntity>();

                // build the linkq expression backwards;
                // query = query.Orderby(x => x.property);

                // x => x.Property
                var key = ExpressionHelper.GetPropertyExpression(obj, propertyInfo);

                var keySelector = ExpressionHelper.GetLambda(typeof(TEntity), propertyInfo.PropertyType, obj, key);

                // then by
                // query.OrderBy/ThenBy[Descending](x => x.Propery)
                modifiedQuery = ExpressionHelper.CallOrderByOrThenBy(modifiedQuery, useThenBy, term.Descending, propertyInfo.PropertyType, keySelector);

                useThenBy = true;
            }
            return modifiedQuery;
        }
    }
}
