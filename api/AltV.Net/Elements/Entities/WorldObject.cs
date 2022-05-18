using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public abstract class WorldObject : BaseObject, IWorldObject
    {
        public IntPtr WorldObjectNativePointer { get; }
        public override IntPtr NativePointer => WorldObjectNativePointer;
        
        private static IntPtr GetBaseObjectPointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Shared.WorldObject_GetBaseObject(nativePointer);
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
                    Core.Library.Shared.WorldObject_GetPosition(WorldObjectNativePointer, &position);
                    return position;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Server.WorldObject_SetPosition(WorldObjectNativePointer, value);
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
                    return Core.Library.Server.WorldObject_GetDimension(WorldObjectNativePointer);
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Server.WorldObject_SetDimension(WorldObjectNativePointer, value);
                }
            }
        }

        protected WorldObject(ICore core, IntPtr nativePointer, BaseObjectType type) : base(core, GetBaseObjectPointer(core, nativePointer), type)
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