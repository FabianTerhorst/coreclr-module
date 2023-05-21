using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Pools;

public class PoolManager : IPoolManager
{
    public IEntityPool<IPlayer> Player { get; }
    IReadOnlyEntityPool<ISharedPlayer> ISharedPoolManager.Player => Player;
    public IEntityPool<IVehicle> Vehicle { get; }
    IReadOnlyEntityPool<ISharedVehicle> ISharedPoolManager.Vehicle => Vehicle;
    public IEntityPool<IPed> Ped { get; }
    IReadOnlyEntityPool<ISharedPed> ISharedPoolManager.Ped => Ped;
    public IEntityPool<IObject> Object { get; }
    IReadOnlyEntityPool<ISharedObject> ISharedPoolManager.Object => Object;

    public IEntityPool<INetworkObject> NetworkObject { get; }

    public IBaseObjectPool<IBlip> Blip { get; }
    IReadOnlyBaseObjectPool<ISharedBlip> ISharedPoolManager.Blip => Blip;
    public IBaseObjectPool<ICheckpoint> Checkpoint { get; }
    IReadOnlyBaseObjectPool<ISharedCheckpoint> ISharedPoolManager.Checkpoint => Checkpoint;
    public IBaseObjectPool<IVoiceChannel> VoiceChannel { get; }
    public IBaseObjectPool<IConnectionInfo> ConnectionInfo { get; }
    public IBaseObjectPool<IColShape> ColShape { get; }
    IReadOnlyBaseObjectPool<ISharedColShape> ISharedPoolManager.ColShape => ColShape;
    public IBaseObjectPool<IVirtualEntity> VirtualEntity { get; }
    IReadOnlyBaseObjectPool<ISharedVirtualEntity> ISharedPoolManager.VirtualEntity => VirtualEntity;
    public IBaseObjectPool<IVirtualEntityGroup> VirtualEntityGroup { get; }
    IReadOnlyBaseObjectPool<ISharedVirtualEntityGroup> ISharedPoolManager.VirtualEntityGroup => VirtualEntityGroup;
    public IBaseObjectPool<IMarker> Marker { get; }

    IReadOnlyBaseObjectPool<ISharedMarker> ISharedPoolManager.Marker => Marker;

    public PoolManager(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool, IEntityPool<IPed> pedPool, IEntityPool<INetworkObject> networkObjectPool,
        IBaseObjectPool<IBlip> blipPool, IBaseObjectPool<ICheckpoint> checkpointPool,
        IBaseObjectPool<IVoiceChannel> voiceChannelPool, IBaseObjectPool<IColShape> colShapePool,
        IBaseObjectPool<IVirtualEntity> virtualEntityPool,
        IBaseObjectPool<IVirtualEntityGroup> virtualEntityGroupPool,
        IBaseObjectPool<IMarker> markerPool,
        IBaseObjectPool<IConnectionInfo> connectionInfoPool)
    {
        this.Player = playerPool;
        this.Vehicle = vehiclePool;
        this.Ped = pedPool;
        this.NetworkObject = networkObjectPool;
        this.Blip = blipPool;
        this.Checkpoint = checkpointPool;
        this.VoiceChannel = voiceChannelPool;
        this.ColShape = colShapePool;
        this.VirtualEntity = virtualEntityPool;
        this.VirtualEntityGroup = virtualEntityGroupPool;
        this.Marker = markerPool;
        this.ConnectionInfo = connectionInfoPool;
    }

    public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId)
    {
        return baseObjectType switch
        {
            BaseObjectType.Player => Player.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.Vehicle => Vehicle.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.Ped => Ped.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.NetworkObject => NetworkObject.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.Blip => Blip.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.Checkpoint => Checkpoint.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.VoiceChannel => VoiceChannel.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.ColShape => ColShape.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.VirtualEntity => VirtualEntity.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.VirtualEntityGroup => VirtualEntityGroup.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.Marker => Marker.GetOrCreate(core, entityPointer, entityId),
            BaseObjectType.ConnectionInfo => ConnectionInfo.GetOrCreate(core, entityPointer, entityId),
            _ => default
        };
    }

    public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType)
    {
        return baseObjectType switch
        {
            BaseObjectType.Player => Player.GetOrCreate(core, entityPointer),
            BaseObjectType.Vehicle => Vehicle.GetOrCreate(core, entityPointer),
            BaseObjectType.Ped => Ped.GetOrCreate(core, entityPointer),
            BaseObjectType.NetworkObject => NetworkObject.GetOrCreate(core, entityPointer),
            BaseObjectType.Blip => Blip.GetOrCreate(core, entityPointer),
            BaseObjectType.Checkpoint => Checkpoint.GetOrCreate(core, entityPointer),
            BaseObjectType.VoiceChannel => VoiceChannel.GetOrCreate(core, entityPointer),
            BaseObjectType.ColShape => ColShape.GetOrCreate(core, entityPointer),
            BaseObjectType.VirtualEntity => VirtualEntity.GetOrCreate(core, entityPointer),
            BaseObjectType.VirtualEntityGroup => VirtualEntityGroup.GetOrCreate(core, entityPointer),
            BaseObjectType.Marker => Marker.GetOrCreate(core, entityPointer),
            BaseObjectType.ConnectionInfo => ConnectionInfo.GetOrCreate(core, entityPointer),
            _ => default
        };
    }

    public IBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType)
    {
        return baseObjectType switch
        {
            BaseObjectType.Player => Player.Get(entityPointer),
            BaseObjectType.Vehicle => Vehicle.Get(entityPointer),
            BaseObjectType.Ped => Ped.Get(entityPointer),
            BaseObjectType.NetworkObject => NetworkObject.Get(entityPointer),
            BaseObjectType.Blip => Blip.Get(entityPointer),
            BaseObjectType.Checkpoint => Checkpoint.Get(entityPointer),
            BaseObjectType.VoiceChannel => VoiceChannel.Get(entityPointer),
            BaseObjectType.ColShape => ColShape.Get(entityPointer),
            BaseObjectType.VirtualEntity => VirtualEntity.Get(entityPointer),
            BaseObjectType.VirtualEntityGroup => VirtualEntityGroup.Get(entityPointer),
            BaseObjectType.Marker => Marker.Get(entityPointer),
            BaseObjectType.ConnectionInfo => ConnectionInfo.Get(entityPointer),
            _ => default
        };
    }

    public void Dispose()
    {
        Player.Dispose();
        Vehicle.Dispose();
        Ped.Dispose();
        NetworkObject.Dispose();
        Blip.Dispose();
        Checkpoint.Dispose();
        VoiceChannel.Dispose();
        ColShape.Dispose();
        VirtualEntity.Dispose();
        VirtualEntityGroup.Dispose();
        Marker.Dispose();
        ConnectionInfo.Dispose();
    }

    public bool Remove(IBaseObject entity)
    {
        return Remove(entity.NativePointer, entity.Type);
    }

    public bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType)
    {
        return baseObjectType switch
        {
            BaseObjectType.Player => Player.Remove(entityPointer),
            BaseObjectType.Vehicle => Vehicle.Remove(entityPointer),
            BaseObjectType.Ped => Ped.Remove(entityPointer),
            BaseObjectType.NetworkObject => NetworkObject.Remove(entityPointer),
            BaseObjectType.Blip => Blip.Remove(entityPointer),
            BaseObjectType.Checkpoint => Checkpoint.Remove(entityPointer),
            BaseObjectType.VoiceChannel => VoiceChannel.Remove(entityPointer),
            BaseObjectType.ColShape => ColShape.Remove(entityPointer),
            BaseObjectType.VirtualEntity => VirtualEntity.Remove(entityPointer),
            BaseObjectType.VirtualEntityGroup => VirtualEntityGroup.Remove(entityPointer),
            BaseObjectType.Marker => Marker.Remove(entityPointer),
            BaseObjectType.ConnectionInfo => ConnectionInfo.Remove(entityPointer),
            _ => false
        };
    }

    ISharedBaseObject ISharedPoolManager.GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType,
        uint entityId) => GetOrCreate((ICore)core, entityPointer, baseObjectType, entityId);

    ISharedBaseObject ISharedPoolManager.GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType) => GetOrCreate((ICore)core, entityPointer, baseObjectType);

    ISharedBaseObject ISharedPoolManager.Get(IntPtr entityPointer, BaseObjectType baseObjectType) => Get(entityPointer, baseObjectType);

}