using System;
using System.Runtime.InteropServices;
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

        public override int Dimension
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

        public ColShapeType ColShapeType
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_GetColShapeType(NativePointer);
            }
        }
        
        public bool IsPlayersOnly
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_IsPlayersOnly(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Checkpoint.Checkpoint_SetPlayersOnly(NativePointer, value); 
            }
        }

        public override void GetMetaData(string key, out MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            value = new MValueConst(AltNative.Checkpoint.Checkpoint_GetMetaData(NativePointer, stringPtr));
            Marshal.FreeHGlobal(stringPtr);
        }

        public override void SetMetaData(string key, in MValueConst value)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Checkpoint.Checkpoint_SetMetaData(NativePointer, stringPtr, value.nativePointer);
            Marshal.FreeHGlobal(stringPtr);
        }

        public override bool HasMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            var result = AltNative.Checkpoint.Checkpoint_HasMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
            return result;
        }

        public override void DeleteMetaData(string key)
        {
            var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
            AltNative.Checkpoint.Checkpoint_DeleteMetaData(NativePointer, stringPtr);
            Marshal.FreeHGlobal(stringPtr);
        }
        
        public byte CheckpointType
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_GetCheckpointType(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Checkpoint.Checkpoint_SetCheckpointType(NativePointer, value);
            }
        }

        public float Height
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_GetHeight(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Checkpoint.Checkpoint_SetHeight(NativePointer, value);
            }
        }

        public float Radius
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Checkpoint.Checkpoint_GetRadius(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Checkpoint.Checkpoint_SetRadius(NativePointer, value);
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
            set
            {
                CheckIfEntityExists();
                AltNative.Checkpoint.Checkpoint_SetColor(NativePointer, value);
            }
        }

        public Position NextPosition
        {
            get
            {
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.Checkpoint.Checkpoint_GetNextPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Checkpoint.Checkpoint_SetNextPosition(NativePointer, value);
            }
        }

        public Checkpoint(IServer server, IntPtr nativePointer) : base(server, nativePointer, BaseObjectType.Checkpoint)
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
        
        public bool IsEntityIn(IEntity entity)
        {
            CheckIfEntityExists();
            entity.CheckIfEntityExists();

            switch (entity)
            {
                case IPlayer player:
                    return AltNative.Checkpoint.Checkpoint_IsPlayerIn(NativePointer, player.NativePointer);
                case IVehicle vehicle:
                    return AltNative.Checkpoint.Checkpoint_IsVehicleIn(NativePointer, vehicle.NativePointer);
                default:
                    return false;
            }
        }
        
        public void Remove()
        {
            Alt.RemoveCheckpoint(this);
        }
        
        protected override void InternalAddRef()
        {
            AltNative.Checkpoint.Checkpoint_AddRef(NativePointer);
        }

        protected override void InternalRemoveRef()
        {
            AltNative.Checkpoint.Checkpoint_RemoveRef(NativePointer);
        }
    }
}