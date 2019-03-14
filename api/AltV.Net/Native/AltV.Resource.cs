using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        internal static class Resource
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort CSharpResource_SetExport(IntPtr resourcePointer, string key, ref MValue value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort Resource_GetExports(IntPtr resourcePointer, ref StringViewArray keys,
                ref MValueArray values);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Resource_GetExport(IntPtr resourcePointer, string key, ref MValue mvalue);
        }
    }
}