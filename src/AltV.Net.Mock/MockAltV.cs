using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
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

        public IPlayer ConnectPlayer(string playerName)
        {
            var ptr = MockEntities.GetNextPtr();
            Alt.Module.PlayerPool.Create(ptr, out var player);
            player.Name = playerName;
            MockEntities.Insert(player);
            Alt.Module.OnPlayerConnect(ptr, "direct connect");
            return player;
        }
    }
}