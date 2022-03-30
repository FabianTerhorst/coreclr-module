using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client
{
    public abstract class Resource : IResource
    {
        public abstract void OnStart();

        public abstract void OnStop();

        public virtual IPlayerFactory GetPlayerFactory()
        {
            return new PlayerFactory();
        }

        public virtual IEntityFactory<IVehicle> GetVehicleFactory()
        {
            return new VehicleFactory();
        }
    }
}