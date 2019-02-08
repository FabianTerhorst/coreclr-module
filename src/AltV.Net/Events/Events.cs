using AltV.Net.Elements.Entities;

namespace AltV.Net.Events
{
    public delegate void CheckpointDelegate(ICheckpoint checkpoint, IEntity entity, bool state);

    public delegate void ClientEventDelegate(IPlayer player, object[] args);

    public delegate void PlayerConnectDelegate(IPlayer player, string reason);

    public delegate void PlayerDamageDelegate(IPlayer player, IEntity attacker, uint weapon, byte damage);

    public delegate void PlayerDeadDelegate(IPlayer player, IEntity killer, uint weapon);

    public delegate void PlayerDisconnectDelegate(IPlayer player, string reason);

    public delegate void EntityRemoveDelegate(IEntity entity);

    public delegate void EventDelegate(object[] args);

    public delegate void VehicleChangeSeatDelegate(IVehicle vehicle, IPlayer player, sbyte oldSeat, sbyte newSeat);

    public delegate void VehicleEnterDelegate(IVehicle vehicle, IPlayer player, sbyte seat);

    public delegate void VehicleLeaveDelegate(IVehicle vehicle, IPlayer player, sbyte seat);
}