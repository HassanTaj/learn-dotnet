namespace TodoServer.Services.Events
{
    public interface IEventService<TModel>
    {
        int Count { get; }

        bool Init();
        IEnumerable<TModel> GetAll();
        TModel? LastItem { get; }
        TModel Create(TModel obj);
        IEnumerable<TModel> CreateRange(params TModel[] objs);
        TModel Update(int id, TModel obj);
        TModel Delete(int id);
        TModel Delete(Func<TModel, bool> predicate);
        IObservable<IEnumerable<TModel>> Subscribe(params EventTypes[] types);
        IObservable<Event<EventTypes, TModel>> SubscribeEvents();
        int ClearAll();
    }
}
