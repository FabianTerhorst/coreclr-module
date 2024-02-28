using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public abstract class WorldObject : BaseObject, IWorldObject
    {
        public IntPtr WorldObjectNativePointer { get; private set; }
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
                CheckIfEntityExistsOrCached();
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
                    Core.Library.Shared.WorldObject_SetPosition(WorldObjectNativePointer, value);
                }
            }
        }
        public int Dimension
        {
            get
            {
                CheckIfEntityExistsOrCached();
                unsafe
                {
                    return Core.Library.Shared.WorldObject_GetDimension(WorldObjectNativePointer);
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Core.Library.Shared.WorldObject_SetDimension(WorldObjectNativePointer, value);
                }
            }
        }

        protected WorldObject(ICore core, IntPtr nativePointer, BaseObjectType type, uint id) : base(core, GetBaseObjectPointer(core, nativePointer), type, id)
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

        public override void SetCached(IntPtr cachedWorldObject)
        {
            this.WorldObjectNativePointer = cachedWorldObject;
            base.SetCached(GetBaseObjectPointer(Core, cachedWorldObject));
        }

        public void SetPosition((float X, float Y, float Z) position)
        {
            Position = new Position(position.X, position.Y, position.Z);
        }

        public void SetPosition(float x, float y, float z)
        {
            Position = new Position(x, y, z);
        }

        public (float X, float Y, float Z) GetPosition()
        {
            return (Position.X, Position.Y, Position.Z);
        }
    }
}