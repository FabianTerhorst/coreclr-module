using System.Collections.Concurrent;
using System.Reflection;

namespace AltV.Net.Shared.Serialization;

public sealed class MValueSerializerRegistry : IMValueSerializerRegistry
{
    private readonly ISharedCore _core;
    private readonly ConcurrentDictionary<Type, IMValueSerializer> _cache = new();
    private readonly ConcurrentStack<IMValueSerializationProvider> _serializationProviders = new();

    public MValueSerializerRegistry(ISharedCore core)
    {
        _core = core;
    }
    
    public IMValueSerializer GetSerializer(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        var typeInfo = type.GetTypeInfo();
        if (typeInfo.IsGenericType && typeInfo.ContainsGenericParameters)
        {
            throw new ArgumentException($"Generic type {type} has unassigned type parameters.", nameof(type));
        }

        return _cache.GetOrAdd(type, CreateSerializer);
    }
    
    public IMValueSerializer<T> GetSerializer<T>()
    {
        return (IMValueSerializer<T>) GetSerializer(typeof(T));
    }
    
    private IMValueSerializer CreateSerializer(Type type)
    {
        foreach (var serializationProvider in _serializationProviders)
        {
            IMValueSerializer serializer = serializationProvider.GetSerializer(_core, type);

            if (serializer != null)
            {
                return serializer;
            }
        }

        throw new Exception($"No serializer found for type {type.FullName}.");
    }
    
    public void RegisterSerializationProvider(IMValueSerializationProvider serializationProvider)
    {
        ArgumentNullException.ThrowIfNull(serializationProvider);

        _serializationProviders.Push(serializationProvider);
    }
    
    public void RegisterSerializer(Type type, IMValueSerializer serializer)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(serializer);
        
        var typeInfo = type.GetTypeInfo();
        if (typeInfo.IsGenericType && typeInfo.ContainsGenericParameters)
        {
            throw new ArgumentException($"Generic type {type} has unassigned type parameters.", nameof(type));
        }

        if (!_cache.TryAdd(type, serializer))
        {
            throw new Exception($"There is already a serializer registered for type {type}.");
        }
    }
}