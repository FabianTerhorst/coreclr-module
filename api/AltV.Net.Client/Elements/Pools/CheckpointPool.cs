using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public class CheckpointPool : BaseObjectPool<ICheckpoint>
    {
        public CheckpointPool(IBaseObjectFactory<ICheckpoint> blipFactory) : base(blipFactory)
        {
        }
    }
}