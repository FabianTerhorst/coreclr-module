using System.Runtime.InteropServices;

namespace AltV.Net.Data;

[StructLayout(LayoutKind.Sequential)]
internal readonly struct DecorationInternal
{
    private readonly bool Collection;
    private readonly bool Overlay;

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
    public bool Collection;
    public bool Overlay;
}