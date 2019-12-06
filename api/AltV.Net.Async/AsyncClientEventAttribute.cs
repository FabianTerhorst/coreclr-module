using System;

namespace AltV.Net.Async
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AsyncClientEventAttribute : Attribute
    {
        public string Name { get; }

        public AsyncClientEventAttribute(string name = null)
        {
            Name = name;
        }
    }
}