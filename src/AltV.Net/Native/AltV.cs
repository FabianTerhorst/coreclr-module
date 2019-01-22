using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        private const string _dllName = "dotnet-wrapper";
        private const CallingConvention _callingConvention = CallingConvention.Cdecl;

        [DllImport(_dllName, CallingConvention = _callingConvention)]
        internal static extern int FreeObject(IntPtr pointer);

        [DllImport(_dllName, CallingConvention = _callingConvention)]
        internal static extern int FreeArray(IntPtr array);
    }
}