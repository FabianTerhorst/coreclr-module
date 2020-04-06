using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncPlayerRef : IDisposable
    {
        private readonly IPlayer player;

        public bool Exists => player != null;

        public AsyncPlayerRef(IPlayer player)
        {
            lock (player)
            {
                if (player.Exists)
                {
                    this.player = player.AddRef() ? player : null;
                    Alt.Module.CountUpRefForCurrentThread(player);
                }
                else
                {
                    this.player = null;
                }
            }
        }

        public void Dispose()
        {
            if (player == null) return;
            lock (player)
            {
                if (player.Exists)
                {
                    player.RemoveRef();
                }
            }

            Alt.Module.CountDownRefForCurrentThread(player);
        }
    }
}