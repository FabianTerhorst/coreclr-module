using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncObjectFactory : IEntityFactory<IObject>
    {
        public IObject Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncObject(core, baseObjectPointer, id);
        }
    }
}