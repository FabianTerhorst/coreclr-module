using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class SByteSerializer : MValueSerializerBase<sbyte>
{
    public SByteSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override sbyte Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => (sbyte) (mValueConst.GetBool() ? 1 : 0),
            MValueConst.Type.Int => (sbyte) mValueConst.GetInt(),
            MValueConst.Type.Uint => (sbyte) mValueConst.GetUint(),
            MValueConst.Type.Double => (sbyte) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
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