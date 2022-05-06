namespace AltV.Net.Client.Events
{
    internal interface IEventHandler<TEvent>
    {
        void Add(TEvent value);

        void Remove(TEvent value);

        HashSet<TEvent> GetEvents();

        bool HasEvents();
    }
}