using System;
using AltV.Net.Elements.Entities;

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

        public BaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool, IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool, IBaseObjectPool<IColShape> colShapePool)
        {
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
            this.blipPool = blipPool;
            this.checkpointPool = checkpointPool;
            this.voiceChannelPool = voiceChannelPool;
            this.colShapePool = colShapePool;
        }

        public bool Get(IntPtr entityPointer, BaseObjectType baseObjectType, out IBaseObject entity)
        {
            bool result;
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    result = playerPool.Get(entityPointer, out var player);
                    entity = player;
                    return result;
                case BaseObjectType.Vehicle:
                    result = vehiclePool.Get(entityPointer, out var vehicle);
                    entity = vehicle;
                    return result;
                case BaseObjectType.Blip:
                    result = blipPool.Get(entityPointer, out var blip);
                    entity = blip;
                    return result;
                case BaseObjectType.Checkpoint:
                    result = checkpointPool.Get(entityPointer, out var checkpoint);
                    entity = checkpoint;
                    return result;
                case BaseObjectType.VoiceChannel:
                    result = voiceChannelPool.Get(entityPointer, out var voiceChannel);
                    entity = voiceChannel;
                    return result;
                case BaseObjectType.ColShape:
                    result = colShapePool.Get(entityPointer, out var colShape);
                    entity = colShape;
                    return result;
                default:
                    entity = default;
                    return false;
            }
        }

        public bool GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, out IBaseObject entity)
        {
            bool result;
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    result = playerPool.GetOrCreate(core, entityPointer, out var player);
                    entity = player;
                    return result;
                case BaseObjectType.Vehicle:
                    result = vehiclePool.GetOrCreate(core, entityPointer, out var vehicle);
                    entity = vehicle;
                    return result;
                case BaseObjectType.Blip:
                    result = blipPool.GetOrCreate(core, entityPointer, out var blip);
                    entity = blip;
                    return result;
                case BaseObjectType.Checkpoint:
                    result = checkpointPool.GetOrCreate(core, entityPointer, out var checkpoint);
                    entity = checkpoint;
                    return result;
                case BaseObjectType.VoiceChannel:
                    result = voiceChannelPool.GetOrCreate(core, entityPointer, out var voiceChannel);
                    entity = voiceChannel;
                    return result;
                case BaseObjectType.ColShape:
                    result = colShapePool.GetOrCreate(core, entityPointer, out var colShape);
                    entity = colShape;
                    return result;
                default:
                    entity = default;
                    return false;
            }
        }

        public bool GetOrCreate(ICore core, IntPtr entityPointer, BaseObjectType baseObjectType, ushort entityId,
            out IBaseObject entity)
        {
            bool result;
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    result = playerPool.GetOrCreate(core, entityPointer, entityId, out var player);
                    entity = player;
                    return result;
                case BaseObjectType.Vehicle:
                    result = vehiclePool.GetOrCreate(core, entityPointer, entityId, out var vehicle);
                    entity = vehicle;
                    return result;
                case BaseObjectType.Blip:
                    result = blipPool.GetOrCreate(core, entityPointer, out var blip);
                    entity = blip;
                    return result;
                case BaseObjectType.Checkpoint:
                    result = checkpointPool.GetOrCreate(core, entityPointer, out var checkpoint);
                    entity = checkpoint;
                    return result;
                case BaseObjectType.VoiceChannel:
                    result = voiceChannelPool.GetOrCreate(core, entityPointer, out var voiceChannel);
                    entity = voiceChannel;
                    return result;
                case BaseObjectType.ColShape:
                    result = colShapePool.GetOrCreate(core, entityPointer, out var colShape);
                    entity = colShape;
                    return result;
                default:
                    entity = default;
                    return false;
            }
        }

        public bool Remove(IBaseObject entity)
        {
            return Remove(entity.NativePointer, entity.Type);
        }

        public bool Remove(IntPtr entityPointer, BaseObjectType baseObjectType)
        {
            switch (baseObjectType)
            {
                case BaseObjectType.Player:
                    return playerPool.Remove(entityPointer);
                case BaseObjectType.Vehicle:
                    return vehiclePool.Remove(entityPointer);
                case BaseObjectType.Blip:
                    return blipPool.Remove(entityPointer);
                case BaseObjectType.Checkpoint:
                    return checkpointPool.Remove(entityPointer);
                case BaseObjectType.VoiceChannel:
                    return voiceChannelPool.Remove(entityPointer);
                case BaseObjectType.ColShape:
                    return colShapePool.Remove(entityPointer);
                default:
                    return false;
            }
        }
    }
}