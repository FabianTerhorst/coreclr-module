using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MValue
    {
        // The MValue param needs to be an List type
        public delegate MValue Function(MValue args);

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

        public static MValue Nil = new MValue(0, IntPtr.Zero);

        public static MValue? CreateFromObject(object obj)
        {
            switch (obj)
            {
                case IntPtr entityPointer:
                    return Create(entityPointer);
                case IEntity entity:
                    return Create(entity.NativePointer);
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
                case string value:
                    return Create(value);
                case MValue value:
                    return value;
                case MValue[] value:
                    return Create(value);
                case Dictionary<string, object> value:
                    var dictMValues = new List<MValue>();
                    foreach (var dictValue in value.Values)
                    {
                        var dictMValue = CreateFromObject(dictValue);
                        if (!dictMValue.HasValue) continue;
                        dictMValues.Add(dictMValue.Value);
                    }

                    return Create(dictMValues.ToArray(), value.Keys.ToArray());
                case Function value:
                    return CreateFunction(value);
                case object[] value:
                    return Create((from objArrayValue in value
                        select CreateFromObject(objArrayValue)
                        into objArrayMValue
                        where objArrayMValue.HasValue
                        select objArrayMValue.Value).ToArray());
            }

            return null;
        }

        public static MValue Create(bool value)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateBool(value, ref mValue);
            return mValue;
        }

        public static MValue Create(long value)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateInt(value, ref mValue);
            return mValue;
        }

        public static MValue Create(ulong value)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateUInt(value, ref mValue);
            return mValue;
        }

        public static MValue Create(double value)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateDouble(value, ref mValue);
            return mValue;
        }

        public static MValue Create(string value)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateString(value, ref mValue);
            return mValue;
        }

        public static MValue Create(MValue[] values)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateList(values, (ulong) values.Length, ref mValue);
            return mValue;
        }

        public static MValue Create(MValue[] values, string[] keys)
        {
            if (values.Length != keys.Length) throw new ArgumentException("values length != keys length");
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateDict(values, keys, (ulong) values.Length, ref mValue);
            return mValue;
        }

        public static MValue Create(IntPtr entityPointer)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateEntity(entityPointer, ref mValue);
            return mValue;
        }

        public static MValue CreateFunction(Function function)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateFunction(Alt.MValueCreate.Invoker_Create(function), ref mValue);
            return mValue;
        }
        
        public static MValue CreateFunction(IntPtr invoker)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateFunction(invoker, ref mValue);
            return mValue;
        }

        public Type type;
        public IntPtr storagePointer;

        public MValue(Type type, IntPtr storagePointer)
        {
            this.type = type;
            this.storagePointer = storagePointer;
        }

        public bool GetBool()
        {
            return Alt.MValueGet.MValue_GetBool(ref this);
        }

        public long GetInt()
        {
            return Alt.MValueGet.MValue_GetInt(ref this);
        }

        public ulong GetUint()
        {
            return Alt.MValueGet.MValue_GetUInt(ref this);
        }

        public double GetDouble()
        {
            return Alt.MValueGet.MValue_GetDouble(ref this);
        }

        public void GetString(ref string value)
        {
            Alt.MValueGet.MValue_GetString(ref this, ref value);
        }

        public string GetString()
        {
            var value = string.Empty;
            Alt.MValueGet.MValue_GetString(ref this, ref value);
            return value;
        }

        public void GetEntityPointer(ref IntPtr entityPointer)
        {
            Alt.MValueGet.MValue_GetEntity(ref this, ref entityPointer);
        }

        public IntPtr GetEntityPointer()
        {
            var entityPointer = IntPtr.Zero;
            Alt.MValueGet.MValue_GetEntity(ref this, ref entityPointer);
            return entityPointer;
        }

        public void GetList(ref MValueArray mValueArray)
        {
            Alt.MValueGet.MValue_GetList(ref this, ref mValueArray);
        }

        public MValue[] GetList()
        {
            var mValueArray = MValueArray.Nil;
            Alt.MValueGet.MValue_GetList(ref this, ref mValueArray);
            return mValueArray.ToArray();
        }

        public Dictionary<string, MValue> GetDictionary()
        {
            var stringViewArrayRef = StringViewArray.Nil;
            var valueArrayRef = MValueArray.Nil;
            Alt.MValueGet.MValue_GetDict(ref this, ref stringViewArrayRef, ref valueArrayRef);
            var stringViewArray = stringViewArrayRef.ToArray();
            var dictionary = new Dictionary<string, MValue>();
            var valueArray = valueArrayRef.ToArray();
            var i = 0;
            foreach (var key in stringViewArray)
            {
                dictionary[key.Text] = valueArray[i++];
            }

            return dictionary;
        }

        public Function GetFunction()
        {
            return Alt.MValueGet.MValue_GetFunction(ref this);
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
                    return GetList().Length.ToString();
                case Type.DICT:
                    return GetDictionary().Count.ToString();
                case Type.ENTITY:
                    return "MValue<Entity>";
                case Type.FUNCTION:
                    return "MValue<Function>";
            }

            return "MValue<>";
        }
    }
}