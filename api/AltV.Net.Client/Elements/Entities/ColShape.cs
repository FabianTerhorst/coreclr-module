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

        protected ColShape(ICore core, IntPtr nativePointer) : base(core, GetWorldObjectPointer(core, nativePointer), BaseObjectType.ColShape)
        {
            ColShapeNativePointer = nativePointer;
        }

        protected ColShape(ICore core, IntPtr nativePointer, BaseObjectType baseObjectType) : base(core, GetWorldObjectPointer(core, nativePointer), baseObjectType)
        {
            ColShapeNativePointer = nativePointer;
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