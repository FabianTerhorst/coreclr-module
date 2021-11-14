using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HeadOverlay : IEquatable<HeadOverlay>
    {
        public static HeadOverlay Zero = new(0, 0, 0, 0, 0);

        public byte Index;
        public float Opacity;
        public byte ColorType;
        public byte ColorIndex;
        public byte SecondColorIndex;

        public HeadOverlay(byte index, float opacity, byte colorType, byte colorIndex, byte secondColorIndex)
        {
            Index = index;
            Opacity = opacity;
            ColorType = colorType;
            ColorIndex = colorIndex;
            SecondColorIndex = secondColorIndex;
        }

        public override string ToString()
        {
            return $"HeadOverlay(index: {Index}, opacity: {Opacity}, colorType: {ColorType}, colorIndex: {ColorIndex}, secondColorIndex: {SecondColorIndex})";
        }

        public override bool Equals(object obj)
        {
            return obj is HeadOverlay other && Equals(other);
        }

        public bool Equals(HeadOverlay other)
        {
            return Index.Equals(other.Index) && Opacity.Equals(other.Opacity) && ColorType.Equals(other.ColorType) && ColorIndex.Equals(other.ColorIndex) && SecondColorIndex.Equals(other.SecondColorIndex);
        }

        public override int GetHashCode() => HashCode.Combine(Index.GetHashCode(), Opacity.GetHashCode(), ColorType.GetHashCode(), ColorIndex.GetHashCode(), SecondColorIndex.GetHashCode());
    }
}