namespace AltV.Net
{
    public interface IMValueDeserializer<out T>
    {
        T FromMValue(IMValueReader reader);
    }
}