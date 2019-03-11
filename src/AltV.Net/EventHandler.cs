using System.Collections.Generic;

namespace AltV.Net
{
    internal class EventHandler<TEvent>
    {
        private readonly HashSet<TEvent> events = new HashSet<TEvent>();

        public void Add(TEvent callback)
        {
            if (callback == null) return;
            events.Add(callback);
        }

        public void Remove(TEvent callback)
        {
            if (callback == null) return;
            events.Remove(callback);
        }

        public HashSet<TEvent> GetSubscriptions() => events;

        public bool HasSubscriptions() => events.Count != 0;
    }
}