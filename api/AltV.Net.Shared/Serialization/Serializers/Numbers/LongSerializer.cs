using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class LongSerializer : MValueSerializerBase<long>
{
    public LongSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override long Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => mValueConst.GetBool() ? 1 : 0,
            MValueConst.Type.Int => (long) mValueConst.GetInt(),
            MValueConst.Type.Uint => (long) mValueConst.GetUint(),
            MValueConst.Type.Double => (long) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
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