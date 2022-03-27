using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace AltV.Net.Native
{
    [SuppressUnmanagedCodeSecurity]
    internal static partial class AltNative
    {
        private const string DllName = "csharp-module";
        private const CallingConvention NativeCallingConvention = CallingConvention.Cdecl;
    }
}