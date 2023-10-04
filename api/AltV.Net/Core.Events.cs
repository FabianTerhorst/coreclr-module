using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;
using AltV.Net.FunctionParser;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Events;

namespace AltV.Net
{
    public partial class Core
    {
        internal readonly IEventHandler<CheckpointDelegate> CheckpointEventHandler =
            new HashSetEventHandler<CheckpointDelegate>(EventType.COLSHAPE_EVENT);

        internal readonly IEventHandler<PlayerConnectDelegate> PlayerConnectEventHandler =
            new HashSetEventHandler<PlayerConnectDelegate>(EventType.PLAYER_CONNECT);

        internal readonly IEventHandler<PlayerConnectDeniedDelegate> PlayerConnectDeniedEventHandler =
            new HashSetEventHandler<PlayerConnectDeniedDelegate>(EventType.PLAYER_CONNECT_DENIED);

        internal readonly IEventHandler<ResourceEventDelegate> ResourceStartEventHandler =
            new HashSetEventHandler<ResourceEventDelegate>(EventType.RESOURCE_START);

        internal readonly IEventHandler<ResourceEventDelegate> ResourceStopEventHandler =
            new HashSetEventHandler<ResourceEventDelegate>(EventType.RESOURCE_STOP);

        internal readonly IEventHandler<ResourceEventDelegate> ResourceErrorEventHandler =
            new HashSetEventHandler<ResourceEventDelegate>(EventType.RESOURCE_ERROR);

        internal readonly IEventHandler<PlayerDamageDelegate> PlayerDamageEventHandler =
            new HashSetEventHandler<PlayerDamageDelegate>(EventType.PLAYER_DAMAGE);

        internal readonly IEventHandler<PlayerDeadDelegate> PlayerDeadEventHandler =
            new HashSetEventHandler<PlayerDeadDelegate>(EventType.PLAYER_DEATH);

        internal readonly IEventHandler<PlayerHealDelegate> PlayerHealEventHandler =
            new HashSetEventHandler<PlayerHealDelegate>(EventType.PLAYER_HEAL);

        internal readonly IEventHandler<ExplosionDelegate> ExplosionEventHandler =
            new HashSetEventHandler<ExplosionDelegate>(EventType.EXPLOSION_EVENT);

        internal readonly IEventHandler<WeaponDamageDelegate> WeaponDamageEventHandler =
            new HashSetEventHandler<WeaponDamageDelegate>(EventType.WEAPON_DAMAGE_EVENT);

        internal readonly IEventHandler<PlayerChangeVehicleSeatDelegate> PlayerChangeVehicleSeatEventHandler =
            new HashSetEventHandler<PlayerChangeVehicleSeatDelegate>(EventType.PLAYER_CHANGE_VEHICLE_SEAT);

        internal readonly IEventHandler<PlayerEnterVehicleDelegate> PlayerEnterVehicleEventHandler =
            new HashSetEventHandler<PlayerEnterVehicleDelegate>(EventType.PLAYER_ENTER_VEHICLE);

        internal readonly IEventHandler<PlayerEnteringVehicleDelegate> PlayerEnteringVehicleEventHandler =
            new HashSetEventHandler<PlayerEnteringVehicleDelegate>(EventType.PLAYER_ENTERING_VEHICLE);

        internal readonly IEventHandler<PlayerLeaveVehicleDelegate> PlayerLeaveVehicleEventHandler =
            new HashSetEventHandler<PlayerLeaveVehicleDelegate>(EventType.PLAYER_LEAVE_VEHICLE);

        internal readonly IEventHandler<PlayerDisconnectDelegate> PlayerDisconnectEventHandler =
            new HashSetEventHandler<PlayerDisconnectDelegate>(EventType.PLAYER_DISCONNECT);

        internal readonly IEventHandler<PlayerRemoveDelegate> PlayerRemoveEventHandler =
            new HashSetEventHandler<PlayerRemoveDelegate>();

        internal readonly IEventHandler<VehicleRemoveDelegate> VehicleRemoveEventHandler =
            new HashSetEventHandler<VehicleRemoveDelegate>();

        internal readonly IEventHandler<PedRemoveDelegate> PedRemoveEventHandler =
            new HashSetEventHandler<PedRemoveDelegate>();

        internal readonly IEventHandler<ConsoleCommandDelegate> ConsoleCommandEventHandler =
            new HashSetEventHandler<ConsoleCommandDelegate>(EventType.CONSOLE_COMMAND_EVENT);

        internal readonly IEventHandler<MetaDataChangeDelegate> MetaDataChangeEventHandler =
            new HashSetEventHandler<MetaDataChangeDelegate>(EventType.META_CHANGE);

        internal readonly IEventHandler<MetaDataChangeDelegate> SyncedMetaDataChangeEventHandler =
            new HashSetEventHandler<MetaDataChangeDelegate>(EventType.SYNCED_META_CHANGE);

        internal readonly IEventHandler<ColShapeDelegate> ColShapeEventHandler =
            new HashSetEventHandler<ColShapeDelegate>(EventType.COLSHAPE_EVENT);

        internal readonly IEventHandler<VehicleDestroyDelegate> VehicleDestroyEventHandler =
            new HashSetEventHandler<VehicleDestroyDelegate>(EventType.VEHICLE_DESTROY);

        internal readonly IEventHandler<FireDelegate> FireEventHandler =
            new HashSetEventHandler<FireDelegate>(EventType.FIRE_EVENT);

        internal readonly IEventHandler<StartProjectileDelegate> StartProjectileEventHandler =
            new HashSetEventHandler<StartProjectileDelegate>(EventType.START_PROJECTILE_EVENT);

        internal readonly IEventHandler<PlayerWeaponChangeDelegate> PlayerWeaponChangeEventHandler =
            new HashSetEventHandler<PlayerWeaponChangeDelegate>(EventType.PLAYER_WEAPON_CHANGE);

        internal readonly IEventHandler<NetOwnerChangeDelegate> NetOwnerChangeEventHandler =
            new HashSetEventHandler<NetOwnerChangeDelegate>(EventType.NETOWNER_CHANGE);

        internal readonly IEventHandler<VehicleAttachDelegate> VehicleAttachEventHandler =
            new HashSetEventHandler<VehicleAttachDelegate>(EventType.VEHICLE_ATTACH);

        internal readonly IEventHandler<VehicleDetachDelegate> VehicleDetachEventHandler =
            new HashSetEventHandler<VehicleDetachDelegate>(EventType.VEHICLE_DETACH);

        internal readonly IEventHandler<VehicleDamageDelegate> VehicleDamageEventHandler =
            new HashSetEventHandler<VehicleDamageDelegate>(EventType.VEHICLE_DAMAGE);

        internal readonly IEventHandler<VehicleHornDelegate> VehicleHornEventHandler =
            new HashSetEventHandler<VehicleHornDelegate>(EventType.VEHICLE_HORN);

        internal readonly IEventHandler<ConnectionQueueAddDelegate> ConnectionQueueAddHandler =
            new HashSetEventHandler<ConnectionQueueAddDelegate>(EventType.CONNECTION_QUEUE_ADD);

        internal readonly IEventHandler<ConnectionQueueRemoveDelegate> ConnectionQueueRemoveHandler =
            new HashSetEventHandler<ConnectionQueueRemoveDelegate>(EventType.CONNECTION_QUEUE_REMOVE);

        internal readonly IEventHandler<ServerStartedDelegate> ServerStartedHandler =
            new HashSetEventHandler<ServerStartedDelegate>(EventType.SERVER_STARTED);

        internal readonly IEventHandler<PlayerRequestControlDelegate> PlayerRequestControlHandler =
            new HashSetEventHandler<PlayerRequestControlDelegate>(EventType.PLAYER_REQUEST_CONTROL);

        internal readonly IEventHandler<PlayerChangeAnimationDelegate> PlayerChangeAnimationHandler =
            new HashSetEventHandler<PlayerChangeAnimationDelegate>(EventType.PLAYER_CHANGE_ANIMATION_EVENT);

        internal readonly IEventHandler<PlayerChangeInteriorDelegate> PlayerChangeInteriorHandler =
            new HashSetEventHandler<PlayerChangeInteriorDelegate>(EventType.PLAYER_CHANGE_INTERIOR_EVENT);

        internal readonly IEventHandler<PlayerDimensionChangeDelegate> PlayerDimensionChangeHandler =
            new HashSetEventHandler<PlayerDimensionChangeDelegate>(EventType.PLAYER_DIMENSION_CHANGE);

        internal readonly IEventHandler<VehicleSirenDelegate> VehicleSirenHandler =
            new HashSetEventHandler<VehicleSirenDelegate>(EventType.VEHICLE_SIREN);

        internal readonly IEventHandler<PlayerSpawnDelegate> PlayerSpawnHandler =
            new HashSetEventHandler<PlayerSpawnDelegate>(EventType.PLAYER_SPAWN);

        internal readonly IEventHandler<RequestSyncedSceneDelegate> RequestSyncedSceneHandler =
            new HashSetEventHandler<RequestSyncedSceneDelegate>(EventType.REQUEST_SYNCED_SCENE);

        internal readonly IEventHandler<StartSyncedSceneDelegate> StartSyncedSceneHandler =
            new HashSetEventHandler<StartSyncedSceneDelegate>(EventType.START_SYNCED_SCENE);

        internal readonly IEventHandler<StopSyncedSceneDelegate> StopSyncedSceneHandler =
            new HashSetEventHandler<StopSyncedSceneDelegate>(EventType.STOP_SYNCED_SCENE);

        internal readonly IEventHandler<UpdateSyncedSceneDelegate> UpdateSyncedSceneHandler =
            new HashSetEventHandler<UpdateSyncedSceneDelegate>(EventType.UPDATE_SYNCED_SCENE);

        internal readonly IEventHandler<ClientRequestObjectDelegate> ClientRequestObjectHandler =
            new HashSetEventHandler<ClientRequestObjectDelegate>(EventType.CLIENT_REQUEST_OBJECT_EVENT);

        internal readonly IEventHandler<ClientDeleteObjectDelegate> ClientDeleteObjectHandler =
            new HashSetEventHandler<ClientDeleteObjectDelegate>(EventType.CLIENT_DELETE_OBJECT_EVENT);

        internal readonly IEventHandler<GivePedScriptedTaskDelegate> GivePedScriptedTaskHandler =
            new HashSetEventHandler<GivePedScriptedTaskDelegate>(EventType.GIVE_PED_SCRIPTED_TASK);

        internal readonly IEventHandler<PedDamageDelegate> PedDamageEventHandler =
            new HashSetEventHandler<PedDamageDelegate>(EventType.PED_DAMAGE);

        internal readonly IEventHandler<PedDeadDelegate> PedDeadEventHandler =
            new HashSetEventHandler<PedDeadDelegate>(EventType.PED_DEATH);

        internal readonly IEventHandler<PedHealDelegate> PedHealEventHandler =
            new HashSetEventHandler<PedHealDelegate>(EventType.PED_HEAL);

        internal readonly IEventHandler<PlayerStartTalkingDelegate> PlayerStartTalkingHandler =
            new HashSetEventHandler<PlayerStartTalkingDelegate>(EventType.PLAYER_START_TALKING);

        internal readonly IEventHandler<PlayerStopTalkingDelegate> PlayerStopTalkingHandler =
            new HashSetEventHandler<PlayerStopTalkingDelegate>(EventType.PLAYER_STOP_TALKING);

        internal readonly IEventHandler<ScriptRpcDelegate> ScriptRpcHandler =
            new HashSetEventHandler<ScriptRpcDelegate>(EventType.SCRIPT_RPC_EVENT);

        internal readonly IEventHandler<ScriptRpcAnswerDelegate> ScriptRpcAnswerHandler =
            new HashSetEventHandler<ScriptRpcAnswerDelegate>(EventType.SCRIPT_RPC_ANSWER_EVENT);

        public void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, BaseObjectType baseObjectType,
            bool state)
        {
            var checkpoint = PoolManager.Checkpoint.Get(checkpointPointer);
            if (checkpoint == null)
            {
                Console.WriteLine("OnCheckpoint Invalid checkpoint " + checkpointPointer + " " + entityPointer + " " +
                                  baseObjectType + " " + state);
                return;
            }

            var entity = (IWorldObject)PoolManager.Get(entityPointer, baseObjectType);

            if (entity is null)
            {
                Console.WriteLine("OnCheckpoint Invalid entity " + checkpointPointer + " " + entityPointer + " " +
                                  baseObjectType + " " + state);
                return;
            }

            OnCheckPointEvent(checkpoint, entity, state);
        }

        public virtual void OnCheckPointEvent(ICheckpoint checkpoint, IWorldObject entity, bool state)
        {
            foreach (var @delegate in CheckpointEventHandler.GetEvents())
            {
                try
                {
                    @delegate(checkpoint, entity, state);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnCheckPointEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnCheckPointEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerConnect(IntPtr playerPointer, string reason)
        {
            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerConnect Invalid player " + playerPointer + " " +
                                  reason);
                return;
            }

            OnPlayerConnectEvent(player, reason);
        }

        public virtual void OnPlayerConnectEvent(IPlayer player, string reason)
        {
            foreach (var @delegate in PlayerConnectEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, reason);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerConnectEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerConnectEvent" + ":" + exception);
                }
            }
        }

        public void onPlayerConnectDenied(PlayerConnectDeniedReason reason, string name, string ip, ulong passwordHash,
            bool isDebug, string branch, uint majorVersion, string cdnUrl, long discordId)
        {
            onPlayerConnectDeniedEvent(reason, name, ip, passwordHash, isDebug, branch, majorVersion, cdnUrl,
                discordId);
        }


        public virtual void onPlayerConnectDeniedEvent(PlayerConnectDeniedReason reason, string name, string ip,
            ulong passwordHash, bool isDebug, string branch, uint majorVersion, string cdnUrl, long discordId)
        {
            foreach (var @delegate in PlayerConnectDeniedEventHandler.GetEvents())
            {
                try
                {
                    @delegate(reason, name, ip, passwordHash, isDebug, branch, majorVersion, cdnUrl, discordId);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "onPlayerConnectDeniedEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "onPlayerConnectDeniedEvent" + ":" + exception);
                }
            }
        }

        public void OnResourceStart(IntPtr resourcePointer)
        {
            var resource = GetResource(resourcePointer);
            if (resource == null) return;
            OnResourceStartEvent(resource);
        }

        public virtual void OnResourceStartEvent(INativeResource resource)
        {
            foreach (var @delegate in ResourceStartEventHandler.GetEvents())
            {
                try
                {
                    @delegate(resource);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnResourceStartEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnResourceStartEvent" + ":" + exception);
                }
            }
        }

        public void OnResourceStop(IntPtr resourcePointer)
        {
            var resource = GetResource(resourcePointer);
            if (resource == null) return;
            OnResourceStopEvent(resource);
        }

        public virtual void OnResourceStopEvent(INativeResource resource)
        {
            foreach (var @delegate in ResourceStopEventHandler.GetEvents())
            {
                try
                {
                    @delegate(resource);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnResourceStopEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnResourceStopEvent" + ":" + exception);
                }
            }
        }

        public void OnResourceError(IntPtr resourcePointer)
        {
            var resource = GetResource(resourcePointer);
            if (resource == null) return;
            OnResourceErrorEvent(resource);
        }

        public virtual void OnResourceErrorEvent(INativeResource resource)
        {
            foreach (var @delegate in ResourceErrorEventHandler.GetEvents())
            {
                try
                {
                    @delegate(resource);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnResourceErrorEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnResourceErrorEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer,
            BaseObjectType attackerBaseObjectType, uint weapon, ushort healthDamage, ushort armourDamage)
        {
            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerDamage Invalid player " + playerPointer + " " + attackerEntityPointer + " " +
                                  attackerBaseObjectType + " " + weapon + " " + healthDamage +
                                  " " + armourDamage);
                return;
            }

            var attacker = (IEntity)PoolManager.Get(attackerEntityPointer, attackerBaseObjectType);

            OnPlayerDamageEvent(player, attacker, weapon, healthDamage, armourDamage);
        }

        public virtual void OnPlayerDamageEvent(IPlayer player, IEntity attacker, uint weapon, ushort healthDamage,
            ushort armourDamage)
        {
            foreach (var @delegate in PlayerDamageEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, attacker, weapon, healthDamage, armourDamage);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDamageEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDamageEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerDeath(IntPtr playerPointer, IntPtr killerEntityPointer, BaseObjectType killerBaseObjectType,
            uint weapon)
        {
            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerDeath Invalid player " + playerPointer + " " + killerEntityPointer + " " +
                                  killerBaseObjectType + " " + weapon);
                return;
            }

            var killer = (IEntity)PoolManager.Get(killerEntityPointer, killerBaseObjectType);

            OnPlayerDeathEvent(player, killer, weapon);
        }

        public virtual void OnPlayerDeathEvent(IPlayer player, IEntity killer, uint weapon)
        {
            foreach (var @delegate in PlayerDeadEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, killer, weapon);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDeathEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDeathEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerHeal(IntPtr playerPointer, ushort oldHealth, ushort newHealth, ushort oldArmour,
            ushort newArmour)
        {
            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerHeal Invalid player " + playerPointer + " " + oldHealth + " " +
                                  newHealth + " " + oldArmour + " " + newArmour);
                return;
            }

            OnPlayerHealEvent(player, oldHealth, newHealth, oldArmour, newArmour);
        }

        public virtual void OnPlayerHealEvent(IPlayer player, ushort oldHealth, ushort newHealth, ushort oldArmour,
            ushort newArmour)
        {
            foreach (var @delegate in PlayerHealEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, oldHealth, newHealth, oldArmour, newArmour);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerHealEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerHealEvent" + ":" + exception);
                }
            }
        }

        public void OnExplosion(IntPtr eventPointer, IntPtr playerPointer, ExplosionType explosionType,
            Position position, uint explosionFx, IntPtr targetEntityPointer, BaseObjectType targetEntityType)
        {
            var sourcePlayer = PoolManager.Player.Get(playerPointer);
            if (sourcePlayer == null)
            {
                Console.WriteLine("OnExplosion Invalid player " + playerPointer + " " + explosionType + " " +
                                  position + " " + explosionFx);
                return;
            }

            var targetEntity = (IEntity)PoolManager.Get(targetEntityPointer, targetEntityType);

            OnExplosionEvent(eventPointer, sourcePlayer, explosionType, position, explosionFx, targetEntity);
        }

        public virtual void OnExplosionEvent(IntPtr eventPointer, IPlayer sourcePlayer, ExplosionType explosionType,
            Position position,
            uint explosionFx, IEntity targetEntity)
        {
            var cancel = false;
            foreach (var @delegate in ExplosionEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(sourcePlayer, explosionType, position, explosionFx, targetEntity))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnExplosionEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnExplosionEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnWeaponDamage(IntPtr eventPointer, IntPtr playerPointer, IntPtr entityPointer,
            BaseObjectType entityType, uint weapon,
            ushort damage, Position shotOffset, BodyPart bodyPart)
        {
            var sourcePlayer = PoolManager.Player.Get(playerPointer);
            if (sourcePlayer == null)
            {
                Console.WriteLine("OnWeaponDamage Invalid player " + playerPointer + " " + entityPointer + " " +
                                  entityType + " " + weapon + " " + damage + " " + shotOffset + " " + bodyPart);
                return;
            }

            var targetEntity = (IEntity)PoolManager.Get(entityPointer, entityType);

            OnWeaponDamageEvent(eventPointer, sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart);
        }

        public virtual void OnWeaponDamageEvent(IntPtr eventPointer, IPlayer sourcePlayer, IEntity targetEntity,
            uint weapon, ushort damage,
            Position shotOffset, BodyPart bodyPart)
        {
            uint? weaponDamage = null;
            var cancel = false;
            foreach (var @delegate in WeaponDamageEventHandler.GetEvents())
            {
                try
                {
                    var result = @delegate(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart);

                    if (!result.notCancel)
                    {
                        cancel = true;
                    }

                    if (result.Damage.HasValue)
                    {
                        weaponDamage ??= result.Damage.Value;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnWeaponDamageEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnWeaponDamageEvent" + ":" + exception);
                }
            }

            if (weaponDamage is not null)
            {
                unsafe
                {
                    Alt.Core.Library.Server.Event_WeaponDamageEvent_SetDamageValue(eventPointer, weaponDamage.Value);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnPlayerChangeVehicleSeat(IntPtr vehiclePointer, IntPtr playerPointer, byte oldSeat,
            byte newSeat)
        {
            var vehicle = PoolManager.Vehicle.Get(vehiclePointer);
            if (vehicle == null)
            {
                Console.WriteLine("OnPlayerChangeVehicleSeat Invalid vehicle " + vehiclePointer + " " + playerPointer +
                                  " " +
                                  oldSeat + " " + newSeat);
                return;
            }

            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerChangeVehicleSeat Invalid player " + vehiclePointer + " " + playerPointer +
                                  " " +
                                  oldSeat + " " + newSeat);
                return;
            }

            if (VehiclePassengers.TryGetValue(vehiclePointer, out var passengers))
            {
                if (passengers.Exists(x => x.PlayerPointer == playerPointer))
                {
                    var playerSeat = passengers.First(x => x.PlayerPointer == playerPointer);
                    playerSeat.Seat = newSeat;
                }
                else
                {
                    passengers.Add(new InternalPlayerSeat { PlayerPointer = playerPointer, Seat = newSeat });
                }
            }
            else
            {
                VehiclePassengers[vehiclePointer] = new List<InternalPlayerSeat>
                    { new() { PlayerPointer = playerPointer, Seat = newSeat } };
            }

            OnPlayerChangeVehicleSeatEvent(vehicle, player, oldSeat, newSeat);
        }

        public virtual void OnPlayerChangeVehicleSeatEvent(IVehicle vehicle, IPlayer player, byte oldSeat, byte newSeat)
        {
            foreach (var @delegate in PlayerChangeVehicleSeatEventHandler.GetEvents())
            {
                try
                {
                    @delegate(vehicle, player, oldSeat, newSeat);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerChangeVehicleSeatEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerChangeVehicleSeatEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerEnterVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            var vehicle = PoolManager.Vehicle.Get(vehiclePointer);
            if (vehicle == null)
            {
                Console.WriteLine("OnPlayerEnterVehicle Invalid vehicle " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerEnterVehicle Invalid player " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            if (VehiclePassengers.TryGetValue(vehiclePointer, out var passengers))
            {
                if (passengers.Exists(x => x.PlayerPointer == playerPointer))
                {
                    var playerSeat = passengers.First(x => x.PlayerPointer == playerPointer);
                    playerSeat.Seat = seat;
                }
                else
                {
                    passengers.Add(new InternalPlayerSeat { PlayerPointer = playerPointer, Seat = seat });
                }
            }
            else
            {
                VehiclePassengers[vehiclePointer] = new List<InternalPlayerSeat>
                    { new() { PlayerPointer = playerPointer, Seat = seat } };
            }

            OnPlayerEnterVehicleEvent(vehicle, player, seat);
        }

        public virtual void OnPlayerEnterVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            foreach (var @delegate in PlayerEnterVehicleEventHandler.GetEvents())
            {
                try
                {
                    @delegate(vehicle, player, seat);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerEnterVehicleEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerEnterVehicleEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerEnteringVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            var vehicle = PoolManager.Vehicle.Get(vehiclePointer);
            if (vehicle == null)
            {
                Console.WriteLine("OnPlayerEnteringVehicle Invalid vehicle " + vehiclePointer + " " + playerPointer +
                                  " " + seat);
                return;
            }

            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerEnteringVehicle Invalid player " + vehiclePointer + " " + playerPointer +
                                  " " + seat);
                return;
            }

            if (VehiclePassengers.TryGetValue(vehiclePointer, out var passengers))
            {
                if (passengers.Exists(x => x.PlayerPointer == playerPointer))
                {
                    var playerSeat = passengers.First(x => x.PlayerPointer == playerPointer);
                    playerSeat.Seat = seat;
                }
                else
                {
                    passengers.Add(new InternalPlayerSeat { PlayerPointer = playerPointer, Seat = seat });
                }
            }
            else
            {
                VehiclePassengers[vehiclePointer] = new List<InternalPlayerSeat>
                    { new() { PlayerPointer = playerPointer, Seat = seat } };
            }

            OnPlayerEnteringVehicleEvent(vehicle, player, seat);
        }

        public virtual void OnPlayerEnteringVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            foreach (var @delegate in PlayerEnteringVehicleEventHandler.GetEvents())
            {
                try
                {
                    @delegate(vehicle, player, seat);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerEnteringVehicleEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerEnteringVehicleEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerLeaveVehicle(IntPtr vehiclePointer, IntPtr playerPointer, byte seat)
        {
            var vehicle = PoolManager.Vehicle.Get(vehiclePointer);
            if (vehicle == null)
            {
                Console.WriteLine("OnPlayerLeaveVehicle Invalid vehicle " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerLeaveVehicle Invalid player " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            if (VehiclePassengers.TryGetValue(vehiclePointer, out var passengers))
            {
                if (passengers.Exists(x => x.PlayerPointer == playerPointer))
                {
                    var playerSeat = passengers.First(x => x.PlayerPointer == playerPointer);
                    passengers.Remove(playerSeat);
                }

                if (!passengers.Any())
                {
                    VehiclePassengers.Remove(vehiclePointer);
                }
            }

            OnPlayerLeaveVehicleEvent(vehicle, player, seat);
        }

        public virtual void OnPlayerLeaveVehicleEvent(IVehicle vehicle, IPlayer player, byte seat)
        {
            foreach (var @delegate in PlayerLeaveVehicleEventHandler.GetEvents())
            {
                try
                {
                    @delegate(vehicle, player, seat);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerLeaveVehicleEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerLeaveVehicleEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerDisconnect Invalid player " + playerPointer + " " + reason);
                return;
            }

            OnPlayerDisconnectEvent(player, reason);
        }

        public virtual void OnPlayerDisconnectEvent(IPlayer player, string reason)
        {
            foreach (var @delegate in PlayerDisconnectEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, reason);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDisconnectEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDisconnectEvent" + ":" + exception);
                }
            }
        }

        public void OnConsoleCommand(string name, string[] args)
        {
            if (ConsoleCommandEventHandler.HasEvents())
            {
                foreach (var eventHandler in ConsoleCommandEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(name, args);
                    }
                    catch (TargetInvocationException exception)
                    {
                        Alt.Log("exception at event:" + "OnConsoleCommand" + ":" + exception.InnerException);
                    }
                    catch (Exception exception)
                    {
                        Alt.Log("exception at event:" + "OnConsoleCommand" + ":" + exception);
                    }
                }
            }

            OnConsoleCommandEvent(name, args);
        }

        public virtual void OnConsoleCommandEvent(string name, string[] args)
        {
        }

        public void OnMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            IntPtr value)
        {
            var entity = (IEntity)PoolManager.Get(entityPointer, entityType);
            if (entity is null)
            {
                Console.WriteLine("OnMetaDataChange Invalid entity " + entityPointer + " " + entityType + " " + key +
                                  " " + value);
                return;
            }

            OnMetaDataChangeEvent(entity, key, new MValueConst(this, value).ToObject());
        }

        public virtual void OnMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            if (!MetaDataChangeEventHandler.HasEvents()) return;
            foreach (var eventHandler in MetaDataChangeEventHandler.GetEvents())
            {
                try
                {
                    eventHandler(entity, key, value);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnMetaDataChangeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnMetaDataChangeEvent" + ":" + exception);
                }
            }
        }

        public void OnSyncedMetaDataChange(IntPtr entityPointer, BaseObjectType entityType, string key,
            IntPtr value)
        {
            var entity = (IEntity)PoolManager.Get(entityPointer, entityType);
            if (entity is null)
            {
                Console.WriteLine("OnSyncedMetaDataChange Invalid entity " + entityPointer + " " + entityType + " " +
                                  key + " " + value);
                return;
            }

            OnSyncedMetaDataChangeEvent(entity, key, new MValueConst(this, value).ToObject());
        }

        public virtual void OnSyncedMetaDataChangeEvent(IEntity entity, string key, object value)
        {
            if (!SyncedMetaDataChangeEventHandler.HasEvents()) return;
            foreach (var eventHandler in SyncedMetaDataChangeEventHandler.GetEvents())
            {
                try
                {
                    eventHandler(entity, key, value);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnSyncedMetaDataChangeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnSyncedMetaDataChangeEvent" + ":" + exception);
                }
            }
        }

        public void OnColShape(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType,
            bool state)
        {
            var colShape = PoolManager.ColShape.Get(colShapePointer);
            if (colShape == null)
            {
                Console.WriteLine("OnColShape Invalid colshape " + colShapePointer + " " + targetEntityPointer + " " +
                                  entityType + " " + state);
                return;
            }

            var entity = (IWorldObject)PoolManager.Get(targetEntityPointer, entityType);

            if (entity is null)
            {
                Console.WriteLine("OnColShape Invalid entity " + colShapePointer + " " + targetEntityPointer + " " +
                                  entityType + " " + state);
                return;
            }

            OnColShapeEvent(colShape, entity, state);
        }

        public virtual void OnColShapeEvent(IColShape colShape, IWorldObject entity, bool state)
        {
            if (!ColShapeEventHandler.HasEvents()) return;
            foreach (var eventHandler in ColShapeEventHandler.GetEvents())
            {
                try
                {
                    eventHandler(colShape, entity, state);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnColShapeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnColShapeEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleDestroy(IntPtr vehiclePointer)
        {
            var vehicle = PoolManager.Vehicle.Get(vehiclePointer);
            if (vehicle == null)
            {
                Console.WriteLine("OnVehicleDestroy Invalid vehicle " + vehiclePointer);
                return;
            }

            OnVehicleDestroyEvent(vehicle);
        }

        public virtual void OnVehicleDestroyEvent(IVehicle vehicle)
        {
            if (!VehicleDestroyEventHandler.HasEvents()) return;
            foreach (var eventHandler in VehicleDestroyEventHandler.GetEvents())
            {
                try
                {
                    eventHandler(vehicle);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDestroyEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDestroyEvent" + ":" + exception);
                }
            }
        }

        public void OnFire(IntPtr eventPointer, IntPtr playerPointer, FireInfo[] fires)
        {
            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnFire Invalid player " + playerPointer);
                return;
            }

            OnFireEvent(eventPointer, player, fires);
        }

        public virtual void OnFireEvent(IntPtr eventPointer, IPlayer player, FireInfo[] fires)
        {
            if (!FireEventHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in FireEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(player, fires))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnFireEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnFireEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnStartProjectile(IntPtr eventPointer, IntPtr sourcePlayerPointer, Position startPosition,
            Position direction, uint ammoHash, uint weaponHash)
        {
            var player = PoolManager.Player.Get(sourcePlayerPointer);
            if (player == null)
            {
                Console.WriteLine("OnStartProjectile Invalid player " + sourcePlayerPointer);
                return;
            }

            OnStartProjectileEvent(eventPointer, player, startPosition, direction, ammoHash, weaponHash);
        }

        public virtual void OnStartProjectileEvent(IntPtr eventPointer, IPlayer player, Position startPosition,
            Position direction, uint ammoHash, uint weaponHash)
        {
            if (!StartProjectileEventHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in StartProjectileEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(player, startPosition, direction, ammoHash, weaponHash))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnStartProjectileEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnStartProjectileEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnPlayerWeaponChange(IntPtr eventPointer, IntPtr targetPlayerPointer, uint oldWeapon,
            uint newWeapon)
        {
            var player = PoolManager.Player.Get(targetPlayerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerWeaponChange Invalid player " + targetPlayerPointer);
                return;
            }

            OnPlayerWeaponChangeEvent(eventPointer, player, oldWeapon, newWeapon);
        }

        public virtual void OnPlayerWeaponChangeEvent(IntPtr eventPointer, IPlayer player, uint oldWeapon,
            uint newWeapon)
        {
            if (!PlayerWeaponChangeEventHandler.HasEvents()) return;
            foreach (var @delegate in PlayerWeaponChangeEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player, oldWeapon, newWeapon);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerWeaponChangeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerWeaponChangeEvent" + ":" + exception);
                }
            }
        }

        public void OnNetOwnerChange(IntPtr eventPointer, IntPtr targetEntityPointer, BaseObjectType targetEntityType,
            IntPtr oldNetOwnerPointer, IntPtr newNetOwnerPointer)
        {
            var targetEntity = (IEntity)PoolManager.Get(targetEntityPointer, targetEntityType);
            if (targetEntity is null)
            {
                Console.WriteLine("OnNetOwnerChange Invalid targetEntity " + targetEntityPointer + " " +
                                  targetEntityType);
                return;
            }

            var oldPlayer = PoolManager.Player.Get(oldNetOwnerPointer);
            var newPlayer = PoolManager.Player.Get(newNetOwnerPointer);

            OnNetOwnerChangeEvent(targetEntity, oldPlayer, newPlayer);
        }

        public virtual void OnNetOwnerChangeEvent(IEntity targetEntity, IPlayer oldPlayer, IPlayer newPlayer)
        {
            if (!NetOwnerChangeEventHandler.HasEvents()) return;
            foreach (var @delegate in NetOwnerChangeEventHandler.GetEvents())
            {
                try
                {
                    @delegate(targetEntity, oldPlayer, newPlayer);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnNetOwnerChangeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnNetOwnerChangeEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleAttach(IntPtr eventPointer, IntPtr targetPointer, IntPtr attachedPointer)
        {
            var targetVehicle = PoolManager.Vehicle.Get(targetPointer);
            if (targetVehicle == null)
            {
                Console.WriteLine("OnVehicleAttach Invalid targetVehicle " + targetPointer);
                return;
            }

            var attachedVehicle = PoolManager.Vehicle.Get(attachedPointer);
            if (attachedVehicle == null)
            {
                Console.WriteLine("OnVehicleAttach Invalid attachedVehicle " + attachedPointer);
                return;
            }

            OnVehicleAttachEvent(targetVehicle, attachedVehicle);
        }

        public virtual void OnVehicleAttachEvent(IVehicle targetVehicle, IVehicle attachedVehicle)
        {
            if (!VehicleAttachEventHandler.HasEvents()) return;
            foreach (var @delegate in VehicleAttachEventHandler.GetEvents())
            {
                try
                {
                    @delegate(targetVehicle, attachedVehicle);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleAttachEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleAttachEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleDetach(IntPtr eventPointer, IntPtr targetPointer, IntPtr detachedPointer)
        {
            var targetVehicle = PoolManager.Vehicle.Get(targetPointer);
            if (targetVehicle == null)
            {
                Console.WriteLine("OnVehicleAttach Invalid targetVehicle " + targetPointer);
                return;
            }

            var detachedVehicle = PoolManager.Vehicle.Get(detachedPointer);
            if (detachedVehicle == null)
            {
                Console.WriteLine("OnVehicleDetach Invalid detachedPointer " + detachedPointer);
                return;
            }

            OnVehicleDetachEvent(targetVehicle, detachedVehicle);
        }

        public virtual void OnVehicleDetachEvent(IVehicle targetVehicle, IVehicle detachedVehicle)
        {
            if (!VehicleDetachEventHandler.HasEvents()) return;
            foreach (var @delegate in VehicleDetachEventHandler.GetEvents())
            {
                try
                {
                    @delegate(targetVehicle, detachedVehicle);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDetachEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDetachEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleDamage(IntPtr eventPointer, IntPtr vehiclePointer, IntPtr entityPointer,
            BaseObjectType entityType, uint bodyHealthDamage, uint additionalBodyHealthDamage,
            uint engineHealthDamage, uint petrolTankDamage, uint weaponHash)
        {
            var targetVehicle = PoolManager.Vehicle.Get(vehiclePointer);
            if (targetVehicle == null)
            {
                Console.WriteLine("OnVehicleDamage Invalid vehicle " + vehiclePointer + " " + entityPointer + " " +
                                  entityType + " " + bodyHealthDamage +
                                  " " + additionalBodyHealthDamage + " " + engineHealthDamage + " " + petrolTankDamage +
                                  " " + weaponHash);
                return;
            }

            var sourceEntity = (IEntity)PoolManager.Get(entityPointer, entityType);

            OnVehicleDamageEvent(targetVehicle, sourceEntity, bodyHealthDamage, additionalBodyHealthDamage,
                engineHealthDamage, petrolTankDamage, weaponHash);
        }

        public virtual void OnVehicleDamageEvent(IVehicle targetVehicle, IEntity sourceEntity, uint bodyHealthDamage,
            uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weaponHash)
        {
            foreach (var @delegate in VehicleDamageEventHandler.GetEvents())
            {
                try
                {
                    @delegate(targetVehicle, sourceEntity, bodyHealthDamage, additionalBodyHealthDamage,
                        engineHealthDamage, petrolTankDamage, weaponHash);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDamageEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleDamageEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleHorn(IntPtr eventPointer, IntPtr targetPointer, IntPtr reporterPointer, bool state)
        {
            var targetVehicle = PoolManager.Vehicle.Get(targetPointer);
            if (targetVehicle == null)
            {
                Console.WriteLine(
                    "OnVehicleHorn Invalid vehicle " + targetPointer + " " + reporterPointer + " " + state);
                return;
            }

            var reporterPlayer = PoolManager.Player.Get(reporterPointer);
            if (reporterPlayer == null)
            {
                Console.WriteLine("OnVehicleHorn Invalid player " + targetPointer + " " + reporterPointer + " " +
                                  state);
                return;
            }

            OnVehicleHornEvent(eventPointer, targetVehicle, reporterPlayer, state);
        }

        public virtual void OnVehicleHornEvent(IntPtr eventPointer, IVehicle targetVehicle, IPlayer reporterPlayer,
            bool state)
        {
            var cancel = false;
            foreach (var @delegate in VehicleHornEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(targetVehicle, reporterPlayer, state))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleHornEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleHornEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public virtual void OnConnectionQueueAdd(IntPtr connectionInfoPtr)
        {
            var connectionInfo = (IConnectionInfo)PoolManager.Get(connectionInfoPtr, BaseObjectType.ConnectionInfo);
            if (connectionInfo is null)
            {
                Console.WriteLine("OnConnectionQueueAdd Invalid connectionInfo " + connectionInfoPtr);
                return;
            }

            OnConnectionQueueAddEvent(connectionInfo);
        }

        public virtual void OnConnectionQueueAddEvent(IConnectionInfo connectionInfo)
        {
            foreach (var @delegate in ConnectionQueueAddHandler.GetEvents())
            {
                try
                {
                    @delegate(connectionInfo);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnConnectionQueueAddEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnConnectionQueueAddEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnConnectionQueueRemove(IntPtr connectionInfoPtr)
        {
            var connectionInfo = (IConnectionInfo)PoolManager.Get(connectionInfoPtr, BaseObjectType.ConnectionInfo);
            if (connectionInfo is null)
            {
                Console.WriteLine("OnConnectionQueueRemove Invalid connectionInfo " + connectionInfoPtr);
                return;
            }

            OnConnectionQueueRemoveEvent(connectionInfo);
        }

        public virtual void OnConnectionQueueRemoveEvent(IConnectionInfo connectionInfo)
        {
            foreach (var @delegate in ConnectionQueueRemoveHandler.GetEvents())
            {
                try
                {
                    @delegate(connectionInfo);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnConnectionQueueRemoveEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnConnectionQueueRemoveEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnServerStarted()
        {
            OnServerStartedEvent();
        }

        public virtual void OnServerStartedEvent()
        {
            foreach (var @delegate in ServerStartedHandler.GetEvents())
            {
                try
                {
                    @delegate();
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnServerStartedEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnServerStartedEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnPlayerRequestControl(IntPtr targetPtr, BaseObjectType targetType, IntPtr playerPtr)
        {
            var target = (IEntity)PoolManager.Get(targetPtr, targetType);
            if (target is null)
            {
                Console.WriteLine("OnPlayerRequestControl Invalid targetEntity " + targetPtr + " " + targetType);
                return;
            }

            var player = PoolManager.Player.Get(playerPtr);
            if (player == null)
            {
                Console.WriteLine("OnPlayerRequestControl Invalid player " + playerPtr);
                return;
            }

            OnPlayerRequestControlEvent(target, player);
        }

        public virtual void OnPlayerRequestControlEvent(IEntity target, IPlayer player)
        {
            foreach (var @delegate in PlayerRequestControlHandler.GetEvents())
            {
                try
                {
                    @delegate(target, player);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerRequestControlEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerRequestControlEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnPlayerChangeAnimation(IntPtr playerPtr, uint oldDict, uint newDict, uint oldName,
            uint newName)
        {
            var player = PoolManager.Player.Get(playerPtr);
            if (player == null)
            {
                Console.WriteLine("OnPlayerChangeAnimation Invalid player " + playerPtr);
                return;
            }

            OnPlayerChangeAnimationEvent(player, oldDict, newDict, oldName, newName);
        }

        public virtual void OnPlayerChangeAnimationEvent(IPlayer player, uint oldDict, uint newDict, uint oldName,
            uint newName)
        {
            foreach (var @delegate in PlayerChangeAnimationHandler.GetEvents())
            {
                try
                {
                    @delegate(player, oldDict, newDict, oldName, newName);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerChangeAnimationEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerChangeAnimationEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnPlayerChangeInterior(IntPtr playerPtr, uint oldIntLoc, uint newIntLoc)
        {
            var player = PoolManager.Player.Get(playerPtr);
            if (player == null)
            {
                Console.WriteLine("OnPlayerChangeInterior Invalid player " + playerPtr);
                return;
            }

            OnPlayerChangeInteriorEvent(player, oldIntLoc, newIntLoc);
        }

        public virtual void OnPlayerChangeInteriorEvent(IPlayer player, uint oldIntLoc, uint newIntLoc)
        {
            foreach (var @delegate in PlayerChangeInteriorHandler.GetEvents())
            {
                try
                {
                    @delegate(player, oldIntLoc, newIntLoc);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerChangeInteriorEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerChangeInteriorEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnPlayerDimensionChange(IntPtr playerPtr, int oldDimension, int newDimension)
        {
            var player = PoolManager.Player.Get(playerPtr);
            if (player is null)
            {
                Console.WriteLine("OnPlayerDimensionChange Invalid player " + playerPtr);
                return;
            }

            OnPlayerDimensionChangeEvent(player, oldDimension, newDimension);
        }

        public virtual void OnPlayerDimensionChangeEvent(IPlayer player, int oldDimension, int newDimension)
        {
            foreach (var @delegate in PlayerDimensionChangeHandler.GetEvents())
            {
                try
                {
                    @delegate(player, oldDimension, newDimension);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDimensionChangeEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDimensionChangeEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleSiren(IntPtr targetVehiclePointer, bool state)
        {
            var targetVehicle = PoolManager.Vehicle.Get(targetVehiclePointer);
            if (targetVehicle is null)
            {
                Console.WriteLine($"OnVehicleSiren Invalid vehicle {targetVehiclePointer} {state}");
                return;
            }

            OnVehicleSirenEvent(targetVehicle, state);
        }

        public virtual void OnVehicleSirenEvent(IVehicle targetVehicle, bool state)
        {
            foreach (var @delegate in VehicleSirenHandler.GetEvents())
            {
                try
                {
                    @delegate(targetVehicle, state);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleSirenEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleSirenEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerSpawn(IntPtr playerPointer)
        {
            var player = PoolManager.Player.Get(playerPointer);
            if (player is null)
            {
                Console.WriteLine($"OnPlayerSpawn Invalid player {playerPointer}");
                return;
            }

            OnPlayerSpawnEvent(player);
        }

        public virtual void OnPlayerSpawnEvent(IPlayer player)
        {
            foreach (var @delegate in PlayerSpawnHandler.GetEvents())
            {
                try
                {
                    @delegate(player);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerSpawnEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerSpawnEvent" + ":" + exception);
                }
            }
        }


        //For custom defined args event handlers
        private readonly Dictionary<string, List<FunctionCall>> eventBusClient =
            new Dictionary<string, List<FunctionCall>>();

        private readonly Dictionary<string, List<FunctionCall>> eventBusServer =
            new Dictionary<string, List<FunctionCall>>();

        private readonly Dictionary<string, HashSet<IParserClientEventHandler>> eventBusClientParser =
            new Dictionary<string, HashSet<IParserClientEventHandler>>();

        private readonly Dictionary<string, HashSet<IParserServerEventHandler>> eventBusServerParser =
            new Dictionary<string, HashSet<IParserServerEventHandler>>();

        public virtual IEnumerable<string> GetRegisteredClientEvents()
        {
            return eventBusClient.Keys.Concat(eventBusClientParser.Keys).Distinct();
        }

        public virtual IEnumerable<string> GetRegisteredServerEvents()
        {
            return eventBusServer.Keys.Concat(eventBusServerParser.Keys).Distinct();
        }

        internal readonly IEventHandler<ServerEventEventDelegate> ServerEventEventHandler =
            new HashSetEventHandler<ServerEventEventDelegate>();

        internal readonly IEventHandler<ServerCustomEventEventDelegate> ServerCustomEventEventHandler =
            new HashSetEventHandler<ServerCustomEventEventDelegate>();

        internal readonly IEventHandler<PlayerClientEventDelegate> PlayerClientEventEventHandler =
            new HashSetEventHandler<PlayerClientEventDelegate>();

        internal readonly IEventHandler<PlayerClientCustomEventDelegate> PlayerClientCustomEventEventHandler =
            new HashSetEventHandler<PlayerClientCustomEventDelegate>();

        public Function OnClient(string eventName, Function function, bool isOnce = false)
        {
            if (function == null)
            {
                Alt.LogWarning("Failed to register client event " + eventName + ": function is null");
                return null;
            }

            if (eventBusClient.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(new FunctionCall { Function = function, IsOnce = isOnce });
            }
            else
            {
                eventHandlers = new List<FunctionCall> { new() { Function = function } };
                eventBusClient[eventName] = eventHandlers;
            }

            return function;
        }

        public void OffClient(string eventName, Function function)
        {
            if (function == null) return;

            if (eventBusClient.TryGetValue(eventName, out var eventHandlers))
            {
                var functionCall = eventHandlers.First(x => x.Function == function);
                eventHandlers.Remove(functionCall);
            }
        }

        public Function OnServer(string eventName, Function function, bool isOnce = false)
        {
            if (function == null)
            {
                Alt.LogWarning("Failed to register server event " + eventName + ": function is null");
                return null;
            }

            if (eventBusServer.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(new FunctionCall { Function = function, IsOnce = isOnce });
            }
            else
            {
                eventHandlers = new List<FunctionCall> { new() { Function = function } };
                eventBusServer[eventName] = eventHandlers;
            }

            return function;
        }

        public void OffServer(string eventName, Function function)
        {
            if (function == null) return;

            if (eventBusServer.TryGetValue(eventName, out var eventHandlers))
            {
                var functionCall = eventHandlers.First(x => x.Function == function);
                eventHandlers.Remove(functionCall);
            }
        }

        public void On<TFunc>(string eventName, TFunc func, ClientEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (eventBusClientParser.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(new ParserClientEventHandler<TFunc>(func, parser));
            }
            else
            {
                eventHandlers = new HashSet<IParserClientEventHandler>
                    { new ParserClientEventHandler<TFunc>(func, parser) };
                eventBusClientParser[eventName] = eventHandlers;
            }
        }

        public void Off<TFunc>(string eventName, TFunc func, ClientEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (!eventBusClientParser.TryGetValue(eventName, out var eventHandlers)) return;
            var parsersToDelete = new LinkedList<IParserClientEventHandler>();
            var eventHandlerToFind = new ParserClientEventHandler<TFunc>(func, parser);
            foreach (var eventHandler in eventHandlers.Where(eventHandler =>
                         eventHandler.Equals(eventHandlerToFind)))
            {
                parsersToDelete.AddFirst(eventHandler);
            }

            foreach (var parserToDelete in parsersToDelete)
            {
                eventHandlers.Remove(parserToDelete);
            }
        }

        public void On<TFunc>(string eventName, TFunc func, ServerEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (eventBusServerParser.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(new ParserServerEventHandler<TFunc>(func, parser));
            }
            else
            {
                eventHandlers = new HashSet<IParserServerEventHandler>
                    { new ParserServerEventHandler<TFunc>(func, parser) };
                eventBusServerParser[eventName] = eventHandlers;
            }
        }

        public void Off<TFunc>(string eventName, TFunc func, ServerEventParser<TFunc> parser) where TFunc : Delegate
        {
            if (func == null || parser == null) return;
            if (!eventBusServerParser.TryGetValue(eventName, out var eventHandlers)) return;
            var parsersToDelete = new LinkedList<IParserServerEventHandler>();
            var eventHandlerToFind = new ParserServerEventHandler<TFunc>(func, parser);
            foreach (var eventHandler in eventHandlers.Where(eventHandler =>
                         eventHandler.Equals(eventHandlerToFind)))
            {
                parsersToDelete.AddFirst(eventHandler);
            }

            foreach (var parserToDelete in parsersToDelete)
            {
                eventHandlers.Remove(parserToDelete);
            }
        }


        public void OnClientEvent(IntPtr playerPointer, string name, IntPtr[] args)
        {
            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnClientEvent Invalid player " + playerPointer);
                return;
            }

            var length = args.Length;
            MValueConst[] mValues = null;

            if (eventBusClientParser.Count != 0 &&
                eventBusClientParser.TryGetValue(name, out var parserEventHandlers))
            {
                mValues = new MValueConst[length];
                for (var i = 0; i < length; i++)
                {
                    mValues[i] = new MValueConst(this, args[i]);
                }

                foreach (var parserEventHandler in parserEventHandlers)
                {
                    try
                    {
                        parserEventHandler.Call(player, mValues);
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

            if (eventBusClient.Count != 0 && eventBusClient.TryGetValue(name, out var eventHandlersClient))
            {
                if (mValues == null)
                {
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(this, args[i]);
                    }
                }

                foreach (var eventHandler in eventHandlersClient)
                {
                    if (eventHandler.IsOnce && eventHandler.IsCalled) continue;
                    try
                    {
                        eventHandler.Function.Call(player, mValues);
                        if (eventHandler.IsOnce)
                        {
                            eventHandler.IsCalled = true;
                        }
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

            if (PlayerClientEventEventHandler.HasEvents())
            {
                if (mValues == null)
                {
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(this, args[i]);
                    }
                }

                argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = mValues[i].ToObject();
                }

                foreach (var eventHandler in PlayerClientEventEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(player, name, argObjects);
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

            if (PlayerClientCustomEventEventHandler.HasEvents())
            {
                if (mValues == null)
                {
                    mValues = new MValueConst[length];
                    for (var i = 0; i < length; i++)
                    {
                        mValues[i] = new MValueConst(this, args[i]);
                    }
                }

                foreach (var eventHandler in PlayerClientCustomEventEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(player, name, mValues);
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

            OnClientEventEvent(player, name, args, mValues, argObjects);
        }

        public virtual void OnClientEventEvent(IPlayer player, string name, IntPtr[] args, MValueConst[] mValues,
            object[] objects)
        {
        }

        public void OnServerEvent(string name, IntPtr[] args)
        {
            var length = args.Length;
            var mValues = new MValueConst[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = new MValueConst(this, args[i]);
            }

            if (eventBusServerParser.Count != 0 &&
                eventBusServerParser.TryGetValue(name, out var parserEventHandlers))
            {
                foreach (var parserEventHandler in parserEventHandlers)
                {
                    parserEventHandler.Call(mValues);
                }
            }

            if (eventBusServer.Count != 0 && eventBusServer.TryGetValue(name, out var eventHandlersServer))
            {
                foreach (var eventNameEventHandler in eventHandlersServer)
                {
                    if (eventNameEventHandler.IsOnce && eventNameEventHandler.IsCalled) continue;
                    try
                    {
                        eventNameEventHandler.Function.Call(mValues);
                        if (eventNameEventHandler.IsOnce)
                        {
                            eventNameEventHandler.IsCalled = true;
                        }
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

            if (ServerEventEventHandler.HasEvents())
            {
                argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = mValues[i].ToObject();
                }

                foreach (var eventHandler in ServerEventEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(name, argObjects);
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

            if (ServerCustomEventEventHandler.HasEvents())
            {
                foreach (var eventHandler in ServerCustomEventEventHandler.GetEvents())
                {
                    try
                    {
                        eventHandler(name, mValues);
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

            OnServerEventEvent(name, args, mValues, argObjects);
        }

        public virtual void OnServerEventEvent(string name, IntPtr[] args, MValueConst[] mValues, object[] objects)
        {
        }

        public void OnModulesLoaded(IModule[] modules)
        {
            foreach (var module in modules)
            {
                OnModuleLoaded(module);
            }
        }

        public virtual void OnModuleLoaded(IModule module)
        {
        }

        public void OnCreateBaseObject(IntPtr baseObject, BaseObjectType type, uint id)
        {
            PoolManager.GetOrCreate(this, baseObject, type, id);
        }

        public void OnRemoveBaseObject(IntPtr baseObject, BaseObjectType type)
        {
            PoolManager.Remove(baseObject, type);
        }

        public void OnPlayerRemove(IntPtr playerPointer)
        {
            var player = PoolManager.Player.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerRemove Invalid player " + playerPointer);
                return;
            }

            foreach (var vehiclePassenger in VehiclePassengers)
            {
                if (vehiclePassenger.Value.All(x => x.PlayerPointer != playerPointer))
                {
                    continue;
                }

                var playerSeat = vehiclePassenger.Value.First(x => x.PlayerPointer == playerPointer);
                vehiclePassenger.Value.Remove(playerSeat);
            }

            OnPlayerRemoveEvent(player);
        }

        public virtual void OnPlayerRemoveEvent(IPlayer player)
        {
            foreach (var @delegate in PlayerRemoveEventHandler.GetEvents())
            {
                try
                {
                    @delegate(player);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerRemoveEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerRemoveEvent" + ":" + exception);
                }
            }
        }

        public void OnVehicleRemove(IntPtr vehiclePointer)
        {
            var vehicle = PoolManager.Vehicle.Get(vehiclePointer);
            if (vehicle == null)
            {
                Console.WriteLine("OnVehicleRemove Invalid vehicle " + vehiclePointer);
                return;
            }

            if (VehiclePassengers.ContainsKey(vehiclePointer))
            {
                VehiclePassengers.Remove(vehiclePointer);
            }

            OnVehicleRemoveEvent(vehicle);
        }

        public virtual void OnVehicleRemoveEvent(IVehicle vehicle)
        {
            foreach (var @delegate in VehicleRemoveEventHandler.GetEvents())
            {
                try
                {
                    @delegate(vehicle);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleRemoveEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnVehicleRemoveEvent" + ":" + exception);
                }
            }
        }

        public void OnPedRemove(IntPtr pedPointer)
        {
            var ped = PoolManager.Ped.Get(pedPointer);
            if (ped == null)
            {
                Console.WriteLine("OnPedRemove Invalid ped " + pedPointer);
                return;
            }

            OnPedRemoveEvent(ped);
        }

        public virtual void OnPedRemoveEvent(IPed ped)
        {
            foreach (var @delegate in PedRemoveEventHandler.GetEvents())
            {
                try
                {
                    @delegate(ped);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPedRemoveEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPedRemoveEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnRequestSyncedScene(IntPtr eventPointer, IntPtr source, int sceneid)
        {
            var sourcePlayer = PoolManager.Player.Get(source);
            if (sourcePlayer == null)
            {
                Console.WriteLine("OnRequestSyncedSceneDelegate Invalid source " + source + " " + sceneid);
                return;
            }

            OnRequestSyncedSceneEvent(eventPointer, sourcePlayer, sceneid);
        }

        public virtual void OnRequestSyncedSceneEvent(IntPtr eventPointer, IPlayer sourcePlayer, int sceneid)
        {
            if (!RequestSyncedSceneHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in RequestSyncedSceneHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(sourcePlayer, sceneid))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnRequestSyncedSceneEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnRequestSyncedSceneEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public virtual void OnStartSyncedScene(IntPtr source, int sceneid, Position position, Rotation rotation,
            uint animDictHash, IntPtr[] entites, BaseObjectType[] types, uint[] animHashes, ulong size)
        {
            var sourcePlayer = PoolManager.Player.Get(source);
            if (sourcePlayer == null)
            {
                Console.WriteLine("OnStartSyncedScene Invalid source " + source + " " + sceneid + " " + position + " " +
                                  rotation + " " + animDictHash);
                return;
            }

            var entityAndAnimHash = new Dictionary<IEntity, uint>();
            for (ulong i = 0; i < size; i++)
            {
                var entityObject = (IEntity)PoolManager.Get(entites[i], types[i]);
                entityAndAnimHash.Add(entityObject, animHashes[i]);
            }

            OnStartSyncedSceneEvent(sourcePlayer, sceneid, position, rotation, animDictHash, entityAndAnimHash);
        }

        public virtual void OnStartSyncedSceneEvent(IPlayer sourcePlayer, int sceneid, Position position,
            Rotation rotation, uint animDictHash, Dictionary<IEntity, uint> entityAndAnimHash)
        {
            if (!StartSyncedSceneHandler.HasEvents()) return;
            foreach (var @delegate in StartSyncedSceneHandler.GetEvents())
            {
                try
                {
                    @delegate(sourcePlayer, sceneid, position, rotation, animDictHash, entityAndAnimHash);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnStartSyncedSceneEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnStartSyncedSceneEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnStopSyncedScene(IntPtr source, int sceneid)
        {
            var sourcePlayer = PoolManager.Player.Get(source);
            if (sourcePlayer == null)
            {
                Console.WriteLine("OnStopSyncedScene Invalid source " + source + " " + sceneid);
                return;
            }

            OnStopSyncedSceneEvent(sourcePlayer, sceneid);
        }

        public virtual void OnStopSyncedSceneEvent(IPlayer sourcePlayer, int sceneid)
        {
            if (!StopSyncedSceneHandler.HasEvents()) return;
            foreach (var @delegate in StopSyncedSceneHandler.GetEvents())
            {
                try
                {
                    @delegate(sourcePlayer, sceneid);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnStopSyncedSceneEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnStopSyncedSceneEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnUpdateSyncedScene(IntPtr source, float startRate, int sceneid)
        {
            var sourcePlayer = PoolManager.Player.Get(source);
            if (sourcePlayer == null)
            {
                Console.WriteLine("OnUpdateSyncedScene Invalid source " + source + " " + startRate + " " + sceneid);
                return;
            }

            OnUpdateSyncedSceneEvent(sourcePlayer, startRate, sceneid);
        }

        public virtual void OnUpdateSyncedSceneEvent(IPlayer sourcePlayer, float startRate, int sceneid)
        {
            if (!UpdateSyncedSceneHandler.HasEvents()) return;
            foreach (var @delegate in UpdateSyncedSceneHandler.GetEvents())
            {
                try
                {
                    @delegate(sourcePlayer, startRate, sceneid);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnUpdateSyncedSceneEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnUpdateSyncedSceneEvent" + ":" + exception);
                }
            }
        }

        public virtual void OnClientRequestObject(IntPtr eventPointer, IntPtr source, uint model, Position position)
        {
            var sourcePlayer = PoolManager.Player.Get(source);
            if (sourcePlayer == null)
            {
                Console.WriteLine("OnClientRequestObject Invalid source " + source + " " + model + " " + position);
                return;
            }

            OnClientRequestObjectEvent(eventPointer, sourcePlayer, model, position);
        }

        public virtual void OnClientRequestObjectEvent(IntPtr eventPointer, IPlayer sourcePlayer, uint model,
            Position position)
        {
            if (!ClientRequestObjectHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in ClientRequestObjectHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(sourcePlayer, model, position))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnClientRequestObjectEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnClientRequestObjectEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public virtual void OnClientDeleteObject(IntPtr eventPointer, IntPtr source)
        {
            var sourcePlayer = PoolManager.Player.Get(source);
            if (sourcePlayer == null)
            {
                Console.WriteLine("OnClientDeleteObject Invalid source " + source);
                return;
            }

            OnClientDeleteObjectEvent(eventPointer, sourcePlayer);
        }

        public virtual void OnClientDeleteObjectEvent(IntPtr eventPointer, IPlayer sourcePlayer)
        {
            if (!ClientDeleteObjectHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in ClientDeleteObjectHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(sourcePlayer))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnClientDeleteObjectEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnClientDeleteObjectEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public virtual void OnGivePedScriptedTask(IntPtr eventPointer, IntPtr source, IntPtr target, uint taskType)
        {
            var sourcePlayer = PoolManager.Player.Get(source);
            var targetPed = PoolManager.Ped.Get(target);

            if (sourcePlayer == null)
            {
                Console.WriteLine("OnGivePedScriptedTask Invalid source " + source);
                return;
            }

            if (targetPed == null)
            {
                Console.WriteLine("OnGivePedScriptedTask Invalid target " + target);
                return;
            }

            OnGivePedScriptedTaskEvent(eventPointer, sourcePlayer, targetPed, taskType);
        }

        public virtual void OnGivePedScriptedTaskEvent(IntPtr eventPointer, IPlayer source, IPed target, uint taskType)
        {
            if (!GivePedScriptedTaskHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in GivePedScriptedTaskHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(source, target, taskType))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnGivePedScriptedTaskEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnGivePedScriptedTaskEvent" + ":" + exception);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnPedDamage(IntPtr pedpointer, IntPtr attackerentitypointer, BaseObjectType attackerbaseobjecttype, uint weapon, ushort healthdamage, ushort armourdamage)
        {
            var ped = PoolManager.Ped.Get(pedpointer);
            if (ped == null)
            {
                Console.WriteLine("OnPedDamage Invalid player " + pedpointer + " " + attackerentitypointer + " " +
                                  attackerbaseobjecttype + " " + weapon + " " + healthdamage +
                                  " " + armourdamage);
                return;
            }

            var attacker = (IEntity)PoolManager.Get(attackerentitypointer, attackerbaseobjecttype);

            OnPedDamageEvent(ped, attacker, weapon, healthdamage, armourdamage);
        }

        public virtual void OnPedDamageEvent(IPed ped, IEntity attacker, uint weapon, ushort healthDamage,
            ushort armourDamage)
        {
            foreach (var @delegate in PedDamageEventHandler.GetEvents())
            {
                try
                {
                    @delegate(ped, attacker, weapon, healthDamage, armourDamage);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPedDamageEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPedDamageEvent" + ":" + exception);
                }
            }
        }

        public void OnPedDeath(IntPtr pedpointer, IntPtr killerentitypointer, BaseObjectType killerbaseobjecttype, uint weapon)
        {
            var ped = PoolManager.Ped.Get(pedpointer);
            if (ped == null)
            {
                Console.WriteLine("OnPedDeath Invalid ped " + pedpointer + " " + killerentitypointer + " " +
                                  killerbaseobjecttype + " " + weapon);
                return;
            }

            var killer = (IEntity)PoolManager.Get(killerentitypointer, killerbaseobjecttype);

            OnPedDeathEvent(ped, killer, weapon);
        }

        public virtual void OnPedDeathEvent(IPed ped, IEntity killer, uint weapon)
        {
            foreach (var @delegate in PedDeadEventHandler.GetEvents())
            {
                try
                {
                    @delegate(ped, killer, weapon);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPedDeathEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPedDeathEvent" + ":" + exception);
                }
            }
        }

        public void OnPedHeal(IntPtr pedpointer, ushort oldHealth, ushort newHealth, ushort oldArmour,
            ushort newArmour)
        {
            var ped = PoolManager.Ped.Get(pedpointer);
            if (ped == null)
            {
                Console.WriteLine("OnPedHeal Invalid ped " + pedpointer + " " + oldHealth + " " +
                                  newHealth + " " + oldArmour + " " + newArmour);
                return;
            }

            OnPedHealEvent(ped, oldHealth, newHealth, oldArmour, newArmour);
        }

        public virtual void OnPedHealEvent(IPed ped, ushort oldHealth, ushort newHealth, ushort oldArmour,
            ushort newArmour)
        {
            foreach (var @delegate in PedHealEventHandler.GetEvents())
            {
                try
                {
                    @delegate(ped, oldHealth, newHealth, oldArmour, newArmour);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPedHealEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPedHealEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerStartTalking(IntPtr playerpointer)
        {
            var player = PoolManager.Player.Get(playerpointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerStartTalking Invalid player " + playerpointer);
                return;
            }

            OnPlayerStartTalkingEvent(player);
        }

        public virtual void OnPlayerStartTalkingEvent(IPlayer player)
        {
            foreach (var @delegate in PlayerStartTalkingHandler.GetEvents())
            {
                try
                {
                    @delegate(player);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerStartTalkingEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerStartTalkingEvent" + ":" + exception);
                }
            }
        }

        public void OnPlayerStopTalking(IntPtr playerpointer)
        {
            var player = PoolManager.Player.Get(playerpointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerStopTalking Invalid player " + playerpointer);
                return;
            }

            OnPlayerStopTalkingEvent(player);
        }

        public virtual void OnPlayerStopTalkingEvent(IPlayer player)
        {
            foreach (var @delegate in PlayerStopTalkingHandler.GetEvents())
            {
                try
                {
                    @delegate(player);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerStopTalkingEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerStopTalkingEvent" + ":" + exception);
                }
            }
        }

        public void OnScriptRPC(IntPtr eventpointer, IntPtr targetpointer, string name, IntPtr pointer, ulong size, ushort answerId)
        {
            var target = PoolManager.Player.Get(targetpointer);
            if (target == null)
            {
                Console.WriteLine("OnScriptRPC Invalid target " + targetpointer);
                return;
            }

            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            OnScriptRPCEvent(eventpointer, target, name, args, answerId);
        }

        public virtual void OnScriptRPCEvent(IntPtr eventpointer, IPlayer target, string name, IntPtr[] args, ushort answerId)
        {
            var mValues = MValueConst.CreateFrom(this, args);
            var clientScriptRPCEvent = new ScriptRpcEvent(this, eventpointer);
            foreach (var @delegate in ScriptRpcHandler.GetEvents())
            {
                try
                {
                    @delegate(clientScriptRPCEvent, target, name, mValues.Select(x => x.ToObject()).ToArray(), answerId);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnScriptRPCEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnScriptRPCEvent" + ":" + exception);
                }
            }
        }

        public void OnScriptAnswerRPC(IntPtr targetpointer, ushort answerid, IntPtr answer, string answererror)
        {
            var target = PoolManager.Player.Get(targetpointer);
            if (target == null)
            {
                Console.WriteLine("OnScriptRPC Invalid target " + targetpointer);
                return;
            }

            OnScriptAnswerRPCEvent(target, answerid, answer, answererror);
        }

        public virtual void OnScriptAnswerRPCEvent(IPlayer target, ushort answerid, IntPtr mValue, string answererror)
        {
            var mValues = new MValueConst(this, mValue);
            foreach (var @delegate in ScriptRpcAnswerHandler.GetEvents())
            {
                try
                {
                    @delegate(target, answerid, mValues.ToObject(), answererror);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnScriptRPCEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnScriptRPCEvent" + ":" + exception);
                }
            }
        }
    }
}