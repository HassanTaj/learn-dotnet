using GraphQL;
using GraphQL.Types;
using RealEstateManager.Graph.Mutations;
using RealEstateManager.Graph.Queries;

namespace RealEstateManager.Graph.Schemas {
    public class RealEstateSchema : Schema {
        public RealEstateSchema(IDependencyResolver resolver) : base(resolver){
            Query = resolver.Resolve<PropertyQuery>();
            Mutation = resolver.Resolve<PropertyMutation>();
        }
    }
}
