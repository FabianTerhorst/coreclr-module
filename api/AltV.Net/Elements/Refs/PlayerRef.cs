using System;
using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Refs
{
    public readonly struct PlayerRef : IDisposable
    {
        private readonly IPlayer player;

        public bool Exists => player != null;

        public PlayerRef(IPlayer player)
        {
            this.player = player.AddRef() ? player : null;
        }

        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.Module.CountUpRefForCurrentThread(player);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.Module.CountDownRefForCurrentThread(player);
        }

        public void Dispose()
        {
            player?.RemoveRef();
        }
    }
}