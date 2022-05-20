using System;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    //TODO: allocate position, rotation, rgba structs in task thread an pass them to the main thread instead of creating them in the main thread
    public partial class AltAsync
    {
        [Obsolete("Use async entities instead")]
        public static Task SetPositionAsync(this IWorldObject worldObject, Position position) =>
            AltVAsync.Schedule(() => worldObject.Position = position);

        [Obsolete("Use async entities instead")]
        public static Task SetPositionAsync(this IWorldObject worldObject, float x, float y, float z) =>
            AltVAsync.Schedule(() => worldObject.SetPosition(x, y, z));

        [Obsolete("Use async entities instead")]
        public static Task SetPositionAsync(this IWorldObject worldObject, (float X, float Y, float Z) position) =>
            AltVAsync.Schedule(() => worldObject.SetPosition(position));

        [Obsolete("Use async entities instead")]
        public static Task<Position> GetPositionAsync(this IWorldObject worldObject) =>
            AltVAsync.Schedule(() => worldObject.Position);

        [Obsolete("Use async entities instead")]
        public static Task<(float X, float Y, float Z)> GetPositionTupleAsync(this IWorldObject worldObject) =>
            AltVAsync.Schedule(worldObject.GetPosition);

        [Obsolete("Use async entities instead")]
        public static Task SetDimensionAsync(this IWorldObject worldObject, int dimension) =>
            AltVAsync.Schedule(() => worldObject.Dimension = dimension);

        [Obsolete("Use async entities instead")]
        public static Task<int> GetDimensionAsync(this IWorldObject worldObject) =>
            AltVAsync.Schedule(() => worldObject.Dimension);
    }
}
