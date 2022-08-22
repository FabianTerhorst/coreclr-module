using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class ShortSerializer : MValueSerializerBase<short>
{
    public ShortSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override short Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => (short) (mValueConst.GetBool() ? 1 : 0),
            MValueConst.Type.Int => (short) mValueConst.GetInt(),
            MValueConst.Type.Uint => (short) mValueConst.GetUint(),
            MValueConst.Type.Double => (short) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
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