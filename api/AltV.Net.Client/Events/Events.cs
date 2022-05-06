using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Events
{
    public delegate void TickDelegate();
    public delegate void ConsoleCommandDelegate(string name, string[] args);
    public delegate void PlayerSpawnDelegate();
    public delegate void PlayerDisconnectDelegate();
    public delegate void PlayerEnterVehicleDelegate(IVehicle vehicle, byte seat);
    public delegate void PlayerChangeVehicleSeatDelegate(IVehicle vehicle, byte oldSeat, byte newSeat);
    public delegate void PlayerLeaveVehicleDelegate(IVehicle vehicle, byte seat);
    public delegate void GameEntityCreateDelegate(IEntity entity);
    public delegate void GameEntityDestroyDelegate(IEntity entity);
    public delegate void RemoveEntityDelegate(IEntity entity);

    public delegate void AnyResourceErrorDelegate(string name);
    public delegate void AnyResourceStartDelegate(string name);
    public delegate void AnyResourceStopDelegate(string name);

    public delegate void KeyUpDelegate(ConsoleKey key);
    public delegate void KeyDownDelegate(ConsoleKey key);

    public delegate void ConnectionCompleteDelegate();

    public delegate void GlobalMetaChangeDelegate(string key, object value, object oldValue);
    public delegate void GlobalSyncedMetaChangeDelegate(string key, object value, object oldValue);
    public delegate void LocalMetaChangeDelegate(string key, object value, object oldValue);
    public delegate void StreamSyncedMetaChangeDelegate(IEntity target, string key, object value, object oldValue);
    public delegate void SyncedMetaChangeDelegate(IEntity target, string key, object value, object oldValue);

    public delegate void TaskChangeDelegate(int oldTask, int newTask);

    public delegate void WindowFocusChangeDelegate(bool state);
    public delegate void WindowResolutionChangeDelegate(Vector2 oldResolution, Vector2 newResolution);

    public delegate void NetOwnerChangeDelegate(IEntity target, IPlayer? newOwner, IPlayer? oldOwner);


}