using AltV.Net.Events;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static event CheckpointDelegate OnCheckpoint
        {
            add => Core.CheckpointEventHandler.Add(value);
            remove => Core.CheckpointEventHandler.Remove(value);
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
            add => Core.PlayerConnectEventHandler.Add(value);
            remove => Core.PlayerConnectEventHandler.Remove(value);
        }

        public static event PlayerBeforeConnectDelegate OnPlayerBeforeConnect
        {
            add => Core.PlayerBeforeConnectEventHandler.Add(value);
            remove => Core.PlayerBeforeConnectEventHandler.Remove(value);
        }

        public static event ResourceEventDelegate OnAnyResourceStart
        {
            add => Core.ResourceStartEventHandler.Add(value);
            remove => Core.ResourceStartEventHandler.Remove(value);
        }

        public static event ResourceEventDelegate OnAnyResourceStop
        {
            add => Core.ResourceStopEventHandler.Add(value);
            remove => Core.ResourceStopEventHandler.Remove(value);
        }

        public static event ResourceEventDelegate OnAnyResourceError
        {
            add => Core.ResourceErrorEventHandler.Add(value);
            remove => Core.ResourceErrorEventHandler.Remove(value);
        }

        public static event PlayerDamageDelegate OnPlayerDamage
        {
            add => Core.PlayerDamageEventHandler.Add(value);
            remove => Core.PlayerDamageEventHandler.Remove(value);
        }

        public static event PlayerDeadDelegate OnPlayerDead
        {
            add => Core.PlayerDeadEventHandler.Add(value);
            remove => Core.PlayerDeadEventHandler.Remove(value);
        }

        public static event ExplosionDelegate OnExplosion
        {
            add => Core.ExplosionEventHandler.Add(value);
            remove => Core.ExplosionEventHandler.Remove(value);
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
            add => Core.WeaponDamageEventHandler.Add(value);
            remove => Core.WeaponDamageEventHandler.Remove(value);
        }

        public static event PlayerDisconnectDelegate OnPlayerDisconnect
        {
            add => Core.PlayerDisconnectEventHandler.Add(value);
            remove => Core.PlayerDisconnectEventHandler.Remove(value);
        }

        public static event PlayerRemoveDelegate OnPlayerRemove
        {
            add => Core.PlayerRemoveEventHandler.Add(value);
            remove => Core.PlayerRemoveEventHandler.Remove(value);
        }

        public static event VehicleRemoveDelegate OnVehicleRemove
        {
            add => Core.VehicleRemoveEventHandler.Add(value);
            remove => Core.VehicleRemoveEventHandler.Remove(value);
        }

        public static event PlayerChangeVehicleSeatDelegate OnPlayerChangeVehicleSeat
        {
            add => Core.PlayerChangeVehicleSeatEventHandler.Add(value);
            remove => Core.PlayerChangeVehicleSeatEventHandler.Remove(value);
        }

        public static event PlayerEnterVehicleDelegate OnPlayerEnterVehicle
        {
            add => Core.PlayerEnterVehicleEventHandler.Add(value);
            remove => Core.PlayerEnterVehicleEventHandler.Remove(value);
        }

        public static event PlayerEnteringVehicleDelegate OnPlayerEnteringVehicle
        {
            add => Core.PlayerEnteringVehicleEventHandler.Add(value);
            remove => Core.PlayerEnteringVehicleEventHandler.Remove(value);
        }

        public static event PlayerLeaveVehicleDelegate OnPlayerLeaveVehicle
        {
            add => Core.PlayerLeaveVehicleEventHandler.Add(value);
            remove => Core.PlayerLeaveVehicleEventHandler.Remove(value);
        }

        public static event PlayerClientEventDelegate OnPlayerEvent
        {
            add => Core.PlayerClientEventEventHandler.Add(value);
            remove => Core.PlayerClientEventEventHandler.Remove(value);
        }

        public static event PlayerClientCustomEventDelegate OnPlayerCustomEvent
        {
            add => Core.PlayerClientCustomEventEventHandler.Add(value);
            remove => Core.PlayerClientCustomEventEventHandler.Remove(value);
        }

        public static event ServerEventEventDelegate OnServerEvent
        {
            add => Core.ServerEventEventHandler.Add(value);
            remove => Core.ServerEventEventHandler.Remove(value);
        }

        public static event ServerCustomEventEventDelegate OnServerCustomEvent
        {
            add => Core.ServerCustomEventEventHandler.Add(value);
            remove => Core.ServerCustomEventEventHandler.Remove(value);
        }

        public static event ConsoleCommandDelegate OnConsoleCommand
        {
            add => Core.ConsoleCommandEventHandler.Add(value);
            remove => Core.ConsoleCommandEventHandler.Remove(value);
        }

        /// <summary>
        /// Event that is invoked when the meta data of an entity has changed.
        /// </summary>
        /// <remarks>Meta data is accessible across different serverside resources.</remarks>
        public static event MetaDataChangeDelegate OnMetaDataChange
        {
            add => Core.MetaDataChangeEventHandler.Add(value);
            remove => Core.MetaDataChangeEventHandler.Remove(value);
        }

        /// <summary>
        /// Event that is invoked when the synced meta data of an entity has changed.
        /// </summary>
        /// <remarks>Synced meta data is accessible across different serverside resources and to all clients without range limitation.</remarks>
        public static event MetaDataChangeDelegate OnSyncedMetaDataChange
        {
            add => Core.SyncedMetaDataChangeEventHandler.Add(value);
            remove => Core.SyncedMetaDataChangeEventHandler.Remove(value);
        }

        public static event ColShapeDelegate OnColShape
        {
            add => Core.ColShapeEventHandler.Add(value);
            remove => Core.ColShapeEventHandler.Remove(value);
        }

        public static event VehicleDestroyDelegate OnVehicleDestroy
        {
            add => Core.VehicleDestroyEventHandler.Add(value);
            remove => Core.VehicleDestroyEventHandler.Remove(value);
        }

        public static event FireDelegate OnFire
        {
            add => Core.FireEventHandler.Add(value);
            remove => Core.FireEventHandler.Remove(value);
        }

        public static event StartProjectileDelegate OnStartProjectile
        {
            add => Core.StartProjectileEventHandler.Add(value);
            remove => Core.StartProjectileEventHandler.Remove(value);
        }

        public static event PlayerWeaponChangeDelegate OnPlayerWeaponChange
        {
            add => Core.PlayerWeaponChangeEventHandler.Add(value);
            remove => Core.PlayerWeaponChangeEventHandler.Remove(value);
        }

        public static event NetOwnerChangeDelegate OnNetworkOwnerChange
        {
            add => Core.NetOwnerChangeEventHandler.Add(value);
            remove => Core.NetOwnerChangeEventHandler.Remove(value);
        }

        public static event VehicleAttachDelegate OnVehicleAttach
        {
            add => Core.VehicleAttachEventHandler.Add(value);
            remove => Core.VehicleAttachEventHandler.Remove(value);
        }

        public static event VehicleDetachDelegate OnVehicleDetach
        {
            add => Core.VehicleDetachEventHandler.Add(value);
            remove => Core.VehicleDetachEventHandler.Remove(value);
        }

        public static event VehicleDamageDelegate OnVehicleDamage
        {
            add => Core.VehicleDamageEventHandler.Add(value);
            remove => Core.VehicleDamageEventHandler.Remove(value);
        }
        
        public static event ConnectionQueueAddDelegate OnConnectionQueueAdd
        {
            add => Core.ConnectionQueueAddHandler.Add(value);
            remove => Core.ConnectionQueueAddHandler.Remove(value);
        }
        
        public static event ConnectionQueueRemoveDelegate OnConnectionQueueRemove
        {
            add => Core.ConnectionQueueRemoveHandler.Add(value);
            remove => Core.ConnectionQueueRemoveHandler.Remove(value);
        }
    }
}