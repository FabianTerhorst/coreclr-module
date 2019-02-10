using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockCheckpointPool : CheckpointPool
    {
        public MockCheckpointPool(IEntityFactory<ICheckpoint> checkpointFactory) : base(checkpointFactory)
        {
        }

        public override ushort GetId(IntPtr entityPointer)
        {
            return 0;
        }
    }
}