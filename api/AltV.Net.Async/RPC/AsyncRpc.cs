using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.RPC
{
    public static class AsyncRpc
    {
        internal static Func<IPlayer, string, object, Task> EmitSingleFunc;

        public static Task EmitSingle(this IPlayer player, string eventName, object data)
        {
            return EmitSingleFunc(player, eventName, data);
        }
    }
}