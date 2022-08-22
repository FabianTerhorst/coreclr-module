using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class SByteSerializer : MValueSerializerBase<sbyte>
{
    public SByteSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override sbyte Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => (sbyte) (mValueConst.GetBool() ? 1 : 0),
            MValueType.Int => (sbyte) mValueConst.GetInt(),
            MValueType.Uint => (sbyte) mValueConst.GetUint(),
            MValueType.Double => (sbyte) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "int")
        };
    }
    
    public override MValueConst Serialize(sbyte value)
    {
        _core.CreateMValueInt(out var mValue, value);
        return mValue;
    }

    public override sbyte DeserializeFromString(string value)
    {
        return sbyte.Parse(value);
    }

    public override string SerializeToString(sbyte value)
    {
        return value.ToString();
    }
}