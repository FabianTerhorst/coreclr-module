using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces;

public interface IMarker : ISharedMarker, IWorldObject
{
    bool IsStreamedIn { get; }
}