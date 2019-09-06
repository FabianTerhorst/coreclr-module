using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class ColShape : WorldObject, IColShape
    {
        public override Position Position
        {
            get
            {
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.ColShape.ColShape_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.ColShape.ColShape_SetPosition(NativePointer, value);
            }
        }

        public override short Dimension
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.ColShape.ColShape_GetDimension(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.ColShape.ColShape_SetDimension(NativePointer, value);
            }
        }

        public override void GetMetaData(string key, ref MValue value) =>
            AltNative.ColShape.ColShape_GetMetaData(NativePointer, key, ref value);

        public override void SetMetaData(string key, ref MValue value) =>
            AltNative.ColShape.ColShape_SetMetaData(NativePointer, key, ref value);

        public ColShapeType ColShapeType
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.ColShape.ColShape_GetColShapeType(NativePointer);
            }
        }

        public ColShape(IntPtr nativePointer) : base(nativePointer, BaseObjectType.ColShape)
        {
        }

        public bool IsEntityIn(IEntity entity)
        {
            CheckIfEntityExists();
            entity.CheckIfEntityExists();

            return AltNative.ColShape.ColShape_IsEntityIn(NativePointer, entity.NativePointer);
        }

        public void Remove()
        {
            Alt.RemoveColShape(this);
        }
    }
}