using System;
using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public abstract class WorldObject : BaseObject, IWorldObject
    {
        public abstract Position Position { get; set; }
        public abstract short Dimension { get; set; }

        protected WorldObject(IntPtr nativePointer, BaseObjectType type) : base(nativePointer, type)
        {
        }

        protected override void CheckExistence()
        {
            if (Exists)
            {
                return;
            }

            throw new WorldObjectDeletedException(this);
        }
    }
}