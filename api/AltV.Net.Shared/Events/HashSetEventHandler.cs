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
            var first = events.Count == 0;
            events.Add(value);
            
            if (first && type != null)
            {
                unsafe
                {
                    core.Library.Shared.Core_ToggleEvent(core.NativePointer, (byte) type, 1);
                }
            }
        }

        public void Remove(TEvent value)
        {
            if (value == null) return;
            events.Remove(value);
            
            if (events.Count == 0 && type != null)
            {
                unsafe
                {
                    core.Library.Shared.Core_ToggleEvent(core.NativePointer, (byte) type, 0);
                }
            }
        }

        public HashSet<TEvent> GetEvents() => events;

        public bool HasEvents() => events.Count != 0;
    }
}