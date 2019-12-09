using System;

namespace AltV.Net.Async
{
    [Obsolete("This attribute is obsolete. Use AsyncServerEventAttribute or AsyncClientEventAttribute instead.")]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AsyncEventAttribute : Attribute
    {
        public string Name { get; }

        public AsyncEventAttribute(string name = null)
        {
            Name = name;
        }
    }
}