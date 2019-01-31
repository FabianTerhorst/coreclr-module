using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AltV.Net.Native
{
    internal static partial class Alt
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct StringView
        {
            public static StringView Empty = new StringView
            {
                data = IntPtr.Zero,
                size = 0
            };

            public IntPtr data;
            public ulong size;
            private string _text;
            public string text
            {
                get
                {
                    if (this._text == null)
                    {
                        this._text = Marshal.PtrToStringAnsi(data);
                    }
                    return this._text;
                }
            }
        }
    }
}