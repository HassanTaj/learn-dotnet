using GraphQL.Types;

namespace TodoServer.Graphs.TodoGraph {
    public class TodoSchema : Schema {
        public TodoSchema(IServiceProvider serviceProvider) : base(serviceProvider) {
            Query = new AutoRegisteringObjectGraphType<Query>();
            Mutation = new AutoRegisteringObjectGraphType<Mutation>();
            Subscription = new AutoRegisteringObjectGraphType<Subscription>();
        }
    }
}
