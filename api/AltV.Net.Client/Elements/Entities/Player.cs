using System.Numerics;

namespace AltV.Net.Client.Elements.Entities
{
    public class Player : IPlayer
    {
        public IntPtr NativePointer { get; }
        private readonly IClient _client;
        
        public Player(IClient client, IntPtr nativePointer, ushort id)
        {
            Id = id;
            _client = client;
            NativePointer = nativePointer;
        }
        
        public ushort Id { get; }
        public bool Exists => true; // todo

        public Vector3 Position
        {
            get
            {
                unsafe
                {
                    var position = Vector3.Zero;
                    this._client.Library.Player_GetPosition(this.NativePointer, &position);
                    return position;
                }
            }
        }
    }
}