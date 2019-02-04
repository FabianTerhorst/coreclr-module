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

        //private Position position = Position.Zero;

        //private Rotation rotation = Rotation.Zero;

        public IntPtr NativePointer { get; }
        public bool Exists { get; set; }

        public ushort Id { get; }
        public EntityType Type { get; }

        private protected Server Server { get; }

        protected Entity(IntPtr nativePointer, EntityType type, Server server)
        {
            NativePointer = nativePointer;

            Id = AltVNative.Entity.Entity_GetID(NativePointer);
            Type = type;
            Server = server;
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

        //"Has" needs to do the same calculations Get has to do so consider using Get always
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

        /*public Position PositionRef for later performance optimization
        {
            get
            {
                AltVNative.Entity.Entity_GetPositionRef(NativePointer, ref position);
                return position;
            }
            set
            {
                position = value;
                AltVNative.Entity.Entity_SetPositionRef(NativePointer, ref value);
            }
        }*/

        /*public Rotation RotationRef for later performance optimization
        {
            get
            {
                AltVNative.Entity.Entity_GetRotationRef(NativePointer, ref rotation);
                return rotation;
            }
            set
            {
                rotation = value;
                AltVNative.Entity.Entity_SetRotationRef(NativePointer, ref value);
            }
        }*/

        public Position Position
        {
            get => AltVNative.Entity.Entity_GetPosition(NativePointer);
            set => AltVNative.Entity.Entity_SetPosition(NativePointer, value);
        }

        public Rotation Rotation
        {
            get => AltVNative.Entity.Entity_GetRotation(NativePointer);
            set => AltVNative.Entity.Entity_SetRotation(NativePointer, value);
        }

        public ushort Dimension
        {
            get => AltVNative.Entity.Entity_GetDimension(NativePointer);
            set => AltVNative.Entity.Entity_SetDimension(NativePointer, value);
        }

        public void SetPosition(float x, float y, float z)
        {
            AltVNative.Entity.Entity_SetPositionXYZ(NativePointer, x, y, z);
        }

        public void SetRotation(float roll, float pitch, float yaw)
        {
            AltVNative.Entity.Entity_SetRotationRPY(NativePointer, roll, pitch, yaw);
        }

        public void SetMetaData(string key, MValue value)
        {
            AltVNative.Entity.Entity_SetMetaData(NativePointer, key, ref value);
        }

        public MValue GetMetaData(string key)
        {
            var value = MValue.Nil;
            AltVNative.Entity.Entity_SetMetaData(NativePointer, key, ref value);
            return value;
        }
    }
}