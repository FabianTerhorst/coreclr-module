using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct Array
        {
            public IntPtr data;// Array of MValue's
            public ulong size;
            public ulong capacity;
        }

        internal static class MValueArray
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern Array MValueArray_Create();
            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void MValueArray_Push(Alt.Array array, IntPtr value);
        }
    }
}