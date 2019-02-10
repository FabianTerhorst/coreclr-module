using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IResource
    {
        void OnStart();

        void OnStop();

        IEntityFactory<IPlayer> GetPlayerFactory();
        IEntityFactory<IVehicle> GetVehicleFactory();
        IEntityFactory<IBlip> GetBlipFactory();
        IEntityFactory<ICheckpoint> GetCheckpointFactory();
    }
}