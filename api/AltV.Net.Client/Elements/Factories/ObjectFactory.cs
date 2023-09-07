using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class ObjectFactory : IEntityFactory<IObject>
    {
        public IObject Create(ICore core, IntPtr objectPointer, uint id)
        {
            return new Entities.Object(core, objectPointer, id);
        }
    }
}