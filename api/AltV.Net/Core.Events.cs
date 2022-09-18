﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;
using AltV.Net.FunctionParser;
using AltV.Net.Native;
using AltV.Net.Shared.Events;
using AltV.Net.Types;

namespace AltV.Net
{
    public partial class Core
    {
        internal readonly IEventHandler<CheckpointDelegate> CheckpointEventHandler =
            new HashSetEventHandler<CheckpointDelegate>(EventType.COLSHAPE_EVENT);

        internal readonly IEventHandler<PlayerConnectDelegate> PlayerConnectEventHandler =
            new HashSetEventHandler<PlayerConnectDelegate>(EventType.PLAYER_CONNECT);

        internal readonly IEventHandler<PlayerBeforeConnectDelegate> PlayerBeforeConnectEventHandler =
            new HashSetEventHandler<PlayerBeforeConnectDelegate>(EventType.PLAYER_BEFORE_CONNECT);

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
            new HashSetEventHandler<PlayerRemoveDelegate>(EventType.REMOVE_ENTITY_EVENT);

        internal readonly IEventHandler<VehicleRemoveDelegate> VehicleRemoveEventHandler =
            new HashSetEventHandler<VehicleRemoveDelegate>(EventType.REMOVE_ENTITY_EVENT);

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

        private readonly ConcurrentDictionary<IntPtr, IConnectionInfo> connectionInfos =
            new ();
        
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


        public void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, BaseObjectType baseObjectType,
            bool state)
        {
            var checkpoint = CheckpointPool.Get(checkpointPointer);
            if (checkpoint == null)
            {
                Console.WriteLine("OnCheckpoint Invalid checkpoint " + checkpointPointer + " " + entityPointer + " " +
                                  baseObjectType + " " + state);
                return;
            }

            if (!BaseEntityPool.Get(entityPointer, baseObjectType, out var entity))
            {
                Console.WriteLine("OnCheckpoint Invalid entity " + checkpointPointer + " " + entityPointer + " " +
                                  baseObjectType + " " + state);
                return;
            }

            OnCheckPointEvent(checkpoint, entity, state);
        }

        public virtual void OnCheckPointEvent(ICheckpoint checkpoint, IEntity entity, bool state)
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

        public void OnPlayerConnect(IntPtr playerPointer, ushort playerId, string reason)
        {
            var player = PlayerPool.Get(playerPointer);
            if (player == null)
            {
                Console.WriteLine("OnPlayerConnect Invalid player " + playerPointer + " " + playerId + " " +
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
        
        public void OnPlayerBeforeConnect(IntPtr eventPointer, PlayerConnectionInfo connectionInfo, string reason)
        {
            OnPlayerBeforeConnectEvent(eventPointer, connectionInfo, reason);
        }

        public virtual void OnPlayerBeforeConnectEvent(IntPtr eventPointer, PlayerConnectionInfo connectionInfo, string reason)
        {
            if (!PlayerBeforeConnectEventHandler.HasEvents()) return;
            string cancel = null;
            foreach (var @delegate in PlayerBeforeConnectEventHandler.GetEvents())
            {
                try
                {
                    if (@delegate(connectionInfo, reason) is string cancelReason)
                    {
                        cancel = cancelReason;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerBeforeConnectEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerBeforeConnectEvent" + ":" + exception);
                }
            }

            if (cancel != null)
            {
                unsafe
                {
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(cancel);
                    Alt.Core.Library.Server.Event_PlayerBeforeConnect_Cancel(eventPointer, stringPtr);
                    Marshal.FreeHGlobal(stringPtr);
                }
            }
        }

        public void onPlayerConnectDenied(PlayerConnectDeniedReason reason, string name, string ip, ulong passwordHash, bool isDebug, string branch, uint majorVersion, string cdnUrl, long discordId)
        {
            onPlayerConnectDeniedEvent(reason, name, ip, passwordHash, isDebug, branch,majorVersion, cdnUrl, discordId);
        }


        public virtual void onPlayerConnectDeniedEvent(PlayerConnectDeniedReason reason, string name, string ip, ulong passwordHash, bool isDebug, string branch, uint majorVersion, string cdnUrl, long discordId)
        {
            foreach (var @delegate in PlayerConnectDeniedEventHandler.GetEvents())
            {
                try
                {
                    @delegate(reason, name, ip, passwordHash, isDebug, branch,majorVersion, cdnUrl, discordId);
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
            BaseObjectType attackerBaseObjectType,
            ushort attackerEntityId, uint weapon, ushort healthDamage, ushort armourDamage)
        {
            var player = PlayerPool.Get(playerPointer);
			if (player == null)
            {
                Console.WriteLine("OnPlayerDamage Invalid player " + playerPointer + " " + attackerEntityPointer + " " +
                                  attackerBaseObjectType + " " + attackerEntityId + " " + weapon + " " + healthDamage + " " + armourDamage);
                return;
            }

            BaseEntityPool.Get(attackerEntityPointer, attackerBaseObjectType,
                out var attacker);

            OnPlayerDamageEvent(player, attacker, weapon, healthDamage, armourDamage);
        }

        public virtual void OnPlayerDamageEvent(IPlayer player, IEntity attacker, uint weapon, ushort healthDamage, ushort armourDamage)
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
            var player = PlayerPool.Get(playerPointer);
			if (player == null)
            {
                Console.WriteLine("OnPlayerDeath Invalid player " + playerPointer + " " + killerEntityPointer + " " +
                                  killerBaseObjectType + " " + weapon);
                return;
            }

            BaseEntityPool.Get(killerEntityPointer, killerBaseObjectType, out var killer);

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

        public void OnExplosion(IntPtr eventPointer, IntPtr playerPointer, ExplosionType explosionType,
            Position position, uint explosionFx, IntPtr targetEntityPointer, BaseObjectType targetEntityType)
        {
            var sourcePlayer = PlayerPool.Get(playerPointer);
			if (sourcePlayer == null)
            {
                Console.WriteLine("OnExplosion Invalid player " + playerPointer + " " + explosionType + " " +
                                  position + " " + explosionFx);
                return;
            }

            BaseEntityPool.Get(targetEntityPointer, targetEntityType, out var targetEntity);

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
                    Alt.Core.Library.Server.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnWeaponDamage(IntPtr eventPointer, IntPtr playerPointer, IntPtr entityPointer,
            BaseObjectType entityType, uint weapon,
            ushort damage, Position shotOffset, BodyPart bodyPart)
        {
            var sourcePlayer = PlayerPool.Get(playerPointer);
			if (sourcePlayer == null)
            {
                Console.WriteLine("OnWeaponDamage Invalid player " + playerPointer + " " + entityPointer + " " +
                                  entityType + " " + weapon + " " + damage + " " + shotOffset + " " + bodyPart);
                return;
            }

            BaseEntityPool.Get(entityPointer, entityType, out var targetEntity);

            OnWeaponDamageEvent(eventPointer, sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart);
        }

        public virtual void OnWeaponDamageEvent(IntPtr eventPointer, IPlayer sourcePlayer, IEntity targetEntity,
            uint weapon, ushort damage,
            Position shotOffset, BodyPart bodyPart)
        {
            var cancel = false;
            foreach (var @delegate in WeaponDamageEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(sourcePlayer, targetEntity, weapon, damage, shotOffset, bodyPart))
                    {
                        cancel = true;
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

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Server.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnPlayerChangeVehicleSeat(IntPtr vehiclePointer, IntPtr playerPointer, byte oldSeat,
            byte newSeat)
        {
            var vehicle = VehiclePool.Get(vehiclePointer);
			if (vehicle == null)
            {
                Console.WriteLine("OnPlayerChangeVehicleSeat Invalid vehicle " + vehiclePointer + " " + playerPointer + " " +
                                  oldSeat + " " + newSeat);
                return;
            }

            var player = PlayerPool.Get(playerPointer);
			if (player == null)
            {
                Console.WriteLine("OnPlayerChangeVehicleSeat Invalid player " + vehiclePointer + " " + playerPointer + " " +
                                  oldSeat + " " + newSeat);
                return;
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
            var vehicle = VehiclePool.Get(vehiclePointer);
			if (vehicle == null)
            {
                Console.WriteLine("OnPlayerEnterVehicle Invalid vehicle " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            var player = PlayerPool.Get(playerPointer);
			if (player == null)
            {
                Console.WriteLine("OnPlayerEnterVehicle Invalid player " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
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
            var vehicle = VehiclePool.Get(vehiclePointer);
			if (vehicle == null)
            {
                Console.WriteLine("OnPlayerEnteringVehicle Invalid vehicle " + vehiclePointer + " " + playerPointer +
                                  " " + seat);
                return;
            }

            var player = PlayerPool.Get(playerPointer);
			if (player == null)
            {
                Console.WriteLine("OnPlayerEnteringVehicle Invalid player " + vehiclePointer + " " + playerPointer +
                                  " " + seat);
                return;
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
            var vehicle = VehiclePool.Get(vehiclePointer);
			if (vehicle == null)
            {
                Console.WriteLine("OnPlayerLeaveVehicle Invalid vehicle " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
            }

            var player = PlayerPool.Get(playerPointer);
			if (player == null)
            {
                Console.WriteLine("OnPlayerLeaveVehicle Invalid player " + vehiclePointer + " " + playerPointer + " " +
                                  seat);
                return;
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
            var player = PlayerPool.Get(playerPointer);
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

        public void OnPlayerRemove(IntPtr playerPointer)
        {
            var player = PlayerPool.Get(playerPointer);
			if (player == null)
            {
                Console.WriteLine("OnPlayerRemove Invalid player " + playerPointer);
                return;
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
            var vehicle = VehiclePool.Get(vehiclePointer);
			if (vehicle == null)
            {
                Console.WriteLine("OnVehicleRemove Invalid vehicle " + vehiclePointer);
                return;
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
            if (!BaseEntityPool.Get(entityPointer, entityType, out var entity))
            {
                Console.WriteLine("OnMetaDataChange Invalid entity " + entityPointer + " " + entityType + " " + key + " " + value);
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
            if (!BaseEntityPool.Get(entityPointer, entityType, out var entity))
            {
                Console.WriteLine("OnSyncedMetaDataChange Invalid entity " + entityPointer + " " + entityType + " " + key + " " + value);
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
            var colShape = ColShapePool.Get(colShapePointer); 
            if (colShape == null)
            {
                Console.WriteLine("OnColShape Invalid colshape " + colShapePointer + " " + targetEntityPointer + " " + entityType + " " + state);
                return;
            }

            if (!BaseEntityPool.Get(targetEntityPointer, entityType, out var entity))
            {
                Console.WriteLine("OnColShape Invalid entity " + colShapePointer + " " + targetEntityPointer + " " + entityType + " " + state);
                return;
            }

            OnColShapeEvent(colShape, entity, state);
        }

        public virtual void OnColShapeEvent(IColShape colShape, IEntity entity, bool state)
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
            var vehicle = VehiclePool.Get(vehiclePointer);
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
            var player = PlayerPool.Get(playerPointer);
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
                    Alt.Core.Library.Server.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnStartProjectile(IntPtr eventPointer, IntPtr sourcePlayerPointer, Position startPosition, Position direction, uint ammoHash, uint weaponHash)
        {
            var player = PlayerPool.Get(sourcePlayerPointer);
            if (player == null)
            {
                Console.WriteLine("OnStartProjectile Invalid player " + sourcePlayerPointer);
                return;
            }

            OnStartProjectileEvent(eventPointer, player, startPosition, direction, ammoHash, weaponHash);
        }

        public virtual void OnStartProjectileEvent(IntPtr eventPointer, IPlayer player, Position startPosition, Position direction, uint ammoHash, uint weaponHash)
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
                    Alt.Core.Library.Server.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnPlayerWeaponChange(IntPtr eventPointer, IntPtr targetPlayerPointer, uint oldWeapon, uint newWeapon)
        {
            var player = PlayerPool.Get(targetPlayerPointer);
			if (player == null)
            {
                Console.WriteLine("OnPlayerWeaponChange Invalid player " + targetPlayerPointer);
                return;
            }

            OnPlayerWeaponChangeEvent(eventPointer, player, oldWeapon, newWeapon);
        }

        public virtual void OnPlayerWeaponChangeEvent(IntPtr eventPointer, IPlayer player, uint oldWeapon, uint newWeapon)
        {
            if (!PlayerWeaponChangeEventHandler.HasEvents()) return;
            var cancel = false;
            foreach (var @delegate in PlayerWeaponChangeEventHandler.GetEvents())
            {
                try
                {
                    if (!@delegate(player, oldWeapon, newWeapon))
                    {
                        cancel = true;
                    }
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

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Server.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnNetOwnerChange(IntPtr eventPointer, IntPtr targetEntityPointer, BaseObjectType targetEntityType, IntPtr oldNetOwnerPointer, IntPtr newNetOwnerPointer)
        {
            if (!BaseEntityPool.Get(targetEntityPointer, targetEntityType, out var targetEntity))
            {
                Console.WriteLine("OnNetOwnerChange Invalid targetEntity " + targetEntity);
                return;
            }

            var oldPlayer = PlayerPool.Get(oldNetOwnerPointer);
            var newPlayer = PlayerPool.Get(newNetOwnerPointer);

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
            var targetVehicle = VehiclePool.Get(targetPointer);
            if (targetVehicle == null)
            {
                Console.WriteLine("OnVehicleAttach Invalid targetVehicle " + targetVehicle);
                return;
            }

            var attachedVehicle = VehiclePool.Get(attachedPointer);
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
            var targetVehicle = VehiclePool.Get(targetPointer);
			if (targetVehicle == null)
            {
                Console.WriteLine("OnVehicleAttach Invalid targetVehicle " + targetVehicle);
                return;
            }

            var detachedVehicle = VehiclePool.Get(detachedPointer);
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
            var targetVehicle = VehiclePool.Get(vehiclePointer);
			if (targetVehicle == null)
            {
                Console.WriteLine("OnVehicleDamage Invalid vehicle " + vehiclePointer + " " + entityPointer + " " + entityType + " " + bodyHealthDamage +
                                  " " + additionalBodyHealthDamage + " " + engineHealthDamage + " " + petrolTankDamage + " " + weaponHash);
                return;
            }

            BaseEntityPool.Get(entityPointer, entityType, out var sourceEntity);

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
                    @delegate(targetVehicle, sourceEntity, bodyHealthDamage, additionalBodyHealthDamage, engineHealthDamage, petrolTankDamage, weaponHash);
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

        public virtual void OnConnectionQueueAdd(IntPtr connectionInfoPtr)
        {
            IConnectionInfo connectionInfo = new ConnectionInfo(this, connectionInfoPtr);
            connectionInfos[connectionInfoPtr] = connectionInfo;
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
            if (!connectionInfos.Remove(connectionInfoPtr, out var connectionInfo))
            {
                return;
            }

            OnConnectionQueueRemoveEvent(connectionInfo);

            lock (connectionInfo)
            {
                ((IInternalNative) connectionInfo).Exists = false;
            }
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
            if (!BaseEntityPool.Get(targetPtr, targetType, out var target))
            {
                Console.WriteLine("OnPlayerRequestControl Invalid targetEntity " + targetPtr + " " + targetType);
                return;
            }

            var player = PlayerPool.Get(playerPtr);
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

        public virtual void OnPlayerChangeAnimation(IntPtr playerPtr, uint oldDict, uint newDict, uint oldName, uint newName)
        {
            var player = PlayerPool.Get(playerPtr);
            if (player == null)
            {
                Console.WriteLine("OnPlayerChangeAnimation Invalid player " + playerPtr);
                return;
            }
            OnPlayerChangeAnimationEvent(player, oldDict, newDict, oldName, newName);
        }

        public virtual void OnPlayerChangeInterior(IntPtr playerPtr, uint oldIntLoc, uint newIntLoc)
        {
            var player = PlayerPool.Get(playerPtr);
            if (player == null)
            {
                Console.WriteLine("OnPlayerChangeInterior Invalid player " + playerPtr);
                return;
            }
            OnPlayerChangeInteriorEvent(player, oldIntLoc, newIntLoc);
        }
        
        public virtual void OnPlayerChangeAnimationEvent(IPlayer player, uint oldDict, uint newDict, uint oldName, uint newName)
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
        

        //For custom defined args event handlers
        private readonly Dictionary<string, HashSet<Function>> eventBusClient =
            new Dictionary<string, HashSet<Function>>();

        private readonly Dictionary<string, HashSet<Function>> eventBusServer =
            new Dictionary<string, HashSet<Function>>();

        private readonly Dictionary<string, HashSet<IParserClientEventHandler>> eventBusClientParser =
            new Dictionary<string, HashSet<IParserClientEventHandler>>();

        private readonly Dictionary<string, HashSet<IParserServerEventHandler>> eventBusServerParser =
            new Dictionary<string, HashSet<IParserServerEventHandler>>();

        internal readonly IEventHandler<ServerEventEventDelegate> ServerEventEventHandler =
            new HashSetEventHandler<ServerEventEventDelegate>();

        internal readonly IEventHandler<ServerCustomEventEventDelegate> ServerCustomEventEventHandler =
            new HashSetEventHandler<ServerCustomEventEventDelegate>();

        internal readonly IEventHandler<PlayerClientEventDelegate> PlayerClientEventEventHandler =
            new HashSetEventHandler<PlayerClientEventDelegate>();

        internal readonly IEventHandler<PlayerClientCustomEventDelegate> PlayerClientCustomEventEventHandler =
            new HashSetEventHandler<PlayerClientCustomEventDelegate>();

        public Function OnClient(string eventName, Function function)
        {
            if (function == null)
            {
                Alt.LogWarning("Failed to register client event " + eventName + ": function is null");
                return null;
            }
            
            if (eventBusClient.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new HashSet<Function> {function};
                eventBusClient[eventName] = eventHandlers;
            }

            return function;
        }

        public void OffClient(string eventName, Function function)
        {
            if (function == null) return;
            
            if (eventBusClient.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
            }
        }

        public Function OnServer(string eventName, Function function)
        {
            if (function == null)
            {
                Alt.LogWarning("Failed to register server event " + eventName + ": function is null");
                return null;
            }
            
            if (eventBusServer.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new HashSet<Function> {function};
                eventBusServer[eventName] = eventHandlers;
            }

            return function;
        }

        public void OffServer(string eventName, Function function)
        {
            if (function == null) return;
            
            if (eventBusServer.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Remove(function);
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
                    {new ParserClientEventHandler<TFunc>(func, parser)};
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
                    {new ParserServerEventHandler<TFunc>(func, parser)};
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
            var player = PlayerPool.Get(playerPointer);
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
                    try
                    {
                        eventHandler.Call(player, mValues);
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

                if (argObjects == null)
                {
                    argObjects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        argObjects[i] = mValues[i].ToObject();
                    }
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
                    try
                    {
                        eventNameEventHandler.Call(mValues);
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
                if (argObjects == null)
                {
                    argObjects = new object[length];
                    for (var i = 0; i < length; i++)
                    {
                        argObjects[i] = mValues[i].ToObject();
                    }
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
        

        public void OnCreatePlayer(IntPtr playerPointer, ushort playerId)
        {
            PlayerPool.Create(this, playerPointer, playerId);
        }

        public void OnRemovePlayer(IntPtr playerPointer)
        {
            PlayerPool.Remove(playerPointer);
        }

        public void OnCreateObject(IntPtr playerPointer, ushort playerId)
        {
            ObjectPool.Create(this, playerPointer, playerId);
        }

        public void OnRemoveObject(IntPtr playerPointer)
        {
            ObjectPool.Remove(playerPointer);
        }

        public void OnCreateVehicle(IntPtr vehiclePointer, ushort vehicleId)
        {
            VehiclePool.Create(this, vehiclePointer, vehicleId);
        }

        public void OnCreateVoiceChannel(IntPtr channelPointer)
        {
            VoiceChannelPool.Create(this, channelPointer);
        }

        public void OnCreateColShape(IntPtr colShapePointer)
        {
            ColShapePool.Create(this, colShapePointer);
        }

        public void OnRemoveVehicle(IntPtr vehiclePointer)
        {
            VehiclePool.Remove(vehiclePointer);
        }

        public void OnCreateBlip(IntPtr blipPointer)
        {
            BlipPool.Create(this, blipPointer);
        }

        public void OnRemoveBlip(IntPtr blipPointer)
        {
            BlipPool.Remove(blipPointer);
        }

        public void OnCreateCheckpoint(IntPtr checkpointPointer)
        {
            CheckpointPool.Create(this, checkpointPointer);
        }

        public void OnRemoveCheckpoint(IntPtr checkpointPointer)
        {
            CheckpointPool.Remove(checkpointPointer);
        }

        public void OnRemoveVoiceChannel(IntPtr channelPointer)
        {
            VoiceChannelPool.Remove(channelPointer);
        }

        public void OnRemoveColShape(IntPtr colShapePointer)
        {
            ColShapePool.Remove(colShapePointer);
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
    }
}