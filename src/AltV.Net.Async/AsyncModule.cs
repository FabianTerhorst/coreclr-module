using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Async.Events;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public class AsyncModule : Module
    {
        internal readonly Dictionary<string, HashSet<Function>> AsyncEventHandlers =
            new Dictionary<string, HashSet<Function>>();

        internal readonly AsyncEventHandler<CheckpointAsyncDelegate> CheckpointAsyncEventHandler =
            new AsyncEventHandler<CheckpointAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerConnectAsyncDelegate> PlayerConnectAsyncEventHandler =
            new AsyncEventHandler<PlayerConnectAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerDamageAsyncDelegate> PlayerDamageAsyncEventHandler =
            new AsyncEventHandler<PlayerDamageAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerDeadAsyncDelegate> PlayerDeadAsyncEventHandler =
            new AsyncEventHandler<PlayerDeadAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerChangeVehicleSeatAsyncDelegate> PlayerChangeVehicleSeatAsyncEventHandler =
            new AsyncEventHandler<PlayerChangeVehicleSeatAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerEnterVehicleAsyncDelegate> PlayerEnterVehicleAsyncEventHandler =
            new AsyncEventHandler<PlayerEnterVehicleAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerLeaveVehicleAsyncDelegate> PlayerLeaveVehicleAsyncEventHandler =
            new AsyncEventHandler<PlayerLeaveVehicleAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerDisconnectAsyncDelegate> PlayerDisconnectAsyncEventHandler =
            new AsyncEventHandler<PlayerDisconnectAsyncDelegate>();

        internal readonly AsyncEventHandler<EntityRemoveAsyncDelegate> EntityRemoveAsyncEventHandler =
            new AsyncEventHandler<EntityRemoveAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerClientEventAsyncDelegate> PlayerClientEventAsyncEventHandler =
            new AsyncEventHandler<PlayerClientEventAsyncDelegate>();

        private readonly Dictionary<string, HashSet<ClientEventAsyncDelegate>> clientEventAsyncDelegateHandlers
            =
            new Dictionary<string, HashSet<ClientEventAsyncDelegate>>();

        private readonly Dictionary<string, HashSet<ServerEventAsyncDelegate>> serverEventAsyncDelegateHandlers
            =
            new Dictionary<string, HashSet<ServerEventAsyncDelegate>>();

        public AsyncModule(IServer server, CSharpNativeResource cSharpNativeResource, IBaseBaseObjectPool baseBaseObjectPool, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool) : base(server, cSharpNativeResource, baseBaseObjectPool, baseEntityPool, playerPool, vehiclePool, blipPool,
            checkpointPool)
        {
            AltAsync.Setup(this);
        }

        public override void OnCheckPointEvent(ICheckpoint checkpoint, IEntity entity, bool state)
        {
            base.OnCheckPointEvent(checkpoint, entity, state);
            Task.Run(() => CheckpointAsyncEventHandler.CallAsync(@delegate => @delegate(checkpoint, entity, state)));
        }

        public override void OnPlayerConnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerConnectEvent(player, reason);
            Task.Run(() => PlayerConnectAsyncEventHandler.CallAsync(@delegate => @delegate(player, reason)));
        }

        public override void OnPlayerDamageEvent(IPlayer player, IEntity attacker, uint weapon, ushort damage)
        {
            base.OnPlayerDamageEvent(player, attacker, weapon, damage);
            Task.Run(() =>
                PlayerDamageAsyncEventHandler.CallAsync(@delegate => @delegate(player, attacker, weapon, damage)));
        }

        public override void OnPlayerDeathEvent(IPlayer player, IEntity killer, uint weapon)
        {
            base.OnPlayerDeathEvent(player, killer, weapon);
            Task.Run(() =>
                PlayerDeadAsyncEventHandler.CallAsync(@delegate => @delegate(player, killer, weapon)));
        }

        public override void OnPlayerChangeVehicleSeatEvent(IVehicle vehicle, IPlayer player, byte oldSeat, byte newSeat)
        {
            base.OnPlayerChangeVehicleSeatEvent(vehicle, player, oldSeat, newSeat);
            Task.Run(() =>
                PlayerChangeVehicleSeatAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, oldSeat, newSeat)));
        }

        public override void OnPlayerEnterVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerEnterVehicleEvent(vehicle, player, seat);
            Task.Run(() =>
                PlayerEnterVehicleAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat)));
        }

        public override void OnPlayerLeaveVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerLeaveVehicleEvent(vehicle, player, seat);
            Task.Run(() =>
                PlayerLeaveVehicleAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat)));
        }

        public override void OnPlayerDisconnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerDisconnectEvent(player, reason);
            Task.Run(() =>
                PlayerDisconnectAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, reason)));
        }

        public override void OnEntityRemoveEvent(IBaseObject entity)
        {
            base.OnEntityRemoveEvent(entity);
            Task.Run(() =>
                EntityRemoveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(entity)));
        }

        public override void OnClientEventEvent(IPlayer player, string name, ref MValueArray args, MValue[] mValues,
            object[] objects)
        {
            base.OnClientEventEvent(player, name, ref args, mValues, objects);

            if (AsyncEventHandlers.Count != 0 && AsyncEventHandlers.TryGetValue(name, out var eventHandlers))
            {
                if (mValues == null)
                {
                    mValues = args.ToArray();
                }

                if (objects == null)
                {
                    var length = mValues.Length;
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject(BaseBaseObjectPool);
                    }
                }

                Task.Run(() =>
                {
                    foreach (var eventHandler in eventHandlers)
                    {
                        var invokeValues = eventHandler.CalculateInvokeValues(objects);
                        if (invokeValues != null)
                        {
                            eventHandler.InvokeNoResult(invokeValues);
                        }
                        else
                        {
                            AltAsync.Log("Wrong function params for " + name);
                        }
                    }
                });
            }

            if (clientEventAsyncDelegateHandlers.Count != 0 &&
                clientEventAsyncDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (mValues == null)
                {
                    mValues = args.ToArray();
                }

                if (objects == null)
                {
                    var length = mValues.Length;
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject(BaseBaseObjectPool);
                    }
                }

                Task.Run(() =>
                {
                    foreach (var eventHandler in eventDelegates)
                    {
                        AsyncEventHandler<ClientEventAsyncDelegate>.ExecuteSubscriptionAsync(eventHandler,
                            @delegate => @delegate(player, objects));
                    }
                });
            }

            if (PlayerClientEventAsyncEventHandler.HasSubscriptions())
            {
                if (mValues == null)
                {
                    mValues = args.ToArray();
                }

                if (objects == null)
                {
                    var length = mValues.Length;
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject(BaseBaseObjectPool);
                    }
                }

                Task.Run(() =>
                {
                    foreach (var eventHandler in PlayerClientEventAsyncEventHandler.GetSubscriptions())
                    {
                        AsyncEventHandler<PlayerClientEventAsyncDelegate>.ExecuteSubscriptionAsync(eventHandler,
                            @delegate => @delegate(player, name, objects));
                    }
                });
            }
        }

        public override void OnServerEventEvent(string name, ref MValueArray args, MValue[] mValues, object[] objects)
        {
            base.OnServerEventEvent(name, ref args, mValues, objects);

            if (AsyncEventHandlers.Count != 0 && AsyncEventHandlers.TryGetValue(name, out var eventHandlers))
            {
                if (mValues == null)
                {
                    mValues = args.ToArray();
                }

                if (objects == null)
                {
                    var length = mValues.Length;
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject(BaseBaseObjectPool);
                    }
                }

                Task.Run(() =>
                {
                    foreach (var eventHandler in eventHandlers)
                    {
                        var invokeValues = eventHandler.CalculateInvokeValues(objects);
                        if (invokeValues != null)
                        {
                            eventHandler.InvokeNoResult(invokeValues);
                        }
                        else
                        {
                            AltAsync.Log("Wrong function params for " + name);
                        }
                    }
                });
            }

            if (serverEventAsyncDelegateHandlers.Count != 0 &&
                serverEventAsyncDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (mValues == null)
                {
                    mValues = args.ToArray();
                }

                if (objects == null)
                {
                    var length = mValues.Length;
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject(BaseBaseObjectPool);
                    }
                }

                Task.Run(() =>
                {
                    foreach (var eventHandler in eventDelegates)
                    {
                        AsyncEventHandler<ServerEventAsyncDelegate>.ExecuteSubscriptionAsync(eventHandler,
                            @delegate => @delegate(objects));
                    }
                });
            }
        }

        public void On(string eventName, ClientEventAsyncDelegate eventDelegate)
        {
            if (eventDelegate == null) return;
            if (clientEventAsyncDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(eventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<ClientEventAsyncDelegate> {eventDelegate};
                clientEventAsyncDelegateHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void On(string eventName, ServerEventAsyncDelegate eventDelegate)
        {
            if (eventDelegate == null) return;
            if (serverEventAsyncDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(eventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<ServerEventAsyncDelegate> {eventDelegate};
                serverEventAsyncDelegateHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public new void On(string eventName, Function function)
        {
            if (function == null) return;
            if (AsyncEventHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new HashSet<Function> {function};
                AsyncEventHandlers[eventName] = eventHandlersForEvent;
            }
        }
    }
}