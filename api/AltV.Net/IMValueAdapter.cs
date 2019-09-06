namespace AltV.Net
{
    public interface IMValueAdapter<T> : IMValueBaseAdapter
    {
        new T FromMValue(IMValueReader reader);

        void ToMValue(T value, IMValueWriter writer);
    }
}