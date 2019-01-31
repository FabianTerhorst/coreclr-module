using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        internal static class Events
        {
            public delegate Task PlayerConnectDelegate(IPlayer player, string reason);

            public delegate Task PlayerDisconnectDelegate(IPlayer player, string reason);
        }
    }
}