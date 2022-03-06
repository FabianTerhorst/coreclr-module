using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public abstract class Entity : WorldObject, IEntity
    {
        public IntPtr EntityNativePointer { get; }
        public override IntPtr NativePointer => EntityNativePointer;
        
        private static IntPtr GetWorldObjectNativePointer(IServer server, IntPtr nativePointer)
        {
            unsafe
            {
                return server.Library.Shared.Entity_GetWorldObject(nativePointer);
            }
        }
        
        public ushort Id { get; }
        
        public IPlayer NetworkOwner
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    var entityPointer = Server.Library.Shared.Entity_GetNetOwner(EntityNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.PlayerPool.Get(entityPointer, out var player) ? player : null;
                }
            }
        }
        
        public Rotation Rotation
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    var rotation = Rotation.Zero;
                    Server.Library.Shared.Entity_GetRotation(EntityNativePointer, &rotation);
                    return rotation;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Server.Entity_SetRotation(EntityNativePointer, value);
                }
            }
        }

        public abstract uint Model { get; set; }

        public bool Visible
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Server.Library.Server.Entity_GetVisible(EntityNativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Server.Entity_SetVisible(EntityNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool Streamed
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Server.Library.Server.Entity_GetStreamed(EntityNativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Server.Entity_SetStreamed(EntityNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public void SetNetworkOwner(IPlayer player, bool disableMigration)
        {
            CheckIfEntityExists();
            unsafe
            {
                Server.Library.Server.Entity_SetNetOwner(EntityNativePointer, player?.PlayerNativePointer ?? IntPtr.Zero, disableMigration ? (byte) 1 : (byte) 0);
            }
        }

        public void SetSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Server.Entity_SetSyncedMetaData(EntityNativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Shared.Entity_GetSyncedMetaData(EntityNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool HasSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Shared.Entity_HasSyncedMetaData(EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public void DeleteSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Server.Entity_DeleteSyncedMetaData(EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Server.Entity_SetStreamSyncedMetaData(EntityNativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Shared.Entity_GetStreamSyncedMetaData(EntityNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Shared.Entity_HasStreamSyncedMetaData(EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public void DeleteStreamSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Server.Entity_DeleteStreamSyncedMetaData(EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        
        public void SetSyncedMetaData(string key, object value)
        {
            CheckIfEntityExists();
            Alt.Server.CreateMValue(out var mValue, value);
            SetSyncedMetaData(key, in mValue);
            mValue.Dispose();
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
        
        public void SetStreamSyncedMetaData(string key, object value)
        {
            CheckIfEntityExists();
            Alt.Server.CreateMValue(out var mValue, value);
            SetStreamSyncedMetaData(key, in mValue);
            mValue.Dispose();
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

        public void ResetNetworkOwner()
        {
            SetNetworkOwner(null, false);
        }

        public abstract void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position,
            Rotation rotation,
            bool collision, bool noFixedRotation);

        public abstract void Detach();

        protected Entity(IServer server, IntPtr nativePointer, BaseObjectType type, ushort id) : base(server, GetWorldObjectNativePointer(server, nativePointer), type)
        {
            EntityNativePointer = nativePointer;
            Id = id;
        }

        public override void CheckIfEntityExists()
        {
            CheckIfCallIsValid();
            if (Exists) return;

            throw new EntityRemovedException(this);
        }
    }
}