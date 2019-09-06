namespace AltV.Net
{
    public interface IMValueSerializer<in T>
    {
        void ToMValue(T value, IMValueWriter writer);
    }
}