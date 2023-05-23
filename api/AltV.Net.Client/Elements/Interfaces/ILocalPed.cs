using AltV.Net.Client.Elements.Entities;
using AltV.Net.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces;

public interface ILocalPed : IWorldObject
{
    uint Model { get; set; }
    Rotation Rotation { get; set; }
    uint StreamingDistance { get; }
    bool Visible { get; set; }
    uint RemoteId { get; }
    bool IsRemote { get; }
    bool IsStreamedIn { get; }
}