using System;

namespace AltV.Net.Async
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AsyncServerEventAttribute : Attribute
    {
        public string Name { get; }

        public AsyncServerEventAttribute(string name = null)
        {
            Name = name;
        }
    }
}