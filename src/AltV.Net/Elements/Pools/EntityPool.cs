using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class EntityPool : IEntityPool
    {
        private readonly ConcurrentDictionary<IntPtr, IEntity> entities = new ConcurrentDictionary<IntPtr, IEntity>();

        private readonly ConcurrentDictionary<IntPtr, IPlayer> players = new ConcurrentDictionary<IntPtr, IPlayer>();

        private readonly ConcurrentDictionary<IntPtr, IVehicle> vehicles = new ConcurrentDictionary<IntPtr, IVehicle>();

        private readonly ConcurrentDictionary<IntPtr, IBlip> blips = new ConcurrentDictionary<IntPtr, IBlip>();

        private readonly ConcurrentDictionary<IntPtr, ICheckpoint> checkpoints =
            new ConcurrentDictionary<IntPtr, ICheckpoint>();

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
            entities.TryAdd(entity.NativePointer, entity);
            switch (entity)
            {
                case IPlayer player:
                    players.TryAdd(entity.NativePointer, player);
                    break;
                case IVehicle vehicle:
                    vehicles.TryAdd(entity.NativePointer, vehicle);
                    break;
                case IBlip blip:
                    blips.TryAdd(entity.NativePointer, blip);
                    break;
                case ICheckpoint checkpoint:
                    checkpoints.TryAdd(entity.NativePointer, checkpoint);
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

            players.TryRemove(entityPointer, out _);
            vehicles.TryRemove(entityPointer, out _);
            blips.TryRemove(entityPointer, out _);
            checkpoints.TryRemove(entityPointer, out _);

            return true;
        }

        public ReadOnlyCollection<IPlayer> GetPlayers()
        {
            return (ReadOnlyCollection<IPlayer>) players.Values;
        }

        public ReadOnlyCollection<IVehicle> GetVehicles()
        {
            return (ReadOnlyCollection<IVehicle>) vehicles.Values;
        }

        public ReadOnlyCollection<IBlip> GetBlips()
        {
            return (ReadOnlyCollection<IBlip>) blips.Values;
        }

        public ReadOnlyCollection<ICheckpoint> GetCheckpoints()
        {
            return (ReadOnlyCollection<ICheckpoint>) checkpoints.Values;
        }
    }
}