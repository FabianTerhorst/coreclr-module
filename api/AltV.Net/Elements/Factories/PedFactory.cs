using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Factories;

public class PedFactory : IEntityFactory<IPed>
{
    public IPed Create(ICore core, IntPtr pedPointer, uint id)
    {
        return new Ped(core, pedPointer, id);
    }
}