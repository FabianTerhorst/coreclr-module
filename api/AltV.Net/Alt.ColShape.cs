using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System.Numerics;

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
            return Core.CreateColShapeCylinder(pos, radius, height);
        }

        /// <summary>
        /// Creates a alt:V sphere colshape.
        /// </summary>
        /// <param name="pos">The position of the colshape.</param>
        /// <param name="radius">The size of the colshape.</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapeSphere(Position pos, float radius)
        {
            return Core.CreateColShapeSphere(pos, radius);
        }

        /// <summary>
        /// Creates a alt:V cylinder colshape with no height (from bottom to top of the height of the map).
        /// </summary>
        /// <param name="pos">The position of the colshape.</param>
        /// <param name="radius">The size of the colshape.</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapeCircle(Position pos, float radius)
        {
            return Core.CreateColShapeCircle(pos, radius);
        }

        /// <summary>
        /// Creates a alt:V cube colshape between two positions.
        /// </summary>
        /// <param name="pos">The first position of the colshape.</param>
        /// <param name="pos2">The second position of the colshape.</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapeCube(Position pos, Position pos2)
        {
            return Core.CreateColShapeCube(pos, pos2);
        }

        /// <summary>
        /// Creates a alt:v cube colshape between two positions with no height (from bottom to top of the height of the map).
        /// </summary>
        /// <param name="x1">The first position of the colshape.</param>
        /// <param name="y1">The second position of the colshape.</param>
        /// <param name="x2">The first position of the colshape.</param>
        /// <param name="y2">The second position of the colshape.</param>
        /// <param name="z">The second position of the colshape.</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapeRectangle(float x1, float y1, float x2, float y2, float z)
        {
            return Core.CreateColShapeRectangle(x1, y1, x2, y2, z);
        }
        
        /// <summary>
        /// Creates a alt:v polygon colshape between given points from minmal z position to maximal z position.
        /// </summary>
        /// <param name="minZ">The minimal z-axis of the colshape.</param>
        /// <param name="maxZ">The maximal z-axis of the colshape.</param>
        /// <param name="points">The set of points of the polygon (only x and y axis)</param>
        /// <returns>The created colshape.</returns>
        public static IColShape CreateColShapePolygon(float minZ, float maxZ, Vector2[] points)
        {
            return Core.CreateColShapePolygon(minZ, maxZ, points);
        }
    }
}