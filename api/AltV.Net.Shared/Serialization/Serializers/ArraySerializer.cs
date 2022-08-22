namespace AltV.Net.Shared.Serialization.Serializers
{
    public class ArraySerializer<TItem> : EnumerableSerializerBase<TItem[], TItem>
    {
        public ArraySerializer(ISharedCore core) : base(core)
        {
        }

        protected override TItem[] EnumerableToType(IEnumerable<TItem> enumerable)
        {
            return enumerable.ToArray();
        }
        
        protected override IEnumerable<TItem> TypeToEnumerable(TItem[] value)
        {
            return value;
        }
    }
}