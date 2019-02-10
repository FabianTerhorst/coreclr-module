using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class CheckpointPool : EntityPool<ICheckpoint>
    {
        public CheckpointPool(IEntityFactory<ICheckpoint> checkpointPool) : base(checkpointPool)
        {
        }
    }
}