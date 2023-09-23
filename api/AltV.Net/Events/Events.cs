using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Types;

namespace AltV.Net.Events
{
    public delegate void CheckpointDelegate(ICheckpoint checkpoint, IWorldObject entity, bool state);

    public delegate void ClientEventDelegate(IPlayer player, object[] args);

    public delegate void PlayerConnectDelegate(IPlayer player, string reason);

    public delegate void PlayerConnectDeniedDelegate(PlayerConnectDeniedReason reason, string name, string ip,
        ulong passwordHash, bool isDebug, string branch, uint majorVersion, string cdnUrl, long discordId);

    public delegate void ResourceEventDelegate(INativeResource resource);

    public delegate void PlayerDamageDelegate(IPlayer player, IEntity attacker, uint weapon, ushort healthDamage, ushort armourDamage);

    public delegate void PlayerDeadDelegate(IPlayer player, IEntity killer, uint weapon);

    public delegate void PlayerHealDelegate(IPlayer target, ushort oldHealth, ushort newHealth, ushort oldArmour,
        ushort newArmour);

    public delegate void PlayerDisconnectDelegate(IPlayer player, string reason);

    public delegate void PlayerRemoveDelegate(IPlayer player);

    public delegate void VehicleRemoveDelegate(IVehicle vehicle);

    public delegate void PedRemoveDelegate(IPed ped);

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

    public delegate void ColShapeDelegate(IColShape colShape, IWorldObject targetEntity, bool state);

    public delegate bool ExplosionDelegate(IPlayer player, ExplosionType explosionType, Position position,
        uint explosionFx, IEntity targetEntity);

    public delegate WeaponDamageResponse WeaponDamageDelegate(IPlayer player, IEntity target, uint weapon, ushort damage,
        Position shotOffset, BodyPart bodyPart);

    public delegate void VehicleDestroyDelegate(IVehicle vehicle);

    public delegate bool FireDelegate(IPlayer player, FireInfo[] fireInfos);

    public delegate bool StartProjectileDelegate(IPlayer player, Position startPosition, Position direction, uint ammoHash, uint weaponHash);

    public delegate void PlayerWeaponChangeDelegate(IPlayer player, uint oldWeapon, uint newWeapon);

    public delegate void NetOwnerChangeDelegate(IEntity target, IPlayer oldNetOwner, IPlayer newNetOwner);

    public delegate void VehicleAttachDelegate(IVehicle target, IVehicle attachedVehicle);

    public delegate void VehicleDetachDelegate(IVehicle target, IVehicle detachedVehicle);

    public delegate void VehicleDamageDelegate(IVehicle target, IEntity attacker, uint bodyHealthDamage, uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage, uint weaponHash);

    public delegate bool VehicleHornDelegate(IVehicle target, IPlayer reporter, bool state);

    public delegate void ConnectionQueueAddDelegate(IConnectionInfo connectionInfo);

    public delegate void ConnectionQueueRemoveDelegate(IConnectionInfo connectionInfo);

    public delegate void ServerStartedDelegate();

    public delegate void PlayerRequestControlDelegate(IEntity target, IPlayer player);

    public delegate void PlayerChangeAnimationDelegate(IPlayer player, uint oldDict, uint newDict, uint oldName, uint newName);

    public delegate void PlayerChangeInteriorDelegate(IPlayer player, uint oldIntLoc, uint newIntLoc);

    public delegate void PlayerDimensionChangeDelegate(IPlayer player, int oldDimension, int newDimension);

    public delegate void VehicleSirenDelegate(IVehicle targetVehicle, bool state);

    public delegate void PlayerSpawnDelegate(IPlayer player);

    public delegate bool RequestSyncedSceneDelegate(IPlayer source, int sceneId);

    public delegate void StartSyncedSceneDelegate(IPlayer source, int sceneId, Position position, Rotation rotation, uint animDictHash, Dictionary<IEntity, uint> entityAndAnimHash);
    public delegate void StopSyncedSceneDelegate(IPlayer source, int sceneId);
    public delegate void UpdateSyncedSceneDelegate(IPlayer source, float startRate, int sceneId);
    public delegate bool ClientRequestObjectDelegate(IPlayer target, uint model, Position position);
    public delegate bool ClientDeleteObjectDelegate(IPlayer target);

    public delegate bool GivePedScriptedTaskDelegate(IPlayer source, IPed target, uint taskType);

    public delegate void PedDamageDelegate(IPed ped, IEntity attacker, uint weapon, ushort healthDamage, ushort armourDamage);

    public delegate void PedDeadDelegate(IPed ped, IEntity killer, uint weapon);

    public delegate void PedHealDelegate(IPed ped, ushort oldHealth, ushort newHealth, ushort oldArmour,
        ushort newArmour);
    public delegate bool PlayerStartTalkingDelegate(IPlayer Player);
    public delegate bool PlayerStopTalkingDelegate(IPlayer Player);
}