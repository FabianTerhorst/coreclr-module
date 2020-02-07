using System.Numerics;

namespace AltV.Net.EntitySync
{
    public interface IClient
    {
        string Token { get; }
        
        Vector3 Position { get; set; }
        
        ClientDataSnapshot Snapshot { get; }
        
        bool Exists { get; }

        public bool TryGetPosition(out Vector3 position);

        //TODO: save streamed in entities in client i think
    }
}