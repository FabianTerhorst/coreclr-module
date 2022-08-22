using System.Numerics;
using System.Reflection;
using AltV.Net.Shared.Serialization.Serializers;
using AltV.Net.Shared.Serialization.Serializers.Numbers;

namespace AltV.Net.Shared.Serialization.Providers;

public class PrimitivesSerializationProvider : MValueSerializationProviderBase
{
    private static readonly Dictionary<Type, Type> SerializersTypes = new()
    {
        { typeof(sbyte), typeof(SByteSerializer) },
        { typeof(byte), typeof(ByteSerializer) },
        { typeof(short), typeof(ShortSerializer) },
        { typeof(ushort), typeof(UShortSerializer) },
        { typeof(int), typeof(IntSerializer) },
        { typeof(uint), typeof(UIntSerializer) },
        { typeof(long), typeof(LongSerializer) },
        { typeof(ulong), typeof(ULongSerializer) },
        { typeof(double), typeof(DoubleSerializer) },
        { typeof(float), typeof(FloatSerializer) },
        { typeof(decimal), typeof(DecimalSerializer) },
        
        { typeof(bool), typeof(BoolSerializer) },
        { typeof(object), typeof(ObjectSerializer) },
        { typeof(string), typeof(StringSerializer) },
        
        { typeof(Vector2), typeof(Vector2Serializer) },
        { typeof(Vector3), typeof(Vector3Serializer) },
        { typeof(Tuple<,>), typeof(TupleSerializer<,>) },
        { typeof(ValueTuple<,>), typeof(ValueTupleSerializer<,>) },
        { typeof(Nullable<>), typeof(NullableSerializer<>) }
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

        return null;

    }
}