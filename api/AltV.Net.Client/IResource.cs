using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client
{
    public interface IResource
    {
        public void OnStart();
        public void OnStop();
        public IPlayerFactory GetPlayerFactory();
        public IEntityFactory<IVehicle> GetVehicleFactory();
    }
}