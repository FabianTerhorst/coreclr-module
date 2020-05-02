using System;
using System.Runtime.InteropServices;
using System.Security;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class Event
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Event_WasCancelled(IntPtr eventPointer);
            
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Event_Cancel(IntPtr eventPointer);
        }
    }
}