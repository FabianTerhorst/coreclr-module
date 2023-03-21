using System;

namespace AltV.Net.Data;

[Flags]
public enum EntityType
{
    Player = 0x000001,
    Vehicle = 0x000002,
    Blip = 0x000004,
    Webview = 0x000008,
    VoiceChannel = 0x000016,
    ColShape = 0x000032,
    Checkpoint = 0x000064,
    WebsocketClient = 0x000128,
    HttpClient = 0x000256,
    Audio = 0x000512,
    RmlElement = 0x001024,
    RmlDocument = 0x002048,
    LocalPlayer = 0x004096,
    Object = 0x008192,
    Ped = 0x016384,
    VirtualEntity = 0x032768,
    Marker = 0x065536,
    TextLabel = 0x131072,
    Pickup = 0x262144,
    Undefined = 255
}