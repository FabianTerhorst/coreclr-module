using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Array
    {
        public IntPtr data;
        public ulong size;
        public ulong capacity;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MValueArray
    {
        public IntPtr data; // Array of MValue's
        public ulong size;
        public ulong capacity;
        
        public static MValueArray Nil = new MValueArray
        {
            data = IntPtr.Zero,
            size = 0,
            capacity = 0
        };

        public MValue[] ToArray()
        {
            var value = data;
            var values = new MValue[size];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = Marshal.PtrToStructure<MValue>(value);
                value += MValue.Size;
            }

            return values;
        }
    }

    //TODO: remove these in module
    /*internal static class MValueArray
    {
        [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
        internal static extern Array MValueArray_Create();

        [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
        internal static extern void MValueArray_Push(Array array, IntPtr value);
    }*/
}