using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using AltV.Net.Async.Events;
using AltV.Net.CApi;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Events;

namespace AltV.Net.Async
{
    public class AsyncCore : Core
    {
        private readonly Dictionary<string, List<Function>> asyncEventBusClient =
            new();

        private readonly Dictionary<string, List<Function>> asyncEventBusServer =
            new();

        public override IEnumerable<string> GetRegisteredClientEvents()
        {
            return base.GetRegisteredClientEvents().Concat(asyncEventBusClient.Keys);
        }

        public override IEnumerable<string> GetRegisteredServerEvents()
        {
            return base.GetRegisteredServerEvents().Concat(asyncEventBusServer.Keys);
        }

        internal readonly AsyncEventHandler<CheckpointAsyncDelegate> CheckpointAsyncEventHandler =
            new(EventType.COLSHAPE_EVENT);

        internal readonly AsyncEventHandler<PlayerConnectAsyncDelegate> PlayerConnectAsyncEventHandler =
            new(EventType.PLAYER_CONNECT);

        internal readonly AsyncEventHandler<PlayerConnectDeniedAsyncDelegate> PlayerConnectDeniedAsyncEventHandler =
            new(EventType.PLAYER_CONNECT_DENIED);

        internal readonly AsyncEventHandler<ResourceEventAsyncDelegate> ResourceStartAsyncEventHandler =
            new(EventType.RESOURCE_START);

        internal readonly AsyncEventHandler<ResourceEventAsyncDelegate> ResourceStopAsyncEventHandler =
            new(EventType.RESOURCE_STOP);

        internal readonly AsyncEventHandler<ResourceEventAsyncDelegate> ResourceErrorAsyncEventHandler =
            new(EventType.RESOURCE_ERROR);

        internal readonly AsyncEventHandler<PlayerDamageAsyncDelegate> PlayerDamageAsyncEventHandler =
            new(EventType.PLAYER_DAMAGE);

        internal readonly AsyncEventHandler<PlayerDeadAsyncDelegate> PlayerDeadAsyncEventHandler =
            new(EventType.PLAYER_DEATH);

        internal readonly AsyncEventHandler<PlayerHealAsyncDelegate> PlayerHealAsyncEventHandler =
            new(EventType.PLAYER_HEAL);

        internal readonly AsyncEventHandler<ExplosionAsyncDelegate> ExplosionAsyncEventHandler =
            new(EventType.EXPLOSION_EVENT);

        internal readonly AsyncEventHandler<WeaponDamageAsyncDelegate> WeaponDamageAsyncEventHandler =
            new(EventType.WEAPON_DAMAGE_EVENT);

        internal readonly AsyncEventHandler<PlayerChangeVehicleSeatAsyncDelegate>
            PlayerChangeVehicleSeatAsyncEventHandler =
                new(EventType.PLAYER_CHANGE_VEHICLE_SEAT);

        internal readonly AsyncEventHandler<PlayerEnterVehicleAsyncDelegate> PlayerEnterVehicleAsyncEventHandler =
            new(EventType.PLAYER_ENTER_VEHICLE);

        internal readonly AsyncEventHandler<PlayerEnteringVehicleAsyncDelegate> PlayerEnteringVehicleAsyncEventHandler =
            new(EventType.PLAYER_ENTERING_VEHICLE);

        internal readonly AsyncEventHandler<PlayerLeaveVehicleAsyncDelegate> PlayerLeaveVehicleAsyncEventHandler =
            new(EventType.PLAYER_LEAVE_VEHICLE);

        internal readonly AsyncEventHandler<PlayerDisconnectAsyncDelegate> PlayerDisconnectAsyncEventHandler =
            new(EventType.PLAYER_DISCONNECT);

        internal readonly AsyncEventHandler<PlayerRemoveAsyncDelegate> PlayerRemoveAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<VehicleRemoveAsyncDelegate> VehicleRemoveAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PedRemoveAsyncDelegate> PedRemoveAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<PlayerClientEventAsyncDelegate> PlayerClientEventAsyncEventHandler =
            new();

        internal readonly AsyncEventHandler<ConsoleCommandAsyncDelegate> ConsoleCommandAsyncEventHandler =
            new(EventType.CONSOLE_COMMAND_EVENT);

        internal readonly AsyncEventHandler<MetaDataChangeAsyncDelegate> MetaDataChangeAsyncEventHandler =
            new(EventType.META_CHANGE);

        internal readonly AsyncEventHandler<MetaDataChangeAsyncDelegate> SyncedMetaDataChangeAsyncEventHandler =
            new(EventType.SYNCED_META_CHANGE);

        internal readonly AsyncEventHandler<ColShapeAsyncDelegate> ColShapeAsyncEventHandler =
            new(EventType.COLSHAPE_EVENT);

        internal readonly AsyncEventHandler<VehicleDestroyAsyncDelegate> VehicleDestroyAsyncEventHandler =
            new(EventType.VEHICLE_DESTROY);

        internal readonly AsyncEventHandler<FireAsyncDelegate> FireAsyncEventHandler =
            new(EventType.FIRE_EVENT);

        internal readonly AsyncEventHandler<StartProjectileAsyncDelegate> StartProjectileAsyncEventHandler =
            new(EventType.START_PROJECTILE_EVENT);

        internal readonly AsyncEventHandler<PlayerWeaponChangeAsyncDelegate> PlayerWeaponChangeAsyncEventHandler =
            new(EventType.PLAYER_WEAPON_CHANGE);

        internal readonly AsyncEventHandler<NetOwnerChangeAsyncDelegate> NetOwnerChangeAsyncEventHandler =
            new(EventType.NETOWNER_CHANGE);

        internal readonly AsyncEventHandler<VehicleAttachAsyncDelegate> VehicleAttachAsyncEventHandler =
            new(EventType.VEHICLE_ATTACH);

        internal readonly AsyncEventHandler<VehicleDetachAsyncDelegate> VehicleDetachAsyncEventHandler =
            new(EventType.VEHICLE_DETACH);

        internal readonly AsyncEventHandler<VehicleDamageAsyncDelegate> VehicleDamageAsyncEventHandler =
            new(EventType.VEHICLE_DAMAGE);

        internal readonly AsyncEventHandler<VehicleHornAsyncDelegate> VehicleHornAsyncEventHandler =
            new(EventType.VEHICLE_HORN);

        internal readonly AsyncEventHandler<ConnectionQueueAddAsyncDelegate> ConnectionQueueAddAsyncEventHandler =
            new(EventType.CONNECTION_QUEUE_ADD);

        internal readonly AsyncEventHandler<ConnectionQueueRemoveAsyncDelegate> ConnectionQueueRemoveAsyncEventHandler =
            new(EventType.CONNECTION_QUEUE_REMOVE);

        internal readonly AsyncEventHandler<ServerStartedAsyncDelegate> ServerStartedAsyncEventHandler =
            new(EventType.SERVER_STARTED);

        internal readonly AsyncEventHandler<PlayerRequestControlAsyncDelegate> PlayerRequestControlAsyncEventHandler =
            new(EventType.PLAYER_REQUEST_CONTROL);

        internal readonly AsyncEventHandler<PlayerChangeAnimationAsyncDelegate> PlayerChangeAnimationAsyncEventHandler =
            new(EventType.PLAYER_CHANGE_ANIMATION_EVENT);

        internal readonly AsyncEventHandler<PlayerChangeInteriorAsyncDelegate> PlayerChangeInteriorAsyncEventHandler =
            new(EventType.PLAYER_CHANGE_INTERIOR_EVENT);

        internal readonly AsyncEventHandler<PlayerDimensionChangeAsyncDelegate> PlayerDimensionChangeAsyncEventHandler =
            new(EventType.PLAYER_DIMENSION_CHANGE);

        internal readonly AsyncEventHandler<VehicleSirenAsyncDelegate> VehicleSirenAsyncEventHandler =
            new(EventType.VEHICLE_SIREN);

        internal readonly AsyncEventHandler<PlayerSpawnAsyncDelegate> PlayerSpawnAsyncEventHandler =
            new(EventType.PLAYER_SPAWN);

        internal readonly AsyncEventHandler<RequestSyncedSceneAsyncEventDelegate> RequestSyncedSceneAsyncEventHandler =
            new(EventType.REQUEST_SYNCED_SCENE);

        internal readonly AsyncEventHandler<StartSyncedSceneAsyncEventDelegate> StartSyncedSceneAsyncEventHandler =
            new(EventType.START_SYNCED_SCENE);

        internal readonly AsyncEventHandler<StopSyncedSceneAsyncEventDelegate> StopSyncedSceneAsyncEventHandler =
            new(EventType.STOP_SYNCED_SCENE);

        internal readonly AsyncEventHandler<UpdateSyncedSceneAsyncEventDelegate> UpdateSyncedSceneAsyncEventHandler =
            new(EventType.UPDATE_SYNCED_SCENE);

        internal readonly AsyncEventHandler<ClientRequestObjectAsyncEventDelegate> ClientRequestObjectAsyncEventHandler =
            new(EventType.CLIENT_REQUEST_OBJECT_EVENT);

        internal readonly AsyncEventHandler<ClientDeleteObjectAsyncEventDelegate> ClientDeleteObjectAsyncEventHandler =
            new(EventType.CLIENT_DELETE_OBJECT_EVENT);

        internal readonly AsyncEventHandler<GivePedScriptedTaskAsyncDelegate> GivePedScriptedTaskAsyncEventHandler =
            new(EventType.GIVE_PED_SCRIPTED_TASK);

        internal readonly AsyncEventHandler<PedDamageAsyncDelegate> PedDamageAsyncEventHandler =
            new(EventType.PED_DAMAGE);

        internal readonly AsyncEventHandler<PedDeadAsyncDelegate> PedDeadAsyncEventHandler =
            new(EventType.PED_DEATH);

        internal readonly AsyncEventHandler<PedHealAsyncDelegate> PedHealAsyncEventHandler =
            new(EventType.PED_HEAL);

        internal readonly AsyncEventHandler<PlayerStartTalkingAsyncDelegate> PlayerStartTalkingAsyncEventHandler =
            new(EventType.PLAYER_START_TALKING);

        internal readonly AsyncEventHandler<PlayerStopTalkingAsyncDelegate> PlayerStopTalkingAsyncEventHandler =
            new(EventType.PLAYER_STOP_TALKING);

        internal readonly AsyncEventHandler<ScriptRpcAsyncDelegate> ScriptRpcAsyncEventHandler =
            new(EventType.SCRIPT_RPC_EVENT);

        internal readonly AsyncEventHandler<ScriptRpcAnswerAsyncDelegate> ScriptRpcAnswerAsyncEventHandler =
            new(EventType.SCRIPT_RPC_ANSWER_EVENT);



        public AsyncCore(IntPtr nativePointer, IntPtr resourcePointer, AssemblyLoadContext assemblyLoadContext, ILibrary library, IPoolManager poolManager,
            INativeResourcePool nativeResourcePool) : base(nativePointer, resourcePointer, assemblyLoadContext, library, poolManager, nativeResourcePool)
        {
            AltAsync.Setup(this);
        }

        public override bool IsMainThread()
        {
            return AltAsync.AltVAsync.TickThread == Thread.CurrentThread || base.IsMainThread();
        }

        public override void OnCheckPointEvent(ICheckpoint checkpoint, IWorldObject entity, bool state)
        {
            base.OnCheckPointEvent(checkpoint, entity, state);
            if (!CheckpointAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await CheckpointAsyncEventHandler.CallAsync(@delegate => @delegate(checkpoint, entity, state));
            });
        }

        public override void OnPlayerDeathEvent(IPlayer player, IEntity killer, uint weapon)
        {
            base.OnPlayerDeathEvent(player, killer, weapon);
            if (!PlayerDeadAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerDeadAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, killer, weapon));
            });
        }

        public override void OnPlayerHealEvent(IPlayer player, ushort oldHealth, ushort newHealth, ushort oldArmour, ushort newArmour)
        {
            base.OnPlayerHealEvent(player, oldHealth, newHealth, oldArmour, newArmour);
            if (!PlayerHealAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerHealAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, oldHealth, newHealth, oldArmour, newArmour));
            });
        }

        public override void OnPlayerConnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerConnectEvent(player, reason);
            if (!PlayerConnectAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerConnectAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, reason));
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
            Task.Run(async () =>
            {
                await PlayerDamageAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, entity, oldHealth, oldArmor, oldMaxHealth, oldMaxArmor, weapon, healthDamage,
                        armourDamage));
            });
        }

        public override void OnExplosionEvent(IntPtr eventPointer, IPlayer sourcePlayer, ExplosionType explosionType,
            Position position,
            uint explosionFx, IEntity targetEntity)
        {
            base.OnExplosionEvent(eventPointer, sourcePlayer, explosionType, position, explosionFx, targetEntity);
            if (!ExplosionAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ExplosionAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(sourcePlayer, explosionType, position, explosionFx, targetEntity));
            });
        }

        public override void OnWeaponDamageEvent(IntPtr eventPointer, IPlayer sourcePlayer, IEntity targetEntity,
            uint weapon, ushort damage,
            Position shotOffset, BodyPart bodyPart)
        {
            base.OnWeaponDamageEvent(eventPointer, sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart);
            if (!WeaponDamageAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await WeaponDamageAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart));
            });
        }

        public override void OnPlayerChangeVehicleSeatEvent(IVehicle vehicle, IPlayer player, byte oldSeat,
            byte newSeat)
        {
            base.OnPlayerChangeVehicleSeatEvent(vehicle, player, oldSeat, newSeat);
            if (!PlayerChangeVehicleSeatAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerChangeVehicleSeatAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, oldSeat, newSeat));
            });
        }

        public override void OnPlayerEnterVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerEnterVehicleEvent(vehicle, player, seat);
            if (!PlayerEnterVehicleAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerEnterVehicleAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat));
            });
        }

        public override void OnPlayerEnteringVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerEnteringVehicleEvent(vehicle, player, seat);
            if (!PlayerEnteringVehicleAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerEnteringVehicleAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat));
            });
        }

        public override void OnPlayerLeaveVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            base.OnPlayerLeaveVehicleEvent(vehicle, player, seat);
            if (!PlayerLeaveVehicleAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerLeaveVehicleAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle, player, seat));
            });
        }

        public override void OnPlayerDisconnectEvent(IPlayer player, string reason)
        {
            base.OnPlayerDisconnectEvent(player, reason);
            if (!PlayerDisconnectAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
                {
                    await PlayerDisconnectAsyncEventHandler.CallAsync(@delegate =>
                        @delegate(player, reason));
                }
            );
        }

        public override void OnPlayerRemoveEvent(IPlayer player)
        {
            base.OnPlayerRemoveEvent(player);
            if (!PlayerRemoveAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerRemoveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player));
            });
        }

        public override void OnVehicleRemoveEvent(IVehicle vehicle)
        {
            base.OnVehicleRemoveEvent(vehicle);
            if (!VehicleRemoveAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await VehicleRemoveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle));
            });
        }

        public override void OnPedRemoveEvent(IPed ped)
        {
            base.OnPedRemoveEvent(ped);
            if (!PedRemoveAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PedRemoveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(ped));
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
                        mValues[i] = new MValueConst(this, args[i]);
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
                        var (taskPlayer, taskObjects, taskEventHandlers, taskName) =
                            (ValueTuple<IPlayer, object[], List<Function>, string>)obj;
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
                    },
                    new ValueTuple<IPlayer, object[], List<Function>, string>(player, objects,
                        eventHandlersClient,
                        name));
            }

            if (PlayerClientEventAsyncEventHandler.HasEvents())
            {
                if (mValues == null)
                {
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(this, args[i]);
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
                        var (taskPlayer, taskObjects, taskEventHandlers, taskName) =
                            (ValueTuple<IPlayer, object[], AsyncEventHandler<PlayerClientEventAsyncDelegate>, string>)
                            obj;
                        foreach (var eventHandler in taskEventHandlers.GetEvents())
                        {
                            AsyncEventHandler<PlayerClientEventAsyncDelegate>.ExecuteEventAsyncWithoutTask(eventHandler,
                                @delegate => @delegate(taskPlayer, taskName, taskObjects));
                        }
                    },
                    new ValueTuple<IPlayer, object[], AsyncEventHandler<PlayerClientEventAsyncDelegate>, string>(player,
                        objects, PlayerClientEventAsyncEventHandler, name));
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
                        mValues[i] = new MValueConst(this, args[i]);
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
                        (ValueTuple<object[], List<Function>, string>)obj;
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
                }, new ValueTuple<object[], List<Function>, string>(objects, eventHandlersServer, name));
            }
        }

        public override void OnConsoleCommandEvent(string name, string[] args)
        {
            base.OnConsoleCommandEvent(name, args);
            if (!ConsoleCommandAsyncEventHandler.HasEvents()) return;
            Task.Run(() =>
                ConsoleCommandAsyncEventHandler.CallAsyncWithoutTask(@delegate =>
                    @delegate(name, args)));
        }

        public override void OnMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            base.OnMetaDataChangeEvent(entity, key, value);
            if (!MetaDataChangeAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await MetaDataChangeAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(entity, key, value));
            });
        }

        public override void OnSyncedMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            base.OnSyncedMetaDataChangeEvent(entity, key, value);
            if (!SyncedMetaDataChangeAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await SyncedMetaDataChangeAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(entity, key, value));
            });
        }

        public override void OnColShapeEvent(IColShape colShape, IWorldObject entity, bool state)
        {
            base.OnColShapeEvent(colShape, entity, state);
            if (!ColShapeAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ColShapeAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(colShape, entity, state));
            });
        }

        public override void OnVehicleDestroyEvent(IVehicle vehicle)
        {
            base.OnVehicleDestroyEvent(vehicle);
            if (!VehicleDestroyAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await VehicleDestroyAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(vehicle));
            });
        }

        public override void OnFireEvent(IntPtr eventPointer, IPlayer player, FireInfo[] fires)
        {
            base.OnFireEvent(eventPointer, player, fires);
            if (!FireAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await FireAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, fires));
            });
        }

        public override void OnStartProjectileEvent(IntPtr eventPointer, IPlayer player, Position startPosition,
            Position direction,
            uint ammoHash, uint weaponHash)
        {
            base.OnStartProjectileEvent(eventPointer, player, startPosition, direction, ammoHash, weaponHash);
            if (!StartProjectileAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await StartProjectileAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, startPosition, direction, ammoHash, weaponHash));
            });
        }

        public override void OnPlayerWeaponChangeEvent(IntPtr eventPointer, IPlayer player, uint oldWeapon,
            uint newWeapon)
        {
            base.OnPlayerWeaponChangeEvent(eventPointer, player, oldWeapon, newWeapon);
            if (!PlayerWeaponChangeAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerWeaponChangeAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(player, oldWeapon, newWeapon));
            });
        }

        public override void OnNetOwnerChangeEvent(IEntity targetEntity, IPlayer oldPlayer, IPlayer newPlayer)
        {
            base.OnNetOwnerChangeEvent(targetEntity, oldPlayer, newPlayer);
            if (!NetOwnerChangeAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await NetOwnerChangeAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(targetEntity, oldPlayer, newPlayer));
            });
        }

        public override void OnVehicleAttachEvent(IVehicle targetVehicle, IVehicle attachedVehicle)
        {
            base.OnVehicleAttachEvent(targetVehicle, attachedVehicle);
            if (!VehicleAttachAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await VehicleAttachAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(targetVehicle, attachedVehicle));
            });
        }

        public override void OnVehicleDetachEvent(IVehicle targetVehicle, IVehicle detachedVehicle)
        {
            base.OnVehicleDetachEvent(targetVehicle, detachedVehicle);
            if (!VehicleDetachAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await VehicleDetachAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(targetVehicle, detachedVehicle));
            });
        }

        public override void OnVehicleDamageEvent(IVehicle targetVehicle, IEntity sourceEntity, uint bodyHealthDamage,
            uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weaponHash)
        {
            base.OnVehicleDamageEvent(targetVehicle, sourceEntity, bodyHealthDamage, additionalBodyHealthDamage,
                engineHealthDamage, petrolTankDamage, weaponHash);
            if (!VehicleDamageAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await VehicleDamageAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(targetVehicle, sourceEntity, bodyHealthDamage, additionalBodyHealthDamage,
                        engineHealthDamage, petrolTankDamage, weaponHash));
            });
        }

        public override void OnVehicleHornEvent(IntPtr eventPointer, IVehicle targetVehicle, IPlayer reporterPlayer, bool state)
        {
            base.OnVehicleHornEvent(eventPointer, targetVehicle, reporterPlayer, state);
            if (!VehicleHornAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await VehicleHornAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(targetVehicle, reporterPlayer, state));
            });
        }

        public override void OnConnectionQueueAddEvent(IConnectionInfo connectionInfo)
        {
            base.OnConnectionQueueAddEvent(connectionInfo);
            if (!ConnectionQueueAddAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ConnectionQueueAddAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(connectionInfo));
            });
        }

        public override void OnConnectionQueueRemoveEvent(IConnectionInfo connectionInfo)
        {
            base.OnConnectionQueueRemoveEvent(connectionInfo);
            if (!ConnectionQueueRemoveAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ConnectionQueueRemoveAsyncEventHandler.CallAsync(@delegate =>
                    @delegate(connectionInfo));
            });
        }

        public override void OnServerStartedEvent()
        {
            base.OnServerStartedEvent();
            if (!ServerStartedAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ServerStartedAsyncEventHandler.CallAsync(@delegate =>
                    @delegate());
            });
        }

        public override void OnPlayerRequestControlEvent(IntPtr eventPtr, IEntity target, IPlayer player)
        {
           base.OnPlayerRequestControlEvent(eventPtr, target, player);

           if (!PlayerRequestControlAsyncEventHandler.HasEvents()) return;
           Task.Run(async () =>
           {
               await PlayerRequestControlAsyncEventHandler.CallAsync(@delegate => @delegate(target, player));
           });
        }

        public override void OnPlayerChangeAnimationEvent(IPlayer player, uint oldDict, uint newDict, uint oldName, uint newName)
        {
            base.OnPlayerChangeAnimationEvent(player, oldDict, newDict, oldName, newName);

            if (!PlayerChangeAnimationAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerChangeAnimationAsyncEventHandler.CallAsync(@delegate => @delegate(player, oldDict, newDict, oldName, newName));
            });
        }

        public override void OnPlayerChangeInteriorEvent(IPlayer player, uint oldIntLoc, uint newIntLoc)
        {
            base.OnPlayerChangeInteriorEvent(player, oldIntLoc, newIntLoc);

            if (!PlayerChangeInteriorAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerChangeInteriorAsyncEventHandler.CallAsync(@delegate => @delegate(player, oldIntLoc, newIntLoc));
            });
        }

        public override void OnPlayerDimensionChangeEvent(IPlayer player, int oldDimension, int newDimension)
        {
            base.OnPlayerDimensionChangeEvent(player, oldDimension, newDimension);

            if (!PlayerDimensionChangeAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerDimensionChangeAsyncEventHandler.CallAsync(@delegate => @delegate(player, oldDimension, newDimension));
            });
        }

        public override void OnVehicleSirenEvent(IVehicle targetVehicle, bool state)
        {
            base.OnVehicleSirenEvent(targetVehicle, state);

            if (!VehicleSirenAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await VehicleSirenAsyncEventHandler.CallAsync(@delegate => @delegate(targetVehicle, state));
            });
        }

        public override void OnPlayerSpawnEvent(IPlayer player)
        {
            base.OnPlayerSpawnEvent(player);

            if (!PlayerSpawnAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerSpawnAsyncEventHandler.CallAsync(@delegate => @delegate(player));
            });
        }

        public override void OnRequestSyncedSceneEvent(IntPtr eventPointer, IPlayer sourcePlayer, int sceneid)
        {
            base.OnRequestSyncedSceneEvent(eventPointer, sourcePlayer, sceneid);

            if (!RequestSyncedSceneAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await RequestSyncedSceneAsyncEventHandler.CallAsync(@delegate => @delegate(sourcePlayer, sceneid));
            });
        }

        public override void OnStartSyncedSceneEvent(IPlayer sourcePlayer, int sceneid, Position position,
            Rotation rotation, uint animDictHash, Dictionary<IEntity, uint> entityAndAnimHash)
        {
            base.OnStartSyncedSceneEvent(sourcePlayer, sceneid, position, rotation, animDictHash, entityAndAnimHash);

            if (!StartSyncedSceneAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await StartSyncedSceneAsyncEventHandler.CallAsync(@delegate => @delegate(sourcePlayer, sceneid, position, rotation, animDictHash, entityAndAnimHash));
            });
        }

        public override void OnStopSyncedSceneEvent(IPlayer sourcePlayer, int sceneid)
        {
            base.OnStopSyncedSceneEvent(sourcePlayer, sceneid);

            if (!StopSyncedSceneAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await StopSyncedSceneAsyncEventHandler.CallAsync(@delegate => @delegate(sourcePlayer, sceneid));
            });
        }

        public override void OnUpdateSyncedSceneEvent(IPlayer sourcePlayer, float startRate, int sceneid)
        {
            base.OnUpdateSyncedSceneEvent(sourcePlayer, startRate, sceneid);

            if (!UpdateSyncedSceneAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await UpdateSyncedSceneAsyncEventHandler.CallAsync(@delegate => @delegate(sourcePlayer, startRate, sceneid));
            });
        }

        public override void OnClientRequestObjectEvent(IntPtr eventPointer, IPlayer sourcePlayer, uint model, Position position)
        {
            base.OnClientRequestObjectEvent(eventPointer, sourcePlayer, model, position);

            if (!ClientRequestObjectAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ClientRequestObjectAsyncEventHandler.CallAsync(@delegate => @delegate(sourcePlayer, model, position));
            });
        }

        public override void OnClientDeleteObjectEvent(IntPtr eventPointer, IPlayer sourcePlayer)
        {
            base.OnClientDeleteObjectEvent(eventPointer, sourcePlayer);

            if (!ClientDeleteObjectAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ClientDeleteObjectAsyncEventHandler.CallAsync(@delegate => @delegate(sourcePlayer));
            });
        }

        public override void OnGivePedScriptedTaskEvent(IntPtr eventPointer, IPlayer sourcePlayer, IPed sourcePed, uint taskType)
        {
            base.OnGivePedScriptedTaskEvent(eventPointer, sourcePlayer, sourcePed, taskType);

            if (!GivePedScriptedTaskAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await GivePedScriptedTaskAsyncEventHandler.CallAsync(@delegate => @delegate(sourcePlayer, sourcePed, taskType));
            });
        }

        public override void OnPlayerConnectDeniedEvent(PlayerConnectDeniedReason reason, string name, string ip, ulong passwordHash,
            bool isDebug, string branch, ushort versionMajor, ushort versionMinor, string cdnUrl, long discordId)
        {
            base.OnPlayerConnectDeniedEvent(reason, name, ip, passwordHash, isDebug, branch, versionMajor, versionMinor, cdnUrl, discordId);

            if (!PlayerConnectDeniedAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerConnectDeniedAsyncEventHandler.CallAsync(@delegate => @delegate(reason, name, ip, passwordHash, isDebug, branch, versionMajor, versionMinor, cdnUrl, discordId));
            });
        }

        public override void OnResourceStartEvent(INativeResource resource)
        {
            base.OnResourceStartEvent(resource);

            if (!ResourceStartAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ResourceStartAsyncEventHandler.CallAsync(@delegate => @delegate(resource));
            });
        }

        public override void OnResourceStopEvent(INativeResource resource)
        {
            base.OnResourceStopEvent(resource);

            if (!ResourceStopAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ResourceStopAsyncEventHandler.CallAsync(@delegate => @delegate(resource));
            });
        }

        public override void OnResourceErrorEvent(INativeResource resource)
        {
            base.OnResourceErrorEvent(resource);

            if (!ResourceErrorAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ResourceErrorAsyncEventHandler.CallAsync(@delegate => @delegate(resource));
            });
        }

        public override void OnPedDamageEvent(IPed ped, IEntity attacker, uint weapon, ushort healthDamage, ushort armourDamage)
        {
            base.OnPedDamageEvent(ped, attacker, weapon, healthDamage, armourDamage);

            if (!PedDamageAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PedDamageAsyncEventHandler.CallAsync(@delegate => @delegate(ped, attacker, weapon, healthDamage, armourDamage));
            });
        }

        public override void OnPedDeathEvent(IPed ped, IEntity killer, uint weapon)
        {
            base.OnPedDeathEvent(ped, killer, weapon);

            if (!PedDeadAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PedDeadAsyncEventHandler.CallAsync(@delegate => @delegate(ped, killer, weapon));
            });
        }

        public override void OnPedHealEvent(IPed ped, ushort oldHealth, ushort newHealth, ushort oldArmour, ushort newArmour)
        {
            base.OnPedHealEvent(ped, oldHealth, newHealth, oldArmour, newArmour);

            if (!PedHealAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PedHealAsyncEventHandler.CallAsync(@delegate => @delegate(ped, oldHealth, newHealth, oldArmour, newArmour));
            });
        }

        public override void OnPlayerStartTalkingEvent(IPlayer player)
        {
            base.OnPlayerStartTalkingEvent(player);

            if (!PlayerStartTalkingAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerStartTalkingAsyncEventHandler.CallAsync(@delegate => @delegate(player));
            });
        }

        public override void OnPlayerStopTalkingEvent(IPlayer player)
        {
            base.OnPlayerStopTalkingEvent(player);

            if (!PlayerStopTalkingAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await PlayerStopTalkingAsyncEventHandler.CallAsync(@delegate => @delegate(player));
            });
        }

        public override void OnScriptRPCEvent(IntPtr eventpointer, IPlayer target, string name, IntPtr[] args, ushort answerId, bool async)
        {
            if (!UnansweredServerRpcRequest.Contains(answerId))
            {
                UnansweredServerRpcRequest.Add(answerId);
            }
            base.OnScriptRPCEvent(eventpointer, target, name, args, answerId, true);

            if (UnansweredServerRpcRequest.Contains(answerId))
            {
                unsafe
                {
                    Library.Shared.Event_ScriptRPCEvent_WillAnswer(eventpointer);
                }
            }

            if (!ScriptRpcAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                var mValues = MValueConst.CreateFrom(this, args);
                var clientScriptRPCEvent = new AsyncScriptRpcEvent(target, answerId);
                await ScriptRpcAsyncEventHandler.CallAsync(@delegate => @delegate(clientScriptRPCEvent, target, name, mValues.Select(x => x.ToObject()).ToArray(), answerId));
            });

            if (UnansweredServerRpcRequest.Contains(answerId))
            {
                target.EmitRPCAnswer(answerId, null, "Answer not handled");
                UnansweredServerRpcRequest.Remove(answerId);
            }
        }

        public override void OnScriptAnswerRPCEvent(IPlayer target, ushort answerid, IntPtr mValue, string answererror)
        {
            base.OnScriptAnswerRPCEvent(target, answerid, mValue, answererror);

            if (!ScriptRpcAnswerAsyncEventHandler.HasEvents()) return;
            Task.Run(async () =>
            {
                await ScriptRpcAnswerAsyncEventHandler.CallAsync(@delegate => @delegate(target, answerid, mValue, answererror));
            });
        }

        public new Function OnClient(string eventName, Function function)
        {
            if (function == null)
            {
                Alt.LogWarning("Failed to register client event " + eventName + ": function is null");
                return null;
            }
            if (asyncEventBusClient.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new List<Function> { function };
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
            if (function == null)
            {
                Alt.LogWarning("Failed to register server event " + eventName + ": function is null");
                return null;
            }
            if (asyncEventBusServer.TryGetValue(eventName, out var eventHandlersForEvent))
            {
                eventHandlersForEvent.Add(function);
            }
            else
            {
                eventHandlersForEvent = new List<Function> { function };
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
    }
}