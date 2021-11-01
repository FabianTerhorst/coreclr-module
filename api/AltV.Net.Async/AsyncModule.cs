using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
            new();

        private readonly Dictionary<string, HashSet<Function>> asyncEventBusServer =
            new();

        internal readonly AsyncEventHandler<CheckpointAsyncDelegate> CheckpointAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerConnectAsyncDelegate> PlayerConnectAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerBeforeConnectAsyncDelegate> PlayerBeforeConnectAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerDamageAsyncDelegate> PlayerDamageAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerDeadAsyncDelegate> PlayerDeadAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<ExplosionAsyncDelegate> ExplosionAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<WeaponDamageAsyncDelegate> WeaponDamageAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerChangeVehicleSeatAsyncDelegate>
            PlayerChangeVehicleSeatAsyncEventHandler =
                new();

        internal readonly AsyncEventHandler<PlayerEnterVehicleAsyncDelegate> PlayerEnterVehicleAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerEnteringVehicleAsyncDelegate> PlayerEnteringVehicleAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerLeaveVehicleAsyncDelegate> PlayerLeaveVehicleAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerDisconnectAsyncDelegate> PlayerDisconnectAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerRemoveAsyncDelegate> PlayerRemoveAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<VehicleRemoveAsyncDelegate> VehicleRemoveAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerClientEventAsyncDelegate> PlayerClientEventAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<ConsoleCommandAsyncDelegate> ConsoleCommandAsyncDelegateHandlers =
            new();

        internal readonly AsyncEventHandler<MetaDataChangeAsyncDelegate> MetaDataChangeAsyncDelegateHandlers =
            new();

        internal readonly AsyncEventHandler<MetaDataChangeAsyncDelegate> SyncedMetaDataChangeAsyncDelegateHandlers =
            new();

        internal readonly AsyncEventHandler<ColShapeAsyncDelegate> ColShapeAsyncDelegateHandlers =
            new();

        internal readonly AsyncEventHandler<VehicleDestroyAsyncDelegate> VehicleDestroyAsyncDelegateHandlers =
            new();

        internal readonly AsyncEventHandler<FireAsyncDelegate> FireAsyncDelegateHandlers =
            new();

        internal readonly AsyncEventHandler<StartProjectileAsyncDelegate> StartProjectileAsyncDelegateHandlers =
            new();

        internal readonly AsyncEventHandler<PlayerWeaponChangeAsyncDelegate> PlayerWeaponChangeAsyncDelegateHandlers =
            new();

        internal readonly AsyncEventHandler<NetOwnerChangeAsyncDelegate> NetOwnerChangeAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<VehicleAttachAsyncDelegate> VehicleAttachAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<VehicleDetachAsyncDelegate> VehicleDetachAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<VehicleDamageAsyncDelegate> VehicleDamageAsyncEventHandler =
            new();

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
            CheckRef(in checkpointReference);
            CheckRef(in entityReference);
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
            CheckRef(in playerReference);
            CheckRef(in killerReference);
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
            CheckRef(in playerReference);
            Task.Run(async () =>
            {
                playerReference.DebugCountUp();
                await PlayerConnectAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, reason));
                playerReference.DebugCountDown();
                playerReference.Dispose();
            });
        }

        public override void OnPlayerBeforeConnectEvent(IntPtr eventPointer, IPlayer player, ulong passwordHash, string cdnUrl, string reason)
        {
            base.OnPlayerBeforeConnectEvent(eventPointer, player, passwordHash, cdnUrl, reason);
            if (!PlayerBeforeConnectAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            CheckRef(in playerReference);
            Task.Run(async () =>
            {
                playerReference.DebugCountUp();
                await PlayerBeforeConnectAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, passwordHash, cdnUrl, reason));
                playerReference.DebugCountDown();
                playerReference.Dispose();
            });
        }

        public override void OnPlayerDamageEvent(IPlayer player, IEntity entity, uint weapon, ushort healthDamage,
            ushort armourDamage)
        {
            base.OnPlayerDamageEvent(player, entity, weapon, healthDamage, armourDamage);
            if (!PlayerDamageAsyncEventHandler.HasEvents()) return;
            var oldHealth = player.Health;
            var oldArmor = player.Armor;
            var oldMaxHealth = player.MaxHealth;
            var oldMaxArmor = player.MaxArmor;
            var playerReference = new PlayerRef(player);
            var entityReference = new BaseObjectRef(entity);
            CheckRef(in playerReference);
            CheckRef(in entityReference);
            Task.Run(async () =>
            {
                playerReference.DebugCountUp();
                entityReference.DebugCountUp();
                await PlayerDamageAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, entity, oldHealth, oldArmor, oldMaxHealth, oldMaxArmor, weapon, healthDamage,
                        armourDamage));
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
            CheckRef(in sourceReference);
            CheckRef(in targetEntityReference);
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
            CheckRef(in sourceReference);
            CheckRef(in targetReference);
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
            CheckRef(in playerReference);
            CheckRef(in vehicleReference);
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
            CheckRef(in playerReference);
            CheckRef(in vehicleReference);
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

        public override void OnPlayerEnteringVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerEnteringVehicleEvent(vehicle, player, seat);
            if (!PlayerEnteringVehicleAsyncEventHandler.HasEvents()) return;
            var playerReference = new PlayerRef(player);
            var vehicleReference = new VehicleRef(vehicle);
            CheckRef(in playerReference);
            CheckRef(in vehicleReference);
            Task.Run(async () =>
            {
                playerReference.DebugCountUp();
                vehicleReference.DebugCountUp();
                await PlayerEnteringVehicleAsyncEventHandler.CallAsync(@delegate =>
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
            CheckRef(in playerReference);
            CheckRef(in vehicleReference);
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
            CheckRef(in playerReference);
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
            CheckRef(in playerReference);
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
            CheckRef(in vehicleReference);
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

                var outerPlayerRef = new PlayerRef(player);
                CheckRef(in outerPlayerRef);

                Task.Factory.StartNew(async obj =>
                    {
                        var (taskPlayer, taskObjects, taskEventHandlers, taskName, playerRef) =
                            (ValueTuple<IPlayer, object[], HashSet<Function>, string, PlayerRef>)obj;
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
                                    Alt.LogFast("Wrong function params for " + taskName);
                                }
                            }
                            catch (Exception e)
                            {
                                Alt.LogFast($"Execution of {taskName} threw an error: {e}");
                            }
                        }

                        playerRef.DebugCountDown();
                        playerRef.Dispose();
                    },
                    new ValueTuple<IPlayer, object[], HashSet<Function>, string, PlayerRef>(player, objects,
                        eventHandlersClient,
                        name, outerPlayerRef));
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

                var outerPlayerRef = new PlayerRef(player);
                CheckRef(in outerPlayerRef);

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
                        objects, PlayerClientEventAsyncEventHandler, name, outerPlayerRef));
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
                        (ValueTuple<object[], HashSet<Function>, string>)obj;
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
                                Alt.LogFast($"Execution of {taskName} threw an error: {e}");
                            }
                        }
                        else
                        {
                            Alt.LogFast("Wrong function params for " + taskName);
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
            CheckRef(in baseObjectRef);
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
            CheckRef(in baseObjectRef);
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
            CheckRef(in colShapeReference);
            CheckRef(in baseObjectRef);
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
            CheckRef(in vehicleReference);
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
            CheckRef(in playerRef);
            Task.Run(async () =>
            {
                playerRef.DebugCountUp();
                await FireAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(player, fires));
                playerRef.DebugCountDown();
                playerRef.Dispose();
            });
        }

        public override void OnStartProjectileEvent(IntPtr eventPointer, IPlayer player, Position startPosition,
            Position direction,
            uint ammoHash, uint weaponHash)
        {
            base.OnStartProjectileEvent(eventPointer, player, startPosition, direction, ammoHash, weaponHash);
            if (!StartProjectileAsyncDelegateHandlers.HasEvents()) return;
            var playerRef = new PlayerRef(player);
            CheckRef(in playerRef);
            Task.Run(async () =>
            {
                playerRef.DebugCountUp();
                await StartProjectileAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(player, startPosition, direction, ammoHash, weaponHash));
                playerRef.DebugCountDown();
                playerRef.Dispose();
            });
        }

        public override void OnPlayerWeaponChangeEvent(IntPtr eventPointer, IPlayer player, uint oldWeapon,
            uint newWeapon)
        {
            base.OnPlayerWeaponChangeEvent(eventPointer, player, oldWeapon, newWeapon);
            if (!PlayerWeaponChangeAsyncDelegateHandlers.HasEvents()) return;
            var playerRef = new PlayerRef(player);
            CheckRef(in playerRef);
            Task.Run(async () =>
            {
                playerRef.DebugCountUp();
                await PlayerWeaponChangeAsyncDelegateHandlers.CallAsync(@delegate =>
                    @delegate(player, oldWeapon, newWeapon));
                playerRef.DebugCountDown();
                playerRef.Dispose();
            });
        }

        public override void OnNetOwnerChangeEvent(IEntity targetEntity, IPlayer oldPlayer, IPlayer newPlayer)
        {
            base.OnNetOwnerChangeEvent(targetEntity, oldPlayer, newPlayer);
            if (!NetOwnerChangeAsyncEventHandler.HasEvents()) return;
            var targetEntityRef = new BaseObjectRef(targetEntity);
            var oldPlayerRef = new BaseObjectRef(oldPlayer);
            var newPlayerRef = new BaseObjectRef(newPlayer);
            CheckRef(in targetEntityRef);
            CheckRef(in oldPlayerRef);
            CheckRef(in newPlayerRef);
            Task.Run(async () =>
            {
                targetEntityRef.DebugCountUp();
                oldPlayerRef.DebugCountUp();
                newPlayerRef.DebugCountUp();
                await NetOwnerChangeAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(targetEntity, oldPlayer, newPlayer));
                newPlayerRef.DebugCountDown();
                oldPlayerRef.DebugCountDown();
                targetEntityRef.DebugCountDown();
                newPlayerRef.Dispose();
                oldPlayerRef.Dispose();
                targetEntityRef.Dispose();
            });
        }

        public override void OnVehicleAttachEvent(IVehicle targetVehicle, IVehicle attachedVehicle)
        {
            base.OnVehicleAttachEvent(targetVehicle, attachedVehicle);
            if (!VehicleAttachAsyncEventHandler.HasEvents()) return;
            var targetVehicleRef = new BaseObjectRef(targetVehicle);
            var attachedVehicleRef = new BaseObjectRef(attachedVehicle);
            CheckRef(in targetVehicleRef);
            CheckRef(in attachedVehicleRef);
            Task.Run(async () =>
            {
                targetVehicleRef.DebugCountUp();
                attachedVehicleRef.DebugCountUp();
                await VehicleAttachAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(targetVehicle, attachedVehicle));
                targetVehicleRef.DebugCountDown();
                attachedVehicleRef.DebugCountDown();
                attachedVehicleRef.Dispose();
                targetVehicleRef.Dispose();
            });
        }

        public override void OnVehicleDetachEvent(IVehicle targetVehicle, IVehicle detachedVehicle)
        {
            base.OnVehicleDetachEvent(targetVehicle, detachedVehicle);
            if (!VehicleDetachAsyncEventHandler.HasEvents()) return;
            var targetVehicleRef = new BaseObjectRef(targetVehicle);
            var detachedVehicleRef = new BaseObjectRef(detachedVehicle);
            CheckRef(in targetVehicleRef);
            CheckRef(in detachedVehicleRef);
            Task.Run(async () =>
            {
                targetVehicleRef.DebugCountUp();
                detachedVehicleRef.DebugCountUp();
                await VehicleDetachAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(targetVehicle, detachedVehicle));
                targetVehicleRef.DebugCountDown();
                detachedVehicleRef.DebugCountDown();
                detachedVehicleRef.Dispose();
                targetVehicleRef.Dispose();
            });
        }

        public override void OnVehicleDamageEvent(IVehicle targetVehicle, IEntity sourceEntity, uint bodyHealthDamage,
            uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weaponHash)
        {
            base.OnVehicleDamageEvent(targetVehicle, sourceEntity, bodyHealthDamage, additionalBodyHealthDamage,
                engineHealthDamage, petrolTankDamage, weaponHash);
            if (!VehicleDamageAsyncEventHandler.HasEvents()) return;
            var targetVehicleRef = new BaseObjectRef(targetVehicle);
            var sourceEntityRef = new BaseObjectRef(sourceEntity);
            CheckRef(in targetVehicleRef);
            CheckRef(in sourceEntityRef);
            Task.Run(async () =>
            {
                targetVehicleRef.DebugCountUp();
                sourceEntityRef.DebugCountUp();
                await VehicleDamageAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(targetVehicle, sourceEntity, bodyHealthDamage, additionalBodyHealthDamage,
                        engineHealthDamage, petrolTankDamage, weaponHash));
                targetVehicleRef.DebugCountDown();
                sourceEntityRef.DebugCountDown();
                sourceEntityRef.Dispose();
                targetVehicleRef.Dispose();
            });
        }

        public new Function OnClient(string eventName, Function function)
        {
            if (function == null) return null;
            if (asyncEventBusClient.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new HashSet<Function> { function };
                asyncEventBusClient[eventName] = eventHandlersForEvent;
            }

            return function;
        }

        public new void OffClient(string eventName, Function function)
        {
            if (function == null) return;
            if (asyncEventBusClient.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
            }
        }

        public new Function OnServer(string eventName, Function function)
        {
            if (function == null) return null;
            if (asyncEventBusServer.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new HashSet<Function> { function };
                asyncEventBusServer[eventName] = eventHandlersForEvent;
            }

            return function;
        }

        public new void OffServer(string eventName, Function function)
        {
            if (function == null) return;
            if (asyncEventBusServer.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
            }
        }

        public override void OnScriptLoaded(IScript script)
        {
            AltAsync.RegisterEvents(script);
        }

        [Conditional("DEBUG")]
        private static void CheckRef(in PlayerRef @ref, [CallerMemberName] string callerName = "")
        {
            if (!@ref.Exists)
            {
                Console.WriteLine("PlayerRef couldn't be created inside: " + callerName);
            }
        }

        [Conditional("DEBUG")]
        private static void CheckRef(in VehicleRef @ref, [CallerMemberName] string callerName = "")
        {
            if (!@ref.Exists)
            {
                Console.WriteLine("VehicleRef couldn't be created inside: " + callerName);
            }
        }

        [Conditional("DEBUG")]
        private static void CheckRef(in BaseObjectRef @ref, [CallerMemberName] string callerName = "")
        {
            if (!@ref.Exists)
            {
                Console.WriteLine("BaseObjectRef couldn't be created inside: " + callerName);
            }
        }

        [Conditional("DEBUG")]
        private static void CheckRef(in ColShapeRef @ref, [CallerMemberName] string callerName = "")
        {
            if (!@ref.Exists)
            {
                Console.WriteLine("ColShapeRef couldn't be created inside: " + callerName);
            }
        }

        [Conditional("DEBUG")]
        private static void CheckRef(in CheckpointRef @ref, [CallerMemberName] string callerName = "")
        {
            if (!@ref.Exists)
            {
                Console.WriteLine("CheckpointRef couldn't be created inside: " + callerName);
            }
        }
    }
}