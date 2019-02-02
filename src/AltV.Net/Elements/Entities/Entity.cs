using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    internal abstract class Entity : IInternalEntity, IEntity
    {
        private readonly ConcurrentDictionary<string, object> data = new ConcurrentDictionary<string, object>();

        private Position position = Position.Zero;

        private Rotation rotation = Rotation.Zero;

        public IntPtr NativePointer { get; }
        public bool Exists { get; set; }

        public ushort Id { get; }
        public EntityType Type { get; }

        private protected IEntityPool EntityPool { get; }

        public object this[string key]
        {
            get => data.TryGetValue(key, out var value) ? value : null;
            set => data[key] = value;
        }

        protected Entity(IntPtr nativePointer, EntityType type, IEntityPool entityPool)
        {
            NativePointer = nativePointer;

            Id = Alt.Entity.Entity_GetID(NativePointer);
            Type = type;
            EntityPool = entityPool;
            Exists = true;
        }

        /*public bool Get<T>(string key, ref T result)
        {
            if (!data.TryGetValue(key, out var value)) return false;
            if (!(value is T cast)) return false;
            result = cast;
            return true;
        }*/

        public bool Get<T>(string key, out T result)
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

        //Has needs to do the same calculations Get has to do so consider using Get always
        public bool Has(string key)
        {
            return data.ContainsKey(key);
        }

        protected void CheckExistence()
        {
            if (Exists)
            {
                return;
            }

            throw new EntityDeletedException(this);
        }

        //TODO: create an position object per thread, or threadsafe position get method that creates a new position
        public Position PositionRef
        {
            get
            {
                Alt.Entity.Entity_GetPositionRef(NativePointer, ref position);
                return position;
            }
            set
            {
                position = value;
                Alt.Entity.Entity_SetPositionRef(NativePointer, ref value);
            }
        }
        
        public Position Position
        {
            get => Alt.Entity.Entity_GetPosition(NativePointer);
            set => Alt.Entity.Entity_SetPosition(NativePointer, value);
        }

        public Rotation RotationRef
        {
            get
            {
                Alt.Entity.Entity_GetRotationRef(NativePointer, ref rotation);
                return rotation;
            }
            set
            {
                rotation = value;
                Alt.Entity.Entity_SetRotationRef(NativePointer, ref value);
            }
        }
        
        public Rotation Rotation
        {
            get => Alt.Entity.Entity_GetRotation(NativePointer);
            set => Alt.Entity.Entity_SetRotation(NativePointer, value);
        }

        public ushort Dimension
        {
            get => Alt.Entity.Entity_GetDimension(NativePointer);
            set => Alt.Entity.Entity_SetDimension(NativePointer, value);
        }

        public void setPosition(float x, float y, float z)
        {
            Alt.Entity.Entity_SetPositionXYZ(NativePointer, x, y, z);
        }

        public void setRotation(float roll, float pitch, float yaw)
        {
            Alt.Entity.Entity_SetRotationRPY(NativePointer, roll, pitch, yaw);
        }

        public void setMetaData(string key, MValue value)
        {
            Alt.Entity.Entity_SetMetaData(NativePointer, key, ref value);
        }

        public MValue getMetaData(string key)
        {
            var value = MValue.Nil;
            Alt.Entity.Entity_SetMetaData(NativePointer, key, ref value);
            return value;
        }
    }
}