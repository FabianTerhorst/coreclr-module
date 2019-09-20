using System.Threading.Tasks;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    //TODO: allocate position, rotation, rgba structs in task thread an pass them to the main thread instead of creating them in the main thread
    public partial class AltAsync
    {
        public static Task<bool> ExistsAsync(this IBaseObject baseObject) =>
            AltVAsync.Schedule(() => baseObject.Exists);

        public static Task<BaseObjectType> GetTypeAsync(this IBaseObject baseObject) =>
            AltVAsync.Schedule(() => baseObject.Type);

        public static Task SetMetaDataAsync(this IBaseObject baseObject, string key, object value)
        {
            var mValue = MValue.CreateFromObject(value);
            return AltVAsync.Schedule(() => baseObject.SetMetaData(key, mValue));
        }

        public static Task<T> GetMetaDataAsync<T>(this IBaseObject baseObject, string key) =>
            AltVAsync.Schedule(() =>
            {
                baseObject.GetMetaData<T>(key, out var value);
                return value;
            });
    }
}