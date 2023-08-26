using GraphQL;
using TodoServer.Models;
using TodoServer.Services.Events;

namespace TodoServer.Graphs.TodoGraph
{
    public class Subscription {

        public static IObservable<IEnumerable<Todo>> Todos([FromServices] IEventService<Todo> eventService) {
            return eventService.SubscribeList(EventTypes.Read,EventTypes.Create,EventTypes.Update,EventTypes.Delete);
        }

        public static IObservable<IEnumerable<Todo>> GetAll([FromServices] IEventService<Todo> eventService)
        => eventService.SubscribeAll();

        public static IObservable<Event<EventTypes,Todo>> Events([FromServices] IEventService<Todo> eventService)
           => eventService.SubscribeEvents();
    }
}
