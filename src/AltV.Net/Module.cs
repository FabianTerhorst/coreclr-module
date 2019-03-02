using System;
using System.Collections.Generic;
using System.Reflection;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Events;
using AltV.Net.FunctionParser;
using AltV.Net.Native;

namespace AltV.Net
{
    public class Module
    {
        internal readonly IServer Server;
        
        internal readonly CSharpNativeResource CSharpNativeResource;

        internal readonly IBaseEntityPool BaseEntityPool;

        internal readonly IEntityPool<IPlayer> PlayerPool;

        internal readonly IEntityPool<IVehicle> VehiclePool;

        internal readonly IEntityPool<IBlip> BlipPool;

        internal readonly IEntityPool<ICheckpoint> CheckpointPool;

        //For custom defined args event handlers
        private readonly Dictionary<string, HashSet<Function>> eventHandlers =
            new Dictionary<string, HashSet<Function>>();

        private readonly Dictionary<string, HashSet<IParserClientEventHandler>> parserClientEventHandlers =
            new Dictionary<string, HashSet<IParserClientEventHandler>>();

        private readonly Dictionary<string, HashSet<IParserServerEventHandler>> parserServerEventHandlers =
            new Dictionary<string, HashSet<IParserServerEventHandler>>();

        //For object[] args event handlers
        private readonly Dictionary<string, HashSet<ServerEventDelegate>> eventDelegateHandlers =
            new Dictionary<string, HashSet<ServerEventDelegate>>();

        private readonly Dictionary<string, HashSet<ClientEventDelegate>> clientEventDelegateHandlers =
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

        internal readonly EventHandler<PlayerClientEventDelegate> PlayerClientEventEventHandler =
            new EventHandler<PlayerClientEventDelegate>();

        internal readonly EventHandler<PlayerClientCustomEventDelegate> PlayerClientCustomEventEventHandler =
            new EventHandler<PlayerClientCustomEventDelegate>();

        internal readonly EventHandler<ServerEventEventDelegate> ServerEventEventHandler =
            new EventHandler<ServerEventEventDelegate>();

        internal readonly EventHandler<ServerCustomEventEventDelegate> ServerCustomEventEventHandler =
            new EventHandler<ServerCustomEventEventDelegate>();

        public Module(IServer server, CSharpNativeResource cSharpNativeResource, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool)
        {
            Alt.Setup(this);
            Server = server;
            CSharpNativeResource = cSharpNativeResource;
            BaseEntityPool = baseEntityPool;
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
            BlipPool = blipPool;
            CheckpointPool = checkpointPool;
        }

        public void On(string eventName, Function function)
        {
            if (function == null) return;
            if (eventHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new HashSet<Function> {function};
                eventHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void OnServer(string eventName, ServerEventDelegate serverEventDelegate)
        {
            if (serverEventDelegate == null) return;
            if (eventDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(serverEventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<ServerEventDelegate> {serverEventDelegate};
                eventDelegateHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void OnClient(string eventName, ClientEventDelegate eventDelegate)
        {
            if (eventDelegate == null) return;
            if (clientEventDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(eventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<ClientEventDelegate> {eventDelegate};
                clientEventDelegateHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void On<TFunc>(string eventName, TFunc func, ClientEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (parserClientEventHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(new ParserClientEventHandler<TFunc>(func, parser));
            }
            else
            {
                eventHandlersForEvent = new HashSet<IParserClientEventHandler>
                    {new ParserClientEventHandler<TFunc>(func, parser)};
                parserClientEventHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void On<TFunc>(string eventName, TFunc func, ServerEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (parserServerEventHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(new ParserServerEventHandler<TFunc>(func, parser));
            }
            else
            {
                eventHandlersForEvent = new HashSet<IParserServerEventHandler>
                    {new ParserServerEventHandler<TFunc>(func, parser)};
                parserServerEventHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, EntityType entityType, bool state)
        {
            if (!CheckpointPool.GetOrCreate(checkpointPointer, out var checkpoint))
            {
                return;
            }

            if (!BaseEntityPool.GetOrCreate(entityPointer, entityType, out var entity))
            {
                return;
            }

            OnCheckPointEvent(checkpoint, entity, state);
        }

        public virtual void OnCheckPointEvent(ICheckpoint checkpoint, IEntity entity, bool state)
        {
            foreach (var @delegate in CheckpointEventHandler.GetSubscriptions())
            {
                @delegate(checkpoint, entity, state);
            }
        }

        public void OnPlayerConnect(IntPtr playerPointer, ushort playerId, string reason)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, playerId, out var player))
            {
                return;
            }

            OnPlayerConnectEvent(player, reason);
        }

        public virtual void OnPlayerConnectEvent(IPlayer player, string reason)
        {
            foreach (var @delegate in PlayerConnectEventHandler.GetSubscriptions())
            {
                @delegate(player, reason);
            }
        }

        public void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer, EntityType attackerEntityType,
            ushort attackerEntityId, uint weapon, byte damage)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            BaseEntityPool.GetOrCreate(attackerEntityPointer, attackerEntityType, attackerEntityId, out var attacker);

            OnPlayerDamageEvent(player, attacker, weapon, damage);
        }

        public virtual void OnPlayerDamageEvent(IPlayer player, IEntity attacker, uint weapon, byte damage)
        {
            foreach (var @delegate in PlayerDamageEventHandler.GetSubscriptions())
            {
                @delegate(player, attacker, weapon, damage);
            }
        }


        public void OnPlayerDead(IntPtr playerPointer, IntPtr killerEntityPointer, EntityType killerEntityType,
            uint weapon)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            BaseEntityPool.GetOrCreate(killerEntityPointer, killerEntityType, out var killer);

            OnPlayerDeadEvent(player, killer, weapon);
        }

        public virtual void OnPlayerDeadEvent(IPlayer player, IEntity killer, uint weapon)
        {
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

            OnVehicleChangeSeatEvent(vehicle, player, oldSeat, newSeat);
        }

        public virtual void OnVehicleChangeSeatEvent(IVehicle vehicle, IPlayer player, sbyte oldSeat, sbyte newSeat)
        {
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

            OnVehicleEnterEvent(vehicle, player, seat);
        }

        public virtual void OnVehicleEnterEvent(IVehicle vehicle, IPlayer player, sbyte seat)
        {
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

            OnVehicleLeaveEvent(vehicle, player, seat);
        }

        public virtual void OnVehicleLeaveEvent(IVehicle vehicle, IPlayer player, sbyte seat)
        {
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

            OnPlayerDisconnectEvent(player, reason);
        }

        public virtual void OnPlayerDisconnectEvent(IPlayer player, string reason)
        {
            foreach (var @delegate in PlayerDisconnectEventHandler.GetSubscriptions())
            {
                @delegate(player, reason);
            }
        }

        public void OnEntityRemove(IntPtr entityPointer, EntityType entityType)
        {
            if (!BaseEntityPool.GetOrCreate(entityPointer, entityType, out var entity))
            {
                return;
            }

            OnEntityRemoveEvent(entity);

            BaseEntityPool.Remove(entityPointer, entityType);
        }

        public virtual void OnEntityRemoveEvent(IEntity entity)
        {
            foreach (var @delegate in EntityRemoveEventHandler.GetSubscriptions())
            {
                @delegate(entity);
            }
        }

        public void OnClientEvent(IntPtr playerPointer, string name, ref MValueArray args)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            if (parserClientEventHandlers.Count != 0 &&
                parserClientEventHandlers.TryGetValue(name, out var parserEventHandlers))
            {
                foreach (var parserEventHandler in parserEventHandlers)
                {
                    parserEventHandler.Call(player, ref args);
                }
            }

            MValue[] argArray = null;
            if (this.eventHandlers.Count != 0 && this.eventHandlers.TryGetValue(name, out var eventHandlers))
            {
                argArray = args.ToArray();
                foreach (var eventHandler in eventHandlers)
                {
                    eventHandler.Call(player, BaseEntityPool, argArray);
                }
            }

            object[] argObjects = null;

            if (clientEventDelegateHandlers.Count != 0 &&
                clientEventDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                var length = argArray.Length;
                argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = argArray[i].ToObject(BaseEntityPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(player, argObjects);
                }
            }

            if (PlayerClientEventEventHandler.HasSubscriptions())
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                if (argObjects == null)
                {
                    var length = argArray.Length;
                    argObjects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        argObjects[i] = argArray[i].ToObject(BaseEntityPool);
                    }
                }

                foreach (var eventHandler in PlayerClientEventEventHandler.GetSubscriptions())
                {
                    eventHandler(player, name, argObjects);
                }
            }

            if (PlayerClientCustomEventEventHandler.HasSubscriptions())
            {
                foreach (var eventHandler in PlayerClientCustomEventEventHandler.GetSubscriptions())
                {
                    eventHandler(player, name, ref args);
                }
            }

            OnClientEventEvent(player, name, ref args, argArray, argObjects);
        }

        public virtual void OnClientEventEvent(IPlayer player, string name, ref MValueArray args, MValue[] mValues,
            object[] objects)
        {
        }

        public void OnServerEvent(string name, ref MValueArray args)
        {
            if (parserServerEventHandlers.Count != 0 &&
                parserServerEventHandlers.TryGetValue(name, out var parserEventHandlers))
            {
                foreach (var parserEventHandler in parserEventHandlers)
                {
                    parserEventHandler.Call(ref args);
                }
            }

            MValue[] argArray = null;
            if (this.eventHandlers.Count != 0 && this.eventHandlers.TryGetValue(name, out var eventHandlers))
            {
                argArray = args.ToArray();
                foreach (var eventHandler in eventHandlers)
                {
                    try
                    {
                        eventHandler.Call(BaseEntityPool, argArray);
                    }
                    catch (TargetInvocationException exception)
                    {
                        Alt.Log("exception at event:" + name + ":" + exception.InnerException);
                    }
                    catch (Exception exception)
                    {
                        Alt.Log("exception at event:" + name + ":" + exception);
                    }
                }
            }

            object[] argObjects = null;

            if (eventDelegateHandlers.Count != 0 && eventDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                var length = argArray.Length;
                argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = argArray[i].ToObject(BaseEntityPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(argObjects);
                }
            }

            if (ServerEventEventHandler.HasSubscriptions())
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                if (argObjects == null)
                {
                    var length = argArray.Length;
                    argObjects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        argObjects[i] = argArray[i].ToObject(BaseEntityPool);
                    }
                }

                foreach (var eventHandler in ServerEventEventHandler.GetSubscriptions())
                {
                    eventHandler(name, argObjects);
                }
            }

            if (ServerCustomEventEventHandler.HasSubscriptions())
            {
                foreach (var eventHandler in ServerCustomEventEventHandler.GetSubscriptions())
                {
                    eventHandler(name, ref args);
                }
            }

            OnServerEventEvent(name, ref args, argArray, argObjects);
        }

        public virtual void OnServerEventEvent(string name, ref MValueArray args, MValue[] mValues, object[] objects)
        {
        }
    }
}