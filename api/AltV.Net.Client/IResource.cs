using AltV.Net.CApi;
using AltV.Net.Client.Elements;
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
        public INativeResourceFactory GetResourceFactory();
        public ILogger GetLogger(ILibrary library, IntPtr corePointer);
    }
}