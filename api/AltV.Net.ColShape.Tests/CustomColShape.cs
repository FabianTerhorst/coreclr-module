using AltV.Net.Data;

namespace AltV.Net.ColShape.Tests
{
    public class CustomColShape : ColShape
    {
        public CustomColShape(ulong id, int dimension, Position position, uint radius) : base(id, dimension, position,
            radius)
        {
        }
    }
}