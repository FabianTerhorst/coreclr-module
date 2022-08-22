using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers;

class BoolSerializer : MValueSerializerBase<bool>
{
    public BoolSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override bool Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => false,
            MValueType.Nil => false,
            MValueType.Bool => mValueConst.GetBool(),
            MValueType.Int => mValueConst.GetInt() != 0,
            MValueType.Uint => mValueConst.GetUint() != 0,
            MValueType.Double => mValueConst.GetDouble() != 0,
            MValueType.String => DeserializeFromString(mValueConst.ToString()),
            _ => throw new CannotConvertTypeException(mValueConst.type, "bool")
        };
    }
    
    public override MValueConst Serialize(bool value)
    {
        _core.CreateMValueBool(out var mValue, value);
        return mValue;
    }

    public override bool DeserializeFromString(string value)
    {
        return !string.IsNullOrEmpty(value) && value != "false";
    }

    public override string SerializeToString(bool value)
    {
        return value ? "true" : "false";
    }
}