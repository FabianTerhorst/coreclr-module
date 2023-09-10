using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncConnectionInfoFactory : IBaseObjectFactory<IConnectionInfo>
    {
        public IConnectionInfo Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncConnectionInfo(core, baseObjectPointer, id);
        }
    }
}