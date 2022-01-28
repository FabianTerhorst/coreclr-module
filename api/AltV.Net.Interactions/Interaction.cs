using System.Numerics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Interactions
{
    public class Interaction : IInteraction
    {
        private uint range;
        public ulong Type { get; }
        public ulong Id { get; }
        public Vector3 Position { get; set; }
        public int Dimension { get; set; }
        public uint Range
        {
            get => range;
            set
            {
                range = value;
                RangeSquared = value * value;
            }
        }

        public uint RangeSquared { get; private set; }

        public Interaction(ulong type, ulong id, Vector3 position, int dimension, uint range)
        {
            Type = type;
            Id = id;
            Position = position;
            Dimension = dimension;
            Range = range;
        }

        public virtual bool OnInteraction(IPlayer player, Vector3 interactionPosition, int interactionDimension, object argument)
        {
            return false;
        }
    }
}