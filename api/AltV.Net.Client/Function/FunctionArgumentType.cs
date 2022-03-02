using System.Reflection;
using Microsoft.VisualBasic;

namespace AltV.Net.Client.Function
{
    public struct FunctionArgumentType
    {
        private static NullabilityInfoContext nullabilityInfoContext = new NullabilityInfoContext();
        
        public bool IsNullable = false;
        
        public bool HasDefault = false;

        public object? DefaultValue;
        
        public Type Type;
        
        public FunctionArgumentType(Type type, bool isNullable, bool hasDefault, object? defaultValue)
        {
            Type = type;
            IsNullable = isNullable;
            HasDefault = hasDefault;
            DefaultValue = defaultValue;
        }

        public FunctionArgumentType(ParameterInfo parameterInfo)
        {
            var context = nullabilityInfoContext.Create(parameterInfo);
            IsNullable = context.WriteState == NullabilityState.Nullable;
            Type = Nullable.GetUnderlyingType(parameterInfo.ParameterType) ?? parameterInfo.ParameterType; // todo optimize for non-nullable types
            HasDefault = parameterInfo.HasDefaultValue;
            DefaultValue = Information.IsDBNull(parameterInfo.DefaultValue) ? null : parameterInfo.DefaultValue;
        }
    }
}