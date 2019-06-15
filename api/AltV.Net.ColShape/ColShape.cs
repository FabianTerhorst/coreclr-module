using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape
{
    public class ColShape : IColShape
    {
        public ulong Id { get; }

        public int Dimension { get; }

        public Position Position { get; }

        public uint Radius { get; }

        private readonly HashSet<IWorldObject> worldObjects;

        public IDictionary<IWorldObject, bool> LastChecked { get; }

        public IEnumerable<IWorldObject> WorldObjects => worldObjects;

        public ColShape(ulong id, int dimension, Position position, uint radius)
        {
            Id = id;
            Dimension = dimension;
            Position = position;
            Radius = radius;
            worldObjects = new HashSet<IWorldObject>();
            LastChecked = new Dictionary<IWorldObject, bool>();
        }

        public void AddWorldObject(IWorldObject worldObject)
        {
            worldObjects.Add(worldObject);
        }

        public void RemoveWorldObject(IWorldObject worldObject)
        {
            worldObjects.Remove(worldObject);
        }

        public bool ContainsWorldObject(IWorldObject worldObject)
        {
            return worldObjects.Contains(worldObject);
        }

        public virtual bool IsPositionInside(in Position position)
        {
            return Position.Distance(position) <= Radius;
        }

        public void SetCheck(IWorldObject worldObject)
        {
            LastChecked[worldObject] = true;
        }

        public void ResetCheck(IWorldObject worldObject)
        {
            LastChecked[worldObject] = false;
        }

        public void RemoveCheck(IWorldObject worldObject)
        {
            LastChecked.Remove(worldObject);
        }

        public bool HasCheck(IWorldObject worldObject)
        {
            return LastChecked.TryGetValue(worldObject, out var checkState) && checkState;
        }
    }
}