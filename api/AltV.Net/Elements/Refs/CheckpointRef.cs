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
        }

        public void Dispose()
        {
            checkpoint?.RemoveRef();
        }
    }
}