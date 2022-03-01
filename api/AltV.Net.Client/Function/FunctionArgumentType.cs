using System.Reflection;

namespace AltV.Net.Client.Function
{
    public struct FunctionArgumentType
    {
        private static NullabilityInfoContext nullabilityInfoContext = new NullabilityInfoContext();
        
        public bool Nullable = false;
        
        public bool HasDefault = false;

        public object? DefaultValue;
        
        public Type Type;
        
        public FunctionArgumentType(Type type, bool nullable, bool hasDefault, object? defaultValue)
        {
            Type = type;
            Nullable = nullable;
            HasDefault = hasDefault;
            DefaultValue = defaultValue;
        }

        public FunctionArgumentType(ParameterInfo parameterInfo)
        {
            Type = parameterInfo.ParameterType;
            Nullable = nullabilityInfoContext.Create(parameterInfo).WriteState == NullabilityState.Nullable;
            HasDefault = parameterInfo.HasDefaultValue;
            DefaultValue = parameterInfo.DefaultValue;
        }
    }
}