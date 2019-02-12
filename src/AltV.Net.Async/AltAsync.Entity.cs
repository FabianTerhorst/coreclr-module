using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public partial class AltAsync
    {
        public static async Task<bool> Exists(this IEntity entity) =>
            await AltVAsync.Schedule(() => entity.Exists);

        public static async Task<ushort> GetId(this IEntity entity) =>
            await AltVAsync.Schedule(() => entity.Id);

        public static async Task<EntityType> GetType(this IEntity entity) =>
            await AltVAsync.Schedule(() => entity.Type);

        public static async Task SetPosition(this IEntity entity, Position position) =>
            await AltVAsync.Schedule(() => { entity.Position = position; });

        public static async Task<Position> GetPosition(this IEntity entity) =>
            await AltVAsync.Schedule(() => entity.Position);

        public static async Task SetRotation(this IEntity entity, Rotation rotation) =>
            await AltVAsync.Schedule(() => { entity.Rotation = rotation; });

        public static async Task<Rotation> GetRotation(this IEntity entity) =>
            await AltVAsync.Schedule(() => entity.Rotation);

        public static async Task SetDimension(this IEntity entity, ushort dimension) =>
            await AltVAsync.Schedule(() => { entity.Dimension = dimension; });

        public static async Task SetMetaData(this IEntity entity, string key, object value) =>
            await AltVAsync.Schedule(() => entity.SetMetaData(key, value));

        public static async Task<T> GetMetaData<T>(this IEntity entity, string key) =>
            await AltVAsync.Schedule(() =>
            {
                entity.GetMetaData<T>(key, out var value);
                return value;
            });

        public static async Task SetSyncedMetaData(this IEntity entity, string key, object value) =>
            await AltVAsync.Schedule(() => entity.SetSyncedMetaData(key, value));

        public static async Task<T> GetSyncedMetaData<T>(this IEntity entity, string key) =>
            await AltVAsync.Schedule(() =>
            {
                entity.GetSyncedMetaData<T>(key, out var value);
                return value;
            });

        public static async Task<ushort> GetDimension(this IEntity entity) =>
            await AltVAsync.Schedule(() => entity.Dimension);

        public static async Task Remove(this IEntity entity) =>
            await AltVAsync.Schedule(entity.Remove);
    }
}