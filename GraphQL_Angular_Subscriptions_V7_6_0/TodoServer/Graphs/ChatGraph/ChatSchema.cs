using GraphQL.Types;

namespace TodoServer.Graphs.ChatGraph {
    public class ChatSchema : Schema {
        public ChatSchema(IServiceProvider serviceProvider) : base(serviceProvider) {
            Query = new AutoRegisteringObjectGraphType<Query>();
            Mutation = new AutoRegisteringObjectGraphType<Mutation>();
            Subscription = new AutoRegisteringObjectGraphType<Subscription>();
        }
    }
}
