using System.Numerics;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers;

class Vector2Serializer : MValueSerializerBase<Vector2>
{
    public Vector2Serializer(ISharedCore core) : base(core)
    {
    }
    
    public override Vector2 Deserialize(MValueConst mValueConst)
    {
        switch (mValueConst.type)
        {
            case MValueConst.Type.None:
            case MValueConst.Type.Nil:
                return Vector2.Zero;
            
            case MValueConst.Type.List:
            {
                var list = mValueConst.GetList();
                if (list.Length < 2)
                    throw new Exception("Vector2 must be a list of 2 numbers");
                var x = _core.SerializerRegistry.GetSerializer<float>().Deserialize(list[0]);
                var y = _core.SerializerRegistry.GetSerializer<float>().Deserialize(list[1]);
                return new Vector2(x, y);
            }

            case MValueConst.Type.Dict:
            {
                var dict = mValueConst.GetDictionary();
                
                if (dict.ContainsKey("x") && dict.ContainsKey("y"))
                {
                    var x = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["x"]);
                    var y = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["y"]);
                    return new Vector2(x, y);
                }
                
                if (dict.ContainsKey("X") && dict.ContainsKey("Y"))
                {
                    var x = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["X"]);
                    var y = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["Y"]);
                    return new Vector2(x, y);
                }
                
                throw new Exception("Vector2 must be a dictionary with keys 'x' and 'y' or 'X' and 'Y'");
            }
                
            default:
                throw new CannotConvertTypeException(mValueConst.type, "Vector2");
        }
    }
    
    public override MValueConst Serialize(Vector2 value)
    {
        _core.CreateMValueVector2(out var mValue, value);
        return mValue;
    }
}