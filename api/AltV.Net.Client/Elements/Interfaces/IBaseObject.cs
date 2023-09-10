using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IBaseObject : ISharedBaseObject
    {
        new ICore Core { get; }
        [Obsolete("Use Destroy() instead")]
        public void Remove();
        public void Destroy();
        uint RemoteId { get; }
        bool IsRemote { get; }
    }
}