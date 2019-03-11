using System.Collections.Generic;

namespace AltV.Net
{
    internal class EventHandler<TEvent>
    {
        private readonly HashSet<TEvent> events = new HashSet<TEvent>();

        public void Add(TEvent value)
        {
            if (value == null) return;
            events.Add(value);
        }

        public void Remove(TEvent value)
        {
            if (value == null) return;
            events.Remove(value);
        }

        public HashSet<TEvent> GetSubscriptions() => events;

        public bool HasSubscriptions() => events.Count != 0;
    }
}