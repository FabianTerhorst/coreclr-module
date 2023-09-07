using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools;

public class ObjectPool : EntityPool<IObject>
{
    public ObjectPool(IEntityFactory<IObject> factory) : base(factory)
    {
    }

    protected override uint GetId(IntPtr objectPointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Object_GetID(objectPointer);
        }
    }
}