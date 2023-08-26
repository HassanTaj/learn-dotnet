using System.Reactive.Linq;
using System.Reactive.Subjects;
using TodoServer.Models;

namespace TodoServer.Services.Events {
    public class EventService<TModel> : IEventService<TModel>
        where TModel : IdentityModel, new() {
        private readonly List<TModel> _items = new();
        private readonly Subject<Event<EventTypes, TModel>> _broadcaster = new();
        public TModel? LastItem { get; private set; }

        public IEnumerable<TModel> GetAll() {
            lock (_items) {
                _broadcaster.OnNext(new Event<EventTypes, TModel> { Type = EventTypes.Read, Items = _items.ToList() });
                return _items.ToList();
            }
        }

        public List<TModel> Items {
            get {
                lock (_items) return _items.ToList();
            }
        }

        public virtual TModel Create(TModel obj) {
            LastItem = obj;
            lock (_items) {
                _items.Add(obj);
            }

            _broadcaster.OnNext(new Event<EventTypes, TModel> { Type = EventTypes.Create, Items = _items });
            return obj;
        }

        public virtual IEnumerable<TModel> CreateRange(params TModel[] objs) {
            LastItem = objs.LastOrDefault();
            lock (_items)
                _items.AddRange(objs);

            if (objs.Length > 0) {
                foreach (var item in objs)
                    _broadcaster.OnNext(new Event<EventTypes, TModel> { Type = EventTypes.Create, Items = _items });
            }
            return objs;
        }

        public virtual TModel Update(int id, TModel obj) {
            lock (_items) {
                int updateIndex = _items.FindIndex(x => x.Id == id);
                _items[updateIndex] = obj;
            }
            _broadcaster.OnNext(new Event<EventTypes, TModel> { Type = EventTypes.Update, Items = _items });
            return obj;
        }

        public virtual TModel Delete(int id) {
            return Delete(x => x.Id == id);
        }

        public TModel Delete(Func<TModel, bool> predicate) {
            TModel deletedMessage = default;
            lock (_items) {
                deletedMessage = _items.FirstOrDefault(predicate);
                if (deletedMessage != null) {
                    _items.Remove(deletedMessage);
                }
            }
            _broadcaster.OnNext(new Event<EventTypes, TModel> { Type = EventTypes.Delete, Items = _items });
            return deletedMessage;
        }

        public int ClearAll() {
            int count;
            lock (_items) {
                count = _items.Count;
                _items.Clear();
            }
            _broadcaster.OnNext(new Event<EventTypes, TModel> { Type = EventTypes.RemoveAll, Items = _items });
            return count;
        }
        public IObservable<IEnumerable<TModel>> SubscribeAll() {
            return _broadcaster.Select(x => x.Items!);
        }

        public IObservable<IEnumerable<TModel>> Subscribe(params EventTypes[] types) {
            return _broadcaster.Where(x => types.Contains(x.Type)).Select(x => x.Items!);
        }

        public IObservable<Event<EventTypes, TModel>> SubscribeEvents() => _broadcaster;

        public virtual bool Init() {
            return true;
        }


        public int Count {
            get {
                lock (_items)
                    return _items.Count;
            }
        }
    }

    public class Event<TEventType, TPayLoad> {
        public TEventType Type { get; set; }
        public IEnumerable<TPayLoad> Items { get; set; } = new List<TPayLoad> { };

    }

    public enum EventTypes {
        Create,
        Read,
        Update,
        Delete,
        RemoveAll
    }
}
