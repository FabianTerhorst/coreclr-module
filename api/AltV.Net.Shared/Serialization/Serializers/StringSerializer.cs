using System.Globalization;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers;

public class StringSerializer : MValueSerializerBase<string>
{
    public StringSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override string Deserialize(IMValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueType.None => null,
            MValueType.Nil => null,
            MValueType.Bool => mValueConst.GetBool().ToString(),
            MValueType.Int => mValueConst.GetInt().ToString(),
            MValueType.Uint => mValueConst.GetUint().ToString(),
            MValueType.Double => mValueConst.GetDouble().ToString(CultureInfo.InvariantCulture),
            MValueType.String => mValueConst.GetString(),
            MValueType.Vector3 => mValueConst.GetVector3().ToString(),
            // MValueConst.Type.Vector2 => mValueConst.GetVector2().ToString(), // todo
            _ => throw new CannotConvertTypeException(mValueConst.type, "string")
        };
    }
    
    public override MValueConst Serialize(string value)
    {
        _core.CreateMValueString(out var mValue, value);
        return mValue;
    }

    public override string SerializeToString(string value)
    {
        return value;
    }

    public override string DeserializeFromString(string value)
    {
        return value;
    }
}