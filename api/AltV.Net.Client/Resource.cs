using AltV.Net.CApi;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Pools;

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
        
        public virtual INativeResourceFactory GetResourceFactory()
        {
            return new NativeResourceFactory();
        }
        
        public virtual ILogger GetLogger(ILibrary library, IntPtr corePointer)
        {
            return new Logger(library, corePointer);
        }
    }
}