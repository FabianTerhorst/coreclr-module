using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class CheckpointPool : BaseObjectPool<ICheckpoint>
    {
        public CheckpointPool(IBaseObjectFactory<ICheckpoint> checkpointPool) : base(checkpointPool)
        {
        }
    }
}