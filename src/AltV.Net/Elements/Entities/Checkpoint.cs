using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Checkpoint : Entity, ICheckpoint
    {
        public static ushort GetId(IntPtr checkpointPointer) =>
            AltVNative.Checkpoint.Checkpoint_GetID(checkpointPointer);

        public override Position Position
        {
            get
            {
                CheckExistence();
                var position = Position.Zero;
                AltVNative.Checkpoint.Checkpoint_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckExistence();
                AltVNative.Checkpoint.Checkpoint_SetPosition(NativePointer, value);
            }
        }

        public override Rotation Rotation
        {
            get
            {
                CheckExistence();
                var rotation = Rotation.Zero;
                AltVNative.Checkpoint.Checkpoint_GetRotation(NativePointer, ref rotation);
                return rotation;
            }
            set
            {
                CheckExistence();
                AltVNative.Checkpoint.Checkpoint_SetRotation(NativePointer, value);
            }
        }

        public override ushort Dimension
        {
            get
            {
                CheckExistence();
                return AltVNative.Checkpoint.Checkpoint_GetDimension(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Checkpoint.Checkpoint_SetDimension(NativePointer, value);
            }
        }

        public override void SetMetaData(string key, object value)
        {
            CheckExistence();
            var mValue = MValue.CreateFromObject(value);
            AltVNative.Checkpoint.Checkpoint_SetMetaData(NativePointer, key, ref mValue);
        }

        public override bool GetMetaData<T>(string key, out T result)
        {
            CheckExistence();
            var mValue = MValue.Nil;
            AltVNative.Checkpoint.Checkpoint_GetMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public override void SetSyncedMetaData(string key, object value)
        {
            CheckExistence();
            var mValue = MValue.CreateFromObject(value);
            AltVNative.Checkpoint.Checkpoint_SetSyncedMetaData(NativePointer, key, ref mValue);
        }

        public override bool GetSyncedMetaData<T>(string key, out T result)
        {
            CheckExistence();
            var mValue = MValue.Nil;
            AltVNative.Checkpoint.Checkpoint_GetSyncedMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public bool IsGlobal
        {
            get
            {
                CheckExistence();
                return AltVNative.Checkpoint.Checkpoint_IsGlobal(NativePointer);
            }
        }

        public byte CheckpointType
        {
            get
            {
                CheckExistence();
                return AltVNative.Checkpoint.Checkpoint_GetType(NativePointer);
            }
        }

        public float Height
        {
            get
            {
                CheckExistence();
                return AltVNative.Checkpoint.Checkpoint_GetHeight(NativePointer);
            }
        }

        public float Radius
        {
            get
            {
                CheckExistence();
                return AltVNative.Checkpoint.Checkpoint_GetRadius(NativePointer);
            }
        }

        public Rgba Color
        {
            get
            {
                CheckExistence();
                var color = Rgba.Zero;
                AltVNative.Checkpoint.Checkpoint_GetColor(NativePointer, ref color);
                return color;
            }
        }

        public Checkpoint(IntPtr nativePointer, ushort id) : base(nativePointer, EntityType.Checkpoint, id)
        {
        }
    }
}