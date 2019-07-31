using System;

namespace AltV.Net
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Event : Attribute
    {
        public string Name { get; }

        public Event(string name = null)
        {
            Name = name;
        }
    }
}