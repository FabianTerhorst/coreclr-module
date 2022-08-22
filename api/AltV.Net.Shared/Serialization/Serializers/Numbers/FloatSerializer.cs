using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class FloatSerializer : MValueSerializerBase<float>
{
    public FloatSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override float Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => (float) (mValueConst.GetBool() ? 1 : 0),
            MValueConst.Type.Int => (float) mValueConst.GetInt(),
            MValueConst.Type.Uint => (float) mValueConst.GetUint(),
            MValueConst.Type.Double => (float) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
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