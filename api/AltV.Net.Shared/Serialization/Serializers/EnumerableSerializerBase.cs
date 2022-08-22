using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Args;

namespace AltV.Net.Shared.Serialization.Serializers
{
    public abstract class EnumerableSerializerBase<TValue, TItem> : MValueSerializerBase<TValue>
    {
        private readonly IMValueSerializer<TItem> _itemSerializer;

        public EnumerableSerializerBase(ISharedCore core) : base(core)
        {
            _itemSerializer = core.SerializerRegistry.GetSerializer<TItem>();
        }

        public override TValue Deserialize(IMValueConst mValueConst)
        {
            switch (mValueConst.type)
            {
                case MValueType.List:
                {
                    var list = mValueConst.GetList();
                    return EnumerableToType(list.Select(e => _itemSerializer.Deserialize(e)));
                }
                default:
                    throw new Exception("Invalid list type");
            }
        }

        public override MValueConst Serialize(TValue value)
        {
            var list = new List<MValueConst>();
            
            foreach (var item in TypeToEnumerable(value))
            {
                list.Add(_itemSerializer.Serialize(item));
            }

            _core.CreateMValueList(out var mValue, list.ToArray(), (ulong) list.Count);
            return mValue;
        }

        protected abstract TValue EnumerableToType(IEnumerable<TItem> enumerable);
        protected abstract IEnumerable<TItem> TypeToEnumerable(TValue value);
    }
}