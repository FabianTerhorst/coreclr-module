using System;
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
        
        public override IEnumerable<KeyValuePair<IntPtr, IPlayer>> GetAllPlayers()
        {
            return playerPool.GetEntitiesArray();
        }

        public override IEnumerable<KeyValuePair<IntPtr, IVehicle>> GetAllVehicles()
        {
            return vehiclePool.GetEntitiesArray();
        }
    }
}