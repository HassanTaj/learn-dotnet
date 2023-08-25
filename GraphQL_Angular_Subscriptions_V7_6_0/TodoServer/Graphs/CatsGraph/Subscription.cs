using GraphQL;
using TodoServer.Models;

namespace TodoServer.Graphs.CatsGraph
{
    public class Subscription
    {
        public static IObservable<Cat> Cats([FromServices] CatsData cats) => cats.CatObservable();
    }
}
