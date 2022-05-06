using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Entities
{
    public class Entity : WorldObject, IEntity
    {
        private static IntPtr GetWorldObjectPointer(ICore core, IntPtr entityPointer)
        {
            unsafe
            {
                return core.Library.Shared.Entity_GetWorldObject(entityPointer);
            }
        }

        public IntPtr EntityNativePointer { get; }
        public override IntPtr NativePointer => EntityNativePointer;

        public Entity(ICore core, IntPtr entityPointer, ushort id, BaseObjectType type) : base(core, GetWorldObjectPointer(core, entityPointer), type)
        {
            Id = id;
            EntityNativePointer = entityPointer;
        }

        public ushort Id { get; }

        public uint Model
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Entity_GetModel(EntityNativePointer);
                }
            }
        }

        public IPlayer? NetworkOwner
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var ptr = Core.Library.Shared.Entity_GetNetOwner(EntityNativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    return Alt.Core.PlayerPool.Get(ptr);
                }
            }
        }
        ISharedPlayer ISharedEntity.NetworkOwner => NetworkOwner!;

        public int ScriptId
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.Entity_GetScriptID(EntityNativePointer);
                }
            }
        }

        public bool Spawned => ScriptId != 0;

        public Rotation Rotation
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Rotation.Zero;
                    this.Core.Library.Shared.Entity_GetRotation(this.EntityNativePointer, &position);
                    return position;
                }
            }
        }

        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            CheckIfEntityExists();
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Core, Core.Library.Shared.Entity_GetSyncedMetaData(EntityNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool HasSyncedMetaData(string key)
        {
            CheckIfEntityExists();
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Shared.Entity_HasSyncedMetaData(EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            CheckIfEntityExists();
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Core, Core.Library.Shared.Entity_GetStreamSyncedMetaData(EntityNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            CheckIfEntityExists();
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Shared.Entity_HasStreamSyncedMetaData(EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public bool GetSyncedMetaData<T>(string key, out T result)
        {
            CheckIfEntityExists();
            GetSyncedMetaData(key, out MValueConst mValue);
            var obj = mValue.ToObject();
            mValue.Dispose();
            if (!(obj is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }


        public bool GetStreamSyncedMetaData<T>(string key, out T result)
        {
            CheckIfEntityExists();
            GetStreamSyncedMetaData(key, out MValueConst mValue);
            var obj = mValue.ToObject();
            mValue.Dispose();
            if (!(obj is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public bool GetSyncedMetaData(string key, out int result)
        {
            CheckIfEntityExists();
            GetSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Int)
                {
                    result = default;
                    return false;
                }

                result = (int) mValue.GetInt();
            }

            return true;
        }

        public bool GetSyncedMetaData(string key, out uint result)
        {
            CheckIfEntityExists();
            GetSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Uint)
                {
                    result = default;
                    return false;
                }

                result = (uint) mValue.GetUint();
            }

            return true;
        }

        public bool GetSyncedMetaData(string key, out float result)
        {
            CheckIfEntityExists();
            GetSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Double)
                {
                    result = default;
                    return false;
                }

                result = (float) mValue.GetDouble();
            }

            return true;
        }

        public bool GetStreamSyncedMetaData(string key, out int result)
        {
            CheckIfEntityExists();
            GetStreamSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Int)
                {
                    result = default;
                    return false;
                }

                result = (int) mValue.GetInt();
            }

            return true;
        }

        public bool GetStreamSyncedMetaData(string key, out uint result)
        {
            CheckIfEntityExists();
            GetStreamSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Uint)
                {
                    result = default;
                    return false;
                }

                result = (uint) mValue.GetUint();
            }

            return true;
        }

        public bool GetStreamSyncedMetaData(string key, out float result)
        {
            CheckIfEntityExists();
            GetStreamSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Double)
                {
                    result = default;
                    return false;
                }

                result = (float) mValue.GetDouble();
            }

            return true;
        }

        public override void CheckIfEntityExists()
        {
            CheckIfCallIsValid();
            if (Exists) return;

            throw new EntityRemovedException(this);
        }
    }
}