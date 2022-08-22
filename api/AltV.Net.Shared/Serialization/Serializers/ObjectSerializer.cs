using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
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

        public override object Deserialize(IMValueConst mValueConst)
        {
            return mValueConst.type switch
            {

                MValueType.None => null,
                MValueType.Nil => null,
                MValueType.Bool => mValueConst.GetBool(),
                MValueType.Int => mValueConst.GetInt(),
                MValueType.Uint => mValueConst.GetUint(),
                MValueType.Double => mValueConst.GetDouble(),
                MValueType.String => mValueConst.GetString(),
                MValueType.List => mValueConst.GetList(),
                MValueType.Dict => mValueConst.GetDictionary(),
                MValueType.Vector3 => mValueConst.GetVector3(),
                MValueType.ByteArray => mValueConst.GetByteArray(),
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