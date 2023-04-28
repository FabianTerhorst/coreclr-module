using AltV.Net.Client.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces;

public interface ILocalVehicle : ISharedLocalVehicle, IWorldObject
{
    uint RemoteId { get; }
    bool IsRemote { get; }
    bool IsStreamedIn { get; }
}