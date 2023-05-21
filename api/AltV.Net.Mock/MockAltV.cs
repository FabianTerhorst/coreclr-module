using System;
using System.Runtime.Loader;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    //TODO: MValue_GetEntity is currently broken because the cpp code tries to access the getType method from entity
    //TODO: we need a way now to create MValues that are giving back the correct values inside storage pointer but without using mvalue_get
    //TODO: or create own mock cpp lib? maybe add an macro for building mock lib
    public class MockAltV<TPlayer, TVehicle, TPed, TNetworkObject, TBlip, TCheckpoint, TVoiceChannel, TColShape, TVirtualEntity, TVirtualEntityGroup, TMarker, TConnectionInfo> where TPlayer : IPlayer
        where TVehicle : IVehicle
        where TBlip : IBlip
        where TCheckpoint : ICheckpoint
        where TVoiceChannel : IVoiceChannel
        where TPed : IPed
        where TNetworkObject : INetworkObject
        where TVirtualEntity : IVirtualEntity
        where TVirtualEntityGroup : IVirtualEntityGroup
        where TMarker : IMarker
        where TConnectionInfo : IConnectionInfo
    where TColShape: IColShape
    {
        private readonly ICore core;

        public MockAltV(string entryPoint)
        {
            //var resource = new MockResourceLoader(IntPtr.Zero, string.Empty, entryPoint).Init();
            IResource resource = null;
            var playerFactory = new MockPlayerFactory<TPlayer>(resource.GetPlayerFactory());
            var vehicleFactory = new MockVehicleFactory<TVehicle>(resource.GetVehicleFactory());
            var pedFactory = new MockPedFactory<TPed>(resource.GetPedFactory());
            var networkObjectFactory = new MockNetworkObjectFactory<TNetworkObject>(resource.GetNetworkObjectFactory());
            var blipFactory = new MockBlipFactory<TBlip>(resource.GetBlipFactory());
            var checkpointFactory = new MockCheckpointFactory<TCheckpoint>(resource.GetCheckpointFactory());
            var voiceChannelFactory = new MockVoiceChannelFactory<TVoiceChannel>(resource.GetVoiceChannelFactory());
            var colShapeFactory = new MockColShapeFactory<TColShape>(resource.GetColShapeFactory());
            var virtualEntityFactory = new MockVirtualEntityFactory<TVirtualEntity>(resource.GetVirtualEntityFactory());
            var virtualEntityGroupFactory = new MockVirtualEntityGroupFactory<TVirtualEntityGroup>(resource.GetVirtualEntityGroupFactory());
            var markerFactory = new MockMarkerFactory<TMarker>(resource.GetMarkerFactory());
            var connectionInfoFactory = new MockConnectionInfoFactory<TConnectionInfo>(resource.GetConnectionInfoFactory());

            var playerPool = new MockPlayerPool(playerFactory);
            var vehiclePool = new MockVehiclePool(vehicleFactory);
            var pedPool = new MockPedPool(pedFactory);
            var networkObjectPool = new MockNetworkObjectPool(networkObjectFactory);
            var blipPool = new MockBlipPool(blipFactory);
            var checkpointPool = new MockCheckpointPool(checkpointFactory);
            var voiceChannelPool = new MockVoiceChannelPool(voiceChannelFactory);
            var colShapePool = new MockColShapePool(colShapeFactory);
            var virtualEntityPool = new MockVirtualEntityPool(virtualEntityFactory);
            var virtualEntityGroupPool = new MockVirtualEntityGroupPool(virtualEntityGroupFactory);
            var markerPool = new MockMarkerPool(markerFactory);
            var connectionInfoPool = new MockConnectionInfoPool(connectionInfoFactory);

            var baseObjectPool =
                new MockPoolManager(playerPool, vehiclePool, pedPool, networkObjectPool, blipPool, checkpointPool, voiceChannelPool, colShapePool, virtualEntityPool, virtualEntityGroupPool, markerPool, connectionInfoPool);
            core = new MockCore(IntPtr.Zero, baseObjectPool, null);
            resource.OnStart();
        }

        public IPlayer ConnectPlayer(string playerName, string reason, Action<IPlayer> intercept = null)
        {
            var ptr = MockEntities.GetNextPtr(out var entityId);
            var player = Alt.Core.PoolManager.Player.Create(core, ptr , entityId);
            //player.Name = playerName;
            intercept?.Invoke(player);
            Alt.CoreImpl.OnPlayerConnect(ptr, player.Id, reason);
            return player;
        }
    }
}