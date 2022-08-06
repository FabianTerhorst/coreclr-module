using AltV.Net.Data;

namespace AltV.Net.Shared.Elements.Entities;

public interface ISharedObject : ISharedEntity
{
    IntPtr ObjectNativePointer { get; }
    byte Alpha { get; set; }
    void ResetAlpha();
    bool IsDynamic { get; }
    ushort LodDistance { get; set; }
    bool Gravity { get; set; }
    void AttachToEntity(ISharedEntity entity, short bone, Position position, Rotation rotation, bool useSoftPinning, bool collision, bool fixedRotation);
    void Detach();
}