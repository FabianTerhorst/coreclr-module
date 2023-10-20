using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools;

public class LocalObjectPool : EntityPool<ILocalObject>
{
    public LocalObjectPool(IEntityFactory<ILocalObject> factory) : base(factory)
    {
    }

    protected override uint GetId(IntPtr objectPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Client.LocalObject_GetID(objectPointer);
        }
    }
}