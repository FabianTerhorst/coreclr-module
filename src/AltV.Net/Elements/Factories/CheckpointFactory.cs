using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class CheckpointFactory : IEntityFactory<ICheckpoint>
    {
        public ICheckpoint Create(IntPtr checkpointFactory, ushort id)
        {
            return new Checkpoint(checkpointFactory, id);
        }
    }
}