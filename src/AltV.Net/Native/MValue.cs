using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MValue
    {
        // The MValue param needs to be an List type
        public delegate ref MValue Function(MValue args);

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
                    return Create(value);
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

        //TODO: untested
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

        public static MValue Create(Function function)
        {
            var mValue = Nil;
            Alt.MValueCreate.MValue_CreateFunction(function, ref mValue);
            return mValue;
        }

        public Type type;
        public IntPtr storagePointer;

        public MValue(Type type, IntPtr storagePointer)
        {
            this.type = type;
            this.storagePointer = storagePointer;
        }

        /*~MValue()
        {
            if (storagePointer == IntPtr.Zero) return;
            Marshal.FreeHGlobal(storagePointer);
            storagePointer = IntPtr.Zero;
        }*/
    }
}