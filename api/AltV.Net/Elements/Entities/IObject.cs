using System;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities;

public interface IObject : ISharedObject, IEntity
{
    new byte Alpha { get; set; }
    new byte TextureVariation { get; set; }
    new ushort LodDistance { get; set; }
    void PlaceOnGroundProperly();
    void ActivatePhysics();
}