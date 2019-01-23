using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        internal static class Vehicle
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            //TODO: test
            //[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Alt.RGBAMarshaler))]
            //[return: MarshalAs(UnmanagedType.Struct, MarshalTypeRef = typeof(Alt.RGBAMarshaler))]
            [return: MarshalAs(UnmanagedType.Struct)]
            internal static extern Alt.RGBA GetPrimaryColorRGB(IntPtr vehiclePointer);
        }
    }
}