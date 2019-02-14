using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Async.Events;
using AltV.Net.Elements.Entities;
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

        internal readonly AsyncEventHandler<VehicleChangeSeatAsyncDelegate> VehicleChangeSeatAsyncEventHandler =
            new AsyncEventHandler<VehicleChangeSeatAsyncDelegate>();

        internal readonly AsyncEventHandler<VehicleEnterAsyncDelegate> VehicleEnterAsyncEventHandler =
            new AsyncEventHandler<VehicleEnterAsyncDelegate>();

        internal readonly AsyncEventHandler<VehicleLeaveAsyncDelegate> VehicleLeaveAsyncEventHandler =
            new AsyncEventHandler<VehicleLeaveAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerDisconnectAsyncDelegate> PlayerDisconnectAsyncEventHandler =
            new AsyncEventHandler<PlayerDisconnectAsyncDelegate>();

        internal readonly AsyncEventHandler<EntityRemoveAsyncDelegate> EntityRemoveAsyncEventHandler =
            new AsyncEventHandler<EntityRemoveAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerClientEventAsyncDelegate> PlayerClientEventAsyncEventHandler =
            new AsyncEventHandler<PlayerClientEventAsyncDelegate>();

        internal readonly Dictionary<string, HashSet<ClientEventAsyncDelegate>> ClientEventAsyncDelegateHandlers
            =
            new Dictionary<string, HashSet<ClientEventAsyncDelegate>>();

        internal readonly Dictionary<string, HashSet<ServerEventAsyncDelegate>> ServerEventAsyncDelegateHandlers
            =
            new Dictionary<string, HashSet<ServerEventAsyncDelegate>>();

        public AsyncModule(IServer server, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool) : base(server, baseEntityPool, playerPool, vehiclePool, blipPool,
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

        public override void OnPlayerDamageEvent(IPlayer player, IEntity attacker, uint weapon, byte damage)
        {
            base.OnPlayerDamageEvent(player, attacker, weapon, damage);
            Task.Run(() =>
                PlayerDamageAsyncEventHandler.CallAsync(@delegate => @delegate(player, attacker, weapon, damage)));
        }

        public override void OnPlayerDeadEvent(IPlayer player, IEntity killer, uint weapon)
        {
            base.OnPlayerDeadEvent(player, killer, weapon);
            Task.Run(() =>
                PlayerDeadAsyncEventHandler.CallAsync(@delegate => @delegate(player, killer, weapon)));
        }

        public override void OnVehicleChangeSeatEvent(IVehicle vehicle, IPlayer player, sbyte oldSeat, sbyte newSeat)
        {
            base.OnVehicleChangeSeatEvent(vehicle, player, oldSeat, newSeat);
            Task.Run(() =>
                VehicleChangeSeatAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, oldSeat, newSeat)));
        }

        public override void OnVehicleEnterEvent(IVehicle vehicle, IPlayer player, sbyte seat)
        {
            base.OnVehicleEnterEvent(vehicle, player, seat);
            Task.Run(() =>
                VehicleEnterAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat)));
        }

        public override void OnVehicleLeaveEvent(IVehicle vehicle, IPlayer player, sbyte seat)
        {
            base.OnVehicleLeaveEvent(vehicle, player, seat);
            Task.Run(() =>
                VehicleLeaveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat)));
        }

        public override void OnPlayerDisconnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerDisconnectEvent(player, reason);
            Task.Run(() =>
                PlayerDisconnectAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, reason)));
        }

        public override void OnEntityRemoveEvent(IEntity entity)
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

                foreach (var eventHandler in eventHandlers)
                {
                    var invokeValues = eventHandler.CalculateInvokeValues(player, BaseEntityPool, mValues);
                    Task.Run(() => { eventHandler.InvokeAsync(invokeValues); });
                }
            }

            if (ClientEventAsyncDelegateHandlers.Count != 0 && ClientEventAsyncDelegateHandlers.TryGetValue(name, out var eventDelegates))
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
                        objects[i] = mValues[i].ToObject(BaseEntityPool);
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
                        objects[i] = mValues[i].ToObject(BaseEntityPool);
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

            if (AsyncEventHandlers.TryGetValue(name, out var eventHandlers))
            {
                if (mValues == null)
                {
                    mValues = args.ToArray();
                }

                foreach (var eventHandler in eventHandlers)
                {
                    var invokeValues = eventHandler.CalculateInvokeValues(BaseEntityPool, mValues);
                    Task.Run(() => { eventHandler.InvokeAsync(invokeValues); });
                }
            }

            if (ServerEventAsyncDelegateHandlers.TryGetValue(name, out var eventDelegates))
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
                        objects[i] = mValues[i].ToObject(BaseEntityPool);
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
            if (ClientEventAsyncDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(eventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<ClientEventAsyncDelegate> {eventDelegate};
                ClientEventAsyncDelegateHandlers[eventName] = eventHandlersForEvent;
            }
        }

        public void On(string eventName, ServerEventAsyncDelegate eventDelegate)
        {
            if (eventDelegate == null) return;
            if (ServerEventAsyncDelegateHandlers.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(eventDelegate);
            }
            else
            {
                eventHandlersForEvent = new HashSet<ServerEventAsyncDelegate> {eventDelegate};
                ServerEventAsyncDelegateHandlers[eventName] = eventHandlersForEvent;
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