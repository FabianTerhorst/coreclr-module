using System;

namespace AltV.Net.Elements.Entities;

public interface INetworkObject : IEntity
{
    IntPtr NetworkObjectNativePointer { get; }
    byte Alpha { get; set; }
    ushort LodDistance { get; set; }
    void PlaceOnGroundProperly();
    void ActivatePhysics();
    byte TextureVariation { get; set; }
}