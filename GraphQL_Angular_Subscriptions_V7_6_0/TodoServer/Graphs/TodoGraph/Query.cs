using GraphQL;
using System.Reflection.Metadata.Ecma335;
using TodoServer.Data;
using TodoServer.Models;

namespace TodoServer.Graphs.TodoGraph {
    public class Query {

        public static IEnumerable<Todo> Todos([FromServices] AppDbContext db) {
            var response = new List<Todo>();
            response = db.Todos.ToList();
            TodoService.Init(db);
            return response;
        }

        public static Todo? Todo([FromServices] AppDbContext db, [Id] int id)
      => db.Todos.FirstOrDefault(x => x.Id == id);

    }
}
