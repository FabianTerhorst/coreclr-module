using System;

namespace AltV.Net
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ClientEventAttribute : Attribute
    {
        public string Name { get; }

        public ClientEventAttribute(string name = null)
        {
            Name = name;
        }
    }
}