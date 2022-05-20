using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class CheckpointPool : BaseObjectPool<ICheckpoint>
    {
        public CheckpointPool(IBaseObjectFactory<ICheckpoint> blipFactory) : base(blipFactory)
        {
        }
    }
}