using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class UShortSerializer : MValueSerializerBase<ushort>
{
    public UShortSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override ushort Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => (ushort) (mValueConst.GetBool() ? 1 : 0),
            MValueConst.Type.Int => (ushort) mValueConst.GetInt(),
            MValueConst.Type.Uint => (ushort) mValueConst.GetUint(),
            MValueConst.Type.Double => (ushort) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
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