using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Player
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_Copy(IntPtr playerPointer, ref ReadOnlyPlayer readOnlyPlayer);
            
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            [return: MarshalAs(UnmanagedType.AnsiBStr)]
            internal static extern string Player_GetName(IntPtr playerPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Player_SetName(IntPtr playerPointer,
                [MarshalAs(UnmanagedType.AnsiBStr)] string name);
        }
    }
}