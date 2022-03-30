using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;

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

        public WorldObject(ICore core, IntPtr worldObjectPointer) : base(core, GetBaseObjectPointer(core, worldObjectPointer))
        {
            WorldObjectNativePointer = worldObjectPointer;
        }
        
        public Vector3 Position
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
    }
}