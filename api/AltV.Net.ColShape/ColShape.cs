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

        public IEnumerable<IWorldObject> WorldObjects => worldObjects;

        public ColShape(ulong id, int dimension, Position position, uint radius)
        {
            Id = id;
            Dimension = dimension;
            Position = position;
            Radius = radius;
            worldObjects = new HashSet<IWorldObject>();
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

        public bool IsPositionInside(in Position position)
        {
            return Position.Distance(position) <= Radius;
        }
    }
}