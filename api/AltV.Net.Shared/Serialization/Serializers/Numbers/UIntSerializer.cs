using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class UIntSerializer : MValueSerializerBase<uint>
{
    public UIntSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override uint Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => mValueConst.GetBool() ? 1u : 0u,
            MValueConst.Type.Int => (uint) mValueConst.GetInt(),
            MValueConst.Type.Uint => (uint) mValueConst.GetUint(),
            MValueConst.Type.Double => (uint) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "int")
        };
    }
    
    public override MValueConst Serialize(uint value)
    {
        _core.CreateMValueUInt(out var mValue, value);
        return mValue;
    }

    public override uint DeserializeFromString(string value)
    {
        return uint.Parse(value);
    }

    public override string SerializeToString(uint value)
    {
        return value.ToString();
    }
}