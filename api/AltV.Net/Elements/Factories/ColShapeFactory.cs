using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class ColShapeFactory : IBaseObjectFactory<IColShape>
    {
        public IColShape Create(IntPtr entityPointer)
        {
            return new ColShape(entityPointer);
        }
    }
}