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

        public abstract void SetSyncedMetaData(string key, in MValueConst value);
        public abstract void GetSyncedMetaData(string key, out MValueConst value);
        
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
            GetSyncedMetaData(key, out var mValue);
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

        protected Entity(IntPtr nativePointer, BaseObjectType type, ushort id) : base(nativePointer, type)
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