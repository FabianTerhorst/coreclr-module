using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    //TODO: allocate position, rotation, rgba structs in task thread an pass them to the main thread instead of creating them in the main thread
    public partial class AltAsync
    {
        public static async Task<ushort> GetIdAsync(this IEntity entity) =>
            await AltVAsync.Schedule(() => entity.Id);

        public static async Task<uint> GetModelAsync(this IEntity entity) =>
            await AltVAsync.Schedule(() => entity.Model);

        public static async Task SetRotationAsync(this IEntity entity, Rotation rotation) =>
            await AltVAsync.Schedule(() => { entity.Rotation = rotation; });

        public static async Task<Rotation> GetRotationAsync(this IEntity entity) =>
            await AltVAsync.Schedule(() => entity.Rotation);

        public static async Task SetSyncedMetaDataAsync(this IEntity entity, string key, object value)
        {
            var mValue = MValue.CreateFromObject(value);
            await AltVAsync.Schedule(() => entity.SetSyncedMetaData(key, mValue));
        }

        public static async Task<T> GetSyncedMetaDataAsync<T>(this IEntity entity, string key) =>
            await AltVAsync.Schedule(() =>
            {
                entity.GetSyncedMetaData<T>(key, out var value);
                return value;
            });
    }
}