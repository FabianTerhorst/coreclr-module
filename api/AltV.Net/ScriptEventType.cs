namespace AltV.Net
{
    public enum ScriptEventType
    {
        Checkpoint,
        PlayerConnect,
        PlayerBeforeConnect,
        PlayerDamage,
        PlayerDead,
        PlayerDisconnect,
        PlayerRemove,
        VehicleRemove,
        PlayerChangeVehicleSeat,
        PlayerEnterVehicle,
        PlayerEnteringVehicle,
        PlayerLeaveVehicle,
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
    }
}