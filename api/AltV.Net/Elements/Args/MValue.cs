using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    //TODO: check the types in getter methods
    //TODO: maybe make MValue internal
    [StructLayout(LayoutKind.Sequential)]
    public struct MValue
    {
        // The MValue param needs to be an List type
        public delegate void Function(ref MValue args, ref MValue result);

        public enum Type : byte
        {
            NIL = 0,
            BOOL = 1,
            INT = 2,
            UINT = 3,
            DOUBLE = 4,
            STRING = 5,
            LIST = 6,
            DICT = 7,
            ENTITY = 8,
            FUNCTION = 9
        }

        internal static readonly int Size = Marshal.SizeOf<MValue>();

        public static MValue Nil = new MValue(Type.NIL, IntPtr.Zero);

        //TODO: create a map that holds function pointers for each object type, its probably faster then this switch now
        public static MValue CreateFromObject(object obj)
        {
            if (obj == null)
            {
                return Nil;
            }

            int i;

            string[] dictKeys;
            MValue[] dictValues;
            MValueWriter writer;

            switch (obj)
            {
                case IPlayer player:
                    return Create(player);
                case IVehicle vehicle:
                    return Create(vehicle);
                case IBlip blip:
                    return Create(blip);
                case ICheckpoint checkpoint:
                    return Create(checkpoint);
                case bool value:
                    return Create(value);
                case int value:
                    return Create(value);
                case uint value:
                    return Create(value);
                case long value:
                    return Create(value);
                case ulong value:
                    return Create(value);
                case double value:
                    return Create(value);
                case float value:
                    return Create(value);
                case string value:
                    return Create(value);
                case MValue value:
                    return value;
                case MValue[] value:
                    return Create(value);
                case Invoker value:
                    return Create(value);
                case Function value:
                    return Create(value);
                case Net.Function function:
                    return Create(function.call);
                case IDictionary dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValue[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        if (key is string stringKey)
                        {
                            dictKeys[i++] = stringKey;
                        }
                        else
                        {
                            return Nil;
                        }
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        dictValues[i++] = CreateFromObject(value);
                    }

                    return Create(dictValues, dictKeys);
                case ICollection collection:
                    var length = collection.Count;
                    var listValues = new MValue[length];
                    i = 0;
                    foreach (var value in collection)
                    {
                        listValues[i++] = CreateFromObject(value);
                    }

                    return Create(listValues);
                case IDictionary<string, object> dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValue[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        dictKeys[i++] = key;
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        dictValues[i++] = CreateFromObject(value);
                    }

                    return Create(dictValues, dictKeys);
                case IWritable writable:
                    writer = new MValueWriter();
                    writable.OnWrite(writer);
                    return writer.ToMValue();
                case IMValueConvertible convertible:
                    writer = new MValueWriter();
                    convertible.GetAdapter().ToMValue(obj, writer);
                    return writer.ToMValue();
                case Position position:
                    var posValues = new MValue[3];
                    posValues[0] = Create(position.X);
                    posValues[1] = Create(position.Y);
                    posValues[2] = Create(position.Z);
                    var posKeys = new string[3];
                    posKeys[0] = "x";
                    posKeys[1] = "y";
                    posKeys[2] = "z";
                    return Create(posValues, posKeys);
                case Rotation rotation:
                    var rotValues = new MValue[3];
                    rotValues[0] = Create(rotation.Roll);
                    rotValues[1] = Create(rotation.Pitch);
                    rotValues[2] = Create(rotation.Yaw);
                    var rotKeys = new string[3];
                    rotKeys[0] = "roll";
                    rotKeys[1] = "pitch";
                    rotKeys[2] = "yaw";
                    return Create(rotValues, rotKeys);
                case short value:
                    return Create(value);
                case ushort value:
                    return Create(value);
                default:
                    Alt.Log("can't convert type:" + obj.GetType());
                    return Nil;
            }
        }

        public static MValue Create()
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateNil(ref mValue);
            return mValue;
        }

        public static MValue Create(bool value)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateBool(value, ref mValue);
            return mValue;
        }

        public static MValue Create(long value)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateInt(value, ref mValue);
            return mValue;
        }

        public static MValue Create(ulong value)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateUInt(value, ref mValue);
            return mValue;
        }

        public static MValue Create(double value)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateDouble(value, ref mValue);
            return mValue;
        }

        public static MValue Create(string value)
        {
            var mValue = Nil;
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
            AltNative.MValueCreate.MValue_CreateString(stringPtr, ref mValue);
            if (stringPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(stringPtr);
            }

            return mValue;
        }

        public static MValue Create(MValue[] values)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateList(values, (ulong) values.Length, ref mValue);
            return mValue;
        }

        public static MValue Create(MValue[] values, string[] keys)
        {
            if (values.Length != keys.Length)
                throw new ArgumentException($"values length: {values.Length} != keys length: {keys.Length}");
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateDict(values, keys, (ulong) values.Length, ref mValue);
            return mValue;
        }

        public static MValue Create(IPlayer player)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreatePlayer(player.NativePointer, ref mValue);
            return mValue;
        }

        public static MValue Create(IVehicle vehicle)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateVehicle(vehicle.NativePointer, ref mValue);
            return mValue;
        }

        public static MValue Create(IBlip blip)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateBlip(blip.NativePointer, ref mValue);
            return mValue;
        }

        public static MValue Create(ICheckpoint checkpoint)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateCheckpoint(checkpoint.NativePointer, ref mValue);
            return mValue;
        }

        public static MValue Create(Function function)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateFunction(AltNative.MValueCreate.Invoker_Create(Alt.Module.ModuleResource.NativePointer, function), ref mValue);
            return mValue;
        }

        internal static MValue Create(Invoker invoker)
        {
            var mValue = Nil;
            AltNative.MValueCreate.MValue_CreateFunction(invoker.NativePointer, ref mValue);
            return mValue;
        }

        internal static MValue[] CreateFromObjects(object[] objects)
        {
            var length = objects.Length;
            var mValues = new MValue[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = CreateFromObject(objects[i]);
            }

            return mValues;
        }

        internal static void Dispose(MValue[] mValues)
        {
            for (int i = 0, length = mValues.Length; i < length; i++)
            {
                AltNative.MValueDispose.MValue_Dispose(ref mValues[i]);
            }
        }

        public readonly Type type;
        public readonly IntPtr storagePointer;

        public MValue(Type type, IntPtr storagePointer)
        {
            this.type = type;
            this.storagePointer = storagePointer;
        }

        public bool GetBool()
        {
            return AltNative.MValueGet.MValue_GetBool(ref this);
        }

        public long GetInt()
        {
            return AltNative.MValueGet.MValue_GetInt(ref this);
        }

        public ulong GetUint()
        {
            return AltNative.MValueGet.MValue_GetUInt(ref this);
        }

        public double GetDouble()
        {
            return AltNative.MValueGet.MValue_GetDouble(ref this);
        }

        public string GetString()
        {
            var value = IntPtr.Zero;
            ulong size = 0;
            AltNative.MValueGet.MValue_GetString(ref this, ref value, ref size);
            return Marshal.PtrToStringUTF8(value, (int) size);
        }

        public IntPtr GetEntityPointer(ref BaseObjectType baseObjectType)
        {
            return AltNative.MValueGet.MValue_GetEntity(ref this, ref baseObjectType);
        }

        public void GetList(ref MValueArray mValueArray)
        {
            AltNative.MValueGet.MValue_GetList(ref this, ref mValueArray);
        }

        public MValue[] GetList()
        {
            var mValueArray = MValueArray.Nil;
            AltNative.MValueGet.MValue_GetList(ref this, ref mValueArray);
            var values = mValueArray.ToArray();
            mValueArray.Dispose();
            return values;
        }

        public Dictionary<string, MValue> GetDictionary()
        {
            var stringViewArray = StringArray.Nil;
            var valueArray = MValueArray.Nil;
            AltNative.MValueGet.MValue_GetDict(ref this, ref stringViewArray, ref valueArray);
            var valueArrayPtr = valueArray.data;
            var stringViewArrayPtr = stringViewArray.data;
            var size = (int) stringViewArray.size;
            if (valueArray.Size != (ulong) size) // Value size != key size should never happen
            {
                return null;
            }

            var dictionary = new Dictionary<string, MValue>();
            for (var i = 0; i < size; i++)
            {
                var key = stringViewArray.GetNextWithOffset(ref stringViewArrayPtr);
                var value = valueArray.GetNextWithOffset(ref valueArrayPtr);
                if (key != null)
                {
                    dictionary[key] = value;
                }
            }
            
            stringViewArray.Dispose();
            valueArray.Dispose();

            return dictionary;
        }

        public Function GetFunction()
        {
            return AltNative.MValueGet.MValue_GetFunction(ref this);
        }

        public MValue CallFunction(MValue[] args)
        {
            var result = Nil;
            AltNative.MValueCall.MValue_CallFunction(ref this, args, args.Length, ref result);
            return result;
        }

        public MValue CallFunction(params object[] args)
        {
            var result = Nil;
            AltNative.MValueCall.MValue_CallFunction(ref this, CreateFromObjects(args), args.Length,
                ref result);
            return result;
        }

        public override string ToString()
        {
            switch (type)
            {
                case Type.NIL:
                    return "Nil";
                case Type.BOOL:
                    return GetBool().ToString();
                case Type.INT:
                    return GetInt().ToString();
                case Type.UINT:
                    return GetUint().ToString();
                case Type.DOUBLE:
                    return GetDouble().ToString(CultureInfo.InvariantCulture);
                case Type.STRING:
                    return GetString();
                case Type.LIST:
                    return GetList().Aggregate("List:", (current, value) => current + value.ToString() + ",");
                case Type.DICT:
                    return GetDictionary().Aggregate("Dict:",
                        (current, value) => current + value.Key.ToString() + "=" + value.Value.ToString() + ",");
                case Type.ENTITY:
                    var entityType = BaseObjectType.Undefined;
                    var ptr = GetEntityPointer(ref entityType);
                    if (ptr == IntPtr.Zero) return $"MValue<entity:nilptr>";
                    if (Alt.Module.BaseBaseObjectPool.Get(ptr, entityType, out var entity))
                    {
                        return $"MValue<{entity.Type.ToString()}>";
                    }

                    return "MValue<Entity>";
                case Type.FUNCTION:
                    return "MValue<Function>";
            }

            return "MValue<>";
        }

        public object ToObject()
        {
            return ToObject(Alt.Module.BaseBaseObjectPool);
        }

        public object ToObject(IBaseBaseObjectPool baseBaseObjectPool)
        {
            switch (type)
            {
                case Type.NIL:
                    return null;
                case Type.BOOL:
                    return GetBool();
                case Type.INT:
                    return GetInt();
                case Type.UINT:
                    return GetUint();
                case Type.DOUBLE:
                    return GetDouble();
                case Type.STRING:
                    return GetString();
                case Type.LIST:
                    var mValueArray = MValueArray.Nil;
                    AltNative.MValueGet.MValue_GetList(ref this, ref mValueArray);
                    var arrayValue = mValueArray.data;
                    var arrayValues = new object[mValueArray.Size];
                    for (var i = 0; i < arrayValues.Length; i++)
                    {
                        arrayValues[i] = mValueArray.GetNextWithOffset(ref arrayValue).ToObject(baseBaseObjectPool);
                    }
                    
                    mValueArray.Dispose();

                    return arrayValues;
                case Type.DICT:
                    var stringArray = StringArray.Nil;
                    var valueArray = MValueArray.Nil;
                    AltNative.MValueGet.MValue_GetDict(ref this, ref stringArray, ref valueArray);
                    var valueArrayPtr = valueArray.data;
                    var stringViewArrayPtr = stringArray.data;
                    var size = (int) stringArray.size;
                    if (valueArray.Size != (ulong) size) // Value size != key size should never happen
                    {
                        return null;
                    }

                    var dictionary = new Dictionary<string, object>();
                    for (var i = 0; i < size; i++)
                    {
                        var key = stringArray.GetNextWithOffset(ref stringViewArrayPtr);
                        var value = valueArray.GetNextWithOffset(ref valueArrayPtr);
                        if (key != null)
                        {
                            dictionary[key] = value.ToObject(baseBaseObjectPool);
                        }
                    }
                    
                    stringArray.Dispose();
                    valueArray.Dispose();

                    return dictionary;
                case Type.ENTITY:
                    var entityType = BaseObjectType.Undefined;
                    var entityPointer = GetEntityPointer(ref entityType);
                    if (entityPointer == IntPtr.Zero) return null;
                    if (baseBaseObjectPool.Get(entityPointer, entityType, out var entity))
                    {
                        return entity;
                    }

                    return null;
                case Type.FUNCTION:
                    return GetFunction();
                default:
                    return null;
            }
        }

        public void Dispose()
        {
            AltNative.MValueDispose.MValue_Dispose(ref this);
        }
    }
}