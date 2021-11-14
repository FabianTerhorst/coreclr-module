using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncEntity<TEntity> : AsyncWorldObject<TEntity>, IEntity where TEntity : class, IEntity
    {
        public ushort Id => BaseObject.Id;

        public IPlayer NetworkOwner
        {
            get
            {
                AsyncContext.RunAll();
                IPlayer owner = default;
                AsyncContext.RunOnMainThreadBlocking(() => owner = BaseObject.NetworkOwner);
                return owner;
            }
        }

        public Rotation Rotation
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Rotation;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Rotation = value); }
        }

        public virtual uint Model
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Model;
                }
            }
        }

        public bool Visible
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Visible;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Visible = value); }
        }

        public bool Streamed { get; set; }

        public AsyncEntity(TEntity entity, IAsyncContext asyncContext) : base(entity, asyncContext)
        {
        }

        public void SetNetworkOwner(IPlayer player, bool disableMigration = true)
        {
            AsyncContext.Enqueue(() => BaseObject.SetNetworkOwner(player, disableMigration));
        }

        public void ResetNetworkOwner()
        {
            AsyncContext.Enqueue(() => BaseObject.ResetNetworkOwner());
        }

        public void SetSyncedMetaData(string key, object value)
        {
            AsyncContext.Enqueue(() => BaseObject.SetSyncedMetaData(key, value));
        }

        public bool GetSyncedMetaData<T1>(string key, out T1 result)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    result = default;
                    return false;
                }

                return BaseObject.GetSyncedMetaData(key, out result);
            }
        }

        public void SetStreamSyncedMetaData(string key, object value)
        {
            AsyncContext.Enqueue(() => BaseObject.SetStreamSyncedMetaData(key, value));
        }

        public bool GetStreamSyncedMetaData<T1>(string key, out T1 result)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    result = default;
                    return false;
                }

                return BaseObject.GetStreamSyncedMetaData(key, out result);
            }
        }

        public void SetSyncedMetaData(string key, in MValueConst value)
        {
            var @const = value;
            AsyncContext.Enqueue(() => BaseObject.SetSyncedMetaData(key, in @const));
        }

        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    value = MValueConst.Nil;
                    return;
                }

                BaseObject.GetSyncedMetaData(key, out value);
            }
        }

        public bool GetSyncedMetaData(string key, out int value)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetSyncedMetaData(key, out value);
            }
        }

        public bool GetSyncedMetaData(string key, out uint value)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetSyncedMetaData(key, out value);
            }
        }

        public bool GetSyncedMetaData(string key, out float value)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetSyncedMetaData(key, out value);
            }
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            var @const = value;
            AsyncContext.Enqueue(() => BaseObject.SetSyncedMetaData(key, in @const));
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    value = MValueConst.Nil;
                    return;
                }

                BaseObject.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out int value)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out uint value)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool GetStreamSyncedMetaData(string key, out float value)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject))
                {
                    value = default;
                    return false;
                }

                return BaseObject.GetStreamSyncedMetaData(key, out value);
            }
        }

        public bool HasSyncedMetaData(string key)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.HasSyncedMetaData(key);
            }
        }

        public void DeleteSyncedMetaData(string key)
        {
            AsyncContext.Enqueue(() => BaseObject.DeleteSyncedMetaData(key));
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            AsyncContext.RunAll();
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                return BaseObject.HasStreamSyncedMetaData(key);
            }
        }

        public void DeleteStreamSyncedMetaData(string key)
        {
            AsyncContext.Enqueue(() => BaseObject.DeleteStreamSyncedMetaData(key));
        }

        public void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position, Rotation rotation,
            bool collision, bool noFixedRotation)
        {
            AsyncContext.Enqueue(() =>
                BaseObject.AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRotation));
        }

        public void Detach()
        {
            AsyncContext.Enqueue(() => BaseObject.Detach());
        }
    }
}