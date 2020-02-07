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

        public ClientDataSnapshot Snapshot { get; } = new ClientDataSnapshot();

        public virtual bool Exists { get; } = true;

        public Client(string token)
        {
            Token = token;
        }

        public virtual bool TryGetPosition(out Vector3 position)
        {
            position = Position;
            return true;
        }
    }
}