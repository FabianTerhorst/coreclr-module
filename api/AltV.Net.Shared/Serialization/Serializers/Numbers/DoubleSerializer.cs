using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class DoubleSerializer : MValueSerializerBase<double>
{
    public DoubleSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override double Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => (double) (mValueConst.GetBool() ? 1 : 0),
            MValueConst.Type.Int => (double) mValueConst.GetInt(),
            MValueConst.Type.Uint => (double) mValueConst.GetUint(),
            MValueConst.Type.Double => (double) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
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