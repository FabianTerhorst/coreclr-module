using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MValueArray
    {
        internal IntPtr data; // Array of MValue's
        public ulong Size;
        private ulong capacity;

        public static MValueArray Nil = new MValueArray
        {
            data = IntPtr.Zero,
            Size = 0,
            capacity = 0
        };

        public MValue[] ToArray()
        {
            var value = data;
            var values = new MValue[Size];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = Marshal.PtrToStructure<MValue>(value);
                value += MValue.Size;
            }

            return values;
        }

        public MValueArrayBuffer Reader()
        {
            return new MValueArrayBuffer(data, Size);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StringViewArray
    {
        public IntPtr data; // Array of StringView's
        public ulong size;
        public ulong capacity;

        public static StringViewArray Nil = new StringViewArray
        {
            data = IntPtr.Zero,
            size = 0,
            capacity = 0
        };

        public string[] ToArray()
        {
            var value = data;
            var values = new string[size];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = Marshal.PtrToStructure<StringView>(value).Text;
                value += StringView.Size;
            }

            return values;
        }

        /// <summary>
        /// Consumes and returns next string in the array
        /// </summary>
        /// <returns></returns>
        public string GetNext()
        {
            if (size == 0) return null;
            var value = Marshal.PtrToStructure<StringView>(data).Text;
            size--;
            data += StringView.Size;
            return value;
        }
        
        public void SkipValue()
        {
            if (size == 0) return;
            size--;
            data += StringView.Size;
        }
    }
}