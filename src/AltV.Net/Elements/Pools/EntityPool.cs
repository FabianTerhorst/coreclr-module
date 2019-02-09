using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class EntityPool : IEntityPool
    {
        private readonly Dictionary<IntPtr, IEntity> entities = new Dictionary<IntPtr, IEntity>();

        private readonly Dictionary<IntPtr, IPlayer> players = new Dictionary<IntPtr, IPlayer>();

        private readonly Dictionary<IntPtr, IVehicle> vehicles = new Dictionary<IntPtr, IVehicle>();

        private readonly Dictionary<IntPtr, IBlip> blips = new Dictionary<IntPtr, IBlip>();

        private readonly Dictionary<IntPtr, ICheckpoint> checkpoints = new Dictionary<IntPtr, ICheckpoint>();

        private readonly IPlayerFactory playerFactory;

        private readonly IVehicleFactory vehicleFactory;

        private readonly IBlipFactory blipFactory;

        private readonly ICheckpointFactory checkpointFactory;

        public EntityPool(IPlayerFactory playerFactory, IVehicleFactory vehicleFactory, IBlipFactory blipFactory,
            ICheckpointFactory checkpointFactory)
        {
            this.playerFactory = playerFactory;
            this.vehicleFactory = vehicleFactory;
            this.blipFactory = blipFactory;
            this.checkpointFactory = checkpointFactory;
        }

        public void Add(IEntity entity)
        {
            entities[entity.NativePointer] = entity;
            switch (entity)
            {
                case IPlayer player:
                    players[entity.NativePointer] = player;
                    break;
                case IVehicle vehicle:
                    vehicles[entity.NativePointer] = vehicle;
                    break;
                case IBlip blip:
                    blips[entity.NativePointer] = blip;
                    break;
                case ICheckpoint checkpoint:
                    checkpoints[entity.NativePointer] = checkpoint;
                    break;
            }
        }

        public bool Get(IntPtr entityPointer, out IEntity entity)
        {
            return entities.TryGetValue(entityPointer, out entity) && entity.Exists;
        }

        public bool GetOrCreate(IntPtr entityPointer, out IEntity entity)
        {
            if (entityPointer == IntPtr.Zero)
            {
                entity = default;
                return false;
            }

            if (entities.TryGetValue(entityPointer, out entity)) return entity.Exists;
            var entityType = (EntityType) AltVNative.Entity.BaseObject_GetType(entityPointer);
            switch (entityType)
            {
                case EntityType.Player:
                    entity = playerFactory.Create(entityPointer);
                    Add(entity);
                    break;
                case EntityType.Vehicle:
                    entity = vehicleFactory.Create(entityPointer);
                    Add(entity);
                    break;
                case EntityType.Blip:
                    entity = blipFactory.Create(entityPointer);
                    Add(entity);
                    break;
                case EntityType.Checkpoint:
                    entity = checkpointFactory.Create(entityPointer);
                    Add(entity);
                    break;
                default:
                    return false;
            }

            return entity.Exists;
        }

        public bool Remove(IEntity entity)
        {
            return Remove(entity.NativePointer);
        }

        public bool Remove(IntPtr entityPointer)
        {
            if (!entities.Remove(entityPointer, out var entity) || !entity.Exists) return false;
            if (entity is IInternalEntity internalEntity)
            {
                internalEntity.Exists = false;
            }

            players.Remove(entityPointer, out _);
            vehicles.Remove(entityPointer, out _);
            blips.Remove(entityPointer, out _);
            checkpoints.Remove(entityPointer, out _);

            return true;
        }

        public Dictionary<IntPtr, IPlayer>.ValueCollection GetPlayers()
        {
            return players.Values;
        }

        public Dictionary<IntPtr, IVehicle>.ValueCollection GetVehicles()
        {
            return vehicles.Values;
        }

        public Dictionary<IntPtr, IBlip>.ValueCollection GetBlips()
        {
            return blips.Values;
        }

        public Dictionary<IntPtr, ICheckpoint>.ValueCollection GetCheckpoints()
        {
            return checkpoints.Values;
        }
    }
}