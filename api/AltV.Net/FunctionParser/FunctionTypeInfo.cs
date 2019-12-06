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

        public readonly Func<int, Array> CreateArrayOfElementType;

        public readonly Func<int, Array> CreateArrayOfTypeExp;

        public readonly object EmptyArrayOfType;

        public readonly object DefaultValue;

        public readonly bool IsParamArray;

        public readonly bool IsNullable;

        public readonly Type NullableType;

        public readonly bool IsEnum;

        public readonly FunctionMValueConstParser ConstParser;

        public readonly FunctionStringParser StringParser;

        public readonly FunctionObjectParser ObjectParser;

        public FunctionTypeInfo(Type paramType, ParameterInfo paramInfo = null)
        {
            var param = Expression.Parameter(typeof(int));
            CreateArrayOfElementType = Expression.Lambda<Func<int, Array>>(
                Expression.NewArrayBounds(paramType, param), param).Compile();
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

                var arraySizeParam = Expression.Parameter(typeof(int));
                CreateArrayOfTypeExp = Expression.Lambda<Func<int, Array>>(
                    Expression.NewArrayBounds(ElementType, arraySizeParam),
                    new[] {arraySizeParam}
                ).Compile();
                EmptyArrayOfType = Array.CreateInstance(ElementType, 0);
            }
            else
            {
                CreateArrayOfTypeExp = null;
                EmptyArrayOfType = null;
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


            if (IsNullable)
            {
                paramType = NullableType;
            }
            if (paramType == FunctionTypes.Obj)
            {
                ConstParser = FunctionMValueConstParsers.ParseObject;
                ObjectParser = FunctionObjectParsers.ParseObject;
                StringParser = FunctionStringParsers.ParseObject;
            }
            else if (paramType == FunctionTypes.Bool)
            {
                ConstParser = FunctionMValueConstParsers.ParseBool;
                ObjectParser = FunctionObjectParsers.ParseBool;
                StringParser = FunctionStringParsers.ParseBool;
            }
            else if (paramType == FunctionTypes.Int)
            {
                ConstParser = FunctionMValueConstParsers.ParseInt;
                ObjectParser = FunctionObjectParsers.ParseInt;
                StringParser = FunctionStringParsers.ParseInt;
            }
            else if (paramType == FunctionTypes.Long)
            {
                ConstParser = FunctionMValueConstParsers.ParseLong;
                ObjectParser = FunctionObjectParsers.ParseLong;
                StringParser = FunctionStringParsers.ParseLong;
            }
            else if (paramType == FunctionTypes.UInt)
            {
                ConstParser = FunctionMValueConstParsers.ParseUInt;
                ObjectParser = FunctionObjectParsers.ParseUInt;
                StringParser = FunctionStringParsers.ParseUInt;
            }
            else if (paramType == FunctionTypes.ULong)
            {
                ConstParser = FunctionMValueConstParsers.ParseULong;
                ObjectParser = FunctionObjectParsers.ParseULong;
                StringParser = FunctionStringParsers.ParseULong;
            }
            else if (paramType == FunctionTypes.Float)
            {
                ConstParser = FunctionMValueConstParsers.ParseFloat;
                ObjectParser = FunctionObjectParsers.ParseFloat;
                StringParser = FunctionStringParsers.ParseFloat;
            }
            else if (paramType == FunctionTypes.Double)
            {
                ConstParser = FunctionMValueConstParsers.ParseDouble;
                ObjectParser = FunctionObjectParsers.ParseDouble;
                StringParser = FunctionStringParsers.ParseDouble;
            }
            else if (paramType == FunctionTypes.String)
            {
                ConstParser = FunctionMValueConstParsers.ParseString;
                ObjectParser = FunctionObjectParsers.ParseString;
                StringParser = FunctionStringParsers.ParseString;
            }
            else if (paramType.BaseType == FunctionTypes.Array)
            {
                ConstParser = FunctionMValueConstParsers.ParseArray;
                ObjectParser = FunctionObjectParsers.ParseArray;
                StringParser = FunctionStringParsers.ParseArray;
            }
            else if (IsEntity)
            {
                ConstParser = FunctionMValueConstParsers.ParseEntity;
                ObjectParser = FunctionObjectParsers.ParseEntity;
                StringParser = FunctionStringParsers.ParseEntity;
            }
            else if (IsDict)
            {
                ConstParser = FunctionMValueConstParsers.ParseDictionary;
                ObjectParser = FunctionObjectParsers.ParseDictionary;
                StringParser = FunctionStringParsers.ParseDictionary;
            }
            else if (IsMValueConvertible)
            {
                ConstParser = FunctionMValueConstParsers.ParseConvertible;
                ObjectParser = FunctionObjectParsers.ParseConvertible;
                StringParser = FunctionStringParsers.ParseConvertible;
            }
            else if (paramType == FunctionTypes.FunctionType)
            {
                ConstParser = FunctionMValueConstParsers.ParseFunction;
                ObjectParser = FunctionObjectParsers.ParseFunction;
                StringParser = FunctionStringParsers.ParseFunction;
            }
            else if (IsEnum)
            {
                ConstParser = FunctionMValueConstParsers.ParseEnum;
                ObjectParser = FunctionObjectParsers.ParseEnum;
                StringParser = FunctionStringParsers.ParseEnum;
            }
            else
            {
                ConstParser = null;
                ObjectParser = null;
                StringParser = null;
            }
        }

        public Array CreateArrayOfType(int size, Type type)
        {
            if (CreateArrayOfTypeExp != null)
            {
                return CreateArrayOfTypeExp.Invoke(size);
            }
            else
            {
                return Array.CreateInstance(type, size);
            }
        }
    }
}