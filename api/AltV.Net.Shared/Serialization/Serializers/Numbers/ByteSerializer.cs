using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class ByteSerializer : MValueSerializerBase<byte>
{
    public ByteSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override byte Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => (byte) (mValueConst.GetBool() ? 1 : 0),
            MValueType.Int => (byte) mValueConst.GetInt(),
            MValueType.Uint => (byte) mValueConst.GetUint(),
            MValueType.Double => (byte) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "int")
        };
    }
    
    public override MValueConst Serialize(byte value)
    {
        _core.CreateMValueUInt(out var mValue, value);
        return mValue;
    }

    public override byte DeserializeFromString(string value)
    {
        return byte.Parse(value);
    }

    public override string SerializeToString(byte value)
    {
        return value.ToString();
    }
}