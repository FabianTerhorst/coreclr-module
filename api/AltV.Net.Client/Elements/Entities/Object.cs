using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class Object : Entity, IObject
{
    public IntPtr ObjectNativePointer { get; private set; }

    private static IntPtr GetEntityPointer(ICore core, IntPtr pointer)
    {
        unsafe
        {
            return core.Library.Shared.Object_GetEntity(pointer);
        }
    }

    public static uint GetId(IntPtr pointer)
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Object_GetID(pointer);
        }
    }

    public Object(ICore core, IntPtr nativePointer, uint id) : base(core, GetEntityPointer(core, nativePointer), id, BaseObjectType.Object)
    {
        this.ObjectNativePointer = nativePointer;
    }

    public Object(ICore core, IntPtr nativePointer, BaseObjectType type, uint id) : base(core, GetEntityPointer(core, nativePointer), id, type)
    {
        this.ObjectNativePointer = nativePointer;
    }

    public byte Alpha
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Object_GetAlpha(ObjectNativePointer);
            }
        }
    }

    public ushort LodDistance
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Object_GetLodDistance(ObjectNativePointer);
            }
        }
    }

    public byte TextureVariation
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Object_GetTextureVariation(ObjectNativePointer);
            }
        }
    }

    public override void SetCached(IntPtr cachedNetworkObject)
    {
        this.ObjectNativePointer = cachedNetworkObject;
        base.SetCached(GetEntityPointer(Core, cachedNetworkObject));
    }
}