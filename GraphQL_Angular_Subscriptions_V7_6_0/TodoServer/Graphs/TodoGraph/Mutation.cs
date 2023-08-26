using GraphQL;
using TodoServer.Data;
using TodoServer.Models;
using TodoServer.Services.Events;

namespace TodoServer.Graphs.TodoGraph
{
    public class Mutation {

        public static Todo Save([FromServices] AppDbContext db, [FromServices] IEventService<Todo> eventService, TodoInput inp) {
            var model = new Todo { Task = inp.Task, CreatedOn = DateTime.Now };
            db.Todos.Add(model);
            db.SaveChanges();
            return eventService.Create(model);
        }

        public static Todo? Remove([FromServices] AppDbContext db, [FromServices] IEventService<Todo> eventService, [Id] int id) {
            var model = db.Todos.Where(x => x.Id == id).FirstOrDefault();
            if (model != null) {
                db.Remove(model);
                db.SaveChanges();

                model = eventService.Delete(id);
            }
            return model;
        }
        public static bool? RemoveAll([FromServices] AppDbContext db, [FromServices] IEventService<Todo> eventService) {
            var model = db.Todos.ToList();
            if (model != null && model.Count > 0) {
                foreach (var todo in model) {
                    db.Remove(todo);
                    db.SaveChanges();
                }
                eventService.ClearAll();
            }
            return eventService.Count==0;
        }
    }
}
