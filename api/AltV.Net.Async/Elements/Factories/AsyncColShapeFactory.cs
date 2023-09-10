using System;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Factories
{
    public class AsyncColShapeFactory : IBaseObjectFactory<IColShape>
    {
        public IColShape Create(ICore core, IntPtr baseObjectPointer, uint id)
        {
            return new AsyncColShape(core, baseObjectPointer, id);
        }
    }
}