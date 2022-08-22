using AltV.Net.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers
{
    public class ObjectSerializer : MValueSerializerBase<object>
    {
        public ObjectSerializer(ISharedCore core) : base(core)
        {
        }

        public override MValueConst Serialize(object value)
        {
            var type = value.GetType();
            return _core.SerializerRegistry.GetSerializer(type).Serialize(value);
        }

        public override object Deserialize(MValueConst mValueConst)
        {
            return mValueConst.type switch
            {

                MValueConst.Type.None => null,
                MValueConst.Type.Nil => null,
                MValueConst.Type.Bool => mValueConst.GetBool(),
                MValueConst.Type.Int => mValueConst.GetInt(),
                MValueConst.Type.Uint => mValueConst.GetUint(),
                MValueConst.Type.Double => mValueConst.GetDouble(),
                MValueConst.Type.String => mValueConst.GetString(),
                MValueConst.Type.List => mValueConst.GetList(),
                MValueConst.Type.Dict => mValueConst.GetDictionary(),
                MValueConst.Type.Vector3 => mValueConst.GetVector3(),
                MValueConst.Type.ByteArray => mValueConst.GetByteArray(),
                // MValueConst.Type.Vector2 => mValueConst.GetVector2(), // todo
                _ => throw new CannotConvertTypeException(mValueConst.type, "object")
            };
        }

        public override string SerializeToString(object value)
        {
            var type = value.GetType();
            return _core.SerializerRegistry.GetSerializer(type).SerializeToString(value);
        }

        public override object DeserializeFromString(string value)
        {
            return value;
        }
    }
}