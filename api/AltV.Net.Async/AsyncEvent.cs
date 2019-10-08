using System;

namespace AltV.Net.Async
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AsyncEvent : Attribute
    {
        public string Name { get; }

        public AsyncEvent(string name = null)
        {
            Name = name;
        }
    }
}