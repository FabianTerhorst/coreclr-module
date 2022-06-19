namespace AltV.Net.Shared.Events
{
    public class EventStateManager
    {
        private readonly ISharedCore core;
        public readonly Dictionary<EventType, int> HandlerCount = new();

        public EventStateManager(ISharedCore core)
        {
            this.core = core;
            
            foreach (var internalEvent in InternalEvents)
            {
                unsafe
                {
                    core.Library.Shared.Core_ToggleEvent(core.NativePointer, (byte) internalEvent, 1);
                }
            }
        }

        private static readonly EventType[] InternalEvents =
        {
            EventType.REMOVE_ENTITY_EVENT
        };

        private static bool IsEventIgnored(EventType type) => InternalEvents.Contains(type);

        public void AddHandler(EventType type)
        {
            if (IsEventIgnored(type)) return;
            
            lock (HandlerCount)
            {
                if (!HandlerCount.ContainsKey(type)) HandlerCount[type] = 1;
                else HandlerCount[type]++;

                if (HandlerCount[type] == 1)
                {
                    unsafe
                    {
                        core.Library.Shared.Core_ToggleEvent(core.NativePointer, (byte) type, 1);
                    }
                }
            }
        }
        
        public void RemoveHandler(EventType type)
        {
            if (IsEventIgnored(type)) return;

            lock (HandlerCount)
            {
                if (!HandlerCount.ContainsKey(type)) return;
                HandlerCount[type]--;

                if (HandlerCount[type] == 0)
                {
                    unsafe
                    {
                        core.Library.Shared.Core_ToggleEvent(core.NativePointer, (byte) type, 0);
                    }
                }
            }
        }
    }
}