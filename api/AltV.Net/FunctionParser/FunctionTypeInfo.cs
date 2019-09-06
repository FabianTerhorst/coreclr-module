using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public readonly Func<System.Collections.IDictionary> CreateDictionary;

        public readonly object DefaultValue;

        public FunctionTypeInfo(Type type)
        {
            IsList = type.BaseType == FunctionTypes.Array;
            IsDict = type.Name.StartsWith("Dictionary");
            if (IsDict)
            {
                GenericArguments = type.GetGenericArguments();
                //TODO: dont create this for primitive type dictionaries
                DictType = typeof(Dictionary<,>).MakeGenericType(GenericArguments[0], GenericArguments[1]);
                DictionaryValue = GenericArguments.Length == 2 ? new FunctionTypeInfo(GenericArguments[1]) : null;
                CreateDictionary = Expression.Lambda<Func<System.Collections.IDictionary>>(
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
        }
    }
}