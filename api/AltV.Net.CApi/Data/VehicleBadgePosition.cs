using System.Numerics;
using System.Runtime.InteropServices;

namespace AltV.Net.CApi.Data;

[StructLayout(LayoutKind.Sequential)]
public struct VehicleBadgePosition : IEquatable<VehicleBadgePosition>
{
    public VehicleBadgePosition(bool active, byte alpha, float size, short boneIndex, Vector3 offset, Vector3 direction, Vector3 side)
    {
        Active = active ? (byte)1 : (byte)0;
        Alpha = alpha;
        Size = size;
        BoneIndex = boneIndex;
        Offset = offset;
        Direction = direction;
        Side = side;
    }

    public byte Active { get; set; } = 0;
    public byte Alpha { get; set; } = 255;
    public float Size { get; set; } = 1f;
    public short BoneIndex { get; set; } = 0;
    public Vector3 Offset { get; set; } = new(0, 0, 0);
    public Vector3 Direction { get; set; } = new(0, 0, 0);
    public Vector3 Side { get; set; } = new(0, 0, 0);

    public bool Equals(VehicleBadgePosition other)
    {
        return Active == other.Active && Alpha == other.Alpha && Size.Equals(other.Size) && BoneIndex == other.BoneIndex && Offset.Equals(other.Offset) && Direction.Equals(other.Direction) && Side.Equals(other.Side);
    }

    public override bool Equals(object? obj)
    {
        return obj is VehicleBadgePosition other && Equals(other);
    }

    public override int GetHashCode() => HashCode.Combine(Active.GetHashCode(), Alpha.GetHashCode(), Size.GetHashCode(), BoneIndex.GetHashCode(), Offset.GetHashCode(), Direction.GetHashCode(), Side.GetHashCode());
}