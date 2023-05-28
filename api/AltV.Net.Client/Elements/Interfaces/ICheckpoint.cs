using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface ICheckpoint : ISharedCheckpoint, IWorldObject
    {
        bool IsStreamedIn { get; }
        uint GameId { get; }
    }
}