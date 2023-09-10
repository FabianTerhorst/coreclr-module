using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncMarkerFactory : IBaseObjectFactory<IMarker>
    {
        public IMarker Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncMarker(core, baseObjectPointer, id);
        }
    }
}