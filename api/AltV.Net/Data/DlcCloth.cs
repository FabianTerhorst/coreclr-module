using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DlcCloth : IEquatable<DlcCloth>
    {
        public DlcCloth(uint dlc, ushort drawable, byte texture, byte palette)
        {
            Dlc = dlc;
            Drawable = drawable;
            Texture = texture;
            Palette = palette;
        }

        public uint Dlc;
        public ushort Drawable;
        public byte Texture;
        public byte Palette;

        public override string ToString()
        {
            return $"DlcCloth(dlc: {Dlc}, drawable: {Drawable}, texture: {Texture}, palette: {Palette})";
        }

        public override bool Equals(object obj)
        {
            return obj is DlcCloth other && Equals(other);
        }

        public bool Equals(DlcCloth other)
        {
            return Dlc.Equals(other.Dlc) && Drawable.Equals(other.Drawable) && Texture.Equals(other.Texture) && Palette.Equals(other.Palette);
        }

        public override int GetHashCode() => HashCode.Combine(Dlc.GetHashCode(), Drawable.GetHashCode(), Texture.GetHashCode(), Palette.GetHashCode());
    }
}