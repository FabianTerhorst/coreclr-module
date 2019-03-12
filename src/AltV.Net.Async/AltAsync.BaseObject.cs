using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    //TODO: allocate position, rotation, rgba structs in task thread an pass them to the main thread instead of creating them in the main thread
    public partial class AltAsync
    {
        public static async Task<bool> ExistsAsync(this IBaseObject baseObject) =>
            await AltVAsync.Schedule(() => baseObject.Exists);

        public static async Task<BaseObjectType> GetTypeAsync(this IBaseObject baseObject) =>
            await AltVAsync.Schedule(() => baseObject.Type);

        public static async Task SetMetaDataAsync(this IBaseObject baseObject, string key, object value)
        {
            var mValue = MValue.CreateFromObject(value);
            await AltVAsync.Schedule(() => baseObject.SetMetaData(key, mValue));
        }

        public static async Task<T> GetMetaDataAsync<T>(this IBaseObject baseObject, string key) =>
            await AltVAsync.Schedule(() =>
            {
                baseObject.GetMetaData<T>(key, out var value);
                return value;
            });
    }
}