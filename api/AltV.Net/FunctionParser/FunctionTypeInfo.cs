using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AltV.Net.FunctionParser
{
    internal class FunctionTypeInfo
    {
        public readonly bool IsEntity;

        public readonly bool IsVehicle;

        public readonly bool IsPlayer;

        public readonly bool IsBlip;

        public readonly bool IsCheckpoint;
        
        public readonly bool IsColShape;

        public readonly bool IsDict;

        public readonly bool IsList;

        public readonly bool IsMValueConvertible;

        public readonly FunctionTypeInfo Element;

        public readonly Type ElementType;

        public readonly FunctionTypeInfo DictionaryValue;

        public readonly Type[] GenericArguments;

        public readonly Type DictType;

        public readonly Func<IDictionary> CreateDictionary;

        public readonly object DefaultValue;

        public readonly bool IsParamArray;

        public readonly bool IsNullable;

        public readonly Type NullableType;

        public readonly bool IsEnum;
        
        public FunctionTypeInfo(Type paramType, ParameterInfo paramInfo = null)
        {
            IsList = paramType.BaseType == FunctionTypes.Array;
            IsDict = paramType.Name.StartsWith("Dictionary") || paramType.Name.StartsWith("IDictionary");
            if (IsDict)
            {
                GenericArguments = paramType.GetGenericArguments();
                //TODO: dont create this for primitive type dictionaries
                DictType = typeof(Dictionary<,>).MakeGenericType(GenericArguments[0], GenericArguments[1]);
                DictionaryValue = GenericArguments.Length == 2 ? new FunctionTypeInfo(GenericArguments[1]) : null;
                CreateDictionary = Expression.Lambda<Func<IDictionary>>(
                    Expression.New(DictType)
                ).Compile();
            }
            else
            {
                GenericArguments = null;
                DictType = null;
                DictionaryValue = null;
                CreateDictionary = null;
            }

            if (paramType.IsValueType && paramType != FunctionTypes.String)
            {
                DefaultValue = Activator.CreateInstance(paramType);
            }
            else
            {
                DefaultValue = null;
            }

            var interfaces = paramType.GetInterfaces();
            if (interfaces.Contains(FunctionTypes.Entity))
            {
                IsEntity = true;
                IsVehicle = paramType == FunctionTypes.Vehicle || interfaces.Contains(FunctionTypes.Vehicle);
                IsPlayer = paramType == FunctionTypes.Player || interfaces.Contains(FunctionTypes.Player);
                IsBlip = paramType == FunctionTypes.Blip || interfaces.Contains(FunctionTypes.Blip);
                IsCheckpoint = paramType == FunctionTypes.Checkpoint || interfaces.Contains(FunctionTypes.Checkpoint);
                IsColShape = paramType == FunctionTypes.ColShape || interfaces.Contains(FunctionTypes.ColShape);
            }
            else
            {
                IsEntity = false;
                IsVehicle = false;
                IsPlayer = false;
                IsBlip = false;
                IsCheckpoint = false;
                IsColShape = false;
            }

            IsMValueConvertible = interfaces.Contains(FunctionTypes.MValueConvertible);

            var elementType = paramType.GetElementType();
            if (elementType != null)
            {
                ElementType = elementType;
                Element = new FunctionTypeInfo(elementType);
            }

            if (paramInfo != null)
            {
                IsParamArray = paramInfo.GetCustomAttribute<ParamArrayAttribute>() != null;
            }

            IsNullable = paramType.Name.StartsWith("Nullable");
            if (IsNullable)
            {
                var genericArguments = paramType.GetGenericArguments();
                if (genericArguments.Length != 1)
                {
                    IsNullable = false;
                }
                else
                {
                    NullableType = genericArguments[0];
                    DefaultValue = Activator.CreateInstance(typeof(Nullable<>).MakeGenericType(NullableType));
                }
            }
            
            IsEnum = paramType.IsEnum;
        }
    }
}