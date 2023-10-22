using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IBaseObject : ISharedBaseObject
    {
        new ICore Core { get; }
        uint RemoteId { get; }
        bool IsRemote { get; }
    }
}