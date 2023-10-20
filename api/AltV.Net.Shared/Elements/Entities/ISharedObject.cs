namespace AltV.Net.Shared.Elements.Entities;

public interface ISharedObject : ISharedEntity
{
    IntPtr ObjectNativePointer { get; }
    byte Alpha { get; }
    byte TextureVariation { get; }
    ushort LodDistance { get; }
}