using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities
{
    public class WorldObject : BaseObject, IWorldObject
    {
        private static IntPtr GetBaseObjectPointer(ICore core, IntPtr worldObjectPointer)
        {
            unsafe
            {
                return core.Library.Shared.WorldObject_GetBaseObject(worldObjectPointer);
            }
        }
        
        public IntPtr WorldObjectNativePointer { get; }
        public override IntPtr NativePointer => WorldObjectNativePointer;

        public WorldObject(ICore core, IntPtr worldObjectPointer, BaseObjectType type) : base(core, GetBaseObjectPointer(core, worldObjectPointer), type)
        {
            WorldObjectNativePointer = worldObjectPointer;
        }
        
        public Position Position
        {
            get
            {
                unsafe
                {
                    var position = Vector3.Zero;
                    this.Core.Library.Shared.WorldObject_GetPosition(this.WorldObjectNativePointer, &position);
                    return position;
                }
            }
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