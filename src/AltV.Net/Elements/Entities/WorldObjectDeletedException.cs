using System;

namespace AltV.Net.Elements.Entities
{
    public class WorldObjectDeletedException : Exception
    {
        internal WorldObjectDeletedException(IWorldObject worldObject) : base(
            $"WorldObject(Type: {worldObject.Type.ToString()}: Dimension {worldObject.Dimension}) got deleted.")
        {
        }
    }
}