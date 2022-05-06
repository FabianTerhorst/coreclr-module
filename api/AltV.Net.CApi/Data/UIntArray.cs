using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIntArray
    {
        public IntPtr data; // Array of uint's
        public ulong size;
        public ulong capacity;

        public static readonly int UInt32Size = Marshal.SizeOf<uint>(); //TODO: check if 4

        public static UIntArray Nil = new()
        {
            data = IntPtr.Zero,
            size = 0,
            capacity = 0
        };

        public uint[] ToArray()
        {
            var value = data;
            var values = new uint[size];
            var buffer = new byte[4];
            //TODO:check if read of 4 is possible (UInt32Size)
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = ReadUInt32(buffer, value);
                value += UInt32Size;
            }

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
        public static uint ReadUInt32(byte[] buffer, IntPtr ptr)
        {
            Marshal.Copy(ptr, buffer, 0, 4);
            return BitConverter.ToUInt32(buffer, 0);
        }
    }
}