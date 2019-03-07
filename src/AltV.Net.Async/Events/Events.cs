using System.Threading.Tasks;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Events
{
    public delegate Task CheckpointAsyncDelegate(ICheckpoint checkpoint, IEntity entity, bool state);

    public delegate Task ClientEventAsyncDelegate(IPlayer player, object[] args);

    public delegate Task PlayerConnectAsyncDelegate(IPlayer player, string reason);

    public delegate Task PlayerDamageAsyncDelegate(IPlayer player, IEntity attacker, uint weapon, ushort damage);

    public delegate Task PlayerDeadAsyncDelegate(IPlayer player, IEntity killer, uint weapon);

    public delegate Task PlayerDisconnectAsyncDelegate(IPlayer player, string reason);

    public delegate Task EntityRemoveAsyncDelegate(IBaseObject entity);

    public delegate Task ServerEventAsyncDelegate(object[] args);

    public delegate Task PlayerChangeVehicleSeatAsyncDelegate(IVehicle vehicle, IPlayer player, byte oldSeat, byte newSeat);

    public delegate Task PlayerEnterVehicleAsyncDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate Task PlayerLeaveVehicleAsyncDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate Task PlayerClientEventAsyncDelegate(IPlayer player, string eventName, object[] args);
}