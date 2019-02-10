using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class CheckpointFactory : IEntityFactory<ICheckpoint>
    {
        public ICheckpoint Create(IntPtr checkpointFactory)
        {
            return new Checkpoint(checkpointFactory);
        }
    }
}