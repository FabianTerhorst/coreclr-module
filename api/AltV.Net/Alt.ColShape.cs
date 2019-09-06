using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        /// <summary>
        /// Creates a alt:V cylinder colshape with specigic height.
        /// </summary>
        /// <param name="pos">The position of the colshape.</param>
        /// <param name="radius">The size of the colshape.</param>
        /// <param name="height">The height of the colshape.</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapeCylinder(Position pos, float radius, float height)
        {
            return Module.Server.CreateColShapeCylinder(pos, radius, height);
        }

        /// <summary>
        /// Creates a alt:V sphere colshape.
        /// </summary>
        /// <param name="pos">The position of the colshape.</param>
        /// <param name="radius">The size of the colshape.</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapeSphere(Position pos, float radius)
        {
            return Module.Server.CreateColShapeSphere(pos, radius);
        }

        /// <summary>
        /// Creates a alt:V cylinder colshape with no height (from bottom to top of the height of the map).
        /// </summary>
        /// <param name="pos">The position of the colshape.</param>
        /// <param name="radius">The size of the colshape.</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapeCircle(Position pos, float radius)
        {
            return Module.Server.CreateColShapeCircle(pos, radius);
        }

        /// <summary>
        /// Creates a alt:V cube colshape between two positions.
        /// </summary>
        /// <param name="pos">The first position of the colshape.</param>
        /// <param name="pos2">The second position of the colshape.</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            return Module.Server.CreateColShapeCube(pos, pos2);
        }

        /// <summary>
        /// Creates a alt:v cube colshape between two positions with no height (from vottom to top of the height of the map).
        /// </summary>
        /// <param name="pos">The first position of the colshape.</param>
        /// <param name="pos2">The second position of the colshape.</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapeRectangle(Position pos, Position pos2)
        {
            return Module.Server.CreateColShapeRectangle(pos, pos2);
        }
    }
}