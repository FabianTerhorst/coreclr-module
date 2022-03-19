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
                    var player = playerPool.Get(entityPointer);
                    entity = player;
                    return player is not null;
                case BaseObjectType.Vehicle:
                    var vehicle = vehiclePool.Get(entityPointer);
                    entity = vehicle;
                    return vehicle is not null;
                case BaseObjectType.Blip:
                    var blip = blipPool.Get(entityPointer);
                    entity = blip;
                    return blip is not null;
                case BaseObjectType.Checkpoint:
                    var checkpoint = checkpointPool.Get(entityPointer);
                    entity = checkpoint;
                    return checkpoint is not null;
                case BaseObjectType.VoiceChannel:
                    var voiceChannel = voiceChannelPool.Get(entityPointer);
                    entity = voiceChannel;
                    return voiceChannel is not null;
                case BaseObjectType.ColShape:
                    var colShape = colShapePool.Get(entityPointer);
                    entity = colShape;
                    return colShape is not null;
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
                    var player = playerPool.GetOrCreate(core, entityPointer);
                    entity = player;
                    return  player is not null;
                case BaseObjectType.Vehicle:
                    var vehicle = vehiclePool.GetOrCreate(core, entityPointer);
                    entity = vehicle;
                    return  vehicle is not null;
                case BaseObjectType.Blip:
                    var blip = blipPool.GetOrCreate(core, entityPointer);
                    entity = blip;
                    return  blip is not null;
                case BaseObjectType.Checkpoint:
                    var checkpoint = checkpointPool.GetOrCreate(core, entityPointer);
                    entity = checkpoint;
                    return  checkpoint is not null;
                case BaseObjectType.VoiceChannel:
                    var voiceChannel = voiceChannelPool.GetOrCreate(core, entityPointer);
                    entity = voiceChannel;
                    return  voiceChannel is not null;
                case BaseObjectType.ColShape:
                    var colShape = colShapePool.GetOrCreate(core, entityPointer);
                    entity = colShape;
                    return  colShape is not null;
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
                    var player = playerPool.GetOrCreate(core, entityPointer, entityId);
                    entity = player;
                    return player is not null;
                case BaseObjectType.Vehicle:
                    var vehicle = vehiclePool.GetOrCreate(core, entityPointer, entityId);
                    entity = vehicle;
                    return vehicle is not null;
                case BaseObjectType.Blip:
                    var blip = blipPool.GetOrCreate(core, entityPointer);
                    entity = blip;
                    return  blip is not null;
                case BaseObjectType.Checkpoint:
                    var checkpoint = checkpointPool.GetOrCreate(core, entityPointer);
                    entity = checkpoint;
                    return  checkpoint is not null;
                case BaseObjectType.VoiceChannel:
                    var voiceChannel = voiceChannelPool.GetOrCreate(core, entityPointer);
                    entity = voiceChannel;
                    return  voiceChannel is not null;
                case BaseObjectType.ColShape:
                    var colShape = colShapePool.GetOrCreate(core, entityPointer);
                    entity = colShape;
                    return  colShape is not null;
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