using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared.Utils;

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
                unsafe
                {
                    if (!player.Exists)
                    {
                        return false;
                    }

                    var pos = Vector3.Zero;
                    Alt.Core.Library.Shared.WorldObject_GetPosition(player.WorldObjectNativePointer, &pos);
                    position = pos;
                    return true;
                }
            }
        }

        public static bool EmitLockedWithContext(this IPlayer player, string eventName, params object[] args)
        {
            var size = args.Length;
            var successfully = true;
            var mValues = new MValueConst[size];
            MValueConstLocked.CreateFromObjectsLocked(args, mValues);
            var eventNamePtr = MemoryUtils.StringToHGlobalUtf8(eventName);
            lock (player)
            {
                if (player.Exists)
                {
                    Alt.Core.TriggerClientEvent(player, eventNamePtr, mValues);
                }
                else
                {
                    successfully = false;
                }
            }

            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }

            Marshal.FreeHGlobal(eventNamePtr);

            return successfully;
        }

        public static bool EmitUnreliableLockedWithContext(this IPlayer player, string eventName, params object[] args)
        {
            var size = args.Length;
            var successfully = true;
            var mValues = new MValueConst[size];
            MValueConstLocked.CreateFromObjectsLocked(args, mValues);
            var eventNamePtr = MemoryUtils.StringToHGlobalUtf8(eventName);
            lock (player)
            {
                if (player.Exists)
                {
                    Alt.Core.TriggerClientEventUnreliable(player, eventNamePtr, mValues);
                }
                else
                {
                    successfully = false;
                }
            }

            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }

            Marshal.FreeHGlobal(eventNamePtr);

            return successfully;
        }

        public static bool EmitLocked(this IPlayer player, string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            MValueConstLockedNoRefs.CreateFromObjectsLocked(args, mValues);
            var eventNamePtr = MemoryUtils.StringToHGlobalUtf8(eventName);
            var successfully = true;
            lock (player)
            {
                if (player.Exists)
                {
                    Alt.Core.TriggerClientEvent(player, eventNamePtr, mValues);
                }
                else
                {
                    successfully = false;
                }
            }

            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }

            Marshal.FreeHGlobal(eventNamePtr);

            return successfully;
        }

        public static bool EmitUnreliableLocked(this IPlayer player, string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            MValueConstLockedNoRefs.CreateFromObjectsLocked(args, mValues);
            var eventNamePtr = MemoryUtils.StringToHGlobalUtf8(eventName);
            var successfully = true;
            lock (player)
            {
                if (player.Exists)
                {
                    Alt.Core.TriggerClientEventUnreliable(player, eventNamePtr, mValues);
                }
                else
                {
                    successfully = false;
                }
            }

            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }

            Marshal.FreeHGlobal(eventNamePtr);

            return successfully;
        }
    }
}