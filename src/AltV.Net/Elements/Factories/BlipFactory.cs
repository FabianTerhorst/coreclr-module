using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class BlipFactory : IBaseObjectFactory<IBlip>
    {
        public IBlip Create(IntPtr blipPointer)
        {
            return new Blip(blipPointer);
        }
    }
}