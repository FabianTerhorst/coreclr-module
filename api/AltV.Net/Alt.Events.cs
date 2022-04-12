using AltV.Net.Events;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static event CheckpointDelegate OnCheckpoint
        {
            add => CoreImpl.CheckpointEventHandler.Add(value);
            remove => CoreImpl.CheckpointEventHandler.Remove(value);
        }

        /// <summary>
        /// Player connect event handler
        /// <example>
        /// <code>
        /// Alt.OnPlayerConnect += (player, reason) => {
        ///   Console.WriteLine($"{player.Name} connected.");
        /// };
        /// </code>
        /// </example>
        /// </summary>
        public static event PlayerConnectDelegate OnPlayerConnect
        {
            add => CoreImpl.PlayerConnectEventHandler.Add(value);
            remove => CoreImpl.PlayerConnectEventHandler.Remove(value);
        }

        public static event PlayerBeforeConnectDelegate OnPlayerBeforeConnect
        {
            add => CoreImpl.PlayerBeforeConnectEventHandler.Add(value);
            remove => CoreImpl.PlayerBeforeConnectEventHandler.Remove(value);
        }

        public static event ResourceEventDelegate OnAnyResourceStart
        {
            add => CoreImpl.ResourceStartEventHandler.Add(value);
            remove => CoreImpl.ResourceStartEventHandler.Remove(value);
        }

        public static event ResourceEventDelegate OnAnyResourceStop
        {
            add => CoreImpl.ResourceStopEventHandler.Add(value);
            remove => CoreImpl.ResourceStopEventHandler.Remove(value);
        }

        public static event ResourceEventDelegate OnAnyResourceError
        {
            add => CoreImpl.ResourceErrorEventHandler.Add(value);
            remove => CoreImpl.ResourceErrorEventHandler.Remove(value);
        }

        public static event PlayerDamageDelegate OnPlayerDamage
        {
            add => CoreImpl.PlayerDamageEventHandler.Add(value);
            remove => CoreImpl.PlayerDamageEventHandler.Remove(value);
        }

        public static event PlayerDeadDelegate OnPlayerDead
        {
            add => CoreImpl.PlayerDeadEventHandler.Add(value);
            remove => CoreImpl.PlayerDeadEventHandler.Remove(value);
        }

        public static event ExplosionDelegate OnExplosion
        {
            add => CoreImpl.ExplosionEventHandler.Add(value);
            remove => CoreImpl.ExplosionEventHandler.Remove(value);
        }

        /// <summary>
        /// Weapon damage event handler
        /// <example>
        /// <code>
        /// Alt.OnWeaponDamage += (player, target, weapon, damage, shotOffset, bodyPart) => {
        ///   Console.WriteLine($"{player.Name} got damaged.");
        ///   return true; // return false will cancel the weapon damage event and player won't receive damage.
        /// };
        /// </code>
        /// </example>
        /// </summary>
        public static event WeaponDamageDelegate OnWeaponDamage
        {
            add => CoreImpl.WeaponDamageEventHandler.Add(value);
            remove => CoreImpl.WeaponDamageEventHandler.Remove(value);
        }

        public static event PlayerDisconnectDelegate OnPlayerDisconnect
        {
            add => CoreImpl.PlayerDisconnectEventHandler.Add(value);
            remove => CoreImpl.PlayerDisconnectEventHandler.Remove(value);
        }

        public static event PlayerRemoveDelegate OnPlayerRemove
        {
            add => CoreImpl.PlayerRemoveEventHandler.Add(value);
            remove => CoreImpl.PlayerRemoveEventHandler.Remove(value);
        }

        public static event VehicleRemoveDelegate OnVehicleRemove
        {
            add => CoreImpl.VehicleRemoveEventHandler.Add(value);
            remove => CoreImpl.VehicleRemoveEventHandler.Remove(value);
        }

        public static event PlayerChangeVehicleSeatDelegate OnPlayerChangeVehicleSeat
        {
            add => CoreImpl.PlayerChangeVehicleSeatEventHandler.Add(value);
            remove => CoreImpl.PlayerChangeVehicleSeatEventHandler.Remove(value);
        }

        public static event PlayerEnterVehicleDelegate OnPlayerEnterVehicle
        {
            add => CoreImpl.PlayerEnterVehicleEventHandler.Add(value);
            remove => CoreImpl.PlayerEnterVehicleEventHandler.Remove(value);
        }

        public static event PlayerEnteringVehicleDelegate OnPlayerEnteringVehicle
        {
            add => CoreImpl.PlayerEnteringVehicleEventHandler.Add(value);
            remove => CoreImpl.PlayerEnteringVehicleEventHandler.Remove(value);
        }

        public static event PlayerLeaveVehicleDelegate OnPlayerLeaveVehicle
        {
            add => CoreImpl.PlayerLeaveVehicleEventHandler.Add(value);
            remove => CoreImpl.PlayerLeaveVehicleEventHandler.Remove(value);
        }

        public static event PlayerClientEventDelegate OnPlayerEvent
        {
            add => CoreImpl.PlayerClientEventEventHandler.Add(value);
            remove => CoreImpl.PlayerClientEventEventHandler.Remove(value);
        }

        public static event PlayerClientCustomEventDelegate OnPlayerCustomEvent
        {
            add => CoreImpl.PlayerClientCustomEventEventHandler.Add(value);
            remove => CoreImpl.PlayerClientCustomEventEventHandler.Remove(value);
        }

        public static event ServerEventEventDelegate OnServerEvent
        {
            add => CoreImpl.ServerEventEventHandler.Add(value);
            remove => CoreImpl.ServerEventEventHandler.Remove(value);
        }

        public static event ServerCustomEventEventDelegate OnServerCustomEvent
        {
            add => CoreImpl.ServerCustomEventEventHandler.Add(value);
            remove => CoreImpl.ServerCustomEventEventHandler.Remove(value);
        }

        public static event ConsoleCommandDelegate OnConsoleCommand
        {
            add => CoreImpl.ConsoleCommandEventHandler.Add(value);
            remove => CoreImpl.ConsoleCommandEventHandler.Remove(value);
        }

        /// <summary>
        /// Event that is invoked when the meta data of an entity has changed.
        /// </summary>
        /// <remarks>Meta data is accessible across different serverside resources.</remarks>
        public static event MetaDataChangeDelegate OnMetaDataChange
        {
            add => CoreImpl.MetaDataChangeEventHandler.Add(value);
            remove => CoreImpl.MetaDataChangeEventHandler.Remove(value);
        }

        /// <summary>
        /// Event that is invoked when the synced meta data of an entity has changed.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and to all clients without range limitation.</remarks>
        public static event MetaDataChangeDelegate OnSyncedMetaDataChange
        {
            add => CoreImpl.SyncedMetaDataChangeEventHandler.Add(value);
            remove => CoreImpl.SyncedMetaDataChangeEventHandler.Remove(value);
        }

        public static event ColShapeDelegate OnColShape
        {
            add => CoreImpl.ColShapeEventHandler.Add(value);
            remove => CoreImpl.ColShapeEventHandler.Remove(value);
        }

        public static event VehicleDestroyDelegate OnVehicleDestroy
        {
            add => CoreImpl.VehicleDestroyEventHandler.Add(value);
            remove => CoreImpl.VehicleDestroyEventHandler.Remove(value);
        }

        public static event FireDelegate OnFire
        {
            add => CoreImpl.FireEventHandler.Add(value);
            remove => CoreImpl.FireEventHandler.Remove(value);
        }

        public static event StartProjectileDelegate OnStartProjectile
        {
            add => CoreImpl.StartProjectileEventHandler.Add(value);
            remove => CoreImpl.StartProjectileEventHandler.Remove(value);
        }

        public static event PlayerWeaponChangeDelegate OnPlayerWeaponChange
        {
            add => CoreImpl.PlayerWeaponChangeEventHandler.Add(value);
            remove => CoreImpl.PlayerWeaponChangeEventHandler.Remove(value);
        }

        public static event NetOwnerChangeDelegate OnNetworkOwnerChange
        {
            add => CoreImpl.NetOwnerChangeEventHandler.Add(value);
            remove => CoreImpl.NetOwnerChangeEventHandler.Remove(value);
        }

        public static event VehicleAttachDelegate OnVehicleAttach
        {
            add => CoreImpl.VehicleAttachEventHandler.Add(value);
            remove => CoreImpl.VehicleAttachEventHandler.Remove(value);
        }

        public static event VehicleDetachDelegate OnVehicleDetach
        {
            add => CoreImpl.VehicleDetachEventHandler.Add(value);
            remove => CoreImpl.VehicleDetachEventHandler.Remove(value);
        }

        public static event VehicleDamageDelegate OnVehicleDamage
        {
            add => CoreImpl.VehicleDamageEventHandler.Add(value);
            remove => CoreImpl.VehicleDamageEventHandler.Remove(value);
        }
        
        public static event ConnectionQueueAddDelegate OnConnectionQueueAdd
        {
            add => CoreImpl.ConnectionQueueAddHandler.Add(value);
            remove => CoreImpl.ConnectionQueueAddHandler.Remove(value);
        }
        
        public static event ConnectionQueueRemoveDelegate OnConnectionQueueRemove
        {
            add => CoreImpl.ConnectionQueueRemoveHandler.Add(value);
            remove => CoreImpl.ConnectionQueueRemoveHandler.Remove(value);
        }
        
        public static event ServerStartedDelegate OnServerStarted
        {
            add => CoreImpl.ServerStartedHandler.Add(value);
            remove => CoreImpl.ServerStartedHandler.Remove(value);
        }
        
        public static event PlayerRequestControlDelegate OnPlayerRequestControl
        {
            add => CoreImpl.PlayerRequestControlHandler.Add(value);
            remove => CoreImpl.PlayerRequestControlHandler.Remove(value);
        }
        
    }
}