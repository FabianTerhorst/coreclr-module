using System.Reflection;
using AltV.Net.Shared.Serialization.Serializers;

namespace AltV.Net.Shared.Serialization.Providers;

public class CollectionsSerializationProvider : MValueSerializationProviderBase
{
    private static readonly Dictionary<Type, Type> SerializersTypes = new()
    {
        { typeof(Dictionary<,>), typeof(DictionarySerializer<,>) },
        { typeof(List<>), typeof(ListSerializer<>) },
    };
    
    public override IMValueSerializer GetSerializer(ISharedCore core, Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        
        var typeInfo = type.GetTypeInfo();
        if (typeInfo.IsGenericType && typeInfo.ContainsGenericParameters)
        {
            throw new ArgumentException($"Generic type {type} has unassigned type parameters.", nameof(type));
        }

        if (SerializersTypes.TryGetValue(type, out var serializerType))
        {
            return CreateSerializer(core, serializerType);
        }

        if (typeInfo.IsGenericType && !typeInfo.ContainsGenericParameters)
        {
            if (SerializersTypes.TryGetValue(type.GetGenericTypeDefinition(), out var serializerTypeDefinition))
            {
                return CreateGenericSerializer(core, serializerTypeDefinition, typeInfo.GetGenericArguments());
            }
        }
        
        if (type.IsArray)
        {
            var elementType = type.GetElementType();
            switch (type.GetArrayRank())
            {
                case 1:
                    var arraySerializerDefinition = typeof(ArraySerializer<>);
                    return CreateGenericSerializer(core, arraySerializerDefinition, new [] { elementType });
                default:
                    throw new Exception($"Array rank {type.GetArrayRank()} is not supported.");
            }
        }

        return null;

    }
}