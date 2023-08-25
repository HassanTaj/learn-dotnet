using GraphQL;
using TodoServer.Data;
using TodoServer.Models;

namespace TodoServer.Graphs.TodoGraph {
    public class Subscription {
        public static IObservable<Todo> Todos([FromServices] AppDbContext db, [FromServices] TodoService todoService) {
            todoService.Init(db);
            return todoService.AsObservable();
        }
    }
}
