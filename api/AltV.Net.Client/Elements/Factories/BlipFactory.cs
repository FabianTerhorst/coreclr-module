using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class BlipFactory : IBaseObjectFactory<IBlip>
    {
        public IBlip Create(ICore core, IntPtr blipPointer)
        {
            return new Blip(core, blipPointer);
        }
    }
}