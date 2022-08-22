using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers.Numbers;

class IntSerializer : MValueSerializerBase<int>
{
    public IntSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override int Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => default,
            MValueConst.Type.Nil => default,
            MValueConst.Type.Bool => mValueConst.GetBool() ? 1 : 0,
            MValueConst.Type.Int => (int) mValueConst.GetInt(),
            MValueConst.Type.Uint => (int) mValueConst.GetUint(),
            MValueConst.Type.Double => (int) mValueConst.GetDouble(),
            MValueConst.Type.String => DeserializeFromString(mValueConst.GetString()),
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