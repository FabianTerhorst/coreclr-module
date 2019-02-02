using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StringView
    {
        public static StringView Empty = new StringView
        {
            data = IntPtr.Zero,
            size = 0
        };
        
        internal static readonly int Size = Marshal.SizeOf<StringView>();

        // Never free this pointer, its an reference to the internal alt-v server char pointer
        private IntPtr data;

        private ulong size;
        //private string _text;

        //public string Text => _text ?? (_text = Marshal.PtrToStringAnsi(data));
        public string Text => Marshal.PtrToStringAnsi(data, (int) size);
    }
}