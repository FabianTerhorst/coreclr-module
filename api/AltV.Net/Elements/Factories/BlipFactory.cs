using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class BlipFactory : IBaseObjectFactory<IBlip>
    {
        public IBlip Create(ICore core, IntPtr blipPointer, uint id)
        {
            return new Blip(core, blipPointer, id);
        }
    }
}