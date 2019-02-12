using System;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        internal static AltVAsync AltVAsync;

        internal static void Setup(AltVAsync altVAsync)
        {
            AltVAsync = altVAsync;
        }

        public static async Task Do(Action action)
        {
            await AltVAsync.Schedule(action);
        }

        public static async Task<TResult> Do<TResult>(Func<TResult> action)
        {
            return await AltVAsync.Schedule(action);
        }
    }
}