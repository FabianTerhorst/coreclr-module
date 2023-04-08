using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools;

public class PedPool : EntityPool<IPed>
{
    public PedPool(IEntityFactory<IPed> entityFactory) : base(entityFactory)
    {
    }

    protected override uint GetId(IntPtr pedPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Ped_GetID (pedPointer);
        }
    }
}