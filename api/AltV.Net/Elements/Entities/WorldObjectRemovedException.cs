namespace AltV.Net.Elements.Entities
{
    public class WorldObjectRemovedException : BaseObjectRemovedException
    {
        internal WorldObjectRemovedException(IWorldObject worldObject) : base(
            $"WorldObject(Type: {worldObject.Type.ToString()}: Dimension {worldObject.Dimension}) got deleted.")
        {
        }

        public WorldObjectRemovedException(string message) : base(message)
        {
        }
    }
}