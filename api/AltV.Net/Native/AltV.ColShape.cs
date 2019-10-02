using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class ColShape
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_GetPosition(IntPtr colShape, ref Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_SetPosition(IntPtr colShape, Position pos);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern short ColShape_GetDimension(IntPtr colShape);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_SetDimension(IntPtr colShape, short dimension);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_GetMetaData(IntPtr colShape, IntPtr key, ref MValue val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_SetMetaData(IntPtr colShape, IntPtr key, ref MValue val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ColShapeType ColShape_GetColShapeType(IntPtr colShape);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool ColShape_IsPlayerIn(IntPtr colShape, IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool ColShape_IsVehicleIn(IntPtr colShape, IntPtr vehicle);
        }
    }
}