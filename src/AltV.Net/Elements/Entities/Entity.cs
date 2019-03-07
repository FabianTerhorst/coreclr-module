using System;
using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public abstract class Entity : WorldObject, IEntity
    {
        public ushort Id { get; }

        public abstract Rotation Rotation { get; set; }

        public abstract uint Model { get; }

        public abstract void SetSyncedMetaData(string key, object value);
        public abstract bool GetSyncedMetaData<T>(string key, out T result);

        protected Entity(IntPtr nativePointer, BaseObjectType type, ushort id) : base(nativePointer, type)
        {
            Id = id;
        }

        protected override void CheckExistence()
        {
            if (Exists)
            {
                return;
            }

            throw new EntityDeletedException(this);
        }
    }
}