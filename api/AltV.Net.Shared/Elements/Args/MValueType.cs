namespace AltV.Net.Shared.Elements.Args
{
    public enum MValueType : byte
    {
        None = 0,
        Nil = 1,
        Bool = 2,
        Int = 3,
        Uint = 4,
        Double = 5,
        String = 6,
        List = 7,
        Dict = 8,
        BaseObject = 9,
        Function = 10,
        Vector3 = 11,
        Rgba = 12,
        ByteArray = 13,
        Vector2 = 14,
    }
}