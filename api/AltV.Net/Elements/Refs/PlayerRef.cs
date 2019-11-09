using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Elements.Refs
{
    public readonly struct PlayerRef : IDisposable
    {
        private readonly IntPtr playerPtr;

        public bool Exists => playerPtr != IntPtr.Zero;

        public PlayerRef(IPlayer player)
        {
            lock (player)
            {
                if (player.Exists)
                {
                    playerPtr = player.NativePointer;
                    AltNative.Player.Player_AddRef(playerPtr);       
                }
                else
                {
                    playerPtr = IntPtr.Zero;
                }
            }
        }

        public void Dispose()
        {
            if (playerPtr == IntPtr.Zero) return;
            AltNative.Player.Player_RemoveRef(playerPtr);
        }
    }
}