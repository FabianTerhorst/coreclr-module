using System;
using System.Collections.Concurrent;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public abstract class Entity : IInternalEntity, IEntity
    {
        public static ushort GetId(IntPtr entityPointer) => AltVNative.Entity.Entity_GetID(entityPointer);
        public static EntityType GetType(IntPtr entityPointer) => AltVNative.Entity.BaseObject_GetType(entityPointer);

        private readonly ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();

        public IntPtr NativePointer { get; }
        public bool Exists { get; set; }

        public ushort Id { get; }
        public EntityType Type { get; }
        
        public abstract Position Position { get; set; }
        public abstract Rotation Rotation { get; set; }
        public abstract ushort Dimension { get; set; }
        public abstract void SetMetaData(string key, object value);
        public abstract bool GetMetaData<T>(string key, out T result);
        public abstract void SetSyncedMetaData(string key, object value);
        public abstract bool GetSyncedMetaData<T>(string key, out T result);

        protected Entity(IntPtr nativePointer, EntityType type, ushort id)
        {
            NativePointer = nativePointer;
            Id = id;
            Type = type;
            Exists = true;
        }

        public void SetData(string key, object value)
        {
            data[key] = value;
        }

        public bool GetData<T>(string key, out T result)
        {
            if (!data.TryGetValue(key, out var value))
            {
                result = default;
                return false;
            }

            if (!(value is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        protected void CheckExistence()
        {
            if (Exists)
            {
                return;
            }

            throw new EntityDeletedException(this);
        }

        /*public Position Position
        {
            get => !Exists ? Position.Zero : AltVNative.Entity.Entity_GetPosition(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Entity.Entity_SetPosition(NativePointer, value);
                }
            }
        }

        public Rotation Rotation
        {
            get => !Exists ? Rotation.Zero : AltVNative.Entity.Entity_GetRotation(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Entity.Entity_SetRotation(NativePointer, value);
                }
            }
        }

        public ushort Dimension
        {
            get => !Exists ? default : AltVNative.Entity.Entity_GetDimension(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Entity.Entity_SetDimension(NativePointer, value);
                }
            }
        }

        public void SetMetaData(string key, object value)
        {
            if (Exists)
            {
                var mValue = MValue.CreateFromObject(value);
                AltVNative.Entity.Entity_SetMetaData(NativePointer, key, ref mValue);
            }
        }

        public bool GetMetaData<T>(string key, out T result)
        {
            if (!Exists)
            {
                result = default;
                return false;
            }
            var mValue = MValue.Nil;
            AltVNative.Entity.Entity_GetMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public void SetSyncedMetaData(string key, object value)
        {
            if (Exists)
            {
                var mValue = MValue.CreateFromObject(value);
                AltVNative.Entity.Entity_SetSyncedMetaData(NativePointer, key, ref mValue);
            }
        }

        public bool GetSyncedMetaData<T>(string key, out T result)
        {
            if (!Exists)
            {
                result = default;
                return false;
            }
            var mValue = MValue.Nil;
            AltVNative.Entity.Entity_GetSyncedMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }*/

        public void Remove()
        {
            Alt.RemoveEntity(this);
        }
    }
}