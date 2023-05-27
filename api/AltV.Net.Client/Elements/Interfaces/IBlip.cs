using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IBlip : ISharedBlip, IWorldObject
    {
        bool IsRemote { get; }
        uint GameId { get; }
        bool Visible { get; set; }
    }
}