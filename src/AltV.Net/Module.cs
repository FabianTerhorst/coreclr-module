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

        internal readonly IBaseBaseObjectPool BaseBaseObjectPool;
        
        internal readonly IBaseEntityPool BaseEntityPool;

        internal readonly IEntityPool<IPlayer> PlayerPool;

        internal readonly IEntityPool<IVehicle> VehiclePool;

        internal readonly IBaseObjectPool<IBlip> BlipPool;

        internal readonly IBaseObjectPool<ICheckpoint> CheckpointPool;

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

        internal readonly EventHandler<PlayerChangeVehicleSeatDelegate> PlayerChangeVehicleSeatEventHandler =
            new EventHandler<PlayerChangeVehicleSeatDelegate>();

        internal readonly EventHandler<PlayerEnterVehicleDelegate> PlayerEnterVehicleEventHandler =
            new EventHandler<PlayerEnterVehicleDelegate>();

        internal readonly EventHandler<PlayerLeaveVehicleDelegate> PlayerLeaveVehicleEventHandler =
            new EventHandler<PlayerLeaveVehicleDelegate>();

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

        public Module(IServer server, CSharpNativeResource cSharpNativeResource, IBaseBaseObjectPool baseBaseObjectPool, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool)
        {
            Alt.Setup(this);
            Server = server;
            CSharpNativeResource = cSharpNativeResource;
            BaseBaseObjectPool = baseBaseObjectPool;
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

        public void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, BaseObjectType baseObjectType, bool state)
        {
            if (!CheckpointPool.GetOrCreate(checkpointPointer, out var checkpoint))
            {
                return;
            }

            if (!BaseEntityPool.GetOrCreate(entityPointer, baseObjectType, out var entity))
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

        public void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer, BaseObjectType attackerBaseObjectType,
            ushort attackerEntityId, uint weapon, ushort damage)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            BaseEntityPool.GetOrCreate(attackerEntityPointer, attackerBaseObjectType, attackerEntityId, out var attacker);

            OnPlayerDamageEvent(player, attacker, weapon, damage);
        }

        public virtual void OnPlayerDamageEvent(IPlayer player, IEntity attacker, uint weapon, ushort damage)
        {
            foreach (var @delegate in PlayerDamageEventHandler.GetSubscriptions())
            {
                @delegate(player, attacker, weapon, damage);
            }
        }


        public void OnPlayerDeath(IntPtr playerPointer, IntPtr killerEntityPointer, BaseObjectType killerBaseObjectType,
            uint weapon)
        {
            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            BaseEntityPool.GetOrCreate(killerEntityPointer, killerBaseObjectType, out var killer);

            OnPlayerDeathEvent(player, killer, weapon);
        }

        public virtual void OnPlayerDeathEvent(IPlayer player, IEntity killer, uint weapon)
        {
            foreach (var @delegate in PlayerDeadEventHandler.GetSubscriptions())
            {
                @delegate(player, killer, weapon);
            }
        }

        public void OnPlayerChangeVehicleSeat(IntPtr vehiclePointer, IntPtr playerPointer, byte oldSeat,
            byte newSeat)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            OnPlayerChangeVehicleSeatEvent(vehicle, player, oldSeat, newSeat);
        }

        public virtual void OnPlayerChangeVehicleSeatEvent(IVehicle vehicle, IPlayer player, byte oldSeat, byte newSeat)
        {
            foreach (var @delegate in PlayerChangeVehicleSeatEventHandler.GetSubscriptions())
            {
                @delegate(vehicle, player, oldSeat, newSeat);
            }
        }

        public void OnPlayerEnterVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            OnPlayerEnterVehicleEvent(vehicle, player, seat);
        }

        public virtual void OnPlayerEnterVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            foreach (var @delegate in PlayerEnterVehicleEventHandler.GetSubscriptions())
            {
                @delegate(vehicle, player, seat);
            }
        }

        public void OnPlayerLeaveVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            if (!VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            OnPlayerLeaveVehicleEvent(vehicle, player, seat);
        }

        public virtual void OnPlayerLeaveVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            foreach (var @delegate in PlayerLeaveVehicleEventHandler.GetSubscriptions())
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

        public void OnEntityRemove(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            if (!BaseBaseObjectPool.GetOrCreate(entityPointer, baseObjectType, out var entity))
            {
                return;
            }

            OnEntityRemoveEvent(entity);

            BaseBaseObjectPool.Remove(entityPointer, baseObjectType);
        }

        public virtual void OnEntityRemoveEvent(IBaseObject entity)
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
                    eventHandler.Call(player, BaseBaseObjectPool, argArray);
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
                    argObjects[i] = argArray[i].ToObject(BaseBaseObjectPool);
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
                        argObjects[i] = argArray[i].ToObject(BaseBaseObjectPool);
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
                        eventHandler.Call(BaseBaseObjectPool, argArray);
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
                    argObjects[i] = argArray[i].ToObject(BaseBaseObjectPool);
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
                        argObjects[i] = argArray[i].ToObject(BaseBaseObjectPool);
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