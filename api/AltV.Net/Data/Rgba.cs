using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rgba
    {
        public static Rgba Zero = new Rgba
        {
            R = 0,
            G = 0,
            B = 0,
            A = 0
        };

        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Rgba(byte r, byte g, byte b, byte a)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        public override string ToString()
        {
            return $"RGBA(r: {R}, g: {G}, b: {B}, a: {A})";
        }
    }
}