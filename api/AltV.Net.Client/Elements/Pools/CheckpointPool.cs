using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class CheckpointPool : BaseObjectPool<ICheckpoint>
    {
        public CheckpointPool(IBaseObjectFactory<ICheckpoint> blipFactory) : base(blipFactory)
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