﻿using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Interfaces;

public interface ITextLabel : IWorldObject
{
    IntPtr TextLabelNativePointer { get; }

    uint Id { get; }
    bool IsRemote { get; }
    ulong RemoteId { get; }

    bool IsGlobal { get; }
    IPlayer? Target { get; }
    Rgba Color { get; set; }
    bool Visible { get; set; }
    float Scale { get; set; }
    Rotation Rotation { get; set; }
    uint StreamingDistance { get; }
    bool IsStreamedIn { get; }
}