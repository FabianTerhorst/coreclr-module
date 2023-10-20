using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncBlipFactory : IBaseObjectFactory<IBlip>
    {
        public IBlip Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncBlip(core, baseObjectPointer, id);
        }
    }
}