using GraphQL;
using System.Reactive.Linq;
using TodoServer.Data;
using TodoServer.Models;

namespace TodoServer.Graphs.TodoGraph {
    public class Subscription {
        public static IObservable<Todo> Todos() =>
            TodoService.AsObservable();

        public static IObservable<Todo> OnAddTodo() =>
           TodoService.AsObservable();
    }
}
