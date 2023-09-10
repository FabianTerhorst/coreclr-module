using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class LocalVehicleFactory : IBaseObjectFactory<ILocalVehicle>
    {
        public ILocalVehicle Create(ICore core, IntPtr blipPointer, uint id)
        {
            return new LocalVehicle(core, blipPointer, id);
        }
    }
}