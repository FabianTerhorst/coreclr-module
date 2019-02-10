using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;
using AltV.Net.Native;

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

        public void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, bool state)
        {
            if (!CheckpointPool.GetOrCreate(checkpointPointer, out var checkpointEntity) ||
                !(checkpointEntity is ICheckpoint checkpoint))
            {
                return;
            }

            if (!BaseEntityPool.GetOrCreate(entityPointer, out var entity))
            {
                return;
            }

            foreach (var @delegate in CheckpointEventHandler.GetSubscriptions())
            {
                @delegate(checkpoint, entity, state);
            }
        }

        public void OnPlayerConnect(IntPtr playerPointer, string reason)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var entity) || !(entity is IPlayer player))
            {
                return;
            }

            foreach (var @delegate in PlayerConnectEventHandler.GetSubscriptions())
            {
                @delegate(player, reason);
            }
        }

        public void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer, uint weapon, byte damage)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var entity) || !(entity is IPlayer player))
            {
                return;
            }

            if (!BaseEntityPool.GetOrCreate(attackerEntityPointer, out var attacker))
            {
                return;
            }

            foreach (var @delegate in PlayerDamageEventHandler.GetSubscriptions())
            {
                @delegate(player, attacker, weapon, damage);
            }
        }


        public void OnPlayerDead(IntPtr playerPointer, IntPtr killerEntityPointer, uint weapon)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var entity) || !(entity is IPlayer player))
            {
                return;
            }

            if (!BaseEntityPool.GetOrCreate(killerEntityPointer, out var killer))
            {
                return;
            }

            foreach (var @delegate in PlayerDeadEventHandler.GetSubscriptions())
            {
                @delegate(player, killer, weapon);
            }
        }

        public void OnVehicleChangeSeat(IntPtr vehiclePointer, IntPtr playerPointer, sbyte oldSeat,
            sbyte newSeat)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            foreach (var @delegate in VehicleChangeSeatEventHandler.GetSubscriptions())
            {
                @delegate(vehicle, player, oldSeat, newSeat);
            }
        }

        public void OnVehicleEnter(IntPtr vehiclePointer, IntPtr playerPointer, sbyte seat)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            foreach (var @delegate in VehicleEnterEventHandler.GetSubscriptions())
            {
                @delegate(vehicle, player, seat);
            }
        }

        public void OnVehicleLeave(IntPtr vehiclePointer, IntPtr playerPointer, sbyte seat)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            foreach (var @delegate in VehicleLeaveEventHandler.GetSubscriptions())
            {
                @delegate(vehicle, player, seat);
            }
        }

        public void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            foreach (var @delegate in PlayerDisconnectEventHandler.GetSubscriptions())
            {
                @delegate(player, reason);
            }
        }

        public void OnEntityRemove(IntPtr entityPointer)
        {
            if (!BaseEntityPool.GetOrCreate(entityPointer, out var entity))
            {
                return;
            }

            foreach (var @delegate in EntityRemoveEventHandler.GetSubscriptions())
            {
                @delegate(entity);
            }

            BaseEntityPool.Remove(entityPointer);
        }

        public void OnClientEvent(IntPtr playerPointer, string name, ref MValueArray args)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            MValue[] argArray = null;
            if (EventHandlers.TryGetValue(name, out var eventHandlers))
            {
                argArray = args.ToArray();
                foreach (var eventHandler in eventHandlers)
                {
                    eventHandler.Call(player, BaseEntityPool, argArray);
                }
            }

            if (ClientEventDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                var length = argArray.Length;
                var argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = argArray[i].ToObject(BaseEntityPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(player, argObjects);
                }
            }
        }

        public void OnServerEvent(string name, ref MValueArray args)
        {
            MValue[] argArray = null;
            if (EventHandlers.TryGetValue(name, out var eventHandlers))
            {
                argArray = args.ToArray();
                foreach (var eventHandler in eventHandlers)
                {
                    eventHandler.Call(BaseEntityPool, argArray);
                }
            }

            if (EventDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                var length = argArray.Length;
                var argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = argArray[i].ToObject(BaseEntityPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(argObjects);
                }
            }
        }

        //TODO: currently only for testing
        public void OnServerEvent(string name, MValue[] args)
        {
            if (EventHandlers.TryGetValue(name, out var eventHandlers))
            {
                foreach (var eventHandler in eventHandlers)
                {
                    eventHandler.Call(BaseEntityPool, args);
                }
            }

            if (EventDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                var length = args.Length;
                var argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = args[i].ToObject(BaseEntityPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(argObjects);
                }
            }
        }
    }
}