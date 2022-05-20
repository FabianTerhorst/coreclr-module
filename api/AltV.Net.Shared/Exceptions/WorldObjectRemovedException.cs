using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public class WorldObjectRemovedException : BaseObjectRemovedException
    {
        internal WorldObjectRemovedException(ISharedWorldObject worldObject) : base(
            $"WorldObject(Type: {worldObject.Type.ToString()}) got deleted.")
        {
        }

        public WorldObjectRemovedException(string message) : base(message)
        {
        }
    }
}