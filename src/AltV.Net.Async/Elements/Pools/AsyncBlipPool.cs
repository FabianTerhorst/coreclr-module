using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncBlipPool : AsyncEntityPool<IBlip>
    {
        public AsyncBlipPool(IEntityFactory<IBlip> entityFactory) : base(entityFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => Blip.GetId(entityPointer)).Result;
        }
    }
}