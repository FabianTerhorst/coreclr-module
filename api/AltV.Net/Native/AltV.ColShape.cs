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
            // Entity

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_GetPosition(IntPtr entityPointer, ref Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_SetPosition(IntPtr entityPointer, Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_GetRotation(IntPtr entityPointer, ref Rotation rotation);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_SetRotation(IntPtr entityPointer, Rotation rotation);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern short ColShape_GetDimension(IntPtr entityPointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_SetDimension(IntPtr entityPointer, short dimension);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_GetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = NativeCallingConvention)]
            internal static extern void ColShape_SetMetaData(IntPtr entityPointer, string key, ref MValue value);

            // ColShape
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ColShapeType ColShape_GetColShapeType(IntPtr colShapePointer);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool ColShape_IsEntityIn(IntPtr colShapePointer, IntPtr entityPointer);
        }
    }
}