using System;

namespace AltV.Net
{
    public class Event : Attribute
    {
        public string Name { get; }

        public Event(string name = null)
        {
            Name = name;
        }
    }
}