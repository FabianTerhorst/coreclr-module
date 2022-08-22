using AltV.Net.Elements.Args;

namespace AltV.Net.Shared.Serialization.Serializers
{
    public class NullableSerializer<T> : MValueSerializerBase<T?> where T : struct
    {
        private readonly IMValueSerializer<T> _valueSerializer;
        
        public NullableSerializer(ISharedCore core) : base(core)
        {
            _valueSerializer = core.SerializerRegistry.GetSerializer<T>();
        }

        public override MValueConst Serialize(T? value)
        {
            if (value == null) return MValueConst.Nil;
            return _valueSerializer.Serialize(value);
        }
        
        public override T? Deserialize(MValueConst value)
        {
            if (value.type is MValueConst.Type.Nil or MValueConst.Type.None) return null;
            return _valueSerializer.Deserialize(value);
        }
    }
}