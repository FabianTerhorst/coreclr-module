using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Refs
{
    public readonly struct CheckpointRef : IDisposable
    {
        private readonly ICheckpoint checkpoint;

        public bool Exists => checkpoint != null;

        public CheckpointRef(ICheckpoint checkpoint)
        {
            this.checkpoint = checkpoint.AddRef() ? checkpoint : null;
            Alt.Module.CountUpRefForCurrentThread(checkpoint);
        }

        public void Dispose()
        {
            checkpoint?.RemoveRef();
            Alt.Module.CountDownRefForCurrentThread(checkpoint);
        }
    }
}