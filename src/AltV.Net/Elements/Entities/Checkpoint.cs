using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Checkpoint : WorldObject, ICheckpoint
    {
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

        public override short Dimension
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

        public IPlayer Target
        {
            get
            {
                CheckExistence();
                var playerPointer = AltVNative.Checkpoint.Checkpoint_GetTarget(NativePointer);
                if (playerPointer == IntPtr.Zero) return null;
                return Alt.Module.PlayerPool.GetOrCreate(playerPointer, out var player) ? player : null;
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

        public Checkpoint(IntPtr nativePointer) : base(nativePointer, BaseObjectType.Checkpoint)
        {
        }

        public bool IsPlayerIn(IPlayer player)
        {
            CheckExistence();
            if (!player.Exists)
            {
                throw new EntityDeletedException(player);
            }

            return AltVNative.Checkpoint.Checkpoint_IsPlayerIn(NativePointer, player.NativePointer);
        }

        public bool IsVehicleIn(IVehicle vehicle)
        {
            CheckExistence();
            if (!vehicle.Exists)
            {
                throw new EntityDeletedException(vehicle);
            }

            return AltVNative.Checkpoint.Checkpoint_IsVehicleIn(NativePointer, vehicle.NativePointer);
        }
        
        public void Remove()
        {
            Alt.RemoveCheckpoint(this);
        }
    }
}