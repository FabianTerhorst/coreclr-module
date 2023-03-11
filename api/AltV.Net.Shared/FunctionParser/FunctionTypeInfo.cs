using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AltV.Net.Shared;

namespace AltV.Net.FunctionParser
{
    internal class FunctionTypeInfo
    {
        public readonly bool IsBaseObject;

        public readonly bool IsVehicle;

        public readonly bool IsPlayer;

        public readonly bool IsDict;

        public readonly bool IsList;

        public readonly bool IsMValueConvertible;

        public readonly bool IsPosition;
        
        public readonly bool IsRotation;
        
        public readonly bool IsRgba;
        
        public readonly bool IsVector3;

        public readonly bool IsByteArray;
        
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

            if (paramInfo != null && paramInfo.HasDefaultValue)
            {
                DefaultValue = paramInfo.DefaultValue;
            }
            else
            {
                if (paramType.IsValueType && paramType != FunctionTypes.String)
                {
                    DefaultValue = Activator.CreateInstance(paramType);
                }
                else
                {
                    DefaultValue = null;
                }
            }

            IsPosition = paramType == FunctionTypes.Position;
            IsRotation = paramType == FunctionTypes.Rotation;
            IsRgba = paramType == FunctionTypes.Rgba;
            IsVector3 = paramType == FunctionTypes.Vector3;
            IsByteArray = paramType == FunctionTypes.ByteArray;
            
            var interfaces = paramType.GetInterfaces();
            if (interfaces.Contains(FunctionTypes.BaseObject))
            {
                IsBaseObject = true;
                IsVehicle = paramType == FunctionTypes.Vehicle || interfaces.Contains(FunctionTypes.Vehicle);
                IsPlayer = paramType == FunctionTypes.Player || interfaces.Contains(FunctionTypes.Player);
            }
            else
            {
                IsBaseObject = false;
                IsVehicle = false;
                IsPlayer = false;
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
            else if (paramType == FunctionTypes.SByte)
            {
                ConstParser = FunctionMValueConstParsers.ParseSByte;
                ObjectParser = FunctionObjectParsers.ParseSByte;
                StringParser = FunctionStringParsers.ParseSByte;
            }
            else if (paramType == FunctionTypes.Short)
            {
                ConstParser = FunctionMValueConstParsers.ParseShort;
                ObjectParser = FunctionObjectParsers.ParseShort;
                StringParser = FunctionStringParsers.ParseShort;
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
            else if (paramType == FunctionTypes.Byte)
            {
                ConstParser = FunctionMValueConstParsers.ParseByte;
                ObjectParser = FunctionObjectParsers.ParseByte;
                StringParser = FunctionStringParsers.ParseByte;
            }
            else if (paramType == FunctionTypes.UShort)
            {
                ConstParser = FunctionMValueConstParsers.ParseUShort;
                ObjectParser = FunctionObjectParsers.ParseUShort;
                StringParser = FunctionStringParsers.ParseUShort;
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
            else if (IsByteArray)
            {
                ConstParser = FunctionMValueConstParsers.ParseByteArray;
                ObjectParser = FunctionObjectParsers.ParseByteArray;
                StringParser = FunctionStringParsers.ParseByteArray;
            }
            else if (paramType.BaseType == FunctionTypes.Array)
            {
                ConstParser = FunctionMValueConstParsers.ParseArray;
                ObjectParser = FunctionObjectParsers.ParseArray;
                StringParser = FunctionStringParsers.ParseArray;
            }
            else if (IsBaseObject)
            {
                ConstParser = FunctionMValueConstParsers.ParseBaseObject;
                ObjectParser = FunctionObjectParsers.ParseBaseObject;
                StringParser = FunctionStringParsers.ParseBaseObject;
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
            else if (IsPosition)
            {
                ConstParser = FunctionMValueConstParsers.ParsePosition;
                ObjectParser = FunctionObjectParsers.ParsePosition;
                StringParser = FunctionStringParsers.ParsePosition;
            }
            else if (IsRotation)
            {
                ConstParser = FunctionMValueConstParsers.ParseRotation;
                ObjectParser = FunctionObjectParsers.ParseRotation;
                StringParser = FunctionStringParsers.ParseRotation;
            }
            else if (IsVector3)
            {
                ConstParser = FunctionMValueConstParsers.ParseVector3;
                ObjectParser = FunctionObjectParsers.ParseVector3;
                StringParser = FunctionStringParsers.ParseVector3;
            }
            else if (IsRgba)
            {
                ConstParser = FunctionMValueConstParsers.ParseRgba;
                ObjectParser = FunctionObjectParsers.ParseRgba;
                StringParser = FunctionStringParsers.ParseRgba;
            }
            else if (AltShared.Core.IsMValueConvertible(paramType))
            {
                ConstParser = FunctionMValueConstParsers.ParseConvertible;
                ObjectParser = FunctionObjectParsers.ParseConvertible;
                StringParser = FunctionStringParsers.ParseConvertible;
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