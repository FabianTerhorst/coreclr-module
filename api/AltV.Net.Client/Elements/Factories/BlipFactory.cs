using System;
using AltV.Net.Client;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class BlipFactory : IBaseObjectFactory<IBlip>
    {
        public IBlip Create(ICore core, IntPtr blipPointer)
        {
            return new Blip(core, blipPointer);
        }
    }
}