using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Exceptions;

namespace AltV.Net.Shared.Serialization.Serializers
{
    public class DictionarySerializer<TKey, TValue> : MValueSerializerBase<Dictionary<TKey, TValue>>
    {
        private readonly IMValueSerializer<TKey> _keySerializer;
        private readonly IMValueSerializer<TValue> _valueSerializer;

        public DictionarySerializer(ISharedCore core) : base(core)
        {
            _keySerializer = _core.SerializerRegistry.GetSerializer<TKey>();
            _valueSerializer = _core.SerializerRegistry.GetSerializer<TValue>();
        }

        public override Dictionary<TKey, TValue> Deserialize(IMValueConst mValueConst)
        {
            if (mValueConst.type != MValueType.Dict) throw new CannotConvertTypeException(mValueConst.type, $"Dictionary<string, {typeof(TValue).Name}>");
            return mValueConst.GetDictionary().ToDictionary(
                e => _keySerializer.DeserializeFromString(e.Key),
                e => _valueSerializer.Deserialize(e.Value)
            );
        }

        public override MValueConst Serialize(Dictionary<TKey, TValue> value)
        {
            _core.CreateMValueDict(
                out var mValue,
                value.Keys.Select(e => _keySerializer.SerializeToString(e)).ToArray(),
                value.Values.Select(v => _valueSerializer.Serialize(v)).ToArray(),
                (ulong) value.Count
            );
            return mValue;
        }

    }
}