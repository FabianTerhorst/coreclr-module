using System;

namespace AltV.Net
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ScriptEvent : Attribute
    {
        public ScriptEventType EventType { get; }

        public ScriptEvent(ScriptEventType eventType)
        {
            EventType = eventType;
        }
    }
}