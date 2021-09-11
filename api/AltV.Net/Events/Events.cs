using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Events
{
    public delegate void CheckpointDelegate(ICheckpoint checkpoint, IEntity entity, bool state);

    public delegate void ClientEventDelegate(IPlayer player, object[] args);

    public delegate void PlayerConnectDelegate(IPlayer player, string reason);
    
    public delegate void ResourceEventDelegate(INativeResource resource);

    public delegate void PlayerDamageDelegate(IPlayer player, IEntity attacker, uint weapon, ushort healthDamage, ushort armourDamage);

    public delegate void PlayerDeadDelegate(IPlayer player, IEntity killer, uint weapon);

    public delegate void PlayerDisconnectDelegate(IPlayer player, string reason);

    public delegate void PlayerRemoveDelegate(IPlayer player);

    public delegate void VehicleRemoveDelegate(IVehicle vehicle);

    public delegate void ServerEventDelegate(object[] args);

    public delegate void PlayerClientEventDelegate(IPlayer player, string eventName, object[] args);

    public delegate void PlayerClientCustomEventDelegate(IPlayer player, string eventName, MValueConst[] mValueArray);

    public delegate void PlayerChangeVehicleSeatDelegate(IVehicle vehicle, IPlayer player, byte oldSeat, byte newSeat);

    public delegate void PlayerEnterVehicleDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate void PlayerEnteringVehicleDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate void PlayerLeaveVehicleDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate void ServerEventEventDelegate(string eventName, object[] args);

    public delegate void ServerCustomEventEventDelegate(string eventName, MValueConst[] mValueArray);

    public delegate void ConsoleCommandDelegate(string name, string[] args);

    public delegate void MetaDataChangeDelegate(IEntity entity, string key, object value);

    public delegate void ColShapeDelegate(IColShape colShape, IEntity targetEntity, bool state);

    public delegate bool ExplosionDelegate(IPlayer player, ExplosionType explosionType, Position position,
        uint explosionFx, IEntity targetEntity);

    public delegate bool WeaponDamageDelegate(IPlayer player, IEntity target, uint weapon, ushort damage,
        Position shotOffset, BodyPart bodyPart);
    
    public delegate void VehicleDestroyDelegate(IVehicle vehicle);
    
    public delegate bool FireDelegate(IPlayer player, FireInfo[] fireInfos);
    
    public delegate bool StartProjectileDelegate(IPlayer player, Position startPosition, Position direction, uint ammoHash, uint weaponHash);
    
    public delegate bool PlayerWeaponChangeDelegate(IPlayer player, uint oldWeapon, uint newWeapon);
    
    public delegate void NetOwnerChangeDelegate(IEntity target, IPlayer oldNetOwner, IPlayer newNetOwner);
    
    public delegate void VehicleAttachDelegate(IVehicle target, IVehicle attachedVehicle);
    
    public delegate void VehicleDetachDelegate(IVehicle target, IVehicle detachedVehicle);
    
    public delegate void VehicleDamageDelegate(IVehicle target, IEntity attacker, uint bodyHealthDamage, uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weaponHash);
}