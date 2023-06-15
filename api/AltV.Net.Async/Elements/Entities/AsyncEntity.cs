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
    public class AsyncEntity : AsyncWorldObject, IEntity
    {
        protected readonly IEntity Entity;
        public IntPtr EntityNativePointer => Entity.EntityNativePointer;

        public uint Id => Entity.Id;

        public IPlayer NetworkOwner
        {
            get
            {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity)) return null;
                    return Entity.NetworkOwner;
                }
            }
        }
        ISharedPlayer ISharedEntity.NetworkOwner => NetworkOwner;

        public Rotation Rotation
        {
            get
            {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity)) return default;
                    return Entity.Rotation;
                }
            }
            set {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                    Entity.Rotation = value;
                }
            }
        }

        public virtual uint Model
        {
            get
            {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity)) return default;
                    return Entity.Model;
                }
            }
        }

        public bool Visible
        {
            get
            {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity)) return default;
                    return Entity.Visible;
                }
            }
            set {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                    Entity.Visible = value;
                }
            }
        }

        public bool Streamed
        {
            get
            {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity)) return default;
                    return Entity.Streamed;
                }
            }
            set {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                    Entity.Streamed = value;
                }
            }
        }

        public AsyncEntity(IEntity entity, IAsyncContext asyncContext) : base(entity, asyncContext)
        {
            Entity = entity;
        }

        public void SetNetworkOwner(IPlayer player, bool disableMigration = true)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                Entity.SetNetworkOwner(player, disableMigration);
            }
        }

        public void ResetNetworkOwner()
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                Entity.ResetNetworkOwner();
            }
        }

        public void SetStreamSyncedMetaData(string key, object value)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                Entity.SetStreamSyncedMetaData(key, value);
            }
        }

        public bool GetStreamSyncedMetaData<T1>(string key, out T1 result)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity))
                {
                    result = default;
                    return false;
                }

                return Entity.GetStreamSyncedMetaData(key, out result);
            }
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                Entity.SetSyncedMetaData(key, in value);
            }
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity))
                {
                    value = MValueConst.Nil;
                    return;
                }

                Entity.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out int value)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity))
                {
                    value = default;
                    return false;
                }

                return Entity.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out uint value)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity))
                {
                    value = default;
                    return false;
                }

                return Entity.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out float value)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity))
                {
                    value = default;
                    return false;
                }

                return Entity.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity)) return default;
                return Entity.HasStreamSyncedMetaData(key);
            }
        }

        public void DeleteStreamSyncedMetaData(string key)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                Entity.DeleteStreamSyncedMetaData(key);
            }
        }

        public void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position, Rotation rotation,
            bool collision, bool noFixedRotation)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                Entity.AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRotation);
            }
        }

        public void AttachToEntity(IEntity entity, string otherBone, string ownBone, Position position, Rotation rotation,
            bool collision, bool noFixedRotation)
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                Entity.AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRotation);
            }
        }

        public void Detach()
        {
            lock (Entity)
            {
                if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                Entity.Detach();
            }
        }

        public uint Timestamp
        {
            get
            {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity)) return default;
                    return Entity.Timestamp;
                }
            }

        }

        public bool Frozen
        {
            get
            {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity)) return default;
                    return Entity.Frozen;
                }
            }
            set {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                    Entity.Frozen = value;
                }
            }
        }

        public bool Collision
        {
            get
            {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsOrCachedNullable(Entity)) return default;
                    return Entity.Collision;
                }
            }
            set {
                lock (Entity)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Entity)) return;
                    Entity.Collision = value;
                }
            }
        }
    }
}