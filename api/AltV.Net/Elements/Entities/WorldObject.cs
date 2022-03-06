using System;
using System.Numerics;
using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public abstract class WorldObject : BaseObject, IWorldObject
    {
        public IntPtr WorldObjectNativePointer { get; }
        public override IntPtr NativePointer => WorldObjectNativePointer;
        
        private static IntPtr GetBaseObjectPointer(IServer server, IntPtr nativePointer)
        {
            unsafe
            {
                return server.Library.Shared.WorldObject_GetBaseObject(nativePointer);
            }
        }
        

        public Position Position
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    var position = Vector3.Zero;
                    Server.Library.Shared.WorldObject_GetPosition(WorldObjectNativePointer, &position);
                    return position;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Server.WorldObject_SetPosition(WorldObjectNativePointer, value);
                }
            }
        }
        public int Dimension
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Server.Library.Server.WorldObject_GetDimension(WorldObjectNativePointer);
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Server.WorldObject_SetDimension(WorldObjectNativePointer, value);
                }
            }
        }

        protected WorldObject(IServer server, IntPtr nativePointer, BaseObjectType type) : base(server, GetBaseObjectPointer(server, nativePointer), type)
        {
            WorldObjectNativePointer = nativePointer;
        }

        public override void CheckIfEntityExists()
        {
            CheckIfCallIsValid();
            if (Exists)
            {
                return;
            }

            throw new WorldObjectRemovedException(this);
        }
    }
}