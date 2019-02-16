using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Pools
{
    public class CheckpointPool : EntityPool<ICheckpoint>
    {
        public CheckpointPool(IEntityFactory<ICheckpoint> checkpointPool) : base(checkpointPool)
        {
        }
        
        public override ushort GetId(IntPtr entityPointer)
        {
            return AltVNative.Checkpoint.Checkpoint_GetID(entityPointer);
        }
    }
}