using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Elements.Entities
{
    public abstract class Entity : WorldObject, IEntity
    {
        public ushort Id { get; }

        public abstract Rotation Rotation { get; set; }

        public abstract uint Model { get; set; }

        public abstract void SetSyncedMetaData(string key, ref MValue value);
        public abstract void GetSyncedMetaData(string key, ref MValue value);
        
        public void SetSyncedMetaData(string key, object value)
        {
            CheckIfEntityExists();
            var mValue = MValue.CreateFromObject(value);
            SetSyncedMetaData(key, ref mValue);
        }

        public bool GetSyncedMetaData<T>(string key, out T result)
        {
            CheckIfEntityExists();
            var mValue = MValue.Nil;
            GetSyncedMetaData(key, ref mValue);
            if (!(mValue.ToObject() is T cast))
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
            if (Exists) return;

            throw new EntityRemovedException(this);
        }
    }
}