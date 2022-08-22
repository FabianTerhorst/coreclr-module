using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class DecimalSerializer : MValueSerializerBase<decimal>
{
    public DecimalSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override decimal Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => (decimal) (mValueConst.GetBool() ? 1 : 0),
            MValueConst.Type.Int => (decimal) mValueConst.GetInt(),
            MValueConst.Type.Uint => (decimal) mValueConst.GetUint(),
            MValueConst.Type.Double => (decimal) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
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