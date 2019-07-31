using System;

namespace AltV.Net.Async
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AsyncEvent : Event
    {
        public AsyncEvent(string name = null) : base(name)
        {
        }
    }
}