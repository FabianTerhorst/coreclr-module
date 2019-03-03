using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async
{
    public class AsyncBaseEntityPool : BaseEntityPool
    {
        public AsyncBaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool) : base(playerPool, vehiclePool, blipPool, checkpointPool)
        {
        }
    }
}