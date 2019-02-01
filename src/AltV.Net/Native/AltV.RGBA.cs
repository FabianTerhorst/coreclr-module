using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RGBA
    {
        public static RGBA Zero = new RGBA
        {
            r = 0,
            g = 0,
            b = 0,
            a = 0
        };

        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public RGBA(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}