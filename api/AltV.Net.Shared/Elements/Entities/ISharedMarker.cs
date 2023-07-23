using AltV.Net.Data;
using AltV.Net.Shared.Enums;

namespace AltV.Net.Shared.Elements.Entities;

public interface ISharedMarker : ISharedWorldObject
{
    IntPtr MarkerNativePointer { get; }
    uint Id { get; }
    bool IsGlobal { get; }
    ISharedPlayer Target { get; }
    Rgba Color { get; set; }
    bool Visible { get; set; }
    MarkerType MarkerType { get; set; }
    Position Scale { get; set; }
    Rotation Rotation { get; set; }
    Position Direction { get; set; }

    uint StreamingDistance { get; }
    bool IsFaceCamera { get; set; }
    bool IsRotating { get; set; }
    bool IsBobUpDown { get; set; }
}