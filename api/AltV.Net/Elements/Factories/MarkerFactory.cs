using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class MarkerFactory : IBaseObjectFactory<IMarker>
    {
        public IMarker Create(ICore core, IntPtr markerPointer, uint id)
        {
            return new Marker(core, markerPointer, id);
        }
    }
}