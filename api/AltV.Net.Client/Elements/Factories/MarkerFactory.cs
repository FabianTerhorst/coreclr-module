using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class MarkerFactory : IBaseObjectFactory<IMarker>
    {
        public IMarker Create(ICore core, IntPtr markerPointer, uint id)
        {
            return new Marker(core, markerPointer, id);
        }
    }
}