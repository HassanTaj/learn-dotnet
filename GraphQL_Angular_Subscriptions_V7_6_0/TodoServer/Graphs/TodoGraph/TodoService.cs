using System.Reactive.Linq;
using TodoServer.Data;
using TodoServer.Models;

namespace TodoServer.Graphs.TodoGraph {
    public class TodoService {
        public List<Todo> Todos { get; set; } = new List<Todo>();
        public void Init(AppDbContext db) {
            if (Todos.Count == 0) {
                Todos.AddRange(db.Todos.ToList());
            }
        }
        public IObservable<Todo> AsObservable()
            => Todos.ToObservable();
    }
}
