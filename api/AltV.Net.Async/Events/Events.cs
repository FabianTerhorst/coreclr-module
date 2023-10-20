using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Types;

namespace AltV.Net.Async.Events
{
    public delegate Task CheckpointAsyncDelegate(ICheckpoint checkpoint, IWorldObject entity, bool state);

    public delegate Task ClientEventAsyncDelegate(IPlayer player, object[] args);

    public delegate Task PlayerConnectAsyncDelegate(IPlayer player, string reason);

    public delegate Task PlayerConnectDeniedAsyncDelegate(PlayerConnectDeniedReason reason, string name, string ip,
        ulong passwordHash, bool isDebug, string branch, uint majorVersion, string cdnUrl, long discordId);

    public delegate Task ResourceEventAsyncDelegate(INativeResource resource);

    public delegate Task PlayerDamageAsyncDelegate(IPlayer player, IEntity attacker, ushort oldHealth, ushort oldArmor,
        ushort oldMaxHealth, ushort oldMaxArmor,  uint weapon, ushort healthDamage, ushort armourDamage);

    public delegate Task PlayerDeadAsyncDelegate(IPlayer player, IEntity killer, uint weapon);

    public delegate Task PlayerHealAsyncDelegate(IPlayer target, ushort oldHealth, ushort newHealth, ushort oldArmour,
        ushort newArmour);

    public delegate Task PlayerDisconnectAsyncDelegate(IPlayer player, string reason);

    public delegate Task PlayerRemoveAsyncDelegate(IPlayer player);

    public delegate Task VehicleRemoveAsyncDelegate(IVehicle vehicle);

    public delegate Task PedRemoveAsyncDelegate(IPed ped);

    public delegate Task ServerEventAsyncDelegate(object[] args);

    public delegate Task PlayerChangeVehicleSeatAsyncDelegate(IVehicle vehicle, IPlayer player, byte oldSeat,
        byte newSeat);

    public delegate Task PlayerEnterVehicleAsyncDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate Task PlayerEnteringVehicleAsyncDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate Task PlayerLeaveVehicleAsyncDelegate(IVehicle vehicle, IPlayer player, byte seat);

    public delegate Task PlayerClientEventAsyncDelegate(IPlayer player, string eventName, object[] args);

    public delegate Task ConsoleCommandAsyncDelegate(string name, string[] args);

    public delegate Task MetaDataChangeAsyncDelegate(IEntity entity, string key, object value);

    public delegate Task ColShapeAsyncDelegate(IColShape colShape, IWorldObject targetEntity, bool state);

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

    public delegate Task VehicleHornAsyncDelegate(IVehicle target, IPlayer reporter, bool state);

    public delegate Task ConnectionQueueAddAsyncDelegate(IConnectionInfo connectionInfo);

    public delegate Task ConnectionQueueRemoveAsyncDelegate(IConnectionInfo connectionInfo);

    public delegate Task ServerStartedAsyncDelegate();

    public delegate Task PlayerRequestControlAsyncDelegate(IEntity target, IPlayer player);

    public delegate Task PlayerChangeAnimationAsyncDelegate(IPlayer player, uint oldDict, uint newDict, uint oldName, uint newName);

    public delegate Task PlayerChangeInteriorAsyncDelegate(IPlayer player, uint oldIntLoc, uint newIntLoc);

    public delegate Task PlayerDimensionChangeAsyncDelegate(IPlayer player, int oldDimension, int newDimension);

    public delegate Task VehicleSirenAsyncDelegate(IVehicle vehicle, bool state);

    public delegate Task PlayerSpawnAsyncDelegate(IPlayer player);

    public delegate Task RequestSyncedSceneAsyncEventDelegate(IPlayer source, int sceneId);

    public delegate Task StartSyncedSceneAsyncEventDelegate(IPlayer source, int sceneId, Position position, Rotation rotation, uint animDictHash, Dictionary<IEntity, uint> entityAndAnimHash);
    public delegate Task StopSyncedSceneAsyncEventDelegate(IPlayer source, int sceneId);
    public delegate Task UpdateSyncedSceneAsyncEventDelegate(IPlayer source, float startRate, int sceneId);
    public delegate Task ClientRequestObjectAsyncEventDelegate(IPlayer target, uint model, Position position);
    public delegate Task ClientDeleteObjectAsyncEventDelegate(IPlayer target);

    public delegate Task GivePedScriptedTaskAsyncDelegate(IPlayer source, IPed target, uint taskType);

    public delegate Task PedDamageAsyncDelegate(IPed ped, IEntity attacker, uint weapon, ushort healthDamage, ushort armourDamage);

    public delegate Task PedDeadAsyncDelegate(IPed ped, IEntity killer, uint weapon);

    public delegate Task PedHealAsyncDelegate(IPed ped, ushort oldHealth, ushort newHealth, ushort oldArmour,
        ushort newArmour);
    public delegate Task PlayerStartTalkingAsyncDelegate(IPlayer Player);
    public delegate Task PlayerStopTalkingAsyncDelegate(IPlayer Player);

    public delegate Task ScriptRpcAsyncDelegate(IScriptRPCEvent scriptRpcEvent, IPlayer target, string name, object[] args, ushort answerId);
    public delegate Task ScriptRpcAnswerAsyncDelegate(IPlayer target, ushort answerId, object answer, string answerError);
}