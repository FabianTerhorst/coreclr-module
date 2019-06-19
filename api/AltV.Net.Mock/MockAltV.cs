using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    //TODO: MValue_GetEntity is currently broken because the cpp code tries to access the getType method from entity
    //TODO: we need a way now to create MValues that are giving back the correct values inside storage pointer but without using mvalue_get
    //TODO: or create own mock cpp lib? maybe add an macro for building mock lib
    public class MockAltV<TPlayer, TVehicle, TBlip, TCheckpoint, TVoiceChannel, TColShape> where TPlayer : IPlayer
        where TVehicle : IVehicle
        where TBlip : IBlip
        where TCheckpoint : ICheckpoint
        where TVoiceChannel : IVoiceChannel
    where TColShape: IColShape
    {
        public MockAltV(string entryPoint)
        {
            var resource = new MockResourceLoader(IntPtr.Zero, string.Empty, entryPoint).Init();
            var playerFactory = new MockPlayerFactory<TPlayer>(resource.GetPlayerFactory());
            var vehicleFactory = new MockVehicleFactory<TVehicle>(resource.GetVehicleFactory());
            var blipFactory = new MockBlipFactory<TBlip>(resource.GetBlipFactory());
            var checkpointFactory = new MockCheckpointFactory<TCheckpoint>(resource.GetCheckpointFactory());
            var voiceChannelFactory = new MockVoiceChannelFactory<TVoiceChannel>(resource.GetVoiceChannelFactory());
            var colShapeFactory = new MockColShapeFactory<TColShape>(resource.GetColShapeFactory());
            var playerPool = new MockPlayerPool(playerFactory);
            var vehiclePool = new MockVehiclePool(vehicleFactory);
            var blipPool = new MockBlipPool(blipFactory);
            var checkpointPool = new MockCheckpointPool(checkpointFactory);
            var voiceChannelPool = new MockVoiceChannelPool(voiceChannelFactory);
            var colShapePool = new MockColShapePool(colShapeFactory);
            var entityPool = new MockBaseEntityPool(playerPool, vehiclePool);
            var baseObjectPool =
                new MockBaseBaseObjectPool(playerPool, vehiclePool, blipPool, checkpointPool, voiceChannelPool, colShapePool);
            var server = new MockServer(IntPtr.Zero, baseObjectPool, entityPool, playerPool, vehiclePool, blipPool,
                checkpointPool, voiceChannelPool);
            var cSharpNativeResource = new CSharpNativeResource(IntPtr.Zero);
            var module = resource.GetModule(server, cSharpNativeResource, baseObjectPool, entityPool, playerPool,
                vehiclePool, blipPool, checkpointPool, voiceChannelPool, colShapePool);
            resource.OnStart();
        }

        public IPlayer ConnectPlayer(string playerName, string reason, Action<IPlayer> intercept = null)
        {
            var ptr = MockEntities.GetNextPtr(out var entityId);
            Alt.Module.PlayerPool.Create(ptr, entityId, out var player);
            player.Name = playerName;
            intercept?.Invoke(player);
            Alt.Module.OnPlayerConnect(ptr, player.Id, reason);
            return player;
        }
    }
}