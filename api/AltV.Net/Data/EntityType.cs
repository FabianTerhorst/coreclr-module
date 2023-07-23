using System;

namespace AltV.Net.Data;

[Flags]
public enum EntityType
{
    Player = 1,
    Vehicle = 2,
    // Disable current not supported types
    /*
    Ped = 4,
    NetworkObject = 8,
    Blip = 16,
    Webview = 32,
    VoiceChannel = 64,
    ColShape = 128,
    Checkpoint = 256,
    WebsocketClient = 512,
    HttpClient = 1024,
    Audio = 2048,
    RmlElement = 4096,
    RmlDocument = 8192,
    LocalPlayer = 16384,
    Object = 32768,
    VirtualEntity = 65536,
    VirtualEntityGroup = 131072,
    Marker = 262144,
    TextLabel = 524288,
    LocalPed = 1048576,
    LocalVehicle = 2097152,
    AudioFilter = 4194304,
    ConnectionInfo = 8388608,
    Size = 16777216,
    Undefined = 33554432,
    */
}