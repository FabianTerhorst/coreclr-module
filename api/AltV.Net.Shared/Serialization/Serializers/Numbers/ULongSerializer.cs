using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class ULongSerializer : MValueSerializerBase<ulong>
{
    public ULongSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override ulong Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => mValueConst.GetBool() ? 1ul : 0ul,
            MValueType.Int => (ulong) mValueConst.GetInt(),
            MValueType.Uint => (ulong) mValueConst.GetUint(),
            MValueType.Double => (ulong) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
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