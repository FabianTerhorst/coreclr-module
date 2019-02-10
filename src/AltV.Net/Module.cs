using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;

namespace AltV.Net
{
    public class Module
    {
        internal readonly IServer Server;

        internal readonly IBaseEntityPool BaseEntityPool;
        
        internal readonly IEntityPool<IPlayer> PlayerPool;

        internal readonly IEntityPool<IVehicle> VehiclePool;

        internal readonly IEntityPool<IBlip> BlipPool;

        internal readonly IEntityPool<ICheckpoint> CheckpointPool;

        //For custom defined args event handlers
        internal readonly Dictionary<string, HashSet<Function>> EventHandlers =
            new Dictionary<string, HashSet<Function>>();

        //For object[] args event handlers
        internal readonly Dictionary<string, HashSet<EventDelegate>> EventDelegateHandlers =
            new Dictionary<string, HashSet<EventDelegate>>();
        
        internal readonly Dictionary<string, HashSet<ClientEventDelegate>> ClientEventDelegateHandlers =
            new Dictionary<string, HashSet<ClientEventDelegate>>();
        
        internal readonly EventHandler<CheckpointDelegate> CheckpointEventHandler =
            new EventHandler<CheckpointDelegate>();

        internal readonly EventHandler<PlayerConnectDelegate> PlayerConnectEventHandler =
            new EventHandler<PlayerConnectDelegate>();
        
        internal readonly EventHandler<PlayerDamageDelegate> PlayerDamageEventHandler =
            new EventHandler<PlayerDamageDelegate>();
        
        internal readonly EventHandler<PlayerDeadDelegate> PlayerDeadEventHandler =
            new EventHandler<PlayerDeadDelegate>();
        
        internal readonly EventHandler<VehicleChangeSeatDelegate> VehicleChangeSeatEventHandler =
            new EventHandler<VehicleChangeSeatDelegate>();
        
        internal readonly EventHandler<VehicleEnterDelegate> VehicleEnterEventHandler =
            new EventHandler<VehicleEnterDelegate>();
        
        internal readonly EventHandler<VehicleLeaveDelegate> VehicleLeaveEventHandler =
            new EventHandler<VehicleLeaveDelegate>();

        internal readonly EventHandler<PlayerDisconnectDelegate> PlayerDisconnectEventHandler =
            new EventHandler<PlayerDisconnectDelegate>();

        internal readonly EventHandler<EntityRemoveDelegate> EntityRemoveEventHandler =
            new EventHandler<EntityRemoveDelegate>();

        public Module(IServer server, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool)
        {
            Alt.Setup(this);
            Server = server;
            BaseEntityPool = baseEntityPool;
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
            BlipPool = blipPool;
            CheckpointPool = checkpointPool;
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
        
        public void On(string eventName, ClientEventDelegate eventDelegate)
        {
            if (eventDelegate == null) return;
            if (ClientEventDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(eventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<ClientEventDelegate> {eventDelegate};
                ClientEventDelegateHandlers[eventName] = eventHandlersForEvent;
            }
        }
    }
}