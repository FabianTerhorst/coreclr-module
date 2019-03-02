using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Resource
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort CSharpResource_SetExport(IntPtr resourcePointer, string key, ref MValue value);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Resource_GetExports(IntPtr resourcePointer, ref StringViewArray keys,
                ref MValueArray values);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Resource_GetExport(IntPtr resourcePointer, string key, ref MValue mvalue);
        }
    }
}