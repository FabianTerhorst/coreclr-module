using System;

namespace AltV.Net.Elements.Entities
{
    public class ColShape : WorldObject, IColShape
    {
        public IntPtr ColShapeNativePointer { get; }
        public override IntPtr NativePointer => ColShapeNativePointer;
        
        private static IntPtr GetWorldObjectPointer(IServer server, IntPtr nativePointer)
        {
            unsafe
            {
                return server.Library.Server.ColShape_GetWorldObject(nativePointer);
            }
        }
        
        public bool IsPlayersOnly
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Server.ColShape_IsPlayersOnly(ColShapeNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Server.ColShape_SetPlayersOnly(ColShapeNativePointer, value ? (byte) 1 : (byte) 0);
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
                    return (ColShapeType) Server.Library.Server.ColShape_GetColShapeType(ColShapeNativePointer);
                }
            }
        }

        public ColShape(IServer server, IntPtr nativePointer) : base(server, GetWorldObjectPointer(server, nativePointer), BaseObjectType.ColShape)
        {
            ColShapeNativePointer = nativePointer;
        }

        public bool IsEntityIn(IEntity entity)
        {
            CheckIfEntityExists();
            entity.CheckIfEntityExists();
            
            unsafe
            {
                return Server.Library.Server.ColShape_IsEntityIn(ColShapeNativePointer, entity.EntityNativePointer) == 1;
            }
        }

        [Obsolete("Use IsEntityIn instead")]
        public bool IsPlayerIn(IPlayer player)
        {
            return IsEntityIn(player);
        }

        [Obsolete("Use IsEntityIn instead")]
        public bool IsVehicleIn(IVehicle vehicle)
        {
            return IsEntityIn(vehicle);
        }
        
        public void Remove()
        {
            Alt.RemoveColShape(this);
        }
    }
}