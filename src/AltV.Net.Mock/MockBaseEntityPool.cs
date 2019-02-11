using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockBaseEntityPool : BaseEntityPool
    {
        public MockBaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool) : base(playerPool, vehiclePool, blipPool, checkpointPool)
        {
        }

        public override EntityType GetType(IntPtr entityPointer)
        {
            if (MockEntities.Entities.TryGetValue(entityPointer, out var entity))
            {
                return entity.Type;
            }

            throw new ArgumentException("Trying to access deleted entity");
        }
    }
}