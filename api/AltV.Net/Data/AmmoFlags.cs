using System.Runtime.InteropServices;

namespace AltV.Net.Data;

[StructLayout(LayoutKind.Sequential)]
internal readonly struct AmmoFlagsInternal
{
    [MarshalAs(UnmanagedType.I1)]
    private readonly bool InfiniteAmmo;
    [MarshalAs(UnmanagedType.I1)]
    private readonly bool AddSmokeOnExplosion;
    [MarshalAs(UnmanagedType.I1)]
    private readonly bool Fuse;
    [MarshalAs(UnmanagedType.I1)]
    private readonly bool FixedAfterExplosion;

    public AmmoFlags ToPublic()
    {
        return new AmmoFlags
        {
            InfiniteAmmo = InfiniteAmmo,
            AddSmokeOnExplosion = AddSmokeOnExplosion,
            Fuse = Fuse,
            FixedAfterExplosion = FixedAfterExplosion
        };
    }
}

public struct AmmoFlags
{
    public bool InfiniteAmmo;
    public bool AddSmokeOnExplosion;
    public bool Fuse;
    public bool FixedAfterExplosion;
}