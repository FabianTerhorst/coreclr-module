using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;
using System.Windows.Input;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Data;

namespace AltV.Net.Client.Events
{
    public delegate void TickDelegate();
    public delegate void ConsoleCommandDelegate(string name, string[] args);
    public delegate void PlayerSpawnDelegate();
    public delegate void PlayerDisconnectDelegate();
    public delegate void PlayerEnterVehicleDelegate(IVehicle vehicle, byte seat);
    public delegate void PlayerChangeVehicleSeatDelegate(IVehicle vehicle, byte oldSeat, byte newSeat);
    public delegate void PlayerChangeAnimationDelegate(IPlayer player, uint oldDict, uint newDict, uint oldName, uint newName);
    public delegate void PlayerChangeInteriorDelegate(IPlayer player, uint oldIntLoc, uint newIntLoc);
    public delegate void PlayerWeaponShootDelegate(uint weapon, ushort totalAmmo, ushort ammoInClip);
    public delegate void PlayerWeaponChangeDelegate(uint oldWeapon, uint newWeapon);
    public delegate void PlayerLeaveVehicleDelegate(IVehicle vehicle, byte seat);
    public delegate void GameEntityCreateDelegate(IEntity entity);
    public delegate void GameEntityDestroyDelegate(IEntity entity);
    public delegate void RemoveEntityDelegate(IEntity entity);

    public delegate void AnyResourceErrorDelegate(string name);
    public delegate void AnyResourceStartDelegate(string name);
    public delegate void AnyResourceStopDelegate(string name);

    public delegate void KeyUpDelegate(Key key);
    public delegate void KeyDownDelegate(Key key);

    public delegate void ConnectionCompleteDelegate();

    public delegate void GlobalMetaChangeDelegate(string key, object value, object oldValue);
    public delegate void GlobalSyncedMetaChangeDelegate(string key, object value, object oldValue);
    public delegate void LocalMetaChangeDelegate(string key, object value, object oldValue);
    public delegate void StreamSyncedMetaChangeDelegate(IBaseObject target, string key, object value, object oldValue);
    public delegate void SyncedMetaChangeDelegate(IBaseObject target, string key, object value, object oldValue);
    public delegate void MetaChangeDelegate(IBaseObject target, string key, object value, object oldValue);

    public delegate void TaskChangeDelegate(int oldTask, int newTask);

    public delegate void WindowFocusChangeDelegate(bool state);
    public delegate void WindowResolutionChangeDelegate(Vector2 oldResolution, Vector2 newResolution);

    public delegate void NetOwnerChangeDelegate(IEntity target, IPlayer? newOwner, IPlayer? oldOwner);

    public delegate bool WeaponDamageDelegate(IEntity target, uint weapon, ushort damage, Position shotOffset,
        BodyPart bodyPart);

    public delegate void WorldObjectPositionChangeDelegate(IWorldObject target, Position oldPosition);
    public delegate void WorldObjectStreamInDelegate(IWorldObject target);
    public delegate void WorldObjectStreamOutDelegate(IWorldObject target);

    public delegate void ColShapeDelegate(IColShape colShape, IWorldObject target, bool state);
    public delegate void CheckpointDelegate(ICheckpoint checkpoint, IWorldObject target, bool state);


}