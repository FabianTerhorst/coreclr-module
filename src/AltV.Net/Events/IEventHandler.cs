using System.Collections.Generic;

namespace AltV.Net.Events
{
    internal interface IEventHandler<TEvent>
    {
        void Add(TEvent value);

        void Remove(TEvent value);

        HashSet<TEvent> GetEvents();

        bool HasEvents();
    }
}