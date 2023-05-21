using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;

namespace AltV.Net
{
    /// <summary>
    /// This pool decides which entity pool to use depending on the entity type
    /// </summary>
    public interface IPoolManager : ISharedPoolManager
    {
        new IEntityPool<IPlayer> Player { get; }
        new IEntityPool<IVehicle> Vehicle { get; }
        new IEntityPool<IPed> Ped { get; }
        new IEntityPool<IObject> Object { get; }
        IEntityPool<INetworkObject> NetworkObject { get; }

        new IBaseObjectPool<IBlip> Blip { get; }
        new IBaseObjectPool<ICheckpoint> Checkpoint { get; }
        new IBaseObjectPool<IColShape> ColShape { get; }
        new IBaseObjectPool<IVirtualEntity> VirtualEntity { get; }
        new IBaseObjectPool<IVirtualEntityGroup> VirtualEntityGroup { get; }
        new IBaseObjectPool<IMarker> Marker { get; }
        IBaseObjectPool<IVoiceChannel> VoiceChannel { get; }
        IBaseObjectPool<IConnectionInfo> ConnectionInfo { get; }

        IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId);
        IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType);
        IBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType);
        bool Remove(IBaseObject baseObject);
        bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType);
    }
}