using System;
using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public abstract class WorldObject : BaseObject, IWorldObject
    {
        public abstract Position Position { get; set; }
        public abstract int Dimension { get; set; }

        protected WorldObject(IntPtr nativePointer, BaseObjectType type) : base(nativePointer, type)
        {
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