using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class LongSerializer : MValueSerializerBase<long>
{
    public LongSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override long Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => mValueConst.GetBool() ? 1 : 0,
            MValueType.Int => (long) mValueConst.GetInt(),
            MValueType.Uint => (long) mValueConst.GetUint(),
            MValueType.Double => (long) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "long")
        };
    }
    
    public override MValueConst Serialize(long value)
    {
        _core.CreateMValueInt(out var mValue, value);
        return mValue;
    }

    public override long DeserializeFromString(string value)
    {
        return long.Parse(value);
    }

    public override string SerializeToString(long value)
    {
        return value.ToString();
    }
}