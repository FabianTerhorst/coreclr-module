using System.Drawing;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rgba
    {
        public static implicit operator Color(Rgba rgba)
        {
            return Color.FromArgb(rgba.A, rgba.R, rgba.G, rgba.B);
        }

        public static implicit operator Rgba(Color color)
        {
            return new Rgba
            {
                R = color.R,
                G = color.G,
                B = color.B,
                A = color.A
            };
        }

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
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public override string ToString()
        {
            return $"RGBA(r: {R}, g: {G}, b: {B}, a: {A})";
        }
    }
}