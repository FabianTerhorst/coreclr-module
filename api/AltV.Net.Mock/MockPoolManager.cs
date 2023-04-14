using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockPoolManager : PoolManager
    {
        public MockPoolManager(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IPed> pedPool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool, IBaseObjectPool<IVoiceChannel> voiceChannelPool, IBaseObjectPool<IColShape> colShapePool,
            IBaseObjectPool<IVirtualEntity> virtualEntityPool,
            IBaseObjectPool<IVirtualEntityGroup> virtualEntityGroupPool,
            IBaseObjectPool<IMarker> markerPool) : base(
            playerPool, vehiclePool, pedPool, blipPool, checkpointPool, voiceChannelPool, colShapePool, virtualEntityPool, virtualEntityGroupPool,markerPool)
        {
        }
    }
}