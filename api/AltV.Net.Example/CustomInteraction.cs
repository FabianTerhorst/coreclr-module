using System.Numerics;
using AltV.Net.Elements.Entities;
using AltV.Net.Interactions;

namespace AltV.Net.Example
{
    public class CustomInteraction : Interaction
    {
        public CustomInteraction(ulong type, ulong id, Vector3 position, int dimension, uint range) : base(type, id,
            position, dimension, range)
        {
        }

        public override bool OnInteraction(IPlayer player, Vector3 interactionPosition, int interactionDimension)
        {
            return false;
        }
    }
}