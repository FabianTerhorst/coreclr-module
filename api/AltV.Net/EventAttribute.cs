using System;

namespace AltV.Net
{
    [Obsolete]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class EventAttribute : Attribute
    {
        public string Name { get; }

        public EventAttribute(string name = null)
        {
            Name = name;
        }
    }
}