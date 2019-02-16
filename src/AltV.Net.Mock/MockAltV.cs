using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockAltV<TPlayer, TVehicle, TBlip, TCheckpoint> where TPlayer : IPlayer
        where TVehicle : IVehicle
        where TBlip : IBlip
        where TCheckpoint : ICheckpoint
    {
        public MockAltV(string entryPoint)
        {
            var resourceLoader = new MockResourceLoader(IntPtr.Zero, string.Empty, entryPoint);
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
            resource.OnStart();
        }

        public IPlayer ConnectPlayer(string playerName, string reason, Action<IPlayer> intercept = null)
        {
            var ptr = MockEntities.GetNextPtr();
            Alt.Module.PlayerPool.Create(ptr, MockEntities.Id, out var player);
            player.Name = playerName;
            intercept?.Invoke(player);
            MockEntities.Insert(player);
            Alt.Module.OnPlayerConnect(ptr, player.Id, reason);
            return player;
        }
    }
}