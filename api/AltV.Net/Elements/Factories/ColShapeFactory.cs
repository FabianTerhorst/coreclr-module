using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories
{
    public class ColShapeFactory : IBaseObjectFactory<IColShape>
    {
        public IColShape Create(ICore core, IntPtr entityPointer, uint id)
        {
            return new ColShape(core, entityPointer, id);
        }
    }
}