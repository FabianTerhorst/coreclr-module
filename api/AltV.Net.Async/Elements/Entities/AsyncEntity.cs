using System;
using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncEntity<TEntity> : AsyncWorldObject<TEntity>, IEntity where TEntity : class, IEntity
    {
        public IntPtr EntityNativePointer => BaseObject.EntityNativePointer;
        
        public ushort Id => BaseObject.Id;

        public IPlayer NetworkOwner
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return null;
                    return BaseObject.NetworkOwner;
                }
            }
        }
        ISharedPlayer ISharedEntity.NetworkOwner => NetworkOwner;
        
        public Rotation Rotation
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Rotation;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Rotation = value;
                }
            }
        }

        public virtual uint Model
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Model;
                }
            }
        }

        public bool Visible
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Visible;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Visible = value;
                }
            }
        }

        public bool Streamed
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Streamed;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Streamed = value;
                }
            }
        }

        public AsyncEntity(TEntity entity, IAsyncContext asyncContext) : base(entity, asyncContext)
        {
        }

        public void SetNetworkOwner(IPlayer player, bool disableMigration = true)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetNetworkOwner(player, disableMigration);
            }
        }

        public void ResetNetworkOwner()
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.ResetNetworkOwner();
            }
        }

        public void SetSyncedMetaData(string key, object value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetSyncedMetaData(key, value);
            }
        }

        public bool GetSyncedMetaData<T1>(string key, out T1 result)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    result = default;
                    return false;
                }

                return BaseObject.GetSyncedMetaData(key, out result);
            }
        }

        public void SetStreamSyncedMetaData(string key, object value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetStreamSyncedMetaData(key, value);
            }
        }

        public bool GetStreamSyncedMetaData<T1>(string key, out T1 result)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    result = default;
                    return false;
                }

                return BaseObject.GetStreamSyncedMetaData(key, out result);
            }
        }

        public void SetSyncedMetaData(string key, in MValueConst value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetSyncedMetaData(key, in value);
            }
        }

        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    value = MValueConst.Nil;
                    return;
                }

                BaseObject.GetSyncedMetaData(key, out value);
            }
        }

        public bool GetSyncedMetaData(string key, out int value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetSyncedMetaData(key, out value);
            }
        }

        public bool GetSyncedMetaData(string key, out uint value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetSyncedMetaData(key, out value);
            }
        }

        public bool GetSyncedMetaData(string key, out float value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetSyncedMetaData(key, out value);
            }
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.SetSyncedMetaData(key, in value);
            }
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    value = MValueConst.Nil;
                    return;
                }

                BaseObject.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out int value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out uint value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out float value)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool HasSyncedMetaData(string key)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.HasSyncedMetaData(key);
            }
        }

        public void DeleteSyncedMetaData(string key)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.DeleteSyncedMetaData(key);
            }
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                return BaseObject.HasStreamSyncedMetaData(key);
            }
        }

        public void DeleteStreamSyncedMetaData(string key)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.DeleteStreamSyncedMetaData(key);
            }
        }

        public void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position, Rotation rotation,
            bool collision, bool noFixedRotation)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRotation);
            }
        }

        public void Detach()
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.Detach();
            }
        }

        public bool Frozen
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Frozen;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Frozen = value;
                }
            }
        }

        public bool Collision
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Collision;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Collision = value;
                }
            }
        }
    }
}