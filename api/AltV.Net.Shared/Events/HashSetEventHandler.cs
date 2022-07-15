namespace AltV.Net.Shared.Events
{
    internal class HashSetEventHandler<TEvent> : IEventHandler<TEvent>
    {
        private ISharedCore core => AltShared.Core; // todo pass core to constructor
        private readonly EventType? type;
        private readonly HashSet<TEvent> events = new();

        public HashSetEventHandler(EventType type)
        {
            this.type = type;
        }

        public HashSetEventHandler()
        {
        }

        public void Add(TEvent value)
        {
            if (value == null) return;
            if (type != null) core.EventStateManager.AddHandler(type.Value);
            events.Add(value);
        }

        public void Remove(TEvent value)
        {
            if (value == null) return;
            if (type != null) core.EventStateManager.RemoveHandler(type.Value);
            events.Remove(value);
        }

        public HashSet<TEvent> GetEvents() => events;

        public bool HasEvents() => events.Count != 0;
    }
}