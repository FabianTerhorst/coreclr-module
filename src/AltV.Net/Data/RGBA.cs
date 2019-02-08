using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rgba
    {
        public static Rgba Zero = new Rgba
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

        public Rgba(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public override string ToString()
        {
            return $"RGBA(r: {r}, g: {g}, b: {b}, a: {a})";
        }
    }
}