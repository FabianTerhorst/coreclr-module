using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Args
{
    /// <summary>
    /// MValue's received from events are MValueConst
    /// </summary>
    public readonly struct MValueConst : IDisposable
    {
        public static MValueConst Nil = new MValueConst(Type.Nil, IntPtr.Zero);

        public static MValueConst None = new MValueConst(Type.None, IntPtr.Zero);

        public enum Type : byte
        {
            None = 0,
            Nil = 1,
            Bool = 2,
            Int = 3,
            Uint = 4,
            Double = 5,
            String = 6,
            List = 7,
            Dict = 8,
            BaseObject = 9,
            Function = 10,
            Vector3 = 11,
            Rgba = 12,
            ByteArray = 13,
            Vector2 = 14,
        }

        public static MValueConst[] CreateFrom(IntPtr[] pointers)
        {
            int length = pointers.Length;
            var mValues = new MValueConst[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = new MValueConst(pointers[i]);
            }

            return mValues;
        }

        public readonly IntPtr nativePointer;
        public readonly Type type;

        public MValueConst(IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
            if (nativePointer == IntPtr.Zero)
            {
                this.type = Type.Nil;
            }
            else
            {
                unsafe
                {
                    this.type = (Type) Alt.Server.Library.MValueConst_GetType(nativePointer);
                }
            }
        }

        public MValueConst(Type type, IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
            this.type = type;
        }

        public bool GetBool()
        {
            unsafe
            {
                return Alt.Server.Library.MValueConst_GetBool(nativePointer) == 1;
            }
        }

        public long GetInt()
        {
            unsafe
            {
                return Alt.Server.Library.MValueConst_GetInt(nativePointer);
            }
        }

        public ulong GetUint()
        {
            unsafe
            {
                return Alt.Server.Library.MValueConst_GetUInt(nativePointer);
            }
        }

        public double GetDouble()
        {
            unsafe
            {
                return Alt.Server.Library.MValueConst_GetDouble(nativePointer);
            }
        }

        public string GetString()
        {
            unsafe
            {
                var value = IntPtr.Zero;
                ulong size = 0;
                Alt.Server.Library.MValueConst_GetString(nativePointer, &value, &size);
                return Marshal.PtrToStringUTF8(value, (int) size);
            }
        }

        public IntPtr GetEntityPointer(ref BaseObjectType baseObjectType)
        {
            unsafe
            {
                BaseObjectType pType;
                var result = Alt.Server.Library.MValueConst_GetEntity(nativePointer, &pType);
                baseObjectType = pType;
                return result;
            }
        }

        public IBaseObject GetBaseObject()
        {
            var baseObjectType = BaseObjectType.Undefined;
            var baseObjectPtr = GetEntityPointer(ref baseObjectType);
            Alt.Module.BaseBaseObjectPool.Get(baseObjectPtr, baseObjectType, out var baseObject);
            return baseObject;
        }

        public MValueConst[] GetList()
        {
            unsafe
            {
                var size = Alt.Server.Library.MValueConst_GetListSize(nativePointer);
                if (size == 0) return Array.Empty<MValueConst>();
                var mValuePointers = new IntPtr[size];
                Alt.Server.Library.MValueConst_GetList(nativePointer, mValuePointers);
                return CreateFrom(mValuePointers);
            }
        }

        public Dictionary<string, MValueConst> GetDictionary()
        {
            unsafe
            {
                var size = Alt.Server.Library.MValueConst_GetDictSize(nativePointer);
                if (size == 0) return new Dictionary<string, MValueConst>();
                var keyPointers = new IntPtr[size];
                var mValuePointers = new IntPtr[size];
                Alt.Server.Library.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers);

                var dictionary = new Dictionary<string, MValueConst>();

                for (ulong i = 0; i < size; i++)
                {
                    var keyPointer = keyPointers[i];
                    var mValue = new MValueConst(mValuePointers[i]);
                    dictionary[Marshal.PtrToStringUTF8(keyPointer)] = mValue;
                    Alt.Server.Library.FreeCharArray(keyPointer);
                }

                return dictionary;
            }
        }

        public void CallFunction(MValueConst[] args, out MValueConst result)
        {
            unsafe
            {
                var length = (ulong) args.Length;
                var argsPointers = new IntPtr[length];
                for (ulong i = 0; i < length; i++)
                {
                    argsPointers[i] = args[i].nativePointer;
                }

                result = new MValueConst(
                    Alt.Server.Library.MValueConst_CallFunction(Alt.Server.NativePointer, nativePointer, argsPointers,
                        length));
            }
        }

        public void GetVector3(ref Position position)
        {
            unsafe
            {
                Position pos;
                Alt.Server.Library.MValueConst_GetVector3(nativePointer, &pos);
                position = pos;
            }
        }

        public Position GetVector3()
        {
            unsafe
            {
                var position = Position.Zero;
                Alt.Server.Library.MValueConst_GetVector3(nativePointer, &position);
                return position;
            }
        }

        public void GetRgba(ref Rgba rgba)
        {
            unsafe
            {
                Rgba pRgba;
                Alt.Server.Library.MValueConst_GetRGBA(nativePointer, &pRgba);
                rgba = pRgba;
            }
        }

        public Rgba GetRgba()
        {
            unsafe
            {
                var rgba = Rgba.Zero;
                Alt.Server.Library.MValueConst_GetRGBA(nativePointer, &rgba);
                return rgba;
            }
        }

        public byte[] GetByteArray()
        {
            unsafe
            {
                var size = Alt.Server.Library.MValueConst_GetByteArraySize(nativePointer);
                var sizeInt = (int) size;
                var data = Marshal.AllocHGlobal(sizeInt);
                Alt.Server.Library.MValueConst_GetByteArray(nativePointer, size, data);
                var byteSize = Marshal.SizeOf<byte>();
                var byteArray = new byte[size];
                for (var i = 0; i < sizeInt; i++)
                {
                    byteArray[i] = Marshal.ReadByte(data);
                    data += byteSize;
                }

                Marshal.FreeHGlobal(data);

                return byteArray;
            }
        }

        public object ToObject()
        {
            switch (type)
            {
                case Type.None:
                    return None;
                case Type.Nil:
                    return null;
                case Type.Bool:
                    return GetBool();
                case Type.Int:
                    return GetInt();
                case Type.Uint:
                    return GetUint();
                case Type.Double:
                    return GetDouble();
                case Type.String:
                    return GetString();
                case Type.List:
                    unsafe
                    {
                        var listSize = Alt.Server.Library.MValueConst_GetListSize(nativePointer);
                        if (listSize == 0) return Array.Empty<MValueConst>();
                        var mValueListPointers = new IntPtr[listSize];
                        Alt.Server.Library.MValueConst_GetList(nativePointer, mValueListPointers);
                        var arrayValues = new object[listSize];
                        for (ulong i = 0; i < listSize; i++)
                        {
                            var mValue = new MValueConst(mValueListPointers[i]);
                            arrayValues[i] = mValue.ToObject();
                            mValue.Dispose();
                        }

                        return arrayValues;
                    }

                case Type.Dict:
                    unsafe
                    {
                        var size = Alt.Server.Library.MValueConst_GetDictSize(nativePointer);
                        if (size == 0) return new Dictionary<string, MValueConst>();
                        var keyPointers = new IntPtr[size];
                        var mValuePointers = new IntPtr[size];
                        if (Alt.Server.Library.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers) == 0)
                            return null;

                        var dictionary = new Dictionary<string, object>();

                        for (ulong i = 0; i < size; i++)
                        {
                            var keyPointer = keyPointers[i];
                            var mValue = new MValueConst(mValuePointers[i]);
                            dictionary[Marshal.PtrToStringUTF8(keyPointer)] = mValue.ToObject();
                            Alt.Server.Library.FreeCharArray(keyPointer);
                            mValue.Dispose();
                        }

                        return dictionary;
                    }

                case Type.BaseObject:
                    var entityType = BaseObjectType.Undefined;
                    var entityPointer = GetEntityPointer(ref entityType);
                    if (entityPointer == IntPtr.Zero) return null;
                    if (Alt.Module.BaseBaseObjectPool.Get(entityPointer, entityType, out var entity))
                    {
                        return entity;
                    }

                    return null;
                case Type.Function:
                    return null;
                case Type.Vector3:
                    var position = Position.Zero;
                    GetVector3(ref position);
                    return position;
                case Type.Rgba:
                    var rgba = Rgba.Zero;
                    GetRgba(ref rgba);
                    return rgba;
                case Type.ByteArray:
                    return GetByteArray();
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            switch (type)
            {
                case Type.None:
                    return "MValueNone<>";
                case Type.Nil:
                    return "MValueNil<>";
                case Type.Bool:
                    return "MValueBool<" + GetBool().ToString() + ">";
                case Type.Int:
                    return "MValueInt<" + GetInt().ToString() + ">";
                case Type.Uint:
                    return "MValueUInt<" + GetUint().ToString() + ">";
                case Type.Double:
                    return "MValueDouble<" + GetDouble().ToString(CultureInfo.InvariantCulture) + ">";
                case Type.String:
                    return "MValueString<" + GetString() + ">";
                case Type.List:
                    return "MValueList<{" + GetList().Aggregate("", (current, value) =>
                    {
                        var result = current + value.ToString() + ",";
                        value.Dispose();
                        return result;
                    }) + "}>";
                case Type.Dict:
                    return "MValueDict<{" + GetDictionary().Aggregate("",
                               (current, value) =>
                               {
                                   var (key, mValueConst) = value;
                                   var result = current + key.ToString() + "=" + mValueConst.ToString() + ",";
                                   mValueConst.Dispose();
                                   return result;
                               }) + "}>";
                case Type.BaseObject:
                    var entityType = BaseObjectType.Undefined;
                    var ptr = GetEntityPointer(ref entityType);
                    if (ptr == IntPtr.Zero) return $"MValue<entity:nilptr>";
                    if (Alt.Module.BaseBaseObjectPool.Get(ptr, entityType, out var entity))
                    {
                        return $"MValue<{entity.Type.ToString()}>";
                    }

                    return "MValue<Entity>";
                case Type.Function:
                    return "MValue<Function>";
                case Type.Vector3:
                    var position = Position.Zero;
                    GetVector3(ref position);
                    return $"MValue<Vector3<{position.X},{position.Y},{position.Z}>>";
                case Type.Rgba:
                    var rgba = Rgba.Zero;
                    GetRgba(ref rgba);
                    return $"MValue<Rgba<{rgba.R},{rgba.G},{rgba.B},{rgba.A}>>";
                case Type.ByteArray:
                    unsafe
                    {
                        return $"MValueByteArray<{Alt.Server.Library.MValueConst_GetByteArraySize(nativePointer)}>";
                    }
            }

            return "MValue<>";
        }

        public void AddRef()
        {
            unsafe
            {
                // Nil types have zero int ptr to reduce allocations on heap
                if (nativePointer == IntPtr.Zero) return;
                Alt.Server.Library.MValueConst_AddRef(nativePointer);
            }
        }

        public void RemoveRef()
        {
            unsafe
            {
                // Nil types have zero int ptr to reduce allocations on heap
                if (nativePointer == IntPtr.Zero) return;
                Alt.Server.Library.MValueConst_RemoveRef(nativePointer);
            }
        }

        public void Dispose()
        {
            unsafe
            {
                // Nil types have zero int ptr to reduce allocations on heap
                if (nativePointer == IntPtr.Zero) return;
                Alt.Server.Library.MValueConst_Delete(nativePointer);
            }
        }
    }
}