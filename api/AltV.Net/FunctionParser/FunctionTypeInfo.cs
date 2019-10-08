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

        public readonly bool IsEventParams;

        public readonly bool IsNullable;

        public readonly Type NullableType;

        public readonly bool IsEnum;
        
        public FunctionTypeInfo(Type type)
        {
            IsList = type.BaseType == FunctionTypes.Array;
            IsDict = type.Name.StartsWith("Dictionary") || type.Name.StartsWith("IDictionary");
            if (IsDict)
            {
                GenericArguments = type.GetGenericArguments();
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

            if (type.IsValueType && type != FunctionTypes.String)
            {
                DefaultValue = Activator.CreateInstance(type);
            }
            else
            {
                DefaultValue = null;
            }

            var interfaces = type.GetInterfaces();
            if (interfaces.Contains(FunctionTypes.Entity))
            {
                IsEntity = true;
                IsVehicle = type == FunctionTypes.Vehicle || interfaces.Contains(FunctionTypes.Vehicle);
                IsPlayer = type == FunctionTypes.Player || interfaces.Contains(FunctionTypes.Player);
                IsBlip = type == FunctionTypes.Blip || interfaces.Contains(FunctionTypes.Blip);
                IsCheckpoint = type == FunctionTypes.Checkpoint || interfaces.Contains(FunctionTypes.Checkpoint);
            }
            else
            {
                IsEntity = false;
                IsVehicle = false;
                IsPlayer = false;
                IsBlip = false;
                IsCheckpoint = false;
            }

            IsMValueConvertible = interfaces.Contains(FunctionTypes.MValueConvertible);

            var elementType = type.GetElementType();
            if (elementType != null)
            {
                ElementType = elementType;
                Element = new FunctionTypeInfo(elementType);
            }

            IsEventParams = type.GetCustomAttribute<EventParams>() != null;

            IsNullable = type.Name.StartsWith("Nullable");
            if (IsNullable)
            {
                var genericArguments = type.GetGenericArguments();
                if (genericArguments.Length != 1)
                {
                    IsNullable = false;
                }
                else
                {
                    NullableType = genericArguments[0];
                    DefaultValue = typeof(Nullable<>).MakeGenericType(NullableType);
                }
            }
            
            IsEnum = type.IsEnum;
        }
    }
}