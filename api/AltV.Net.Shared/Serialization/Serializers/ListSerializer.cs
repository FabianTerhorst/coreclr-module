namespace AltV.Net.Shared.Serialization.Serializers
{
    public class ListSerializer<TItem> : EnumerableSerializerBase<List<TItem>, TItem>
    {
        public ListSerializer(ISharedCore core) : base(core)
        {
        }

        protected override List<TItem> EnumerableToType(IEnumerable<TItem> enumerable)
        {
            return enumerable.ToList();
        }
        
        protected override IEnumerable<TItem> TypeToEnumerable(List<TItem> value)
        {
            return value;
        }
    }
}