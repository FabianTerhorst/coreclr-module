using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class CheckpointFactory : IBaseObjectFactory<ICheckpoint>
    {
        public ICheckpoint Create(ICore core, IntPtr checkpointFactory, uint id)
        {
            return new Checkpoint(core, checkpointFactory, id);
        }
    }
}