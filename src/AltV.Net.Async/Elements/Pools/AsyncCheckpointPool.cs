using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Pools
{
    public class AsyncCheckpointPool : AsyncEntityPool<ICheckpoint>
    {
        public AsyncCheckpointPool(IEntityFactory<ICheckpoint> entityFactory) : base(entityFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return AltAsync.Do(() => Checkpoint.GetId(entityPointer)).Result;
        }
    }
}