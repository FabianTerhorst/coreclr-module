using System;

namespace AltV.Net.Data;

[Flags]
public enum EntityType
{
    Player = 1,
    Vehicle = 2,
    Ped = 4,
    Object = 8,
    // Disable current not supported types
    /*
    Blip = 16,
    Webview = 32,
    VoiceChannel = 64,
    ColShape = 128,
    Checkpoint = 256,
    WebsocketClient = 512,
    HttpClient = 1024,
    Audio = 2048,
    AudioOutput = 4096,
    AudioOutputWorld = 8192,
    AudioOutputAttached = 16384,
    AudioOutputFrontend = 32768,
    RmlElement = 65536,
    RmlDocument = 131072,
    LocalPlayer = 262144,
    LocalObject = 524288,
    VirtualEntity = 1048576,
    VirtualEntityGroup = 2097152,
    Marker = 4194304,
    TextLabel = 8388608,
    LocalPed = 16777216,
    LocalVehicle = 33554432,
    AudioFilter = 67108864,
    ConnectionInfo = 134217728,
    CustomTexture = 268435456,
    Font = 536870912,
    Size = 1073741824,
    Undefined = -2147483648,
    */

}