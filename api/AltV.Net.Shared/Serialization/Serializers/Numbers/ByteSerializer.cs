using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class ByteSerializer : MValueSerializerBase<byte>
{
    public ByteSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override byte Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => (byte) (mValueConst.GetBool() ? 1 : 0),
            MValueConst.Type.Int => (byte) mValueConst.GetInt(),
            MValueConst.Type.Uint => (byte) mValueConst.GetUint(),
            MValueConst.Type.Double => (byte) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
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