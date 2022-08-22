using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class UIntSerializer : MValueSerializerBase<uint>
{
    public UIntSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override uint Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => mValueConst.GetBool() ? 1u : 0u,
            MValueType.Int => (uint) mValueConst.GetInt(),
            MValueType.Uint => (uint) mValueConst.GetUint(),
            MValueType.Double => (uint) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
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