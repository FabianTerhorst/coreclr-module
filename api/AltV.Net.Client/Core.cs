using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using AltV.Net.Client.CApi;
using AltV.Net.Client.CApi.Memory;
using AltV.Net.Client.Data;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Args;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;

namespace AltV.Net.Client
{
    public partial class Core : ICore
    {
        public ILibrary Library { get; }
        public IntPtr NativePointer { get; }
        
        public IPlayerPool PlayerPool { get; }
        public IEntityPool<IVehicle> VehiclePool { get; }
        
        public INativeResource Resource { get; }
        public ILogger Logger { get; }

        public List<SafeTimer> RunningTimers { get; } = new();

        public Core(ILibrary library, IntPtr nativePointer, IntPtr resourcePointer, IPlayerPool playerPool, IEntityPool<IVehicle> vehiclePool, INativeResourcePool nativeResourcePool, ILogger logger)
        {
            Library = library;
            NativePointer = nativePointer;
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
            Logger = logger;
            nativeResourcePool.GetOrCreate(this, resourcePointer, out var resource);
            Resource = resource;
        }

        #region Log
        public void LogInfo(string message) => Logger.LogInfo(message);
        public void LogWarning(string message) => Logger.LogWarning(message);
        public void LogError(string message) => Logger.LogError(message);
        public void LogDebug(string message) => Logger.LogDebug(message);
        #endregion

        #region MValue
        public void CreateMValueNil(out MValueConst mValue)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Nil, Library.Core_CreateMValueNil(NativePointer));
            }
        }

        public void CreateMValueBool(out MValueConst mValue, bool value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Bool,
                    Library.Core_CreateMValueBool(NativePointer, value ? (byte) 1 : (byte) 0));
            }
        }

        public void CreateMValueInt(out MValueConst mValue, long value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Int, Library.Core_CreateMValueInt(NativePointer, value));
            }
        }

        public void CreateMValueUInt(out MValueConst mValue, ulong value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Uint,
                    Library.Core_CreateMValueUInt(NativePointer, value));
            }
        }

        public void CreateMValueDouble(out MValueConst mValue, double value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Double,
                    Library.Core_CreateMValueDouble(NativePointer, value));
            }
        }

        public void CreateMValueString(out MValueConst mValue, string value)
        {
            unsafe
            {
                var valuePtr = MemoryUtils.StringToHGlobalUtf8(value);
                mValue = new MValueConst(MValueConst.Type.String,
                    Library.Core_CreateMValueString(NativePointer, valuePtr));
                Marshal.FreeHGlobal(valuePtr);
            }
        }


        public void CreateMValueList(out MValueConst mValue, MValueConst[] val, ulong size)
        {
            unsafe
            {
                var pointers = new IntPtr[size];
                for (ulong i = 0; i < size; i++)
                {
                    pointers[i] = val[i].nativePointer;
                }

                mValue = new MValueConst(MValueConst.Type.List,
                    Library.Core_CreateMValueList(NativePointer, pointers, size));
            }
        }

        public void CreateMValueDict(out MValueConst mValue, string[] keys, MValueConst[] val, ulong size)
        {
            unsafe
            {
                var pointers = new IntPtr[size];
                for (ulong i = 0; i < size; i++)
                {
                    pointers[i] = val[i].nativePointer;
                }

                var keyPointers = new IntPtr[size];
                for (ulong i = 0; i < size; i++)
                {
                    keyPointers[i] = MemoryUtils.StringToHGlobalUtf8(keys[i]);
                }

                mValue = new MValueConst(MValueConst.Type.Dict,
                    Library.Core_CreateMValueDict(NativePointer, keyPointers, pointers, size));
                for (ulong i = 0; i < size; i++)
                {
                    Marshal.FreeHGlobal(keyPointers[i]);
                }
            }
        }


        public void CreateMValueVector3(out MValueConst mValue, Vector3 value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Vector3,
                    Library.Core_CreateMValueVector3(NativePointer, value));
            }
        }

        public void CreateMValueVector2(out MValueConst mValue, Vector2 value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Vector2,
                    Library.Core_CreateMValueVector2(NativePointer, value));
            }
        }

        public void CreateMValueRgba(out MValueConst mValue, Rgba value)
        {
            unsafe
            {
                mValue = new MValueConst(MValueConst.Type.Rgba,
                    Library.Core_CreateMValueRgba(NativePointer, value));
            }
        }

        public void CreateMValueByteArray(out MValueConst mValue, byte[] value)
        {
            unsafe
            {
                var size = value.Length;
                var dataPtr = Marshal.AllocHGlobal(size);
                Marshal.Copy(value, 0, dataPtr, size);
                mValue = new MValueConst(MValueConst.Type.ByteArray,
                    Library.Core_CreateMValueByteArray(NativePointer, (ulong) size, dataPtr));
                Marshal.FreeHGlobal(dataPtr);
            }
        }

        public void CreateMValue(out MValueConst mValue, object? obj)
        {
            if (obj == null)
            {
                mValue = MValueConst.Nil;
                return;
            }

            int i;

            string[] dictKeys;
            MValueConst[] dictValues;

            switch (obj)
            {
                // todo IPlayer
                // todo IVehicle
                // todo IBlip
                // todo ICheckpoint
                case bool value:
                    CreateMValueBool(out mValue, value);
                    return;
                case int value:
                    CreateMValueInt(out mValue, value);
                    return;
                case uint value:
                    CreateMValueUInt(out mValue, value);
                    return;
                case long value:
                    CreateMValueInt(out mValue, value);
                    return;
                case ulong value:
                    CreateMValueUInt(out mValue, value);
                    return;
                case double value:
                    CreateMValueDouble(out mValue, value);
                    return;
                case float value:
                    CreateMValueDouble(out mValue, value);
                    return;
                case string value:
                    CreateMValueString(out mValue, value);
                    return;
                case MValueConst value:
                    mValue = value;
                    return;
                case MValueConst[] value:
                    CreateMValueList(out mValue, value, (ulong) value.Length);
                    return;
                // todo Invoker
                // todo MValueFunctionCallback
                // todo Function
                case byte[] byteArray:
                    CreateMValueByteArray(out mValue, byteArray);
                    return;
                case IDictionary dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        if (key is string stringKey)
                        {
                            dictKeys[i++] = stringKey;
                        }
                        else
                        {
                            mValue = MValueConst.Nil;
                            return;
                        }
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }

                    CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictionary.Count; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }

                    return;
                case ICollection collection:
                    var length = (ulong) collection.Count;
                    var listValues = new MValueConst[length];
                    i = 0;
                    foreach (var value in collection)
                    {
                        CreateMValue(out var elementMValue, value);
                        listValues[i++] = elementMValue;
                    }

                    CreateMValueList(out mValue, listValues, length);
                    for (ulong j = 0; j < length; j++)
                    {
                        listValues[j].Dispose();
                    }

                    return;
                case IDictionary<string, object> dictionary:
                    dictKeys = new string[dictionary.Count];
                    dictValues = new MValueConst[dictionary.Count];
                    i = 0;
                    foreach (var key in dictionary.Keys)
                    {
                        dictKeys[i++] = key;
                    }

                    i = 0;
                    foreach (var value in dictionary.Values)
                    {
                        CreateMValue(out var elementMValue, value);
                        dictValues[i++] = elementMValue;
                    }

                    CreateMValueDict(out mValue, dictKeys, dictValues, (ulong) dictionary.Count);
                    for (int j = 0, dictLength = dictionary.Count; j < dictLength; j++)
                    {
                        dictValues[j].Dispose();
                    }

                    return;
                // todo IWritable
                // todo IMValueConvertible
                case Rgba rgba:
                    CreateMValueRgba(out mValue, rgba);
                    return;
                case short value:
                    CreateMValueInt(out mValue, value);
                    return;
                case ushort value:
                    CreateMValueUInt(out mValue, value);
                    return;
                case Vector3 position:
                    CreateMValueVector3(out mValue, position);
                    return;
                case Vector2 value:
                    CreateMValueVector2(out mValue, value);
                    return;
                default:
                    Alt.Log("can't convert type:" + obj.GetType());
                    mValue = MValueConst.Nil;
                    return;
            }
        }
        #endregion
        
        public uint Hash(string stringToHash)
        {
            if (string.IsNullOrEmpty(stringToHash)) return 0;

            var characters = Encoding.UTF8.GetBytes(stringToHash.ToLower());

            uint hash = 0;

            foreach (var c in characters)
            {
                hash += c;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return hash;
        }
        
        // public bool GetEntityById(ushort id, [MaybeNullWhen(false)] out IEntity entity)
        // {
        //     unsafe
        //     {
        //         byte type = 0;
        //         entity = default;
        //         if (this.Core.Library.Entity_GetTypeByID(this.Core.NativePointer, id, &type) != 1) return false;
        //         
        //         switch ((BaseObjectType) type)
        //         {
        //             case BaseObjectType.Player:
        //             case BaseObjectType.LocalPlayer:
        //             {
        //                 entity = PlayerPool.Get(id);
        //                 return entity is not null;
        //             }
        //             case BaseObjectType.Vehicle:
        //             {
        //                 entity = VehiclePool.Get(id);
        //                 return entity is not null;
        //             }
        //             // todo
        //             default:
        //                 return false;
        //         }
        //     }
        // }

        public HandlingData? GetHandlingByModelHash(uint modelHash)
        {
            unsafe
            {
                var pointer = IntPtr.Zero;
                var success = Library.Vehicle_Handling_GetByModelHash(NativePointer, modelHash, &pointer);
                if (success == 0 || pointer == IntPtr.Zero) return null;
                return new HandlingData(this, pointer);
            }
        }
    }
}