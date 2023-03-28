using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools;

public class VirtualEntityGroupPool : BaseObjectPool<IVirtualEntityGroup>
{
    public VirtualEntityGroupPool(IBaseObjectFactory<IVirtualEntityGroup> entityFactory) : base(entityFactory)
    {
    }

    public override uint GetId(IntPtr entityPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.VirtualEntityGroup_GetID(entityPointer);
        }
    }
}