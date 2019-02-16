using System;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Checkpoint : Entity, ICheckpoint
    {
        public new static ushort GetId(IntPtr checkpointPointer) =>
            AltVNative.Checkpoint.Checkpoint_GetID(checkpointPointer);

        public override Position Position
        {
            get
            {
                var position = Position.Zero;
                if (Exists)
                {
                    AltVNative.Checkpoint.Checkpoint_GetPosition(NativePointer, ref position);
                }

                return position;
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Checkpoint.Checkpoint_SetPosition(NativePointer, value);
                }
            }
        }

        public override Rotation Rotation
        {
            get
            {
                var rotation = Rotation.Zero;
                if (Exists)
                {
                    AltVNative.Checkpoint.Checkpoint_GetRotation(NativePointer, ref rotation);
                }

                return rotation;
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Checkpoint.Checkpoint_SetRotation(NativePointer, value);
                }
            }
        }

        public override ushort Dimension
        {
            get => !Exists ? default : AltVNative.Checkpoint.Checkpoint_GetDimension(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Checkpoint.Checkpoint_SetDimension(NativePointer, value);
                }
            }
        }

        public override void SetMetaData(string key, object value)
        {
            if (Exists)
            {
                var mValue = MValue.CreateFromObject(value);
                AltVNative.Checkpoint.Checkpoint_SetMetaData(NativePointer, key, ref mValue);
            }
        }

        public override bool GetMetaData<T>(string key, out T result)
        {
            if (!Exists)
            {
                result = default;
                return false;
            }

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
            if (Exists)
            {
                var mValue = MValue.CreateFromObject(value);
                AltVNative.Checkpoint.Checkpoint_SetSyncedMetaData(NativePointer, key, ref mValue);
            }
        }

        public override bool GetSyncedMetaData<T>(string key, out T result)
        {
            if (!Exists)
            {
                result = default;
                return false;
            }

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

        public bool IsGlobal => Exists && AltVNative.Checkpoint.Checkpoint_IsGlobal(NativePointer);
        public byte CheckpointType => !Exists ? default : AltVNative.Checkpoint.Checkpoint_GetType(NativePointer);
        public float Height => !Exists ? default : AltVNative.Checkpoint.Checkpoint_GetHeight(NativePointer);
        public float Radius => !Exists ? default : AltVNative.Checkpoint.Checkpoint_GetRadius(NativePointer);

        public Rgba Color
        {
            get
            {
                var color = Rgba.Zero;
                if (Exists)
                {
                    AltVNative.Checkpoint.Checkpoint_GetColor(NativePointer, ref color);
                }

                return color;
            }
        }

        public Checkpoint(IntPtr nativePointer, ushort id) : base(nativePointer, EntityType.Checkpoint, id)
        {
        }
    }
}