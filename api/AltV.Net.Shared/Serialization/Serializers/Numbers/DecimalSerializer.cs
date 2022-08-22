using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class DecimalSerializer : MValueSerializerBase<decimal>
{
    public DecimalSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override decimal Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => (decimal) (mValueConst.GetBool() ? 1 : 0),
            MValueType.Int => (decimal) mValueConst.GetInt(),
            MValueType.Uint => (decimal) mValueConst.GetUint(),
            MValueType.Double => (decimal) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "decimal")
        };
    }
    
    public override MValueConst Serialize(decimal value)
    {
        _core.CreateMValueDouble(out var mValue, (double) value); // todo maybe preserve precision somehow
        return mValue;
    }

    public override decimal DeserializeFromString(string value)
    {
        return decimal.Parse(value);
    }

    public override string SerializeToString(decimal value)
    {
        return value.ToString();
    }
}