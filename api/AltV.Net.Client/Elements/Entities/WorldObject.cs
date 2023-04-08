using System.Numerics;
using System.Runtime.CompilerServices;
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

        public IntPtr WorldObjectNativePointer { get; private set; }
        public override IntPtr NativePointer => WorldObjectNativePointer;

        public WorldObject(ICore core, IntPtr worldObjectPointer, BaseObjectType type, uint id) : base(core, GetBaseObjectPointer(core, worldObjectPointer), type, id)
        {
            WorldObjectNativePointer = worldObjectPointer;
        }

        public Position Position
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
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

        public override void SetCached(IntPtr cachedWorldObject)
        {
            this.WorldObjectNativePointer = cachedWorldObject;
            base.SetCached(GetBaseObjectPointer(Core, cachedWorldObject));
        }
    }
}