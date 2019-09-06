using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;

namespace AltV.Net.Mock
{
    public class MockCheckpointPool : CheckpointPool
    {
        public MockCheckpointPool(IBaseObjectFactory<ICheckpoint> checkpointFactory) : base(checkpointFactory)
        {
        }

        public override void OnRemove(ICheckpoint entity)
        {
            MockEntities.FreeNoId(entity.NativePointer);
        }
    }
}