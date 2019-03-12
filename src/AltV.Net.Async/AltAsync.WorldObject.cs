using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    //TODO: allocate position, rotation, rgba structs in task thread an pass them to the main thread instead of creating them in the main thread
    public partial class AltAsync
    {
        public static async Task SetPositionAsync(this IWorldObject worldObject, Position position) =>
            await AltVAsync.Schedule(() => { worldObject.Position = position; });

        public static async Task<Position> GetPositionAsync(this IWorldObject worldObject) =>
            await AltVAsync.Schedule(() => worldObject.Position);

        public static async Task SetDimensionAsync(this IWorldObject worldObject, short dimension) =>
            await AltVAsync.Schedule(() => { worldObject.Dimension = dimension; });

        public static async Task<short> GetDimensionAsync(this IWorldObject worldObject) =>
            await AltVAsync.Schedule(() => worldObject.Dimension);
    }
}