using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncEntity<TEntity> : AsyncWorldObject<TEntity>, IEntity where TEntity: class, IEntity
    {
        public ushort Id { get; }
        public IPlayer NetworkOwner { get; }
        public Rotation Rotation { get; set; }
        public uint Model { get; }
        public bool Visible { get; set; }
        public bool Streamed { get; set; }
        
        public AsyncEntity(TEntity entity, IAsyncContext asyncContext):base(entity, asyncContext)
        {
        }
        
        public void SetNetworkOwner(IPlayer player, bool disableMigration = true)
        {
            throw new System.NotImplementedException();
        }

        public void ResetNetworkOwner()
        {
            throw new System.NotImplementedException();
        }

        public void SetSyncedMetaData(string key, object value)
        {
            throw new System.NotImplementedException();
        }

        public bool GetSyncedMetaData<T1>(string key, out T1 result)
        {
            throw new System.NotImplementedException();
        }

        public void SetStreamSyncedMetaData(string key, object value)
        {
            throw new System.NotImplementedException();
        }

        public bool GetStreamSyncedMetaData<T1>(string key, out T1 result)
        {
            throw new System.NotImplementedException();
        }

        public void SetSyncedMetaData(string key, in MValueConst value)
        {
            throw new System.NotImplementedException();
        }

        public void GetSyncedMetaData(string key, out MValueConst value)
        {
            throw new System.NotImplementedException();
        }

        public bool GetSyncedMetaData(string key, out int value)
        {
            throw new System.NotImplementedException();
        }

        public bool GetSyncedMetaData(string key, out uint value)
        {
            throw new System.NotImplementedException();
        }

        public bool GetSyncedMetaData(string key, out float value)
        {
            throw new System.NotImplementedException();
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            throw new System.NotImplementedException();
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            throw new System.NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out int value)
        {
            throw new System.NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out uint value)
        {
            throw new System.NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out float value)
        {
            throw new System.NotImplementedException();
        }

        public bool HasSyncedMetaData(string key)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSyncedMetaData(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStreamSyncedMetaData(string key)
        {
            throw new System.NotImplementedException();
        }

        public void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position, Rotation rotation,
            bool collision, bool noFixedRotation)
        {
            throw new System.NotImplementedException();
        }

        public void Detach()
        {
            throw new System.NotImplementedException();
        }
    }
}