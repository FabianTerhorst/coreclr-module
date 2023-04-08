using System.Numerics;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities
{
    public abstract class ColShape : WorldObject, ISharedColShape
    {
        public IntPtr ColShapeNativePointer { get; }
        public override IntPtr NativePointer => ColShapeNativePointer;

        private static IntPtr GetWorldObjectPointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Shared.ColShape_GetWorldObject(nativePointer);
            }
        }

        protected ColShape(ICore core, IntPtr nativePointer, uint id) : base(core, GetWorldObjectPointer(core, nativePointer), BaseObjectType.ColShape, id)
        {
            ColShapeNativePointer = nativePointer;
        }

        protected ColShape(ICore core, IntPtr nativePointer, BaseObjectType baseObjectType, uint id) : base(core, GetWorldObjectPointer(core, nativePointer), baseObjectType, id)
        {
            ColShapeNativePointer = nativePointer;
        }

        public bool IsEntityIdIn(ushort id)
        {
            CheckIfEntityExists();

            unsafe
            {
                return Core.Library.Shared.ColShape_IsEntityIdIn(ColShapeNativePointer, id) == 1;
            }
        }

        public bool IsPointIn(Vector3 point)
        {
            CheckIfEntityExists();

            unsafe
            {
                return Core.Library.Shared.ColShape_IsPointIn(ColShapeNativePointer, point) == 1;
            }
        }

        public bool IsEntityIn(ISharedEntity entity)
        {
            CheckIfEntityExists();
            entity.CheckIfEntityExists();

            unsafe
            {
                return Core.Library.Shared.ColShape_IsEntityIn(ColShapeNativePointer, entity.EntityNativePointer) == 1;
            }
        }
    }
}