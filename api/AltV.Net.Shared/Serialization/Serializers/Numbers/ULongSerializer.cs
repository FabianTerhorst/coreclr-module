using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class ULongSerializer : MValueSerializerBase<ulong>
{
    public ULongSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override ulong Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => mValueConst.GetBool() ? 1ul : 0ul,
            MValueConst.Type.Int => (ulong) mValueConst.GetInt(),
            MValueConst.Type.Uint => (ulong) mValueConst.GetUint(),
            MValueConst.Type.Double => (ulong) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "ulong")
        };
    }
    
    public override MValueConst Serialize(ulong value)
    {
        _core.CreateMValueUInt(out var mValue, value);
        return mValue;
    }

    public override ulong DeserializeFromString(string value)
    {
        return ulong.Parse(value);
    }

    public override string SerializeToString(ulong value)
    {
        return value.ToString();
    }
}