using TodoServer.Graphs.ChatGraph;

namespace TodoServer.Services.Chat {
    public interface IChatService
    {
        int Count { get; }
        Message? LastMessage { get; }

        int ClearMessages();
        Message? DeleteMessage(int id);
        IEnumerable<Message> GetAllMessages();
        IEnumerable<Message> GetMessageFromUser(string from);
        Message PostMessage(MessageInput message);
        IObservable<Message> SubscribeAll();
        IObservable<Event> SubscribeEvents();
        IObservable<Message> SubscribeFromUser(string from);
    }
}
