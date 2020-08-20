using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using AltV.Net.Async.Events;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Refs;

namespace AltV.Net.Async
{
    public class AsyncModule : Module
    {
        private readonly Dictionary<string, HashSet<Function>> asyncEventBusClient =
            new Dictionary<string, HashSet<Function>>();

        private readonly Dictionary<string, HashSet<Function>> asyncEventBusServer =
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

        internal readonly AsyncEventHandler<VehicleDestroyAsyncDelegate> VehicleDestroyAsyncDelegateHandlers =
            new AsyncEventHandler<VehicleDestroyAsyncDelegate>();
        
        internal readonly AsyncEventHandler<FireAsyncDelegate> FireAsyncDelegateHandlers =
            new AsyncEventHandler<FireAsyncDelegate>();
        
        internal readonly AsyncEventHandler<StartProjectileAsyncDelegate> StartProjectileAsyncDelegateHandlers =
            new AsyncEventHandler<StartProjectileAsyncDelegate>();
        
        internal readonly AsyncEventHandler<PlayerWeaponChangeAsyncDelegate> PlayerWeaponChangeAsyncDelegateHandlers =
            new AsyncEventHandler<PlayerWeaponChangeAsyncDelegate>();

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
            var entityReference = new BaseObjectRef(entity);
            Task.Run(async () =>
            {
                checkpointReference.DebugCountUp();
                entityReference.DebugCountUp();
                await CheckpointAsyncEventHandler.CallAsync(@delegate => @delegate(checkpoint, entity, state));
                entityReference.DebugCountDown();
                checkpointReference.DebugCountDown();
                entityReference.Dispose();
                checkpointReference.Dispose();
            });
        }

        public override void OnPlayerDeathEvent(IPlayer player, IEntity killer, uint weapon)
        {
            base.OnPlayerDeathEvent(player, killer, weapon);
            if (!PlayerDeadAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            var killerReference = new BaseObjectRef(killer);
            Task.Run(async () =>
            {
                playerReference.DebugCountUp();
                killerReference.DebugCountUp();
                await PlayerDeadAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, killer, weapon));
                killerReference.DebugCountDown();
                playerReference.DebugCountDown();
                playerReference.Dispose();
                killerReference.Dispose();
            });
        }

        public override void OnPlayerConnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerConnectEvent(player, reason);
            if (!PlayerConnectAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            Task.Run(async () =>
            {
                playerReference.DebugCountUp();
                await PlayerConnectAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, reason));
                playerReference.DebugCountDown();
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
            var entityReference = new BaseObjectRef(entity);
            Task.Run(async () =>
            {
                playerReference.DebugCountUp();
                entityReference.DebugCountUp();
                await PlayerDamageAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, entity, oldHealth, oldArmor, oldMaxHealth, oldMaxArmor, weapon, damage));
                entityReference.DebugCountDown();
                playerReference.DebugCountDown();
                playerReference.Dispose();
                entityReference.Dispose();
            });
        }

        public override void OnExplosionEvent(IntPtr eventPointer, IPlayer sourcePlayer, ExplosionType explosionType,
            Position position,
            uint explosionFx, IEntity targetEntity)
        {
            base.OnExplosionEvent(eventPointer, sourcePlayer, explosionType, position, explosionFx, targetEntity);
            if (!ExplosionAsyncEventHandler.HasEvents()) return;
            var sourceReference = new PlayerRef(sourcePlayer);
            var targetEntityReference = new BaseObjectRef(targetEntity);
            Task.Run(async () =>
            {
                sourceReference.DebugCountUp();
                targetEntityReference.DebugCountUp();
                await ExplosionAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(sourcePlayer, explosionType, position, explosionFx, targetEntity));
                sourceReference.DebugCountDown();
                targetEntityReference.DebugCountDown();
                sourceReference.Dispose();
                targetEntityReference.Dispose();
            });
        }

        public override void OnWeaponDamageEvent(IntPtr eventPointer, IPlayer sourcePlayer, IEntity targetEntity,
            uint weapon, ushort damage,
            Position shotOffset, BodyPart bodyPart)
        {
            base.OnWeaponDamageEvent(eventPointer, sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart);
            if (!WeaponDamageAsyncEventHandler.HasEvents()) return;
            var sourceReference = new PlayerRef(sourcePlayer);
            var targetReference = new BaseObjectRef(targetEntity);
            Task.Run(async () =>
            {
                sourceReference.DebugCountUp();
                targetReference.DebugCountUp();
                await WeaponDamageAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart));
                sourceReference.DebugCountDown();
                targetReference.DebugCountDown();
                sourceReference.Dispose();
                targetReference.Dispose();
            });
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
                playerReference.DebugCountUp();
                vehicleReference.DebugCountUp();
                await PlayerChangeVehicleSeatAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, oldSeat, newSeat));
                vehicleReference.DebugCountDown();
                playerReference.DebugCountDown();
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
                playerReference.DebugCountUp();
                vehicleReference.DebugCountUp();
                await PlayerEnterVehicleAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat));
                vehicleReference.DebugCountDown();
                playerReference.DebugCountDown();
                vehicleReference.Dispose();
                playerReference.Dispose();
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
                playerReference.DebugCountUp();
                vehicleReference.DebugCountUp();
                await PlayerLeaveVehicleAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat));
                vehicleReference.DebugCountDown();
                playerReference.DebugCountDown();
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
                    playerReference.DebugCountUp();
                    await PlayerDisconnectAsyncEventHandler.CallAsync(@delegate =>
                        @delegate(player, reason));
                    playerReference.DebugCountDown();
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
                playerReference.DebugCountUp();
                await PlayerRemoveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player));
                playerReference.DebugCountDown();
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
                vehicleReference.DebugCountUp();
                await VehicleRemoveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle));
                vehicleReference.DebugCountDown();
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
            var length = args.Length;

            if (asyncEventBusClient.Count != 0 && asyncEventBusClient.TryGetValue(name, out var eventHandlersClient))
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

                Task.Factory.StartNew(async obj =>
                    {
                        var (taskPlayer, taskObjects, taskEventHandlers, taskName, playerRef) =
                            (ValueTuple<IPlayer, object[], HashSet<Function>, string, PlayerRef>) obj;
                        playerRef.DebugCountUp();
                        foreach (var eventHandler in taskEventHandlers)
                        {
                            try
                            {
                                var invokeValues = eventHandler.CalculateInvokeValues(taskPlayer, taskObjects);
                                if (invokeValues != null)
                                {
                                    var task = eventHandler.InvokeTaskOrNull(invokeValues);
                                    if (task != null)
                                    {
                                        await task;
                                    }
                                }
                                else
                                {
                                    AltAsync.Log("Wrong function params for " + taskName);
                                }
                            }
                            catch (Exception e)
                            {
                                AltAsync.Log($"Execution of {taskName} threw an error: {e}");
                            }
                        }

                        playerRef.DebugCountDown();
                        playerRef.Dispose();
                    },
                    new ValueTuple<IPlayer, object[], HashSet<Function>, string, PlayerRef>(player, objects,
                        eventHandlersClient,
                        name, new PlayerRef(player)));
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

                Task.Factory.StartNew(obj =>
                    {
                        var (taskPlayer, taskObjects, taskEventHandlers, taskName, playerRef) =
                            (ValueTuple<IPlayer, object[], AsyncEventHandler<PlayerClientEventAsyncDelegate>, string,
                                PlayerRef>)
                            obj;
                        playerRef.DebugCountUp();
                        foreach (var eventHandler in taskEventHandlers.GetEvents())
                        {
                            AsyncEventHandler<PlayerClientEventAsyncDelegate>.ExecuteEventAsyncWithoutTask(eventHandler,
                                @delegate => @delegate(taskPlayer, taskName, taskObjects));
                        }

                        playerRef.DebugCountDown();
                        playerRef.Dispose();
                    },
                    new ValueTuple<IPlayer, object[], AsyncEventHandler<PlayerClientEventAsyncDelegate>, string,
                        PlayerRef>(player,
                        objects, PlayerClientEventAsyncEventHandler, name, new PlayerRef(player)));
            }
        }

        public override void OnServerEventEvent(string name, IntPtr[] args, MValueConst[] mValues, object[] objects)
        {
            base.OnServerEventEvent(name, args, mValues, objects);

            var length = args.Length;
            if (asyncEventBusServer.Count != 0 && asyncEventBusServer.TryGetValue(name, out var eventHandlersServer))
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

                Task.Factory.StartNew(async obj =>
                {
                    var (taskObjects, taskEventHandlers, taskName) =
                        (ValueTuple<object[], HashSet<Function>, string>) obj;
                    foreach (var eventHandler in taskEventHandlers)
                    {
                        var invokeValues = eventHandler.CalculateInvokeValues(taskObjects);
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
                                AltAsync.Log($"Execution of {taskName} threw an error: {e}");
                            }
                        }
                        else
                        {
                            AltAsync.Log("Wrong function params for " + taskName);
                        }
                    }
                }, new ValueTuple<object[], HashSet<Function>, string>(objects, eventHandlersServer, name));
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
            var baseObjectRef = new BaseObjectRef(entity);
            Task.Run(async () =>
            {
                baseObjectRef.DebugCountUp();
                await MetaDataChangeAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(entity, key, value));
                baseObjectRef.DebugCountDown();
                baseObjectRef.Dispose();
            });
        }

        public override void OnSyncedMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            base.OnSyncedMetaDataChangeEvent(entity, key, value);
            if (!SyncedMetaDataChangeAsyncDelegateHandlers.HasEvents()) return;
            var baseObjectRef = new BaseObjectRef(entity);
            Task.Run(async () =>
            {
                baseObjectRef.DebugCountUp();
                await SyncedMetaDataChangeAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(entity, key, value));
                baseObjectRef.DebugCountDown();
                baseObjectRef.Dispose();
            });
        }

        public override void OnColShapeEvent(IColShape colShape, IEntity entity, bool state)
        {
            base.OnColShapeEvent(colShape, entity, state);
            if (!ColShapeAsyncDelegateHandlers.HasEvents()) return;
            var colShapeReference = new ColShapeRef(colShape);
            var baseObjectRef = new BaseObjectRef(entity);
            Task.Run(async () =>
            {
                colShapeReference.DebugCountUp();
                baseObjectRef.DebugCountUp();
                await ColShapeAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(colShape, entity, state));
                baseObjectRef.DebugCountDown();
                colShapeReference.DebugCountDown();
                baseObjectRef.Dispose();
                colShapeReference.Dispose();
            });
        }

        public override void OnVehicleDestroyEvent(IVehicle vehicle)
        {
            base.OnVehicleDestroyEvent(vehicle);
            if (!VehicleDestroyAsyncDelegateHandlers.HasEvents()) return;
            var vehicleReference = new VehicleRef(vehicle);
            Task.Run(async () =>
            {
                vehicleReference.DebugCountUp();
                await VehicleDestroyAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(vehicle));
                vehicleReference.DebugCountDown();
                vehicleReference.Dispose();
            });
        }

        public override void OnFireEvent(IntPtr eventPointer, IPlayer player, FireInfo[] fires)
        {
            base.OnFireEvent(eventPointer, player, fires);
            if (!FireAsyncDelegateHandlers.HasEvents()) return;
            var playerRef = new PlayerRef(player);
            Task.Run(async () =>
            {
                playerRef.DebugCountUp();
                await FireAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(player, fires));
                playerRef.DebugCountDown();
                playerRef.Dispose();
            });
        }

        public override void OnStartProjectileEvent(IntPtr eventPointer, IPlayer player, Position startPosition, Position direction,
            uint ammoHash, uint weaponHash)
        {
            base.OnStartProjectileEvent(eventPointer, player, startPosition, direction, ammoHash, weaponHash);
            if (!StartProjectileAsyncDelegateHandlers.HasEvents()) return;
            var playerRef = new PlayerRef(player);
            Task.Run(async () =>
            {
                playerRef.DebugCountUp();
                await StartProjectileAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(player, startPosition, direction, ammoHash, weaponHash));
                playerRef.DebugCountDown();
                playerRef.Dispose();
            });
        }

        public override void OnPlayerWeaponChangeEvent(IntPtr eventPointer, IPlayer player, uint oldWeapon, uint newWeapon)
        {
            base.OnPlayerWeaponChangeEvent(eventPointer, player, oldWeapon, newWeapon);
            if (!PlayerWeaponChangeAsyncDelegateHandlers.HasEvents()) return;
            var playerRef = new PlayerRef(player);
            Task.Run(async () =>
            {
                playerRef.DebugCountUp();
                await PlayerWeaponChangeAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(player, oldWeapon, newWeapon));
                playerRef.DebugCountDown();
                playerRef.Dispose();
            });
        }

        public new void OnClient(string eventName, Function function)
        {
            if (function == null) return;
            if (asyncEventBusClient.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new HashSet<Function> {function};
                asyncEventBusClient[eventName] = eventHandlersForEvent;
            }
        }

        public new void OffClient(string eventName, Function function)
        {
            if (function == null) return;
            if (asyncEventBusClient.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
            }
        }

        public new void OnServer(string eventName, Function function)
        {
            if (function == null) return;
            if (asyncEventBusServer.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new HashSet<Function> {function};
                asyncEventBusServer[eventName] = eventHandlersForEvent;
            }
        }

        public new void OffServer(string eventName, Function function)
        {
            if (function == null) return;
            if (asyncEventBusClient.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
            }
        }

        public override void OnScriptLoaded(IScript script)
        {
            AltAsync.RegisterEvents(script);
        }
    }
}