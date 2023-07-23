using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class ObjectPool : EntityPool<IObject>
    {
        public ObjectPool(IEntityFactory<IObject> factory) : base(factory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Object_GetID(entityPointer);
            }
        }
    }
}