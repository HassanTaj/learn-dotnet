using System.Reactive.Linq;
using TodoServer.Data;
using TodoServer.Models;

namespace TodoServer.Graphs.TodoGraph {
    public class TodoService {
        public static List<Todo> Todos { get; set; } = new List<Todo>();
        public static void Init(AppDbContext db) {
            if (Todos.Count == 0) {
                Todos = db.Todos.ToList();
            }
        }
        public static IObservable<Todo> AsObservable()
            => Todos.ToObservable();
    }
}
