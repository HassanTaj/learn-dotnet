using GraphQL.Types;
using TodoServer.Data;
using TodoServer.Models;
using TodoServer.Services.Events;

namespace TodoServer.Graphs.TodoGraph
{
    public class TodoSchema : Schema {
        public TodoSchema(IServiceProvider serviceProvider) : base(serviceProvider) {
            var _db = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            var eventService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IEventService<Todo>>();

            if (eventService.GetAll().Count() == 0) {
                var items = _db.Todos.ToList();
                if (items.Exists(x => x != null)) {
                    eventService.CreateRange(items.ToArray());
                }
            }

            Query = new AutoRegisteringObjectGraphType<Query>();
            Mutation = new AutoRegisteringObjectGraphType<Mutation>();
            Subscription = new AutoRegisteringObjectGraphType<Subscription>();
        }
    }
}
