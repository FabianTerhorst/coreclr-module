using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockPlayerFactory<TEntity> : IEntityFactory<IPlayer> where TEntity : IPlayer
    {
        private readonly IEntityFactory<IPlayer> playerFactory;

        public MockPlayerFactory(IEntityFactory<IPlayer> playerFactory)
        {
            this.playerFactory = playerFactory;
        }

        public IPlayer Create(IntPtr entityPointer, ushort id)
        {
            return MockDecorator<TEntity, IPlayer>.Create((TEntity) playerFactory.Create(entityPointer, id),
                new MockPlayer(entityPointer, id));
        }
    }

    public class MockVehicleFactory<TEntity> : IEntityFactory<IVehicle> where TEntity : IVehicle
    {
        private readonly IEntityFactory<IVehicle> vehicleFactory;

        public MockVehicleFactory(IEntityFactory<IVehicle> vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;
        }

        public IVehicle Create(IntPtr entityPointer, ushort id)
        {
            return MockDecorator<TEntity, IVehicle>.Create((TEntity) vehicleFactory.Create(entityPointer, id),
                new MockVehicle(entityPointer, id));
        }
    }

    public class MockBlipFactory<TEntity> : IEntityFactory<IBlip> where TEntity : IBlip
    {
        private readonly IEntityFactory<IBlip> blipFactory;

        public MockBlipFactory(IEntityFactory<IBlip> blipFactory)
        {
            this.blipFactory = blipFactory;
        }

        public IBlip Create(IntPtr entityPointer, ushort id)
        {
            return MockDecorator<TEntity, IBlip>.Create((TEntity) blipFactory.Create(entityPointer, id),
                new MockBlip(entityPointer, id));
        }
    }

    public class MockCheckpointFactory<TEntity> : IEntityFactory<ICheckpoint> where TEntity : ICheckpoint
    {
        private readonly IEntityFactory<ICheckpoint> checkpointFactory;

        public MockCheckpointFactory(IEntityFactory<ICheckpoint> checkpointFactory)
        {
            this.checkpointFactory = checkpointFactory;
        }

        public ICheckpoint Create(IntPtr entityPointer, ushort id)
        {
            return MockDecorator<TEntity, ICheckpoint>.Create((TEntity) checkpointFactory.Create(entityPointer, id),
                new MockCheckpoint(entityPointer, id));
        }
    }

    public class MockAltV<TPlayer, TVehicle, TBlip, TCheckpoint> where TPlayer : IPlayer
        where TVehicle : IVehicle
        where TBlip : IBlip
        where TCheckpoint : ICheckpoint
    {
        public MockAltV()
        {
            var resourceLoader = new MockResourceLoader(IntPtr.Zero, string.Empty, "AltV.Net.Example.dll");
            var resource = resourceLoader.Prepare();
            var playerFactory = new MockPlayerFactory<TPlayer>(resource.GetPlayerFactory());
            var vehicleFactory = new MockVehicleFactory<TVehicle>(resource.GetVehicleFactory());
            var blipFactory = new MockBlipFactory<TBlip>(resource.GetBlipFactory());
            var checkpointFactory = new MockCheckpointFactory<TCheckpoint>(resource.GetCheckpointFactory());
            var playerPool = new MockPlayerPool(playerFactory);
            var vehiclePool = new MockVehiclePool(vehicleFactory);
            var blipPool = new MockBlipPool(blipFactory);
            var checkpointPool = new MockCheckpointPool(checkpointFactory);
            var entityPool = new MockBaseEntityPool(playerPool, vehiclePool, blipPool, checkpointPool);
            var server = new MockServer(IntPtr.Zero, entityPool, playerPool, vehiclePool, blipPool,
                checkpointPool);
            var module = new Module(server, entityPool, playerPool, vehiclePool, blipPool, checkpointPool);
            resourceLoader.Start();
        }
    }
}