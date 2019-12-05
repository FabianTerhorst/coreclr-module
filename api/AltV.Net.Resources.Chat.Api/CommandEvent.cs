using System;

namespace AltV.Net.Resources.Chat.Api
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandEvent : Attribute
    {
        public CommandEventType EventType { get; }

        public CommandEvent(CommandEventType eventType)
        {
            EventType = eventType;
        }
    }
}