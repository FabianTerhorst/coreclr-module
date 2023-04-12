using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class BaseBaseObjectPool : IBaseBaseObjectPool
    {
        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;

        private readonly IBaseObjectPool<IBlip> blipPool;

        private readonly IBaseObjectPool<ICheckpoint> checkpointPool;

        private readonly IBaseObjectPool<IVoiceChannel> voiceChannelPool;

        private readonly IBaseObjectPool<IColShape> colShapePool;
        private readonly IBaseObjectPool<IVirtualEntity> virtualEntityPool;
        private readonly IBaseObjectPool<IVirtualEntityGroup> virtualEntityGroupPool;
        private readonly IBaseObjectPool<IMarker> markerPool;

        public BaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool, IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool, IBaseObjectPool<IColShape> colShapePool,
            IBaseObjectPool<IVirtualEntity> virtualEntityPool,
            IBaseObjectPool<IVirtualEntityGroup> virtualEntityGroupPool,
            IBaseObjectPool<IMarker> markerPool)
        {
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            this.voiceChannelPool = voiceChannelPool;
            this.colShapePool = colShapePool;
            this.virtualEntityPool = virtualEntityPool;
            this.virtualEntityGroupPool = virtualEntityGroupPool;
            this.markerPool = markerPool;
        }

        public IBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => playerPool.Get(entityPointer),
                BaseObjectType.Vehicle => vehiclePool.Get(entityPointer),
                BaseObjectType.Blip => blipPool.Get(entityPointer),
                BaseObjectType.Checkpoint => checkpointPool.Get(entityPointer),
                BaseObjectType.VoiceChannel => voiceChannelPool.Get(entityPointer),
                BaseObjectType.ColShape => colShapePool.Get(entityPointer),
                BaseObjectType.VirtualEntity => virtualEntityPool.Get(entityPointer),
                BaseObjectType.VirtualEntityGroup => virtualEntityGroupPool.Get(entityPointer),
                BaseObjectType.Marker => markerPool.Get(entityPointer),
                _ => default
            };
        }

        ISharedBaseObject IReadOnlyBaseBaseObjectPool.Get(IntPtr entityPointer, BaseObjectType baseObjectType) => Get(entityPointer, baseObjectType);

        public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => playerPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Vehicle => vehiclePool.GetOrCreate(core, entityPointer),
                BaseObjectType.Blip => blipPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Checkpoint => checkpointPool.GetOrCreate(core, entityPointer),
                BaseObjectType.VoiceChannel => voiceChannelPool.GetOrCreate(core, entityPointer),
                BaseObjectType.ColShape => colShapePool.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntity => virtualEntityPool.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntityGroup => virtualEntityGroupPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Marker => markerPool.GetOrCreate(core, entityPointer),
                _ => default
            };
        }
        ISharedBaseObject IReadOnlyBaseBaseObjectPool.GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType) => GetOrCreate((ICore) core, entityPointer, baseObjectType);

        public IBaseObject GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => playerPool.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Vehicle => vehiclePool.GetOrCreate(core, entityPointer, entityId),
                BaseObjectType.Blip => blipPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Checkpoint => checkpointPool.GetOrCreate(core, entityPointer),
                BaseObjectType.VoiceChannel => voiceChannelPool.GetOrCreate(core, entityPointer),
                BaseObjectType.ColShape => colShapePool.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntity => virtualEntityPool.GetOrCreate(core, entityPointer),
                BaseObjectType.VirtualEntityGroup => virtualEntityGroupPool.GetOrCreate(core, entityPointer),
                BaseObjectType.Marker => markerPool.GetOrCreate(core, entityPointer),
                _ => default
            };
        }
        ISharedBaseObject IReadOnlyBaseBaseObjectPool.GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId) => GetOrCreate((ICore) core, entityPointer, baseObjectType, entityId);

        public bool Remove(IBaseObject entity)
        {
            return Remove(entity.NativePointer, entity.Type);
        }

        public bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            return baseObjectType switch
            {
                BaseObjectType.Player => playerPool.Remove(entityPointer),
                BaseObjectType.Vehicle => vehiclePool.Remove(entityPointer),
                BaseObjectType.Blip => blipPool.Remove(entityPointer),
                BaseObjectType.Checkpoint => checkpointPool.Remove(entityPointer),
                BaseObjectType.VoiceChannel => voiceChannelPool.Remove(entityPointer),
                BaseObjectType.ColShape => colShapePool.Remove(entityPointer),
                BaseObjectType.VirtualEntity => virtualEntityPool.Remove(entityPointer),
                BaseObjectType.VirtualEntityGroup => virtualEntityGroupPool.Remove(entityPointer),
                BaseObjectType.Marker => markerPool.Remove(entityPointer),
                _ => false
            };
        }
    }
}