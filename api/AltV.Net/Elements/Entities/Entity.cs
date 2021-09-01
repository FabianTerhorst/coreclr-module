using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Elements.Entities
{
    public abstract class Entity : WorldObject, IEntity
    {
        public ushort Id { get; }
        
        public abstract IPlayer NetworkOwner { get; }

        public abstract Rotation Rotation { get; set; }

        public abstract uint Model { get; set; }

        public abstract bool Visible { get; set; }
        
        public abstract bool Streamed { get; set; }

        public abstract void SetNetworkOwner(IPlayer player, bool disableMigration);
        public abstract void SetSyncedMetaData(string key, in MValueConst value);
        public abstract void GetSyncedMetaData(string key, out MValueConst value);
        public abstract bool HasSyncedMetaData(string key);
        public abstract void DeleteSyncedMetaData(string key);
        public abstract void SetStreamSyncedMetaData(string key, in MValueConst value);
        public abstract void GetStreamSyncedMetaData(string key, out MValueConst value);
        public abstract bool HasStreamSyncedMetaData(string key);
        public abstract void DeleteStreamSyncedMetaData(string key);
        
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

        protected Entity(IServer server, IntPtr nativePointer, BaseObjectType type, ushort id) : base(server, nativePointer, type)
        {
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