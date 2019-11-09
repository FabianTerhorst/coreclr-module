using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class Blip
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Blip_GetPosition(IntPtr blip, ref Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Blip_SetPosition(IntPtr blip, Position pos);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern int Blip_GetDimension(IntPtr blip);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Blip_SetDimension(IntPtr blip, int dimension);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Blip_GetMetaData(IntPtr blip, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Blip_SetMetaData(IntPtr blip, IntPtr key, IntPtr val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Blip_IsGlobal(IntPtr blip);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Blip_IsAttached(IntPtr blip);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Blip_AttachedTo(IntPtr blip, ref BaseObjectType type);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Blip_GetType(IntPtr blip);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Blip_SetSprite(IntPtr blip, ushort sprite);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Blip_SetColor(IntPtr blip, byte color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Blip_SetRoute(IntPtr blip, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Blip_SetRouteColor(IntPtr blip, byte color);
        }
    }
}