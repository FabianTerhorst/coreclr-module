using System.Reflection;

namespace AltV.Net.Shared.Serialization.Providers
{
    public abstract class MValueSerializationProviderBase : IMValueSerializationProvider
    {
        public abstract IMValueSerializer GetSerializer(ISharedCore core, Type valueType);
        
        protected virtual IMValueSerializer CreateGenericSerializer(ISharedCore core, Type serializerTypeDefinition, Type[] typeArguments)
        {
            var serializerType = serializerTypeDefinition.MakeGenericType(typeArguments);
            return CreateSerializer(core, serializerType);
        }

        protected virtual IMValueSerializer CreateSerializer(ISharedCore core, Type serializerType)
        {
            var serializerTypeInfo = serializerType.GetTypeInfo();
            var constructorInfo = serializerTypeInfo.GetConstructor(new[] { typeof(ISharedCore) });
            if (constructorInfo != null)
            {
                return (IMValueSerializer)constructorInfo.Invoke(new object[] { core });
            }

            constructorInfo = serializerTypeInfo.GetConstructor(Type.EmptyTypes);
            if (constructorInfo != null)
            {
                return (IMValueSerializer)constructorInfo.Invoke(Array.Empty<object>());
            }

            throw new MissingMethodException($"No suitable constructor found for serializer type: '{serializerType.FullName}'.");
        }
    }
}