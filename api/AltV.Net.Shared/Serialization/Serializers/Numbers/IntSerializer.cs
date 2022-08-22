using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class IntSerializer : MValueSerializerBase<int>
{
    public IntSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override int Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => default,
            MValueType.Nil => default,
            MValueType.Bool => mValueConst.GetBool() ? 1 : 0,
            MValueType.Int => (int) mValueConst.GetInt(),
            MValueType.Uint => (int) mValueConst.GetUint(),
            MValueType.Double => (int) mValueConst.GetDouble(),
            MValueType.String => DeserializeFromString(mValueConst.GetString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "int")
        };
    }
    
    public override MValueConst Serialize(int value)
    {
        _core.CreateMValueInt(out var mValue, value);
        return mValue;
    }

    public override int DeserializeFromString(string value)
    {
        return int.Parse(value);
    }

    public override string SerializeToString(int value)
    {
        return value.ToString();
    }
}