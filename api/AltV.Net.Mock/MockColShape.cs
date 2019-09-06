using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockColShape : MockWorldObject, IColShape
    {
        public MockColShape(IntPtr nativePointer) : base(nativePointer, BaseObjectType.ColShape)
        {
        }

        public ColShapeType ColShapeType { get; }
        
        public bool IsEntityIn(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            Alt.Server.RemoveColShape(this);
        }
    }
}