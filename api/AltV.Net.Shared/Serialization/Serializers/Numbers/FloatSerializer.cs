using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class FloatSerializer : MValueSerializerBase<float>
{
    public FloatSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override float Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => (float) (mValueConst.GetBool() ? 1 : 0),
            MValueType.Int => (float) mValueConst.GetInt(),
            MValueType.Uint => (float) mValueConst.GetUint(),
            MValueType.Double => (float) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "float")
        };
    }
    
    public override MValueConst Serialize(float value)
    {
        _core.CreateMValueDouble(out var mValue, value);
        return mValue;
    }

    public override float DeserializeFromString(string value)
    {
        return float.Parse(value);
    }

    public override string SerializeToString(float value)
    {
        return value.ToString();
    }
}