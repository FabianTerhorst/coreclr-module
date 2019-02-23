using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;
using AltV.Net.Elements.Pools;

namespace AltV.Net
{
    public abstract class Resource : IResource
    {
        public abstract void OnStart();

        public abstract void OnStop();

        public virtual void OnTick()
        {
        }

        public virtual IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool, IEntityPool<ICheckpoint> checkpointPool)
        {
            return new BaseEntityPool(playerPool, vehiclePool, blipPool, checkpointPool);
        }

        public virtual IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory)
        {
            return new PlayerPool(playerFactory);
        }

        public virtual IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory)
        {
            return new VehiclePool(vehicleFactory);
        }

        public virtual IEntityPool<IBlip> GetBlipPool(IEntityFactory<IBlip> blipFactory)
        {
            return new BlipPool(blipFactory);
        }

        public virtual IEntityPool<ICheckpoint> GetCheckpointPool(IEntityFactory<ICheckpoint> checkpointFactory)
        {
            return new CheckpointPool(checkpointFactory);
        }

        public virtual IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new PlayerFactory();
        }

        public virtual IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new VehicleFactory();
        }

        public virtual IEntityFactory<IBlip> GetBlipFactory()
        {
            return new BlipFactory();
        }

        public virtual IEntityFactory<ICheckpoint> GetCheckpointFactory()
        {
            return new CheckpointFactory();
        }

        public virtual Module GetModule(IServer server, CSharpNativeResource cSharpNativeResource, IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool)
        {
            return new Module(server, cSharpNativeResource, baseEntityPool, playerPool, vehiclePool, blipPool, checkpointPool);
        }
    }
}