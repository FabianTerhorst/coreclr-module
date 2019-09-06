using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Events
{
    public delegate void CheckpointDelegate(ICheckpoint checkpoint, IEntity entity, bool state);

    public delegate void ClientEventDelegate(IPlayer player, object[] args);

    public delegate void PlayerConnectDelegate(IPlayer player, string reason);

    public delegate void PlayerDamageDelegate(IPlayer player, IEntity attacker, uint weapon, ushort damage);

    public delegate void PlayerDeadDelegate(IPlayer player, IEntity killer, uint weapon);

    public delegate void PlayerDisconnectDelegate(IPlayer player, string reason);

    public delegate void PlayerRemoveDelegate(IPlayer player);

    public delegate void VehicleRemoveDelegate(IVehicle vehicle);

    public delegate void ServerEventDelegate(object[] args);

    public delegate void PlayerClientEventDelegate(IPlayer player, string eventName, object[] args);

    public delegate void PlayerClientCustomEventDelegate(IPlayer player, string eventName, ref MValueArray mValueArray);

    public delegate void PlayerChangeVehicleSeatDelegate(IVehicle vehicle, IPlayer player, byte oldSeat, byte newSeat);

    public delegate void PlayerEnterVehicleDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate void PlayerLeaveVehicleDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate void ServerEventEventDelegate(string eventName, object[] args);

    public delegate void ServerCustomEventEventDelegate(string eventName, ref MValueArray mValueArray);

    public delegate void ConsoleCommandDelegate(string name, string[] args);
    
    public delegate void MetaDataChangeDelegate(IEntity entity, string key, object value);
    
    public delegate void ColShapeDelegate(IColShape colShape, IEntity targetEntity, bool state);
}