using System.Runtime.InteropServices;

namespace AltV.Net.Data;

[StructLayout(LayoutKind.Sequential)]
internal readonly struct DecorationInternal
{
    private readonly uint Collection;
    private readonly uint Overlay;
    private readonly byte Count;

    public Decoration ToPublic()
    {
        return new Decoration
        {
            Collection = Collection,
            Overlay = Overlay,
            Count = Count
        };
    }
}

public struct Decoration
{
    public uint Collection;
    public uint Overlay;
    public byte Count;
}