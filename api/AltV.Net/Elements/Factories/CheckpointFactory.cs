using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class CheckpointFactory : IBaseObjectFactory<ICheckpoint>
    {
        public ICheckpoint Create(IntPtr checkpointFactory)
        {
            return new Checkpoint(checkpointFactory);
        }
    }
}