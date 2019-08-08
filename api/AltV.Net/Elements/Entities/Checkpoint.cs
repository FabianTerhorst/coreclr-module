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
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.Checkpoint.Checkpoint_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Checkpoint.Checkpoint_SetPosition(NativePointer, value);
            }
        }

        public override short Dimension
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_GetDimension(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Checkpoint.Checkpoint_SetDimension(NativePointer, value);
            }
        }

        public IPlayer Target
        {
            get
            {
                CheckIfEntityExists();
                var playerPointer = AltNative.Checkpoint.Checkpoint_GetTarget(NativePointer);
                if (playerPointer == IntPtr.Zero) return null;
                return Alt.Module.PlayerPool.GetOrCreate(playerPointer, out var player) ? player : null;
            }
        }

        public override void GetMetaData(string key, ref MValue value) =>
            AltNative.Checkpoint.Checkpoint_GetMetaData(NativePointer, key, ref value);

        public override void SetMetaData(string key, ref MValue value) =>
            AltNative.Checkpoint.Checkpoint_SetMetaData(NativePointer, key, ref value);

        public bool IsGlobal
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_IsGlobal(NativePointer);
            }
        }

        public byte CheckpointType
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_GetCheckpointType(NativePointer);
            }
        }

        public float Height
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_GetHeight(NativePointer);
            }
        }

        public float Radius
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_GetRadius(NativePointer);
            }
        }

        public Rgba Color
        {
            get
            {
                CheckIfEntityExists();
                var color = Rgba.Zero;
                AltNative.Checkpoint.Checkpoint_GetColor(NativePointer, ref color);
                return color;
            }
        }

        public Checkpoint(IntPtr nativePointer) : base(nativePointer, BaseObjectType.Checkpoint)
        {
        }

        public bool IsPlayerIn(IPlayer player)
        {
            CheckIfEntityExists();
            if (!player.Exists)
            {
                throw new EntityRemovedException(player);
            }

            return AltNative.Checkpoint.Checkpoint_IsPlayerIn(NativePointer, player.NativePointer);
        }

        public bool IsVehicleIn(IVehicle vehicle)
        {
            CheckIfEntityExists();
            if (!vehicle.Exists)
            {
                throw new EntityRemovedException(vehicle);
            }

            return AltNative.Checkpoint.Checkpoint_IsVehicleIn(NativePointer, vehicle.NativePointer);
        }
        
        public void Remove()
        {
            Alt.RemoveCheckpoint(this);
        }
    }
}