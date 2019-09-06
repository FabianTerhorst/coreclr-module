using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncPlayerPool : AsyncEntityPool<IPlayer>
    {
        public AsyncPlayerPool(IEntityFactory<IPlayer> entityFactory) : base(entityFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => Player.GetId(entityPointer)).Result;
        }
    }
}