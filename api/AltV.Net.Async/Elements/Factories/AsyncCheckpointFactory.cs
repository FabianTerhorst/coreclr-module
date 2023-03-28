using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncCheckpointFactory : IBaseObjectFactory<ICheckpoint>
    {
        public ICheckpoint Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncCheckpoint(core, baseObjectPointer, id);
        }
    }
}