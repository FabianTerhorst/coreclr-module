using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public abstract class AsyncResource : Resource
    {
        private readonly AltVAsync altVAsync = new AltVAsync();

        public override void OnTick()
        {
            altVAsync.Tick();
        }

        public override IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool, IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool)
        {
            return new AsyncBaseEntityPool(playerPool, vehiclePool, blipPool, checkpointPool);
        }

        public override IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory)
        {
            return new AsyncEntityPool<IPlayer>(playerFactory);
        }

        public override IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory)
        {
            return new AsyncVehiclePool(vehicleFactory);
        }

        public override IEntityPool<IBlip> GetBlipPool(IEntityFactory<IBlip> blipFactory)
        {
            return new AsyncEntityPool<IBlip>(blipFactory);
        }

        public override IEntityPool<ICheckpoint> GetCheckpointPool(IEntityFactory<ICheckpoint> checkpointFactory)
        {
            return new AsyncEntityPool<ICheckpoint>(checkpointFactory);
        }
        
        public override Module GetModule(IServer server, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool)
        {
            return new AsyncModule(server, baseEntityPool, playerPool, vehiclePool, blipPool, checkpointPool);
        }
    }
}