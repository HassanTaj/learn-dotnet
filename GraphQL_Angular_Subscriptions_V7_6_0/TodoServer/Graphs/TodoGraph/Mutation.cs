using GraphQL;
using TodoServer.Data;
using TodoServer.Models;

namespace TodoServer.Graphs.TodoGraph {
    public class Mutation {

        public static Todo Save([FromServices] AppDbContext db, TodoInput inp) {
            var model = new Todo { Task = inp.Task, CreatedOn=DateTime.Now };
            db.Todos.Add(model);
            db.SaveChanges();

            TodoService.Todos.Add(model);
            return model;
        }

        public static Todo? Remove([FromServices] AppDbContext db, [Id] int id) {
            var model = db.Todos.Where(x => x.Id == id).FirstOrDefault();
            if (model != null) {
                TodoService.Todos.Remove(model);
                db.Remove(model);
                db.SaveChanges();
            }
            return model;
        }
    }
}
