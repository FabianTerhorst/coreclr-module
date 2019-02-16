using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class BlipPool : EntityPool<IBlip>
    {
        public BlipPool(IEntityFactory<IBlip> blipFactory) : base(blipFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return AltVNative.Blip.Blip_GetID(entityPointer);
        }
    }
}