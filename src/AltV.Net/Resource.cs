using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;

namespace AltV.Net
{
    public abstract class Resource : IResource
    {
        public abstract void OnStart();

        public abstract void OnStop();

        public virtual void OnTick()
        {
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
    }
}