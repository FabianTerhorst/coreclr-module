using System.Collections.Generic;

namespace AltV.Net.Events
{
    internal class HashSetEventHandler<TEvent>
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

        public HashSet<TEvent> GetEvents() => events;

        public bool HasEvents() => events.Count != 0;
    }
}