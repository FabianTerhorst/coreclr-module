using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Async
{
    public class AsyncBaseBaseObjectPool : BaseEntityPool
    {
        public AsyncBaseBaseObjectPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool) : base(playerPool, vehiclePool)
        {
        }
    }
}