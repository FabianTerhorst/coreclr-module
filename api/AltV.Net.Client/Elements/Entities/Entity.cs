using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Client.CApi.Memory;
using AltV.Net.Client.Elements.Args;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Entities
{
    public class Entity : WorldObject, IEntity
    {
        private static IntPtr GetWorldObjectPointer(ICore core, IntPtr entityPointer)
        {
            unsafe
            {
                return core.Library.Entity_GetWorldObject(entityPointer);
            }
        }
        
        public IntPtr EntityNativePointer { get; }
        
        public Entity(ICore core, IntPtr entityPointer, ushort id) : base(core, GetWorldObjectPointer(core, entityPointer))
        {
            Id = id;
            EntityNativePointer = entityPointer;
        }

        public ushort Id { get; }
        public bool Exists => true; // todo

        public uint Model
        {
            get
            {
                unsafe
                {
                    return Core.Library.Entity_GetModel(EntityNativePointer);
                }
            }
        }

        public IPlayer? NetOwner
        {
            get
            {
                unsafe
                {
                    byte exists = 0;
                    ushort id = 0;
                    Core.Library.Entity_GetNetOwnerId(EntityNativePointer, &exists, &id);
                    Alt.Log("exists: " + exists + " id: " + id);
                    if (exists != 1) return null;
                    if (!Alt.Module.PlayerPool.Get(id, out var player)) return null;
                    return player;
                }
            }
        }

        public int ScriptID
        {
            get
            {
                unsafe
                {
                    return Core.Library.Entity_GetScriptID(EntityNativePointer);
                }
            }
        }

        public bool Spawned => ScriptID != 0;

        public Vector3 Rotation
        {
            get
            {
                unsafe
                {
                    
                    var position = Vector3.Zero;
                    this.Core.Library.Entity_GetRotation(this.EntityNativePointer, &position);
                    return position;
                }
            }
        }
        
        private MValueConst GetStreamSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var mValue = new MValueConst(Core.Library.Entity_GetStreamSyncedMetaData(this.EntityNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
                return mValue;
            }
        }
        
        public bool HasStreamSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Entity_HasStreamSyncedMetaData(this.EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public bool GetStreamSyncedMetaData(string key, out int value)
        {
            using var mValue = GetStreamSyncedMetaData(key);
            value = default;
            if (mValue.type != MValueConst.Type.Int) return false;

            value = (int) mValue.GetInt();
            return true;
        }
        
        public bool GetStreamSyncedMetaData(string key, out uint value)
        {
            using var mValue = GetStreamSyncedMetaData(key);
            value = default;
            if (mValue.type != MValueConst.Type.Uint) return false;

            value = (uint) mValue.GetUint();
            return true;
        }
        
        public bool GetStreamSyncedMetaData(string key, out float value)
        {
            using var mValue = GetStreamSyncedMetaData(key);
            value = default;
            if (mValue.type != MValueConst.Type.Double) return false;

            value = (float) mValue.GetDouble();
            return true;
        }
        
        public bool GetStreamSyncedMetaData<T>(string key, out T? value)
        {
            using var mValue = GetStreamSyncedMetaData(key);
            var obj = mValue.ToObject();
            if (obj is not T convertedObj)
            {
                value = default;
                return false;
            }

            value = convertedObj;
            return true;
        }
        
        private MValueConst GetSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var mValue = new MValueConst(Core.Library.Entity_GetSyncedMetaData(this.EntityNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
                return mValue;
            }
        }
        
        public bool HasSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Entity_HasSyncedMetaData(this.EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public bool GetSyncedMetaData(string key, out int value)
        {
            using var mValue = GetSyncedMetaData(key);
            value = default;
            if (mValue.type != MValueConst.Type.Int) return false;

            value = (int) mValue.GetInt();
            return true;
        }
        
        public bool GetSyncedMetaData(string key, out uint value)
        {
            using var mValue = GetSyncedMetaData(key);
            value = default;
            if (mValue.type != MValueConst.Type.Uint) return false;

            value = (uint) mValue.GetUint();
            return true;
        }
        
        public bool GetSyncedMetaData(string key, out float value)
        {
            using var mValue = GetSyncedMetaData(key);
            value = default;
            if (mValue.type != MValueConst.Type.Double) return false;

            value = (float) mValue.GetDouble();
            return true;
        }
        
        public bool GetSyncedMetaData<T>(string key, out T? value)
        {
            using var mValue = GetSyncedMetaData(key);
            var obj = mValue.ToObject();
            if (obj is not T convertedObj)
            {
                value = default;
                return false;
            }

            value = convertedObj;
            return true;
        }
    }
}