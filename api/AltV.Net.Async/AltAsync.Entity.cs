using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    //TODO: allocate position, rotation, rgba structs in task thread an pass them to the main thread instead of creating them in the main thread
    public partial class AltAsync
    {
        public static Task<uint> GetModelAsync(this IEntity entity) =>
            AltVAsync.Schedule(() => entity.Model);

        public static Task SetRotationAsync(this IEntity entity, Rotation rotation) =>
            AltVAsync.Schedule(() => entity.Rotation = rotation);

        public static Task<Rotation> GetRotationAsync(this IEntity entity) =>
            AltVAsync.Schedule(() => entity.Rotation);

        public static async Task SetSyncedMetaDataAsync(this IEntity entity, string key, object value)
        {
            Alt.Server.CreateMValue(out var mValue, value);
            await AltVAsync.Schedule(() => entity.SetSyncedMetaData(key, mValue));
            mValue.Dispose();
        }

        public static Task<T> GetSyncedMetaDataAsync<T>(this IEntity entity, string key) =>
            AltVAsync.Schedule(() =>
            {
                entity.GetSyncedMetaData<T>(key, out var value);
                return value;
            });

        public static async Task SetStreamSyncedMetaDataAsync(this IEntity entity, string key, object value)
        {
            Alt.Server.CreateMValue(out var mValue, value);
            await AltVAsync.Schedule(() => entity.SetStreamSyncedMetaData(key, mValue));
            mValue.Dispose();
        }

        public static Task<T> GetStreamSyncedMetaDataAsync<T>(this IEntity entity, string key) =>
            AltVAsync.Schedule(() =>
            {
                entity.GetStreamSyncedMetaData<T>(key, out var value);
                return value;
            });

        public static Task DeleteSyncedMetaDataAsync(this IEntity entity, string key) =>
            AltVAsync.Schedule(() => entity.DeleteSyncedMetaData(key));
        
        public static Task DeleteStreamSyncedMetaDataAsync(this IEntity entity, string key) =>
            AltVAsync.Schedule(() => entity.DeleteStreamSyncedMetaData(key));
    }
}