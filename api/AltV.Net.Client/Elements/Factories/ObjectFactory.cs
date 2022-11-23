using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class ObjectFactory : IEntityFactory<IObject>
    {
        public IObject Create(ICore core, IntPtr objectPointer, ushort id)
        {
            return new ObjectEntity(core, objectPointer, id);
        }
    }
}