using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Pools
{
    public class ColShapePool : BaseObjectPool<IColShape>
    {
        public ColShapePool(IBaseObjectFactory<IColShape> colShapeFactory) : base(colShapeFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.ColShape_GetID(entityPointer);
            }
        }
    }
}