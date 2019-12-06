using System;

namespace AltV.Net
{
    [Obsolete("This attribute is obsolete. Use ServerEventAttribute or ClientEventAttribute instead.")]
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