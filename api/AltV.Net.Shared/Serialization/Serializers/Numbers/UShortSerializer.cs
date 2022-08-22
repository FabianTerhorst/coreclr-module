using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class UShortSerializer : MValueSerializerBase<ushort>
{
    public UShortSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override ushort Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => (ushort) (mValueConst.GetBool() ? 1 : 0),
            MValueType.Int => (ushort) mValueConst.GetInt(),
            MValueType.Uint => (ushort) mValueConst.GetUint(),
            MValueType.Double => (ushort) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "ushort")
        };
    }
    
    public override MValueConst Serialize(ushort value)
    {
        _core.CreateMValueUInt(out var mValue, value);
        return mValue;
    }

    public override ushort DeserializeFromString(string value)
    {
        return ushort.Parse(value);
    }

    public override string SerializeToString(ushort value)
    {
        return value.ToString();
    }
}