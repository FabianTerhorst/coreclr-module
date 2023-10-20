using System;
using AltV.Net.Elements.Entities;
using Object = AltV.Net.Elements.Entities.Object;

namespace AltV.Net.Elements.Factories;

public class ObjectFactory : IEntityFactory<IObject>
{
    public IObject Create(ICore core, IntPtr pointer, uint id)
    {
        return new Object(core, pointer, id);
    }
}