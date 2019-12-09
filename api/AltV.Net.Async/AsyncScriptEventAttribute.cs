using System;

namespace AltV.Net.Async
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AsyncScriptEventAttribute : Attribute
    {
        public ScriptEventType EventType { get; }

        public AsyncScriptEventAttribute(ScriptEventType eventType)
        {
            EventType = eventType;
        }
    }
}