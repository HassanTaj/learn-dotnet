namespace TodoServer.Graphs.ChatGraph
{
    public class Event {
        public EventType Type { get; set; }
        public Message? Message { get; set; }
    }
}
                              