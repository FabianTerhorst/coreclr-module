using System;
using System.Collections.Generic;
using System.Runtime.Loader;
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

        internal readonly AsyncEventHandler<PlayerChangeVehicleSeatAsyncDelegate>
            PlayerChangeVehicleSeatAsyncEventHandler =
                new AsyncEventHandler<PlayerChangeVehicleSeatAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerEnterVehicleAsyncDelegate> PlayerEnterVehicleAsyncEventHandler =
            new AsyncEventHandler<PlayerEnterVehicleAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerLeaveVehicleAsyncDelegate> PlayerLeaveVehicleAsyncEventHandler =
            new AsyncEventHandler<PlayerLeaveVehicleAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerDisconnectAsyncDelegate> PlayerDisconnectAsyncEventHandler =
            new AsyncEventHandler<PlayerDisconnectAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerRemoveAsyncDelegate> PlayerRemoveAsyncEventHandler =
            new AsyncEventHandler<PlayerRemoveAsyncDelegate>();

        internal readonly AsyncEventHandler<VehicleRemoveAsyncDelegate> VehicleRemoveAsyncEventHandler =
            new AsyncEventHandler<VehicleRemoveAsyncDelegate>();

        internal readonly AsyncEventHandler<PlayerClientEventAsyncDelegate> PlayerClientEventAsyncEventHandler =
            new AsyncEventHandler<PlayerClientEventAsyncDelegate>();

        internal readonly AsyncEventHandler<ConsoleCommandAsyncDelegate> ConsoleCommandAsyncDelegateHandlers =
            new AsyncEventHandler<ConsoleCommandAsyncDelegate>();

        internal readonly AsyncEventHandler<MetaDataChangeAsyncDelegate> MetaDataChangeAsyncDelegateHandlers =
            new AsyncEventHandler<MetaDataChangeAsyncDelegate>();

        internal readonly AsyncEventHandler<MetaDataChangeAsyncDelegate> SyncedMetaDataChangeAsyncDelegateHandlers =
            new AsyncEventHandler<MetaDataChangeAsyncDelegate>();

        internal readonly AsyncEventHandler<ColShapeAsyncDelegate> ColShapeAsyncDelegateHandlers =
            new AsyncEventHandler<ColShapeAsyncDelegate>();

        private readonly Dictionary<string, HashSet<ClientEventAsyncDelegate>> clientEventAsyncDelegateHandlers
            =
            new Dictionary<string, HashSet<ClientEventAsyncDelegate>>();

        private readonly Dictionary<string, HashSet<ServerEventAsyncDelegate>> serverEventAsyncDelegateHandlers
            =
            new Dictionary<string, HashSet<ServerEventAsyncDelegate>>();

        public AsyncModule(IServer server, AssemblyLoadContext assemblyLoadContext, NativeResource moduleResource,
            IBaseBaseObjectPool baseBaseObjectPool, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool) : base(server, assemblyLoadContext, moduleResource, baseBaseObjectPool,
            baseEntityPool, playerPool, vehiclePool, blipPool,
            checkpointPool, voiceChannelPool, colShapePool)
        {
            AltAsync.Setup(this);
        }

        public override void OnCheckPointEvent(ICheckpoint checkpoint, IEntity entity, bool state)
        {
            base.OnCheckPointEvent(checkpoint, entity, state);
            if (!CheckpointAsyncEventHandler.HasEvents()) return;
            Task.Run(() =>
                CheckpointAsyncEventHandler.CallAsyncWithoutTask(@delegate => @delegate(checkpoint, entity, state)));
        }

        public override void OnPlayerConnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerConnectEvent(player, reason);
            if (!PlayerConnectAsyncEventHandler.HasEvents()) return;
            Task.Run(() => PlayerConnectAsyncEventHandler.CallAsyncWithoutTask(@delegate => @delegate(player, reason)));
        }

        public override void OnPlayerDamageEvent(IPlayer player, IEntity attacker, uint weapon, ushort damage)
        {
            base.OnPlayerDamageEvent(player, attacker, weapon, damage);
            if (!PlayerDamageAsyncEventHandler.HasEvents()) return;
            var oldHealth = player.Health;
            var oldArmor = player.Armor;
            Task.Run(() =>
                PlayerDamageAsyncEventHandler.CallAsyncWithoutTask(@delegate =>
                    @delegate(player, attacker, oldHealth, oldArmor, weapon, damage)));
        }

        public override void OnPlayerDeathEvent(IPlayer player, IEntity killer, uint weapon)
        {
            base.OnPlayerDeathEvent(player, killer, weapon);
            if (!PlayerDeadAsyncEventHandler.HasEvents()) return;
            Task.Run(() =>
                PlayerDeadAsyncEventHandler.CallAsyncWithoutTask(@delegate => @delegate(player, killer, weapon)));
        }

        public override void OnPlayerChangeVehicleSeatEvent(IVehicle vehicle, IPlayer player, byte oldSeat,
            byte newSeat)
        {
            base.OnPlayerChangeVehicleSeatEvent(vehicle, player, oldSeat, newSeat);
            if (!PlayerChangeVehicleSeatAsyncEventHandler.HasEvents()) return;
            Task.Run(() =>
                PlayerChangeVehicleSeatAsyncEventHandler.CallAsyncWithoutTask(@delegate =>
                    @delegate(vehicle, player, oldSeat, newSeat)));
        }

        public override void OnPlayerEnterVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerEnterVehicleEvent(vehicle, player, seat);
            if (!PlayerEnterVehicleAsyncEventHandler.HasEvents()) return;
            Task.Run(() =>
                PlayerEnterVehicleAsyncEventHandler.CallAsyncWithoutTask(@delegate =>
                    @delegate(vehicle, player, seat)));
        }

        public override void OnPlayerLeaveVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerLeaveVehicleEvent(vehicle, player, seat);
            if (!PlayerLeaveVehicleAsyncEventHandler.HasEvents()) return;
            Task.Run(() =>
                PlayerLeaveVehicleAsyncEventHandler.CallAsyncWithoutTask(@delegate =>
                    @delegate(vehicle, player, seat)));
        }

        public override void OnPlayerDisconnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerDisconnectEvent(player, reason);
            if (!PlayerDisconnectAsyncEventHandler.HasEvents()) return;
            var readOnlyPlayer = player.Copy();
            Task.Run(async () =>
                {
                    await PlayerDisconnectAsyncEventHandler.CallAsync(@delegate =>
                        @delegate(readOnlyPlayer, player, reason));
                    readOnlyPlayer.Dispose();
                }
            );
        }

        public override void OnPlayerRemoveEvent(IPlayer player)
        {
            base.OnPlayerRemoveEvent(player);
            if (!PlayerRemoveAsyncEventHandler.HasEvents()) return;
            Task.Run(() =>
                PlayerRemoveAsyncEventHandler.CallAsyncWithoutTask(@delegate =>
                    @delegate(player)));
        }

        public override void OnVehicleRemoveEvent(IVehicle vehicle)
        {
            base.OnVehicleRemoveEvent(vehicle);
            if (!VehicleRemoveAsyncEventHandler.HasEvents()) return;
            Task.Run(() =>
                VehicleRemoveAsyncEventHandler.CallAsyncWithoutTask(@delegate =>
                    @delegate(vehicle)));
        }

        //TODO: we could write mvalue's to own onion struct in cpp to better share it but we would need to execute at least getorcreate entity when it contains a entity type in main thread
        //TODO: or lock entities dictionary so entity can't get removed until thread got it from dictionary
        //TODO: lock dictionary for async maybe as well for use cases like this
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

                Task.Run(async () =>
                {
                    foreach (var eventHandler in eventHandlers)
                    {
                        var invokeValues = eventHandler.CalculateInvokeValues(objects, player);
                        if (invokeValues != null)
                        {
                            try
                            {
                                var task = eventHandler.InvokeTaskOrNull(invokeValues);
                                if (task != null)
                                {
                                    await task;
                                }
                            }
                            catch (Exception e)
                            {
                                AltAsync.Log($"Execution of {name} threw an error: {e}");
                            }
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
                        AsyncEventHandler<ClientEventAsyncDelegate>.ExecuteEventAsyncWithoutTask(eventHandler,
                            @delegate => @delegate(player, objects));
                    }
                });
            }

            if (PlayerClientEventAsyncEventHandler.HasEvents())
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
                    foreach (var eventHandler in PlayerClientEventAsyncEventHandler.GetEvents())
                    {
                        AsyncEventHandler<PlayerClientEventAsyncDelegate>.ExecuteEventAsyncWithoutTask(eventHandler,
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

                Task.Run(async () =>
                {
                    foreach (var eventHandler in eventHandlers)
                    {
                        var invokeValues = eventHandler.CalculateInvokeValues(objects);
                        if (invokeValues != null)
                        {
                            try
                            {
                                var task = eventHandler.InvokeTaskOrNull(invokeValues);
                                if (task != null)
                                {
                                    await task;
                                }
                            }
                            catch (Exception e)
                            {
                                AltAsync.Log($"Execution of {name} threw an error: {e}");
                            }
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
                        AsyncEventHandler<ServerEventAsyncDelegate>.ExecuteEventAsyncWithoutTask(eventHandler,
                            @delegate => @delegate(objects));
                    }
                });
            }
        }

        public override void OnConsoleCommandEvent(string name, string[] args)
        {
            base.OnConsoleCommandEvent(name, args);
            if (!ConsoleCommandAsyncDelegateHandlers.HasEvents()) return;
            Task.Run(() =>
                ConsoleCommandAsyncDelegateHandlers.CallAsyncWithoutTask(@delegate =>
                    @delegate(name, args)));
        }

        public override void OnMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            base.OnMetaDataChangeEvent(entity, key, value);
            if (!MetaDataChangeAsyncDelegateHandlers.HasEvents()) return;
            Task.Run(() =>
                MetaDataChangeAsyncDelegateHandlers.CallAsyncWithoutTask(@delegate =>
                    @delegate(entity, key, value)));
        }

        public override void OnSyncedMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            base.OnSyncedMetaDataChangeEvent(entity, key, value);
            if (!SyncedMetaDataChangeAsyncDelegateHandlers.HasEvents()) return;
            Task.Run(() =>
                SyncedMetaDataChangeAsyncDelegateHandlers.CallAsyncWithoutTask(@delegate =>
                    @delegate(entity, key, value)));
        }

        public override void OnColShapeEvent(IColShape colShape, IEntity entity, bool state)
        {
            base.OnColShapeEvent(colShape, entity, state);
            if (!ColShapeAsyncDelegateHandlers.HasEvents()) return;
            Task.Run(() =>
                ColShapeAsyncDelegateHandlers.CallAsyncWithoutTask(@delegate =>
                    @delegate(colShape, entity, state)));
        }

        public void OnClient(string eventName, ClientEventAsyncDelegate eventDelegate)
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

        public void OnServer(string eventName, ServerEventAsyncDelegate eventDelegate)
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

        public override void OnScriptLoaded(IScript script)
        {
            AltAsync.RegisterEvents(script);
        }
    }
}