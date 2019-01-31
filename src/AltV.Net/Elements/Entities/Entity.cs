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
        private readonly ConcurrentDictionary<string, object> _data = new ConcurrentDictionary<string, object>();

        private Position position = Position.Zero;

        private Rotation rotation = Rotation.Zero;

        public IntPtr NativePointer { get; }
        public bool Exists { get; set; }

        public ushort Id { get; }
        public EntityType Type { get; }

        protected Entity(IntPtr nativePointer, EntityType type)
        {
            NativePointer = nativePointer;

            Id = Alt.Entity.Entity_GetId(NativePointer);
            Type = type;
            Exists = true;
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
        public Position Position
        {
            get
            {
                Alt.Entity.Entity_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                position = value;
                Alt.Entity.Entity_SetPosition(NativePointer, ref value);
            }
        }

        public Rotation Rotation
        {
            get
            {
                Alt.Entity.Entity_GetRotation(NativePointer, ref rotation);
                return rotation;
            }
            set
            {
                rotation = value;
                Alt.Entity.Entity_SetRotation(NativePointer, ref value);
            }
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
    }
}