using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories;

public class PedFactory : IEntityFactory<IPed>
{
    public IPed Create(ICore core, IntPtr pedPointer, uint id)
    {
        return new Ped(core, pedPointer, id);
    }
}