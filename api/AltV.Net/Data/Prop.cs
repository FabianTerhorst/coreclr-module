using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Prop : IEquatable<Prop>
    {
        public Prop(ushort drawable, byte texture)
        {
            Drawable = drawable;
            Texture = texture;
        }

        public ushort Drawable;
        public byte Texture;

        public override string ToString()
        {
            return $"Prop(drawable: {Drawable}, texture: {Texture})";
        }

        public override bool Equals(object obj)
        {
            return obj is Prop other && Equals(other);
        }

        public bool Equals(Prop other)
        {
            return Drawable.Equals(other.Drawable) && Texture.Equals(other.Texture);
        }

        public override int GetHashCode() => HashCode.Combine(Drawable.GetHashCode(), Texture.GetHashCode());
    }
}