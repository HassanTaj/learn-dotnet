using GraphQL;
using TodoServer.Models;
using TodoServer.Services.Chat;

namespace TodoServer.Graphs.ChatGraph
{
    public class Subscription {
        public static IObservable<Message> NewMessages([FromServices] IChatService chatService, string? from = null)
    => from == null ? chatService.SubscribeAll() : chatService.SubscribeFromUser(from);

        public static IObservable<Event> Events([FromServices] IChatService chatService)
            => chatService.SubscribeEvents();
    }
}
