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
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Position.Zero;
                    Server.Library.Checkpoint_GetPosition(NativePointer, &position);
                    return position;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Checkpoint_SetPosition(NativePointer, value);
                }
            }
        }

        public override int Dimension
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Checkpoint_GetDimension(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Checkpoint_SetDimension(NativePointer, value);
                }
            }
        }

        public ColShapeType ColShapeType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return (ColShapeType) Server.Library.Checkpoint_GetColShapeType(NativePointer);
                }
            }
        }
        
        public bool IsPlayersOnly
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Checkpoint_IsPlayersOnly(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Checkpoint_SetPlayersOnly(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public override void GetMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Checkpoint_GetMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void SetMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Checkpoint_SetMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override bool HasMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Checkpoint_HasMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public override void DeleteMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Checkpoint_DeleteMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        
        public byte CheckpointType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Checkpoint_GetCheckpointType(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Checkpoint_SetCheckpointType(NativePointer, value);
                }
            }
        }

        public float Height
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Checkpoint_GetHeight(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Checkpoint_SetHeight(NativePointer, value);
                }
            }
        }

        public float Radius
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Checkpoint_GetRadius(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Checkpoint_SetRadius(NativePointer, value);
                }
            }
        }

        public Rgba Color
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var color = Rgba.Zero;
                    Server.Library.Checkpoint_GetColor(NativePointer, &color);
                    return color;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Checkpoint_SetColor(NativePointer, value);
                }
            }
        }

        public Position NextPosition
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Position.Zero;
                    Server.Library.Checkpoint_GetNextPosition(NativePointer, &position);
                    return position;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Checkpoint_SetNextPosition(NativePointer, value);
                }
            }
        }

        public Checkpoint(IServer server, IntPtr nativePointer) : base(server, nativePointer, BaseObjectType.Checkpoint)
        {
        }

        public bool IsPlayerIn(IPlayer player)
        {
            unsafe
            {
                CheckIfEntityExists();
                if (!player.Exists)
                {
                    throw new EntityRemovedException(player);
                }

                return Server.Library.Checkpoint_IsPlayerIn(NativePointer, player.NativePointer) == 1;
            }
        }

        public bool IsVehicleIn(IVehicle vehicle)
        {
            unsafe
            {
                CheckIfEntityExists();
                if (!vehicle.Exists)
                {
                    throw new EntityRemovedException(vehicle);
                }

                return Server.Library.Checkpoint_IsVehicleIn(NativePointer, vehicle.NativePointer) == 1;
            }
        }
        
        public bool IsEntityIn(IEntity entity)
        {
            CheckIfEntityExists();
            entity.CheckIfEntityExists();

            switch (entity)
            {
                case IPlayer player:
                    unsafe
                    {
                        return Server.Library.Checkpoint_IsPlayerIn(NativePointer, player.NativePointer) == 1;
                    }

                case IVehicle vehicle:
                    unsafe
                    {
                        return Server.Library.Checkpoint_IsVehicleIn(NativePointer, vehicle.NativePointer) == 1;
                    }

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
            unsafe
            {
                Server.Library.Checkpoint_AddRef(NativePointer);
            }
        }

        protected override void InternalRemoveRef()
        {
            unsafe
            {
                Server.Library.Checkpoint_RemoveRef(NativePointer);
            }
        }
    }
}