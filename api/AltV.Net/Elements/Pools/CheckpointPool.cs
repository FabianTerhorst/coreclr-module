using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class CheckpointPool : BaseObjectPool<ICheckpoint>
    {
        public CheckpointPool(IBaseObjectFactory<ICheckpoint> checkpointPool) : base(checkpointPool)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Checkpoint_GetID(entityPointer);
            }
        }
    }
}