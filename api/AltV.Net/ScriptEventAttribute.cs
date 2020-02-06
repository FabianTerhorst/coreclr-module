using System;

namespace AltV.Net
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ScriptEventAttribute : Attribute
    {
        public ScriptEventType EventType { get; }

        public ScriptEventAttribute(ScriptEventType eventType)
        {
            EventType = eventType;
        }
    }
}