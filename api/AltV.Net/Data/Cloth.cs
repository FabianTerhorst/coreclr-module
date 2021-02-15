using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Cloth : IEquatable<Cloth>
    {
        public Cloth(ushort drawable, byte texture, byte palette)
        {
            Drawable = drawable;
            Texture = texture;
            Palette = palette;
        }

        public ushort Drawable;
        public byte Texture;
        public byte Palette;

        public override string ToString()
        {
            return $"Cloth(drawable: {Drawable}, texture: {Texture}, palette: {Palette})";
        }

        public override bool Equals(object obj)
        {
            return obj is Cloth other && Equals(other);
        }

        public bool Equals(Cloth other)
        {
            return Drawable.Equals(other.Drawable) && Texture.Equals(other.Texture) && Palette.Equals(other.Palette);
        }

        public override int GetHashCode() => HashCode.Combine(Drawable.GetHashCode(), Texture.GetHashCode(), Palette.GetHashCode());
    }
}