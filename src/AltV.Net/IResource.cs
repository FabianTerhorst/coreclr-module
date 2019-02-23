using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public interface IResource
    {
        void OnStart();

        void OnStop();

        void OnTick();

        IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool, IEntityPool<ICheckpoint> checkpointPool);

        IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory);
        IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory);
        IEntityPool<IBlip> GetBlipPool(IEntityFactory<IBlip> blipFactory);
        IEntityPool<ICheckpoint> GetCheckpointPool(IEntityFactory<ICheckpoint> checkpointFactory);

        IEntityFactory<IPlayer> GetPlayerFactory();
        IEntityFactory<IVehicle> GetVehicleFactory();
        IEntityFactory<IBlip> GetBlipFactory();
        IEntityFactory<ICheckpoint> GetCheckpointFactory();

        Module GetModule(IServer server, CSharpNativeResource cSharpNativeResource, IBaseEntityPool baseEntityPool,
            IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IEntityPool<IBlip> blipPool,
            IEntityPool<ICheckpoint> checkpointPool);
    }
}