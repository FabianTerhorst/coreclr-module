using System.Collections.Generic;

namespace AltV.Net.Client.EventHandlers
{
    internal abstract class NativeEventHandler<T, T2>
    {
        protected readonly LinkedList<T2> EventHandlers = new LinkedList<T2>();

        public void Add(T2 eventHandler)
        {
            EventHandlers.AddLast(eventHandler);
        }

        public void Remove(T2 eventHandler)
        {
            EventHandlers.Remove(eventHandler);
        }

        public abstract T GetNativeEventHandler();
    }
}