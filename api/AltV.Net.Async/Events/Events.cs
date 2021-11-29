using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Events
{
    public delegate Task CheckpointAsyncDelegate(ICheckpoint checkpoint, IEntity entity, bool state);

    public delegate Task ClientEventAsyncDelegate(IPlayer player, object[] args);

    public delegate Task PlayerConnectAsyncDelegate(IPlayer player, string reason);

    public delegate Task PlayerBeforeConnectAsyncDelegate(PlayerConnectionInfo connectionInfo, string reason);

    public delegate Task PlayerDamageAsyncDelegate(IPlayer player, IEntity attacker, ushort oldHealth, ushort oldArmor,
        ushort oldMaxHealth, ushort oldMaxArmor,  uint weapon, ushort healthDamage, ushort armourDamage);

    public delegate Task PlayerDeadAsyncDelegate(IPlayer player, IEntity killer, uint weapon);

    public delegate Task PlayerDisconnectAsyncDelegate(IPlayer player, string reason);

    public delegate Task PlayerRemoveAsyncDelegate(IPlayer player);

    public delegate Task VehicleRemoveAsyncDelegate(IVehicle vehicle);

    public delegate Task ServerEventAsyncDelegate(object[] args);

    public delegate Task PlayerChangeVehicleSeatAsyncDelegate(IVehicle vehicle, IPlayer player, byte oldSeat,
        byte newSeat);

    public delegate Task PlayerEnterVehicleAsyncDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate Task PlayerEnteringVehicleAsyncDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate Task PlayerLeaveVehicleAsyncDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate Task PlayerClientEventAsyncDelegate(IPlayer player, string eventName, object[] args);

    public delegate Task ConsoleCommandAsyncDelegate(string name, string[] args);

    public delegate Task MetaDataChangeAsyncDelegate(IEntity entity, string key, object value);

    public delegate Task ColShapeAsyncDelegate(IColShape colShape, IEntity targetEntity, bool state);

    public delegate Task ExplosionAsyncDelegate(IPlayer player, ExplosionType explosionType, Position position,
        uint explosionFx, IEntity target);

    public delegate Task WeaponDamageAsyncDelegate(IPlayer player, IEntity target, uint weapon, ushort damage,
        Position shotOffset, BodyPart bodyPart);

    public delegate Task VehicleDestroyAsyncDelegate(IVehicle vehicle);

    public delegate Task FireAsyncDelegate(IPlayer player, FireInfo[] fireInfos);

    public delegate Task StartProjectileAsyncDelegate(IPlayer player, Position startPosition, Position direction, uint ammoHash, uint weaponHash);

    public delegate Task PlayerWeaponChangeAsyncDelegate(IPlayer player, uint oldWeapon, uint newWeapon);

    public delegate Task NetOwnerChangeAsyncDelegate(IEntity target, IPlayer oldNetOwner, IPlayer newNetOwner);

    public delegate Task VehicleAttachAsyncDelegate(IVehicle target, IVehicle attachedVehicle);

    public delegate Task VehicleDetachAsyncDelegate(IVehicle target, IVehicle detachedVehicle);

    public delegate Task VehicleDamageAsyncDelegate(IVehicle target, IEntity attacker, uint bodyHealthDamage, uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weaponHash);
}