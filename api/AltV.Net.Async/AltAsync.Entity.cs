using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    //TODO: allocate position, rotation, rgba structs in task thread an pass them to the main thread instead of creating them in the main thread
    public partial class AltAsync
    {
        public static Task<ushort> GetIdAsync(this IEntity entity) =>
            AltVAsync.Schedule(() => entity.Id);

        public static Task<uint> GetModelAsync(this IEntity entity) =>
            AltVAsync.Schedule(() => entity.Model);

        public static Task SetRotationAsync(this IEntity entity, Rotation rotation) =>
            AltVAsync.Schedule(() => entity.Rotation = rotation);

        public static Task<Rotation> GetRotationAsync(this IEntity entity) =>
            AltVAsync.Schedule(() => entity.Rotation);

        public static Task SetSyncedMetaDataAsync(this IEntity entity, string key, object value)
        {
            var mValue = MValue.CreateFromObject(value);
            return AltVAsync.Schedule(() => entity.SetSyncedMetaData(key, mValue));
        }

        public static Task<T> GetSyncedMetaDataAsync<T>(this IEntity entity, string key) =>
            AltVAsync.Schedule(() =>
            {
                entity.GetSyncedMetaData<T>(key, out var value);
                return value;
            });
    }
}