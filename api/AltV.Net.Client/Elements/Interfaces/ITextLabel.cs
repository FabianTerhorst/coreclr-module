using AltV.Net.Client.Elements.Data;
using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Interfaces;

public interface ITextLabel : IWorldObject
{
    IntPtr TextLabelNativePointer { get; }

    bool IsGlobal { get; }
    IPlayer? Target { get; }
    Rgba Color { get; set; }
    Rgba OutlineColor { get; set; }
    float OutlineWidth { get; set; }
    float FontSize { get; set; }
    TextLabelAlignment Align { get; set; }
    string Text { get; set; }
    string Font { get; set; }
    bool Visible { get; set; }
    float Scale { get; set; }
    Rotation Rotation { get; set; }
    uint StreamingDistance { get; }
    bool IsStreamedIn { get; }

    bool IsFacingCamera { get; set; }
}