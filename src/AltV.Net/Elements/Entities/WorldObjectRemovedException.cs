using System;

namespace AltV.Net.Elements.Entities
{
    public class WorldObjectRemovedException : Exception
    {
        internal WorldObjectRemovedException(IWorldObject worldObject) : base(
            $"WorldObject(Type: {worldObject.Type.ToString()}: Dimension {worldObject.Dimension}) got deleted.")
        {
        }
    }
}