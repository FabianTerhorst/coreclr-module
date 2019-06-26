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
        
        public MValue[] ToArrayAndFree()
        {
            var value = data;
            var values = new MValue[Size];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = Marshal.PtrToStructure<MValue>(value);
                value += MValue.Size;
            }
            
            AltNative.FreeMValueArray(ref this);

            Size = 0;

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
        
        public string[] ToArrayAndFree()
        {
            var value = data;
            var values = new string[size];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = Marshal.PtrToStructure<StringView>(value).Text;
                value += StringView.Size;
            }
            
            AltNative.FreeStringViewArray(ref this);
            
            size = 0;

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

    [StructLayout(LayoutKind.Sequential)]
    public struct UIntArray
    {
        public IntPtr data; // Array of uint's
        public ulong size;
        public ulong capacity;

        private static readonly int UInt32Size = Marshal.SizeOf<uint>(); //TODO: check if 4

        public static UIntArray Nil = new UIntArray
        {
            data = IntPtr.Zero,
            size = 0,
            capacity = 0
        };

        public uint[] ToArrayAndFree()
        {
            var value = data;
            var values = new uint[size];
            var buffer = new byte[4];
            //TODO:check if read of 4 is possible (UInt32Size)
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = ReadUInt32(buffer, data, 0);
                value += UInt32Size;
            }

            AltNative.FreeUIntArray(ref this);
            
            size = 0;

            return values;
        }

        /// <summary>
        /// Reads a 32-bit unsigned integer from unmanaged memory.
        /// </summary>
        /// <param name="buffer">Buffer to cache</param>
        /// <param name="ptr">The base address in unmanaged memory from which to read.</param>
        /// <param name="ofs">An additional byte offset, added to the ptr parameter before reading.</param>
        /// <returns>The 32-bit unsigned integer read from the ptr parameter.</returns>
        //[CLSCompliant(false)]
        public static uint ReadUInt32(byte[] buffer, IntPtr ptr, int ofs)
        {
            Marshal.Copy(new IntPtr(ptr.ToInt32() + ofs), buffer, 0, 4);
            return BitConverter.ToUInt32(buffer, 0);
        }
    }
}