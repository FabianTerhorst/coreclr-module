namespace AltV.Net
{
    public interface IMValueAdapter<T> : IMValueBaseAdapter
    {
        new T FromMValue(MValueReader reader);

        void ToMValue(T value, MValueWriter writer);
    }
}