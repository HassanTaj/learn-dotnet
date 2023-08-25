using GraphQL;

namespace TodoServer.Models
{

    public record Cat([Id] int Id, string Name, string Breed);
}
