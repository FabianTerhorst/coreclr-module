namespace AltV.Net
{
    public enum ScriptEventType
    {
        Checkpoint,
        PlayerConnect,
        PlayerDamage,
        PlayerDead,
        PlayerDisconnect,
        PlayerRemove,
        VehicleRemove,
        PedRemove,
        PlayerChangeVehicleSeat,
        PlayerEnterVehicle,
        PlayerStartEnterVehicle,
        PlayerEnteringVehicle,
        PlayerLeaveVehicle,
        PlayerStartLeaveVehicle,
        PlayerEvent,
        PlayerCustomEvent,
        ServerEvent,
        ServerCustomEvent,
        ConsoleCommand,
        MetaDataChange,
        SyncedMetaDataChange,
        ColShape,
        WeaponDamage,
        VehicleDestroy,
        Explosion,
        Fire,
        StartProjectile,
        PlayerWeaponChange,
        NetOwnerChange,
        VehicleAttach,
        VehicleDetach,
        VehicleDamage,
        ConnectionQueueAdd,
        ConnectionQueueRemove,
        ServerStarted,
        PlayerRequestControl,
        PlayerChangeAnimation,
        PlayerChangeInterior,
        PlayerDimensionChange,
        VehicleHorn,
        VehicleSiren,
        PlayerSpawn,
        RequestSyncedScene
    }
}