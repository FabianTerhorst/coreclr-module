using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape.Tests
{
    public class MockColShapeModule : ColShapeModule
    {
        private readonly IEntityPool<IPlayer> playerPool;

        private readonly IEntityPool<IVehicle> vehiclePool;
        
        public MockColShapeModule(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool)
        {
            this.playerPool = playerPool;
            this.vehiclePool = vehiclePool;
        }
        
        public override ICollection<IPlayer> GetAllPlayers()
        {
            return playerPool.GetAllEntities();
        }

        public override ICollection<IVehicle> GetAllVehicles()
        {
            return vehiclePool.GetAllEntities();
        }
    }
}