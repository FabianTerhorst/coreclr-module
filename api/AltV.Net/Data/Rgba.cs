using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rgba : IEquatable<Rgba>
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

        public static bool operator ==(Rgba rgba1, Rgba rgba2)
        {
            return rgba1.R == rgba2.R && rgba1.G == rgba2.G && rgba1.B == rgba2.B && rgba1.A == rgba2.A;
        }

        public static bool operator !=(Rgba rgba1, Rgba rgba2)
        {
            return rgba1.R != rgba2.R || rgba1.G != rgba2.G || rgba1.B != rgba2.B || rgba1.A != rgba2.A;
        }

        public override bool Equals(object obj)
        {
            return obj is Rgba other && Equals(other);
        }

        public bool Equals(Rgba other)
        {
            return R == other.R && G == other.G && B == other.B && A == other.A;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = R.GetHashCode();
                hashCode = (hashCode * 397) ^ G.GetHashCode();
                hashCode = (hashCode * 397) ^ B.GetHashCode();
                hashCode = (hashCode * 397) ^ A.GetHashCode();
                return hashCode;
            }
        }
    }
}