using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncNetworkObjectFactory : IEntityFactory<INetworkObject>
    {
        public INetworkObject Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncNetworkObject(core, baseObjectPointer, id);
        }
    }
}