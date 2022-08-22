namespace AltV.Net.Shared.Serialization;

public interface IMValueSerializationProvider
{
    IMValueSerializer GetSerializer(ISharedCore core, Type valueType);
}