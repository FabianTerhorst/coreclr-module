using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class ColShapeFactory : IBaseObjectFactory<IColShape>
    {
        public IColShape Create(ICore core, IntPtr blipPointer, uint id)
        {
            return new ColShape(core, blipPointer, id);
        }
    }
}