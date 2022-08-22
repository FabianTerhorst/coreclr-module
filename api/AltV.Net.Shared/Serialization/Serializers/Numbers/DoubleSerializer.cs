using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class DoubleSerializer : MValueSerializerBase<double>
{
    public DoubleSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override double Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => (double) (mValueConst.GetBool() ? 1 : 0),
            MValueType.Int => (double) mValueConst.GetInt(),
            MValueType.Uint => (double) mValueConst.GetUint(),
            MValueType.Double => (double) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "double")
        };
    }
    
    public override MValueConst Serialize(double value)
    {
        _core.CreateMValueDouble(out var mValue, value);
        return mValue;
    }

    public override double DeserializeFromString(string value)
    {
        return double.Parse(value);
    }

    public override string SerializeToString(double value)
    {
        return value.ToString();
    }
}