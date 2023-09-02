using GraphQL.Types;

namespace TodoServer.Graphs.CatsGraph
{
    public class CatsSchema : Schema
    {
        public CatsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = new AutoRegisteringObjectGraphType<Query>();
            Mutation = new AutoRegisteringObjectGraphType<Mutation>();
            Subscription = new AutoRegisteringObjectGraphType<Subscription>();
        }
    }
}
