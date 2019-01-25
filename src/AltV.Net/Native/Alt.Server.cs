using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        internal static class Server
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogInfo(IntPtr playerPointer, [MarshalAs(UnmanagedType.AnsiBStr)] String name);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogDebug(IntPtr playerPointer, [MarshalAs(UnmanagedType.AnsiBStr)] String name);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogWarning(IntPtr playerPointer, [MarshalAs(UnmanagedType.AnsiBStr)] String name);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogError(IntPtr playerPointer, [MarshalAs(UnmanagedType.AnsiBStr)] String name);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Server_LogColored(IntPtr playerPointer, [MarshalAs(UnmanagedType.AnsiBStr)] String name);
        }
    }
}