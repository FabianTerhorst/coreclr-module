using System;
using System.Collections.Generic;
using AltV.Net.Events;

namespace AltV.Net
{
    public class Module
    {
        internal readonly IEntityPool EntityPool;

        internal readonly Server Server;

        internal readonly ResourceLoader ResourceLoader;

        //For custom defined args event handlers
        internal readonly Dictionary<string, HashSet<Function>> EventHandlers =
            new Dictionary<string, HashSet<Function>>();

        //For object[] args event handlers
        internal readonly Dictionary<string, HashSet<EventDelegate>> EventDelegateHandlers =
            new Dictionary<string, HashSet<EventDelegate>>();

        internal readonly EventHandler<PlayerConnectDelegate> PlayerConnectEventHandler =
            new EventHandler<PlayerConnectDelegate>();

        internal readonly EventHandler<PlayerDisconnectDelegate> PlayerDisconnectEventHandler =
            new EventHandler<PlayerDisconnectDelegate>();

        internal readonly EventHandler<EntityRemoveDelegate> EntityRemoveEventHandler =
            new EventHandler<EntityRemoveDelegate>();

        public Module(IntPtr serverPointer)
        {
            Alt.Setup(this);
            EntityPool = new EntityPool();
            Server = new Server(serverPointer, EntityPool);
            ResourceLoader = new ResourceLoader();
        }

        public void On(string eventName, Function function)
        {
            if (function == null) return;
            if (EventHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new HashSet<Function> {function};
                EventHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void On(string eventName, EventDelegate eventDelegate)
        {
            if (eventDelegate == null) return;
            if (EventDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(eventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<EventDelegate> {eventDelegate};
                EventDelegateHandlers[eventName] = eventHandlersForEvent;
            }
        }
    }
}