using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static bool ExecuteLocked(this IBaseObject player, Action action)
        {
            lock (player)
            {
                if (!player.Exists)
                {
                    return false;
                }

                action();
                return true;
            }
        }

        public static bool ExecuteLocked<T>(this IBaseObject player, Action<T> action, T param)
        {
            lock (player)
            {
                if (!player.Exists)
                {
                    return false;
                }

                action(param);
                return true;
            }
        }

        public static bool ExecuteLocked<T1, T2, T3>(this IBaseObject player, Action<T1, T2, T3> action, T1 param1,
            T2 param2, T3 param3)
        {
            lock (player)
            {
                if (!player.Exists)
                {
                    return false;
                }

                action(param1, param2, param3);
                return true;
            }
        }

        public static bool ExecuteLocked<T1, T2, T3, T4>(this IBaseObject player, Action<T1, T2, T3, T4> action,
            T1 param1, T2 param2, T3 param3, T4 param4)
        {
            lock (player)
            {
                if (!player.Exists)
                {
                    return false;
                }

                action(param1, param2, param3, param4);
                return true;
            }
        }

        public static bool SetPositionLocked(this IPlayer player, Position position)
        {
            lock (player)
            {
                if (!player.Exists)
                {
                    return false;
                }

                player.Position = position;
                return true;
            }
        }

        public static bool GetPositionLocked(this IPlayer player, ref Position position)
        {
            lock (player)
            {
                if (!player.Exists)
                {
                    return false;
                }

                AltNative.Player.Player_GetPosition(player.NativePointer, ref position);
                return true;
            }
        }

        public static bool EmitLocked(this IPlayer player, string eventName, params object[] args)
        {
            player.ExecuteLocked<float, float, float>(player.SetPosition, 1, 2, 3);

            var mValues = MValueLocked.CreateFromObjectsLocked(args);
            var mValueArgs = MValue.Create(mValues);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            var successfully = true;
            lock (player)
            {
                if (player.Exists)
                {
                    Alt.Server.TriggerClientEvent(player, eventNamePtr, ref mValueArgs);
                }
                else
                {
                    successfully = false;
                }
            }

            Marshal.FreeHGlobal(eventNamePtr);
            MValue.Dispose(mValues);
            mValueArgs.Dispose();
            return successfully;
        }
    }
}