using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class CheckpointFactory : ICheckpointFactory
    {
        public virtual ICheckpoint Create(IntPtr checkpointFactory)
        {
            return new Checkpoint(checkpointFactory);
        }
    }
}