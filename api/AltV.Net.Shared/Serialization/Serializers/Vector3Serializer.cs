using System.Numerics;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers;

class Vector3Serializer : MValueSerializerBase<Vector3>
{
    public Vector3Serializer(ISharedCore core) : base(core)
    {
    }
    
    public override Vector3 Deserialize(MValueConst mValueConst)
    {
        switch (mValueConst.type)
        {
            case MValueConst.Type.None:
            case MValueConst.Type.Nil:
                return Vector3.Zero;
            
            case MValueConst.Type.List:
            {
                var list = mValueConst.GetList();
                if (list.Length < 3)
                    throw new Exception("Vector3 must be a list of 3 numbers");
                var x = _core.SerializerRegistry.GetSerializer<float>().Deserialize(list[0]);
                var y = _core.SerializerRegistry.GetSerializer<float>().Deserialize(list[1]);
                var z = _core.SerializerRegistry.GetSerializer<float>().Deserialize(list[2]);
                return new Vector3(x, y, z);
            }

            case MValueConst.Type.Dict:
            {
                var dict = mValueConst.GetDictionary();
                
                if (dict.ContainsKey("x") && dict.ContainsKey("y") && dict.ContainsKey("z"))
                {
                    var x = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["x"]);
                    var y = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["y"]);
                    var z = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["z"]);
                    return new Vector3(x, y, z);
                }
                
                if (dict.ContainsKey("X") && dict.ContainsKey("Y") && dict.ContainsKey("Z"))
                {
                    var x = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["X"]);
                    var y = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["Y"]);
                    var z = _core.SerializerRegistry.GetSerializer<float>().Deserialize(dict["Z"]);
                    return new Vector3(x, y, z);
                }
                
                throw new Exception("Vector3 must be a dictionary with keys 'x', 'y', and 'z' or 'X', 'Y', and 'Z'");
            }
                
            default:
                throw new CannotConvertTypeException(mValueConst.type, "Vector3");
        }
    }
    
    public override MValueConst Serialize(Vector3 value)
    {
        _core.CreateMValueVector3(out var mValue, value);
        return mValue;
    }
}