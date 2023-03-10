namespace AltV.Net.CApi.Generator;

public static class FnvHash
{
    private const ulong OffsetBasis = 14695981039346656037;
    public static ulong Generate(string str)
    {
        var hash = OffsetBasis;
        foreach (var c in str)
        {
            hash ^= c;
            hash += (hash << 1) + (hash << 4) + (hash << 5) + (hash << 7) + (hash << 8) + (hash << 40);
        }
        return hash;
    }
}