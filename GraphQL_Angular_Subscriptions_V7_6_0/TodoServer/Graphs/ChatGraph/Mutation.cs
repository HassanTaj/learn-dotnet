using GraphQL;
using TodoServer.Services.ChatRoom;

namespace TodoServer.Graphs.ChatGraph
{
    public class Mutation {
        public static Message AddMessage([FromServices] IChatService chatService, MessageInput message)
       => chatService.PostMessage(message);

        public static Message? DeleteMessage([FromServices] IChatService chatService, [Id] int id)
            => chatService.DeleteMessage(id);

        public static int ClearMessages([FromServices] IChatService chatService)
            => chatService.ClearMessages();
    }
}
