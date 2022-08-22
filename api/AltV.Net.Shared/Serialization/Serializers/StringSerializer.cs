using System.Globalization;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers;

public class StringSerializer : MValueSerializerBase<string>
{
    public StringSerializer(ISharedCore core) : base(core)
    {
    }
    
    public override string Deserialize(MValueConst mValueConst)
    {
        return mValueConst.type switch
        {
            MValueConst.Type.None => null,
            MValueConst.Type.Nil => null,
            MValueConst.Type.Bool => mValueConst.GetBool().ToString(),
            MValueConst.Type.Int => mValueConst.GetInt().ToString(),
            MValueConst.Type.Uint => mValueConst.GetUint().ToString(),
            MValueConst.Type.Double => mValueConst.GetDouble().ToString(CultureInfo.InvariantCulture),
            MValueConst.Type.String => mValueConst.GetString(),
            MValueConst.Type.Vector3 => mValueConst.GetVector3().ToString(),
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