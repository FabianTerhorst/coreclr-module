using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class ColShape : WorldObject, IColShape
    {
        public override Position Position
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Position.Zero;
                    Server.Library.ColShape_GetPosition(NativePointer, &position);
                    return position;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.ColShape_SetPosition(NativePointer, value);
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
                    return Server.Library.ColShape_GetDimension(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.ColShape_SetDimension(NativePointer, value);
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
                    return Server.Library.ColShape_IsPlayersOnly(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.ColShape_SetPlayersOnly(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public override void GetMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.ColShape_GetMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void SetMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.ColShape_SetMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }
        
        public override bool HasMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.ColShape_HasMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public override void DeleteMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.ColShape_DeleteMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public ColShapeType ColShapeType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return (ColShapeType) Server.Library.ColShape_GetColShapeType(NativePointer);
                }
            }
        }

        public ColShape(IServer server, IntPtr nativePointer) : base(server, nativePointer, BaseObjectType.ColShape)
        {
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
                        return Server.Library.ColShape_IsPlayerIn(NativePointer, player.NativePointer) == 1;
                    }

                case IVehicle vehicle:
                    unsafe
                    {
                        return Server.Library.ColShape_IsVehicleIn(NativePointer, vehicle.NativePointer) == 1;
                    }

                default:
                    return false;
            }
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

                return Server.Library.ColShape_IsPlayerIn(NativePointer, player.NativePointer) == 1;
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

                return Server.Library.ColShape_IsVehicleIn(NativePointer, vehicle.NativePointer) == 1;
            }
        }
        
        public void Remove()
        {
            Alt.RemoveColShape(this);
        }
        
        protected override void InternalAddRef()
        {
            unsafe
            {
                Server.Library.ColShape_AddRef(NativePointer);
            }
        }

        protected override void InternalRemoveRef()
        {
            unsafe
            {
                Server.Library.ColShape_RemoveRef(NativePointer);
            }
        }
    }
}