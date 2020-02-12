using System.Numerics;

namespace AltV.Net.EntitySync
{
    public interface IClient
    {
        string Token { get; }
        
        Vector3 Position { get; set; }
        
        int Dimension { get; set; }
        
        ClientDataSnapshot Snapshot { get; }
        
        bool Exists { get; }

        public bool TryGetDimensionAndPosition(out int dimension, out Vector3 position);

        public void SetPositionOverride(Vector3 newPositionOverride);

        public void ResetPositionOverride();

        //TODO: save streamed in entities in client i think
    }
}