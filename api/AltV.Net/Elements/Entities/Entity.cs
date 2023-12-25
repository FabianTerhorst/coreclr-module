using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Elements.Entities
{
    public abstract class Entity : WorldObject, IEntity
    {
        public IntPtr EntityNativePointer { get; private set; }
        public override IntPtr NativePointer => EntityNativePointer;

        private static IntPtr GetWorldObjectNativePointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Shared.Entity_GetWorldObject(nativePointer);
            }
        }

        public IPlayer NetworkOwner
        {
            get
            {
                CheckIfEntityExistsOrCached();
                unsafe
                {
                    var entityPointer = Core.Library.Shared.Entity_GetNetOwner(EntityNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Core.PoolManager.Player.Get(entityPointer);
                }
            }
        }

        ISharedPlayer ISharedEntity.NetworkOwner => NetworkOwner;

        public Rotation Rotation
        {
            get
            {
                CheckIfEntityExistsOrCached();
                unsafe
                {
                    var rotation = Rotation.Zero;
                    Core.Library.Shared.Entity_GetRotation(EntityNativePointer, &rotation);
                    return rotation;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Shared.Entity_SetRotation(EntityNativePointer, value);
                }
            }
        }

        public abstract uint Model { get; set; }

        public bool Visible
        {
            get
            {
                CheckIfEntityExistsOrCached();
                unsafe
                {
                    return Core.Library.Server.Entity_GetVisible(EntityNativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Server.Entity_SetVisible(EntityNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public bool Streamed
        {
            get
            {
                CheckIfEntityExistsOrCached();
                unsafe
                {
                    return Core.Library.Server.Entity_GetStreamed(EntityNativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Server.Entity_SetStreamed(EntityNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public void SetNetworkOwner(IPlayer player, bool disableMigration)
        {
            CheckIfEntityExists();
            unsafe
            {
                Core.Library.Server.Entity_SetNetOwner(EntityNativePointer, player?.PlayerNativePointer ?? IntPtr.Zero,
                    disableMigration ? (byte)1 : (byte)0);
            }
        }

        public void SetStreamSyncedMetaData(Dictionary<string, object> metaData)
        {
            unsafe
            {
                var dataTemp = new Dictionary<IntPtr, MValueConst>();

                var keys = new IntPtr[metaData.Count];
                var values = new IntPtr[metaData.Count];

                for (var i = 0; i < metaData.Count; i++)
                {
                    var stringPtr = MemoryUtils.StringToHGlobalUtf8(metaData.ElementAt(i).Key);
                    Core.CreateMValue(out var mValue, metaData.ElementAt(i).Value);
                    keys[i] = stringPtr;
                    values[i] = mValue.nativePointer;
                    dataTemp.Add(stringPtr, mValue);
                }

                Core.Library.Server.Entity_SetMultipleStreamSyncedMetaData(EntityNativePointer, keys, values,
                    (uint)dataTemp.Count);

                foreach (var dataValue in dataTemp)
                {
                    dataValue.Value.Dispose();
                    Marshal.FreeHGlobal(dataValue.Key);
                }
            }
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.Entity_SetStreamSyncedMetaData(EntityNativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Core,
                    Core.Library.Shared.Entity_GetStreamSyncedMetaData(EntityNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            CheckIfEntityExistsOrCached();
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Shared.Entity_HasStreamSyncedMetaData(EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public void DeleteStreamSyncedMetaData(string key)
        {
            CheckIfEntityExists();
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.Entity_DeleteStreamSyncedMetaData(EntityNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetStreamSyncedMetaData(string key, object value)
        {
            CheckIfEntityExists();
            Alt.Core.CreateMValue(out var mValue, value);
            SetStreamSyncedMetaData(key, in mValue);
            mValue.Dispose();
        }

        public bool GetStreamSyncedMetaData<T>(string key, out T result)
        {
            CheckIfEntityExistsOrCached();
            GetStreamSyncedMetaData(key, out MValueConst mValue);

            if (!Core.FromMValue(mValue, typeof(T), out var obj))
                obj = mValue.ToObject();

            mValue.Dispose();
            if (obj is not T cast)
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public bool GetStreamSyncedMetaData(string key, out int result)
        {
            CheckIfEntityExistsOrCached();
            GetStreamSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Int)
                {
                    result = default;
                    return false;
                }

                result = (int)mValue.GetInt();
            }

            return true;
        }

        public bool GetStreamSyncedMetaData(string key, out uint result)
        {
            CheckIfEntityExistsOrCached();
            GetStreamSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Uint)
                {
                    result = default;
                    return false;
                }

                result = (uint)mValue.GetUint();
            }

            return true;
        }

        public bool GetStreamSyncedMetaData(string key, out float result)
        {
            CheckIfEntityExistsOrCached();
            GetStreamSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Double)
                {
                    result = default;
                    return false;
                }

                result = (float)mValue.GetDouble();
            }

            return true;
        }

        public void ResetNetworkOwner()
        {
            SetNetworkOwner(null, false);
        }

        public void AttachToEntity(IEntity entity, ushort otherBoneId, ushort ownBoneId, Position position,
            Rotation rotation,
            bool collision, bool noFixedRotation)
        {
            unsafe
            {
                CheckIfEntityExists();
                if (entity == null) return;
                entity.CheckIfEntityExists();

                Core.Library.Server.Entity_AttachToEntity(EntityNativePointer, entity.EntityNativePointer, otherBoneId,
                    ownBoneId, position, rotation, collision ? (byte)1 : (byte)0, noFixedRotation ? (byte)1 : (byte)0);
            }
        }

        public void AttachToEntity(IEntity entity, string otherBone, string ownBone, Position position,
            Rotation rotation,
            bool collision, bool noFixedRotation)
        {
            unsafe
            {
                CheckIfEntityExists();
                if (entity == null) return;
                entity.CheckIfEntityExists();

                var otherBonePtr = MemoryUtils.StringToHGlobalUtf8(otherBone);
                var ownBonePtr = MemoryUtils.StringToHGlobalUtf8(ownBone);
                Core.Library.Server.Entity_AttachToEntity_BoneString(EntityNativePointer, entity.EntityNativePointer,
                    otherBonePtr, ownBonePtr, position, rotation, collision ? (byte)1 : (byte)0,
                    noFixedRotation ? (byte)1 : (byte)0);
            }
        }

        public void Detach()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Entity_Detach(EntityNativePointer);
            }
        }

        public uint Timestamp
        {
            get
            {
                CheckIfEntityExistsOrCached();
                unsafe
                {
                    return Core.Library.Server.Entity_GetTimestamp(EntityNativePointer);
                }
            }
        }

        public uint StreamingDistance
        {
            get
            {
                CheckIfEntityExistsOrCached();
                unsafe
                {
                    return Core.Library.Server.Entity_GetStreamingDistance(EntityNativePointer);
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Server.Entity_SetStreamingDistance(EntityNativePointer, value);
                }
            }
        }

        public bool Frozen
        {
            get
            {
                CheckIfEntityExistsOrCached();
                unsafe
                {
                    return Core.Library.Shared.Entity_IsFrozen(EntityNativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Shared.Entity_SetFrozen(EntityNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public bool Collision
        {
            get
            {
                CheckIfEntityExistsOrCached();
                unsafe
                {
                    return Core.Library.Server.Entity_HasCollision(EntityNativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Server.Entity_SetCollision(EntityNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        protected Entity(ICore core, IntPtr nativePointer, BaseObjectType type, uint id) : base(core,
            GetWorldObjectNativePointer(core, nativePointer), type, id)
        {
            EntityNativePointer = nativePointer;
        }

        public override void CheckIfEntityExists()
        {
            CheckIfCallIsValid();
            if (Exists) return;

            throw new EntityRemovedException(this);
        }

        public override void SetCached(IntPtr cachedEntity)
        {
            this.EntityNativePointer = cachedEntity;
            base.SetCached(GetWorldObjectNativePointer(Core, cachedEntity));
        }
    }
}