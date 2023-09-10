using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class LocalPedFactory : IBaseObjectFactory<ILocalPed>
    {
        public ILocalPed Create(ICore core, IntPtr blipPointer, uint id)
        {
            return new LocalPed(core, blipPointer, id);
        }
    }
}