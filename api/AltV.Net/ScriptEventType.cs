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
        PlayerChangeVehicleSeat,
        PlayerEnterVehicle,
        PlayerLeaveVehicle,
        PlayerEvent,
        PlayerCustomEvent,
        ServerEvent,
        ServerCustomEvent,
        ConsoleCommand,
        MetaDataChange,
        SyncedMetaDataChange,
        ColShape
    }
}