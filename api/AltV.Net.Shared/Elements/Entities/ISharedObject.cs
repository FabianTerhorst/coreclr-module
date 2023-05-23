using AltV.Net.Data;

namespace AltV.Net.Shared.Elements.Entities;

public interface ISharedObject : ISharedEntity
{
    new uint Model { get; set; }
    IntPtr ObjectNativePointer { get; }
    byte Alpha { get; set; }
    void ResetAlpha();
    bool IsDynamic { get; }
    ushort LodDistance { get; set; }
    bool Gravity { get; set; }
    void AttachToEntity(ISharedEntity entity, short bone, Position position, Rotation rotation, bool useSoftPinning, bool collision, bool fixedRotation);
    void AttachToEntity(uint scriptId, short bone, Position position, Rotation rotation, bool useSoftPinning, bool collision, bool fixedRotation);
    void Detach(bool dynamic);
    bool Collision { get; }
    void ToggleCollision(bool toggle, bool keepPhysics);
    void PlaceOnGroundProperly();
    void SetPositionFrozen(bool state);
    void ActivatePhysics();
    byte TextureVariation { get; set; }

    /// <summary>
    /// true = Created by GTA, false = Created by API
    /// </summary>
    bool IsWorldObject { get; }

    uint StreamingDistance { get; }

    bool Visible { get; set; }
}