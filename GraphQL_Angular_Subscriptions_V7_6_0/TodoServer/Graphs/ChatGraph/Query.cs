using GraphQL;
using TodoServer.Services.ChatRoom;

namespace TodoServer.Graphs.ChatGraph
{
    public class Query {
        public static Message? LastMessage([FromServices] IChatService chatService)
    => chatService.LastMessage;

        public static IEnumerable<Message> AllMessages([FromServices] IChatService chatService, string? from = null)
            => from == null ? chatService.GetAllMessages() : chatService.GetMessageFromUser(from);

        public static int Count([FromServices] IChatService chatService)
            => chatService.Count;
    }
}
