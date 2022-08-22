using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class ShortSerializer : MValueSerializerBase<short>
{
    public ShortSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override short Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => (short) (mValueConst.GetBool() ? 1 : 0),
            MValueType.Int => (short) mValueConst.GetInt(),
            MValueType.Uint => (short) mValueConst.GetUint(),
            MValueType.Double => (short) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "short")
        };
    }
    
    public override MValueConst Serialize(short value)
    {
        _core.CreateMValueInt(out var mValue, value);
        return mValue;
    }

    public override short DeserializeFromString(string value)
    {
        return short.Parse(value);
    }

    public override string SerializeToString(short value)
    {
        return value.ToString();
    }
}