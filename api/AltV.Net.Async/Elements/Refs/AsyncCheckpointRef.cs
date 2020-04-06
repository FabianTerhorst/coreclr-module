using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncCheckpointRef : IDisposable
    {
        private readonly ICheckpoint checkpoint;

        public bool Exists => checkpoint != null;

        public AsyncCheckpointRef(ICheckpoint checkpoint)
        {
            lock (checkpoint)
            {
                if (checkpoint.Exists) {
                    this.checkpoint = checkpoint.AddRef() ? checkpoint : null;
                    Alt.Module.CountUpRefForCurrentThread(checkpoint);
                }
                else
                {
                    this.checkpoint = null;
                }
            }
        }

        public void Dispose()
        {
            if (checkpoint == null) return;
            lock (checkpoint)
            {
                if (checkpoint.Exists)
                {
                    checkpoint.RemoveRef();
                }
            }

            Alt.Module.CountDownRefForCurrentThread(checkpoint);
        }
    }
}