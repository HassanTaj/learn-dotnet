using GraphQL;
using TodoServer.Data;
using TodoServer.Models;

namespace TodoServer.Graphs.TodoGraph {
    public class Query {

        public static IEnumerable<Todo> Todos([FromServices] AppDbContext db,[FromServices] TodoService todoService) {
            todoService.Init(db);
            return db.Todos.ToList();
        }

        public static Todo? Todo([FromServices] AppDbContext db, [Id] int id)
      => db.Todos.FirstOrDefault(x => x.Id == id);

    }
}
