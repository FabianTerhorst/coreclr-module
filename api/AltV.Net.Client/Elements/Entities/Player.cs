using System.Numerics;

namespace AltV.Net.Client.Elements.Entities
{
    public class Player : IPlayer
    {
        public IntPtr NativePointer { get; }
        private readonly ICore _core;
        
        public Player(ICore core, IntPtr nativePointer, ushort id)
        {
            Id = id;
            _core = core;
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
                    this._core.Library.Player_GetPosition(this.NativePointer, &position);
                    return position;
                }
            }
        }
    }
}