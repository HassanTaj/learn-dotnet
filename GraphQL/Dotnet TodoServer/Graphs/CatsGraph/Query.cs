using GraphQL;
using TodoServer.Models;

namespace TodoServer.Graphs.CatsGraph
{
    public class Query
    {
        public static Cat? Cat([FromServices] CatsData cats, [Id] int id)
      => cats[id];

        public static IEnumerable<Cat> Cats([FromServices] CatsData cats)
            => cats.Cats;
    }
}
