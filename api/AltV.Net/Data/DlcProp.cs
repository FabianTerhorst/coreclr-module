using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DlcProp : IEquatable<DlcProp>
    {
        public DlcProp(uint dlc, ushort drawable, byte texture)
        {
            Dlc = dlc;
            Drawable = drawable;
            Texture = texture;
        }

        public uint Dlc;
        public ushort Drawable;
        public byte Texture;

        public override string ToString()
        {
            return $"DlcProp(dlc: {Dlc}, drawable: {Drawable}, texture: {Texture})";
        }

        public override bool Equals(object obj)
        {
            return obj is DlcProp other && Equals(other);
        }

        public bool Equals(DlcProp other)
        {
            return Dlc.Equals(other.Dlc) && Drawable.Equals(other.Drawable) && Texture.Equals(other.Texture);
        }

        public override int GetHashCode() => HashCode.Combine(Dlc.GetHashCode(), Drawable.GetHashCode(), Texture.GetHashCode());
    }
}