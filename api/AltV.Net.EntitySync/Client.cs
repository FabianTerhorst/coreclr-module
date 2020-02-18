using System.Numerics;

namespace AltV.Net.EntitySync
{
    /// <summary>
    /// A client is a connected peer that authenticated itself via a token.
    /// In most cases the client contains a IPlayer object and gets the position and exists status out of this.
    /// </summary>
    public class Client : IClient
    {
        public string Token { get; }

        public virtual Vector3 Position { get; set; }

        public virtual int Dimension { get; set; }

        public ClientDataSnapshot Snapshot { get; } = new ClientDataSnapshot();

        public virtual bool Exists { get; } = true;

        private Vector3 positionOverride;

        private bool isPositionOverwritten;

        public Client(string token)
        {
            Token = token;
        }

        public virtual bool TryGetDimensionAndPosition(out int dimension, ref Vector3 position)
        {
            lock (this)
            {
                if (isPositionOverwritten)
                {
                    position = positionOverride;
                }
                else
                {
                    position = Position;
                }
                dimension = Dimension;
            }

            return true;
        }

        public virtual void SetPositionOverride(Vector3 newPositionOverride)
        {
            lock (this)
            {
                positionOverride = newPositionOverride;
                isPositionOverwritten = true;
            }
        }

        public virtual void ResetPositionOverride()
        {
            lock (this)
            {
                isPositionOverwritten = false;
            }
        }
    }
}