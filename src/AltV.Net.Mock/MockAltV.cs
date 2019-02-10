using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class PlayerFactory<TEntity> : IEntityFactory<IPlayer> where TEntity : IPlayer
    {
        private readonly IEntityFactory<IPlayer> playerFactory;

        public PlayerFactory(IEntityFactory<IPlayer> playerFactory)
        {
            this.playerFactory = playerFactory;
        }

        public IPlayer Create(IntPtr entityPointer)
        {
            return MockDecorator<TEntity, IPlayer>.Create((TEntity) playerFactory.Create(entityPointer),
                new MockPlayer());
        }
    }
    
    public class VehicleFactory<TEntity> : IEntityFactory<IVehicle> where TEntity : IVehicle
    {
        private readonly IEntityFactory<IVehicle> vehicleFactory;

        public VehicleFactory(IEntityFactory<IVehicle> vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;
        }

        public IVehicle Create(IntPtr entityPointer)
        {
            return MockDecorator<TEntity, IVehicle>.Create((TEntity) vehicleFactory.Create(entityPointer),
                new MockVehicle());
        }
    }
    
    public class BlipFactory<TEntity> : IEntityFactory<IBlip> where TEntity : IBlip
    {
        private readonly IEntityFactory<IBlip> blipFactory;

        public BlipFactory(IEntityFactory<IBlip> blipFactory)
        {
            this.blipFactory = blipFactory;
        }

        public IBlip Create(IntPtr entityPointer)
        {
            return MockDecorator<TEntity, IBlip>.Create((TEntity) blipFactory.Create(entityPointer),
                new MockBlip());
        }
    }
    
    public class CheckpointFactory<TEntity> : IEntityFactory<ICheckpoint> where TEntity : ICheckpoint
    {
        private readonly IEntityFactory<ICheckpoint> checkpointFactory;

        public CheckpointFactory(IEntityFactory<ICheckpoint> checkpointFactory)
        {
            this.checkpointFactory = checkpointFactory;
        }

        public ICheckpoint Create(IntPtr entityPointer)
        {
            return MockDecorator<TEntity, ICheckpoint>.Create((TEntity) checkpointFactory.Create(entityPointer),
                new MockCheckpoint());
        }
    }

    public class MockAltV<TPlayer, TVehicle, TBlip, TCheckpoint> where TPlayer : IPlayer where TVehicle : IVehicle where TBlip : IBlip  where TCheckpoint : ICheckpoint 
    {
        public MockAltV()
        {
            var resourceLoader = new MockResourceLoader(IntPtr.Zero, string.Empty, "AltV.Net.Example.dll");
            var resource = resourceLoader.Prepare();
            var playerFactory = new PlayerFactory<TPlayer>(resource.GetPlayerFactory());
            var vehicleFactory = new VehicleFactory<TVehicle>(resource.GetVehicleFactory());
            var blipFactory = new BlipFactory<TBlip>(resource.GetBlipFactory());
            var checkpointFactory = new CheckpointFactory<TCheckpoint>(resource.GetCheckpointFactory());
            var playerPool = new PlayerPool(playerFactory);
            var vehiclePool = new VehiclePool(vehicleFactory);
            var blipPool = new BlipPool(blipFactory);
            var checkpointPool = new CheckpointPool(checkpointFactory);
            var checkpoint = new CheckpointPool(checkpointFactory);
            var entityPool = new BaseEntityPool(playerPool, vehiclePool, blipPool, checkpoint);
            var server = new MockServer(IntPtr.Zero, entityPool, playerPool, vehiclePool, blipPool,
                checkpointPool);
            var module = new Module(server, entityPool, playerPool, vehiclePool, blipPool, checkpointPool);
            resourceLoader.Start();
        }
    }
}