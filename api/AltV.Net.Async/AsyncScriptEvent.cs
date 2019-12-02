using System;

namespace AltV.Net.Async
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AsyncScriptEvent : Attribute
    {
        public ScriptEventType EventType { get; }

        public AsyncScriptEvent(ScriptEventType eventType)
        {
            EventType = eventType;
        }
    }
}