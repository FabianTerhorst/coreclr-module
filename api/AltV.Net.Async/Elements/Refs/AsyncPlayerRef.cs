using System;
using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncPlayerRef : IDisposable
    {
        private readonly IPlayer player;

        public bool Exists => player != null;

        public AsyncPlayerRef(IPlayer player)
        {
            if (player == null)
            {
                this.player = null;
            }
            else
            {
                lock (player)
                {
                    this.player = player.AddRef() ? player : null;
                }
            }
        }

        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.CoreImpl.CountUpRefForCurrentThread(player);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.CoreImpl.CountDownRefForCurrentThread(player);
        }

        public void Dispose()
        {
            player?.RemoveRef();
        }
    }
}