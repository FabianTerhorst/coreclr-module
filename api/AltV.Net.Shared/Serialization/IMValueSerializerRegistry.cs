namespace AltV.Net.Shared.Serialization;

public interface IMValueSerializerRegistry
{
    IMValueSerializer GetSerializer(Type valueType);
    IMValueSerializer<T> GetSerializer<T>();
    void RegisterSerializationProvider(IMValueSerializationProvider serializationProvider);
    void RegisterSerializer(Type type, IMValueSerializer serializer);
}