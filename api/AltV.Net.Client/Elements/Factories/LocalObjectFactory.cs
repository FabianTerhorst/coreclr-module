using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class LocalObjectFactory : IEntityFactory<ILocalObject>
    {
        public ILocalObject Create(ICore core, IntPtr objectPointer, uint id)
        {
            return new LocalObject(core, objectPointer, id);
        }
    }
}