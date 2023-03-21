using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools;

public class PedPool : EntityPool<IPed>
{
    public PedPool(IEntityFactory<IPed> pedFactory) : base(pedFactory)
    {
    }

    public override ushort GetId(IntPtr entityPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Ped_GetID(entityPointer);
        }
    }
}