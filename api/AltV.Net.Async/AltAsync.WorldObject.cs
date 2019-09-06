using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    //TODO: allocate position, rotation, rgba structs in task thread an pass them to the main thread instead of creating them in the main thread
    public partial class AltAsync
    {
        public static Task SetPositionAsync(this IWorldObject worldObject, Position position) =>
            AltVAsync.Schedule(() => worldObject.Position = position);

        public static Task SetPositionAsync(this IWorldObject worldObject, float x, float y, float z) =>
            AltVAsync.Schedule(() => worldObject.SetPosition(x, y, z));

        public static Task SetPositionAsync(this IWorldObject worldObject, (float X, float Y, float Z) position) =>
            AltVAsync.Schedule(() => worldObject.SetPosition(position));

        public static Task<Position> GetPositionAsync(this IWorldObject worldObject) =>
            AltVAsync.Schedule(() => worldObject.Position);

        public static Task<(float X, float Y, float Z)> GetPositionTupleAsync(this IWorldObject worldObject) =>
            AltVAsync.Schedule(worldObject.GetPosition);

        public static Task SetDimensionAsync(this IWorldObject worldObject, short dimension) =>
            AltVAsync.Schedule(() => worldObject.Dimension = dimension);

        public static Task<short> GetDimensionAsync(this IWorldObject worldObject) =>
            AltVAsync.Schedule(() => worldObject.Dimension);
    }
}