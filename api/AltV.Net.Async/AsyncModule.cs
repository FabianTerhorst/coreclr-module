using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using AltV.Net.Async.Events;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Refs;
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

        internal readonly AsyncEventHandler<ExplosionAsyncDelegate> ExplosionAsyncEventHandler =
            new AsyncEventHandler<ExplosionAsyncDelegate>();

        internal readonly AsyncEventHandler<WeaponDamageAsyncDelegate> WeaponDamageAsyncEventHandler =
            new AsyncEventHandler<WeaponDamageAsyncDelegate>();

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

        public AsyncModule(IServer server, AssemblyLoadContext assemblyLoadContext, INativeResource moduleResource,
            IBaseBaseObjectPool baseBaseObjectPool, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool,
            INativeResourcePool nativeResourcePool) : base(server, assemblyLoadContext, moduleResource,
            baseBaseObjectPool,
            baseEntityPool, playerPool, vehiclePool, blipPool,
            checkpointPool, voiceChannelPool, colShapePool, nativeResourcePool)
        {
            AltAsync.Setup(this);
        }

        public override bool IsMainThread()
        {
            return AltAsync.AltVAsync.TickThread == Thread.CurrentThread || base.IsMainThread();
        }

        public override void OnCheckPointEvent(ICheckpoint checkpoint, IEntity entity, bool state)
        {
            base.OnCheckPointEvent(checkpoint, entity, state);
            if (!CheckpointAsyncEventHandler.HasEvents()) return;
            var checkpointReference = new CheckpointRef(checkpoint);
            switch (entity)
            {
                case IPlayer playerEntity:
                    var playerEntityReference = new PlayerRef(playerEntity);
                    Task.Run(async () =>
                    {
                        await CheckpointAsyncEventHandler.CallAsync(@delegate => @delegate(checkpoint, entity, state));
                        checkpointReference.Dispose();
                        playerEntityReference.Dispose();
                    });
                    break;
                case IVehicle vehicleEntity:
                    var vehicleEntityReference = new VehicleRef(vehicleEntity);
                    Task.Run(async () =>
                    {
                        await CheckpointAsyncEventHandler.CallAsync(@delegate => @delegate(checkpoint, entity, state));
                        checkpointReference.Dispose();
                        vehicleEntityReference.Dispose();
                    });
                    break;
                default:
                    Task.Run(async () =>
                    {
                        await CheckpointAsyncEventHandler.CallAsync(@delegate => @delegate(checkpoint, entity, state));
                        checkpointReference.Dispose();
                    });
                    break;
            }


            Task.Run(async () =>
            {
                await CheckpointAsyncEventHandler.CallAsync(@delegate => @delegate(checkpoint, entity, state));
                checkpointReference.Dispose();
            });
        }

        public override void OnPlayerDeathEvent(IPlayer player, IEntity killer, uint weapon)
        {
            base.OnPlayerDeathEvent(player, killer, weapon);
            if (!PlayerDeadAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            switch (killer)
            {
                case IPlayer playerKiller:
                    var playerKillerReference = new PlayerRef(playerKiller);
                    Task.Run(async () =>
                    {
                        await PlayerDeadAsyncEventHandler.CallAsync(@delegate =>
                            @delegate(player, killer, weapon));
                        playerReference.Dispose();
                        playerKillerReference.Dispose();
                    });
                    break;
                case IVehicle vehicleKiller:
                    var vehicleKillerReference = new VehicleRef(vehicleKiller);
                    Task.Run(async () =>
                    {
                        await PlayerDeadAsyncEventHandler.CallAsync(@delegate =>
                            @delegate(player, killer, weapon));
                        playerReference.Dispose();
                        vehicleKillerReference.Dispose();
                    });
                    break;
                default:
                    Task.Run(async () =>
                    {
                        await PlayerDeadAsyncEventHandler.CallAsync(@delegate =>
                            @delegate(player, killer, weapon));
                        playerReference.Dispose();
                    });
                    break;
            }
        }

        public override void OnPlayerConnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerConnectEvent(player, reason);
            if (!PlayerConnectAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            Task.Run(async () =>
            {
                await PlayerConnectAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, reason));
                playerReference.Dispose();
            });
        }

        public override void OnPlayerDamageEvent(IPlayer player, IEntity entity, uint weapon, ushort damage)
        {
            base.OnPlayerDamageEvent(player, entity, weapon, damage);
            if (!PlayerDamageAsyncEventHandler.HasEvents()) return;
            var oldHealth = player.Health;
            var oldArmor = player.Armor;
            var oldMaxHealth = player.MaxHealth;
            var oldMaxArmor = player.MaxArmor;
            var playerReference = new PlayerRef(player);
            switch (entity)
            {
                case IPlayer playerEntity:
                    var playerEntityReference = new PlayerRef(playerEntity);
                    Task.Run(async () =>
                    {
                        await PlayerDamageAsyncEventHandler.CallAsync(@delegate =>
                            @delegate(player, entity, oldHealth, oldArmor, oldMaxHealth, oldMaxArmor, weapon, damage));
                        playerReference.Dispose();
                        playerEntityReference.Dispose();
                    });
                    break;
                case IVehicle vehicleEntity:
                    var vehicleEntityReference = new VehicleRef(vehicleEntity);
                    Task.Run(async () =>
                    {
                        await PlayerDamageAsyncEventHandler.CallAsync(@delegate =>
                            @delegate(player, entity, oldHealth, oldArmor, oldMaxHealth, oldMaxArmor, weapon, damage));
                        playerReference.Dispose();
                        vehicleEntityReference.Dispose();
                    });
                    break;
                default:
                    Task.Run(async () =>
                    {
                        await PlayerDamageAsyncEventHandler.CallAsync(@delegate =>
                            @delegate(player, entity, oldHealth, oldArmor, oldMaxHealth, oldMaxArmor, weapon, damage));
                        playerReference.Dispose();
                    });
                    break;
            }
        }

        public override void OnExplosionEvent(IPlayer sourcePlayer, ExplosionType explosionType, Position position,
            uint explosionFx)
        {
            base.OnExplosionEvent(sourcePlayer, explosionType, position, explosionFx);
            if (!ExplosionAsyncEventHandler.HasEvents()) return;
            var sourceReference = new PlayerRef(sourcePlayer);
            Task.Run(async () =>
            {
                await ExplosionAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(sourcePlayer, explosionType, position, explosionFx));
                sourceReference.Dispose();
            });
        }

        public override void OnWeaponDamageEvent(IPlayer sourcePlayer, IEntity targetEntity, uint weapon, ushort damage,
            Position shotOffset, BodyPart bodyPart)
        {
            base.OnWeaponDamageEvent(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart);
            if (!WeaponDamageAsyncEventHandler.HasEvents()) return;
            var sourceReference = new PlayerRef(sourcePlayer);
            switch (targetEntity)
            {
                case IPlayer targetPlayer:
                {
                    var targetReference = new PlayerRef(targetPlayer);
                    Task.Run(async () =>
                    {
                        await WeaponDamageAsyncEventHandler.CallAsync(@delegate =>
                            @delegate(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart));
                        sourceReference.Dispose();
                        targetReference.Dispose();
                    });
                    break;
                }
                case IVehicle targetVehicle:
                {
                    var targetReference = new VehicleRef(targetVehicle);
                    Task.Run(async () =>
                    {
                        await WeaponDamageAsyncEventHandler.CallAsync(@delegate =>
                            @delegate(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart));
                        sourceReference.Dispose();
                        targetReference.Dispose();
                    });
                    break;
                }
                default:
                    Task.Run(async () =>
                    {
                        await WeaponDamageAsyncEventHandler.CallAsync(@delegate =>
                            @delegate(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart));
                        sourceReference.Dispose();
                    });
                    break;
            }
        }

        public override void OnPlayerChangeVehicleSeatEvent(IVehicle vehicle, IPlayer player, byte oldSeat,
            byte newSeat)
        {
            base.OnPlayerChangeVehicleSeatEvent(vehicle, player, oldSeat, newSeat);
            if (!PlayerChangeVehicleSeatAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            var vehicleReference = new VehicleRef(vehicle);
            Task.Run(async () =>
            {
                await PlayerChangeVehicleSeatAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, oldSeat, newSeat));
                playerReference.Dispose();
                vehicleReference.Dispose();
            });
        }

        public override void OnPlayerEnterVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerEnterVehicleEvent(vehicle, player, seat);
            if (!PlayerEnterVehicleAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            var vehicleReference = new VehicleRef(vehicle);
            Task.Run(async () =>
            {
                await PlayerEnterVehicleAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat));
                playerReference.Dispose();
                vehicleReference.Dispose();
            });
        }

        public override void OnPlayerLeaveVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerLeaveVehicleEvent(vehicle, player, seat);
            if (!PlayerLeaveVehicleAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            var vehicleReference = new VehicleRef(vehicle);
            Task.Run(async () =>
            {
                await PlayerLeaveVehicleAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat));
                playerReference.Dispose();
                vehicleReference.Dispose();
            });
        }

        public override void OnPlayerDisconnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerDisconnectEvent(player, reason);
            if (!PlayerDisconnectAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            Task.Run(async () =>
                {
                    await PlayerDisconnectAsyncEventHandler.CallAsync(@delegate =>
                        @delegate(player, reason));
                    playerReference.Dispose();
                }
            );
        }

        public override void OnPlayerRemoveEvent(IPlayer player)
        {
            base.OnPlayerRemoveEvent(player);
            if (!PlayerRemoveAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            Task.Run(async () =>
            {
                await PlayerRemoveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player));
                playerReference.Dispose();
            });
        }

        public override void OnVehicleRemoveEvent(IVehicle vehicle)
        {
            base.OnVehicleRemoveEvent(vehicle);
            if (!VehicleRemoveAsyncEventHandler.HasEvents()) return;
            var vehicleReference = new VehicleRef(vehicle);
            Task.Run(async () =>
            {
                await VehicleRemoveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle));
                vehicleReference.Dispose();
            });
        }

        //TODO: we could write mvalue's to own onion struct in cpp to better share it but we would need to execute at least getorcreate entity when it contains a entity type in main thread
        //TODO: or lock entities dictionary so entity can't get removed until thread got it from dictionary
        //TODO: lock dictionary for async maybe as well for use cases like this
        public override void OnClientEventEvent(IPlayer player, string name, IntPtr[] args, MValueConst[] mValues,
            object[] objects)
        {
            base.OnClientEventEvent(player, name, args, mValues, objects);
            int length = args.Length;

            if (AsyncEventHandlers.Count != 0 && AsyncEventHandlers.TryGetValue(name, out var eventHandlers))
            {
                if (mValues == null)
                {
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(args[i]);
                    }
                }

                if (objects == null)
                {
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject();
                    }
                }

                Task.Run(async () =>
                {
                    foreach (var eventHandler in eventHandlers)
                    {
                        var invokeValues = eventHandler.CalculateInvokeValues(player, objects);
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
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(args[i]);
                    }
                }

                if (objects == null)
                {
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject();
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
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(args[i]);
                    }
                }

                if (objects == null)
                {
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject();
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

        public override void OnServerEventEvent(string name, IntPtr[] args, MValueConst[] mValues, object[] objects)
        {
            base.OnServerEventEvent(name, args, mValues, objects);

            var length = args.Length;
            if (AsyncEventHandlers.Count != 0 && AsyncEventHandlers.TryGetValue(name, out var eventHandlers))
            {
                if (mValues == null)
                {
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(args[i]);
                    }
                }

                if (objects == null)
                {
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject();
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
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(args[i]);
                    }
                }

                if (objects == null)
                {
                    objects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        objects[i] = mValues[i].ToObject();
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
            switch (entity)
            {
                case IPlayer playerEntity:
                    var playerEntityReference = new PlayerRef(playerEntity);
                    Task.Run(async () =>
                    {
                        await MetaDataChangeAsyncDelegateHandlers.CallAsync(@delegate =>
                            @delegate(entity, key, value));
                        playerEntityReference.Dispose();
                    });
                    break;
                case IVehicle vehicleEntity:
                    var vehicleEntityReference = new VehicleRef(vehicleEntity);
                    Task.Run(async () =>
                    {
                        await MetaDataChangeAsyncDelegateHandlers.CallAsync(@delegate =>
                            @delegate(entity, key, value));
                        vehicleEntityReference.Dispose();
                    });
                    break;
                default:
                    Task.Run(() => MetaDataChangeAsyncDelegateHandlers.CallAsyncWithoutTask(@delegate =>
                        @delegate(entity, key, value)));
                    break;
            }
        }

        public override void OnSyncedMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            base.OnSyncedMetaDataChangeEvent(entity, key, value);
            if (!SyncedMetaDataChangeAsyncDelegateHandlers.HasEvents()) return;
            switch (entity)
            {
                case IPlayer playerEntity:
                    var playerEntityReference = new PlayerRef(playerEntity);
                    Task.Run(async () =>
                    {
                        await SyncedMetaDataChangeAsyncDelegateHandlers.CallAsync(@delegate =>
                            @delegate(entity, key, value));
                        playerEntityReference.Dispose();
                    });
                    break;
                case IVehicle vehicleEntity:
                    var vehicleEntityReference = new VehicleRef(vehicleEntity);
                    Task.Run(async () =>
                    {
                        await SyncedMetaDataChangeAsyncDelegateHandlers.CallAsync(@delegate =>
                            @delegate(entity, key, value));
                        vehicleEntityReference.Dispose();
                    });
                    break;
                default:
                    Task.Run(() => SyncedMetaDataChangeAsyncDelegateHandlers.CallAsyncWithoutTask(@delegate =>
                        @delegate(entity, key, value)));
                    break;
            }
        }

        public override void OnColShapeEvent(IColShape colShape, IEntity entity, bool state)
        {
            base.OnColShapeEvent(colShape, entity, state);
            if (!ColShapeAsyncDelegateHandlers.HasEvents()) return;
            var colShapeReference = new ColShapeRef(colShape);
            switch (entity)
            {
                case IPlayer playerEntity:
                    var playerEntityReference = new PlayerRef(playerEntity);
                    Task.Run(async () =>
                    {
                        await ColShapeAsyncDelegateHandlers.CallAsync(@delegate =>
                            @delegate(colShape, entity, state));
                        playerEntityReference.Dispose();
                        colShapeReference.Dispose();
                    });
                    break;
                case IVehicle vehicleEntity:
                    var vehicleEntityReference = new VehicleRef(vehicleEntity);
                    Task.Run(async () =>
                    {
                        await ColShapeAsyncDelegateHandlers.CallAsync(@delegate =>
                            @delegate(colShape, entity, state));
                        vehicleEntityReference.Dispose();
                        colShapeReference.Dispose();
                    });
                    break;
                default:
                    Task.Run(async () =>
                    {
                        await ColShapeAsyncDelegateHandlers.CallAsync(@delegate =>
                            @delegate(colShape, entity, state));
                        colShapeReference.Dispose();
                    });
                    break;
            }
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