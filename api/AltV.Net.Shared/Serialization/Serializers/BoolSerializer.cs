using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers;

class BoolSerializer : MValueSerializerBase<bool>
{
    public BoolSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override bool Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => false,
            MValueConst.Type.Nil => false,
            MValueConst.Type.Bool => mValueConst.GetBool(),
            MValueConst.Type.Int => mValueConst.GetInt() != 0,
            MValueConst.Type.Uint => mValueConst.GetUint() != 0,
            MValueConst.Type.Double => mValueConst.GetDouble() != 0,
            MValueConst.Type.String => DeserializeFromString(mValueConst.ToString()),
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