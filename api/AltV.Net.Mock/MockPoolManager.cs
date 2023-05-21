using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockPoolManager : PoolManager
    {
        public MockPoolManager(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IPed> pedPool,
            IEntityPool<INetworkObject> networkObjectPool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool, IBaseObjectPool<IVoiceChannel> voiceChannelPool, IBaseObjectPool<IColShape> colShapePool,
            IBaseObjectPool<IVirtualEntity> virtualEntityPool,
            IBaseObjectPool<IVirtualEntityGroup> virtualEntityGroupPool,
            IBaseObjectPool<IMarker> markerPool, IBaseObjectPool<IConnectionInfo> connectionInfoPool) : base(
            playerPool, vehiclePool, pedPool, networkObjectPool, blipPool, checkpointPool, voiceChannelPool, colShapePool, virtualEntityPool, virtualEntityGroupPool, markerPool, connectionInfoPool)
        {
        }
    }
}