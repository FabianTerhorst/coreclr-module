using System.Runtime.InteropServices;

namespace AltV.Net.Data;

[StructLayout(LayoutKind.Sequential)]
internal readonly struct DecorationInternal
{
    private readonly uint Collection;
    private readonly uint Overlay;

    public Decoration ToPublic()
    {
        return new Decoration
        {
            Collection = Collection,
            Overlay = Overlay
        };
    }
}

public struct Decoration
{
    public uint Collection;
    public uint Overlay;
}