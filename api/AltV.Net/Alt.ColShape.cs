using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            return Module.Server.CreateColShapeCylinder(pos, radius, height);
        }

        public static IColShape CreateColShapeSphere(Position pos, float radius)
        {
            return Module.Server.CreateColShapeSphere(pos, radius);
        }

        public static IColShape CreateColShapeCircle(Position pos, float radius)
        {
            return Module.Server.CreateColShapeCircle(pos, radius);
        }

        public static IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            return Module.Server.CreateColShapeCube(pos, pos2);
        }

        public static IColShape CreateColShapeRectangle(Position pos, Position pos2)
        {
            return Module.Server.CreateColShapeRectangle(pos, pos2);
        }
    }
}