using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools;

public class VirtualEntityPool : BaseObjectPool<IVirtualEntity>
{
    public VirtualEntityPool(IBaseObjectFactory<IVirtualEntity> entityFactory) : base(entityFactory)
    {
    }

    public override uint GetId(IntPtr entityPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.VirtualEntity_GetID(entityPointer);
        }
    }
}