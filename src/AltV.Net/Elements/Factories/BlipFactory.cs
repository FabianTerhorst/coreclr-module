using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class BlipFactory : IEntityFactory<IBlip>
    {
        public IBlip Create(IntPtr blipPointer, ushort id)
        {
            return new Blip(blipPointer, id);
        }
    }
}