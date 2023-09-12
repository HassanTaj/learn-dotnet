using GraphQL;
using TodoServer.Models;
using TodoServer.Services.Events;

namespace TodoServer.Graphs.TodoGraph
{
    public class Query {

        public static IEnumerable<Todo> Todos([FromServices] IEventService<Todo> eventService) {
            return eventService.GetAll();
        }
        public static IEnumerable<Todo> Todoses(IResolveFieldContext ctx, [FromServices] IEventService<Todo> eventService) {
            var fields = ctx.SubFields;
            return eventService.GetAll();
        }

        public static Todo? Todo([FromServices] IEventService<Todo> eventService, [Id] int id) => eventService.GetAll().FirstOrDefault(x => x.Id == id);

    }
}
