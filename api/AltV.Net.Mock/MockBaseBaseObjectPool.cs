using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockBaseBaseObjectPool : BaseBaseObjectPool
    {
        public MockBaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool, IBaseObjectPool<IVoiceChannel> voiceChannelPool) : base(
            playerPool, vehiclePool, blipPool, checkpointPool, voiceChannelPool)
        {
        }
    }
}