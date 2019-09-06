using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockBaseEntityPool : BaseEntityPool
    {
        public MockBaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool) : base(playerPool, vehiclePool)
        {
        }
    }
}