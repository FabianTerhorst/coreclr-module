using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;

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
        
        public override T? Deserialize(IMValueConst value)
        {
            if (value.type is MValueType.Nil or MValueType.None) return null;
            return _valueSerializer.Deserialize(value);
        }
    }
}