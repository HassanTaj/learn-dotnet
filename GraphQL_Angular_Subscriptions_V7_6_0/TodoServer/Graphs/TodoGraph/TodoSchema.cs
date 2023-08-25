using GraphQL.Types;

namespace TodoServer.Graphs.TodoGraph {
    public class TodoSchema : Schema {
        public TodoSchema(IServiceProvider serviceProvider) : base(serviceProvider) {
            Query = new AutoRegisteringObjectGraphType<TodoServer.Graphs.TodoGraph.Query>();
            Mutation = new AutoRegisteringObjectGraphType<TodoServer.Graphs.TodoGraph.Mutation>();
            Subscription = new AutoRegisteringObjectGraphType<TodoServer.Graphs.TodoGraph.Subscription>();
        }
    }
}
