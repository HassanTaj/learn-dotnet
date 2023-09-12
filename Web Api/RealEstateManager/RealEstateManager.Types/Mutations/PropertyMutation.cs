using GraphQL.Types;
using RealEstateManager.EF.Models;
using RealEstateManager.EF.Repositories;
using RealEstateManager.Graph.Types;

namespace RealEstateManager.Graph.Mutations {
    public class PropertyMutation : ObjectGraphType {
        public PropertyMutation(IPropertyRepository propertyRepository) {
            Field<PropertyType>(
                $"add{nameof(Property)}",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PropertyInputType>> { Name = $"{nameof(Property)}".ToLower() }),
                resolve: ctx => {
                    var p = ctx.GetArgument<Property>($"{nameof(Property)}".ToLower());
                    return propertyRepository.Add(p);
                });
        }
    }
}
