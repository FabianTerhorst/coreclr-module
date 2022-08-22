using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Args
{
    /// <summary>
    /// MValue's received from events are MValueConst
    /// </summary>
    public class MValueConst : IMValueConst
    {
        public static MValueConst Nil = new MValueConst(null, MValueType.Nil, IntPtr.Zero);

        public static MValueConst None = new MValueConst(null, MValueType.None, IntPtr.Zero);

        public static MValueConst[] CreateFrom(ISharedCore core, IntPtr[] pointers)
        {
            var length = pointers.Length;
            var mValues = new MValueConst[length];
            for (var i = 0; i < length; i++)
            {
                mValues[i] = new MValueConst(core, pointers[i]);
            }

            return mValues;
        }

        private readonly ISharedCore core;
        public IntPtr nativePointer { get; }
        public MValueType type { get; }

        public MValueConst(ISharedCore core, IntPtr nativePointer)
        {
            this.core = core;
            this.nativePointer = nativePointer;
            if (nativePointer == IntPtr.Zero)
            {
                this.type = MValueType.Nil;
            }
            else
            {
                unsafe
                {
                    this.type = (MValueType) core.Library.Shared.MValueConst_GetType(nativePointer);
                }
            }
        }

        public MValueConst(ISharedCore core, MValueType type, IntPtr nativePointer)
        {
            this.core = core;
            this.nativePointer = nativePointer;
            this.type = type;
        }

        public bool GetBool()
        {
            unsafe
            {
                return core.Library.Shared.MValueConst_GetBool(nativePointer) == 1;
            }
        }

        public long GetInt()
        {
            unsafe
            {
                return core.Library.Shared.MValueConst_GetInt(nativePointer);
            }
        }

        public ulong GetUint()
        {
            unsafe
            {
                return core.Library.Shared.MValueConst_GetUInt(nativePointer);
            }
        }

        public double GetDouble()
        {
            unsafe
            {
                return core.Library.Shared.MValueConst_GetDouble(nativePointer);
            }
        }

        public string GetString()
        {
            unsafe
            {
                var size = 0;
                var value = core.Library.Shared.MValueConst_GetString(nativePointer, &size);
                return core.PtrToStringUtf8AndFree(value, size);
            }
        }

        public IntPtr GetEntityPointer(ref BaseObjectType baseObjectType)
        {
            unsafe
            {
                BaseObjectType pType;
                var result = core.Library.Shared.MValueConst_GetEntity(nativePointer, &pType);
                baseObjectType = pType;
                return result;
            }
        }

        public ISharedBaseObject GetBaseObject()
        {
            var baseObjectType = BaseObjectType.Undefined;
            var baseObjectPtr = GetEntityPointer(ref baseObjectType);
            return core.BaseBaseObjectPool.Get(baseObjectPtr, baseObjectType);
        }

        public IMValueConst[] GetList()
        {
            unsafe
            {
                var size = core.Library.Shared.MValueConst_GetListSize(nativePointer);
                if (size == 0) return Array.Empty<IMValueConst>();
                var mValuePointers = new IntPtr[size];
                core.Library.Shared.MValueConst_GetList(nativePointer, mValuePointers);
                return (IMValueConst[]) CreateFrom(core, mValuePointers);
            }
        }

        public Dictionary<string, IMValueConst> GetDictionary()
        {
            unsafe
            {
                var size = core.Library.Shared.MValueConst_GetDictSize(nativePointer);
                if (size == 0) return new Dictionary<string, IMValueConst>();
                var keyPointers = new IntPtr[size];
                var mValuePointers = new IntPtr[size];
                core.Library.Shared.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers);

                var dictionary = new Dictionary<string, IMValueConst>();

                for (ulong i = 0; i < size; i++)
                {
                    var keyPointer = keyPointers[i];
                    var mValue = new MValueConst(core, mValuePointers[i]);
                    dictionary[Marshal.PtrToStringUTF8(keyPointer)] = mValue;
                    core.Library.Shared.FreeCharArray(keyPointer);
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

                result = new MValueConst(core, 
                    core.Library.Shared.MValueConst_CallFunction(core.NativePointer, nativePointer, argsPointers,
                        length));
            }
        }

        public Position GetVector3()
        {
            unsafe
            {
                var position = Vector3.Zero;
                core.Library.Shared.MValueConst_GetVector3(nativePointer, &position);
                return position;
            }
        }

        public Rgba GetRgba()
        {
            unsafe
            {
                var rgba = Rgba.Zero;
                core.Library.Shared.MValueConst_GetRGBA(nativePointer, &rgba);
                return rgba;
            }
        }

        public byte[] GetByteArray()
        {
            unsafe
            {
                var size = core.Library.Shared.MValueConst_GetByteArraySize(nativePointer);
                var sizeInt = (int) size;
                var data = Marshal.AllocHGlobal(sizeInt);
                core.Library.Shared.MValueConst_GetByteArray(nativePointer, size, data);
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

        public MValueConstCached GetCached()
        {
            object value;
            switch (type)
            {
                case MValueType.None:
                    value = None;
                    break;
                case MValueType.Nil:
                    value = null;
                    break;
                case MValueType.Bool:
                    value = GetBool();
                    break;
                case MValueType.Int:
                    value = GetInt();
                    break;
                case MValueType.Uint:
                    value = GetUint();
                    break;
                case MValueType.Double:
                    value = GetDouble();
                    break;
                case MValueType.String:
                    value = GetString();
                    break;
                case MValueType.Function:
                    value = null; // todo
                    break;
                case MValueType.Vector3:
                    value = GetVector3();
                    break;
                case MValueType.Rgba:
                    value = GetRgba();
                    break;
                case MValueType.ByteArray:
                    value = GetByteArray();
                    break;
                case MValueType.List:
                    unsafe
                    {
                        var listSize = core.Library.Shared.MValueConst_GetListSize(nativePointer);
                        if (listSize == 0)
                        {
                            value = Array.Empty<IMValueConst>();
                            break;
                        }
                        
                        var mValueListPointers = new IntPtr[listSize];
                        core.Library.Shared.MValueConst_GetList(nativePointer, mValueListPointers);
                        var arrayValues = new IMValueConst[listSize];
                        for (ulong i = 0; i < listSize; i++)
                        {
                            var mValue = new MValueConst(core, mValueListPointers[i]);
                            arrayValues[i] = mValue.GetCached();
                            mValue.Dispose();
                        }

                        value = arrayValues;
                        break;
                    }
                    
                case MValueType.Dict:
                    unsafe
                    {
                        var size = core.Library.Shared.MValueConst_GetDictSize(nativePointer);
                        if (size == 0)
                        {
                            value = new Dictionary<string, IMValueConst>();
                            break;
                        }
                        
                        var keyPointers = new IntPtr[size];
                        var mValuePointers = new IntPtr[size];
                        if (core.Library.Shared.MValueConst_GetDict(nativePointer, keyPointers, mValuePointers) == 0)
                            return null;

                        var dictionary = new Dictionary<string, IMValueConst>();

                        for (ulong i = 0; i < size; i++)
                        {
                            var keyPointer = keyPointers[i];
                            var mValue = new MValueConst(core, mValuePointers[i]);
                            dictionary[Marshal.PtrToStringUTF8(keyPointer)] = mValue.GetCached();
                            core.Library.Shared.FreeCharArray(keyPointer);
                            mValue.Dispose();
                        }

                        value = dictionary;
                        break;
                    }

                case MValueType.BaseObject:
                    var entityType = BaseObjectType.Undefined;
                    var entityPointer = GetEntityPointer(ref entityType);
                    if (entityPointer == IntPtr.Zero) return null;
                    value = core.BaseBaseObjectPool.GetOrCreate(core, entityPointer, entityType);
                    break;
                
                default:
                    value = null;
                    break;
            }

            return new MValueConstCached(value, type);
        }

        public override string ToString()
        {
            switch (type)
            {
                case MValueType.None:
                    return "MValueNone<>";
                case MValueType.Nil:
                    return "MValueNil<>";
                case MValueType.Bool:
                    return "MValueBool<" + GetBool() + ">";
                case MValueType.Int:
                    return "MValueInt<" + GetInt() + ">";
                case MValueType.Uint:
                    return "MValueUInt<" + GetUint() + ">";
                case MValueType.Double:
                    return "MValueDouble<" + GetDouble().ToString(CultureInfo.InvariantCulture) + ">";
                case MValueType.String:
                    return "MValueString<" + GetString() + ">";
                case MValueType.List:
                    return "MValueList<{" + GetList().Aggregate("", (current, value) =>
                    {
                        var result = current + value + ",";
                        value.Dispose();
                        return result;
                    }) + "}>";
                case MValueType.Dict:
                    return "MValueDict<{" + GetDictionary().Aggregate("",
                               (current, value) =>
                               {
                                   var (key, mValueConst) = value;
                                   var result = current + key.ToString() + "=" + mValueConst.ToString() + ",";
                                   mValueConst.Dispose();
                                   return result;
                               }) + "}>";
                case MValueType.BaseObject:
                    var entityType = BaseObjectType.Undefined;
                    var ptr = GetEntityPointer(ref entityType);
                    if (ptr == IntPtr.Zero) return $"MValue<entity:nilptr>";
                    var entity = core.BaseBaseObjectPool.Get(ptr, entityType);
                    if (entity != null)
                    {
                        return $"MValue<{entity.Type.ToString()}>";
                    }

                    return "MValue<Entity>";
                case MValueType.Function:
                    return "MValue<Function>";
                case MValueType.Vector3:
                    var position = GetVector3();
                    return $"MValue<Vector3<{position.X},{position.Y},{position.Z}>>";
                case MValueType.Rgba:
                    var rgba = GetRgba();
                    return $"MValue<Rgba<{rgba.R},{rgba.G},{rgba.B},{rgba.A}>>";
                case MValueType.ByteArray:
                    unsafe
                    {
                        return $"MValueByteArray<{core.Library.Shared.MValueConst_GetByteArraySize(nativePointer)}>";
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
                core.Library.Shared.MValueConst_AddRef(nativePointer);
            }
        }

        public void RemoveRef()
        {
            unsafe
            {
                // Nil types have zero int ptr to reduce allocations on heap
                if (nativePointer == IntPtr.Zero) return;
                core.Library.Shared.MValueConst_RemoveRef(nativePointer);
            }
        }

        public void Dispose()
        {
            unsafe
            {
                // Nil types have zero int ptr to reduce allocations on heap
                if (nativePointer == IntPtr.Zero) return;
                core.Library.Shared.MValueConst_Delete(nativePointer);
            }
        }

        [Obsolete]
        public object ToObject()
        {
            return null!;
        }
    }
}