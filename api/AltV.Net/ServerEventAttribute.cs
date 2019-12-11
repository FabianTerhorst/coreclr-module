using System;

namespace AltV.Net
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ServerEventAttribute : Attribute
    {
        public string Name { get; }

        public ServerEventAttribute(string name = null)
        {
            Name = name;
        }
    }
}