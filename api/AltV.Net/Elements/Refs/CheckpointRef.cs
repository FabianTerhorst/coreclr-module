using System;
using System.Diagnostics;
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

        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.Module.CountUpRefForCurrentThread(checkpoint);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.Module.CountDownRefForCurrentThread(checkpoint);
        }
        
        public void Dispose()
        {
            checkpoint?.RemoveRef();
        }
    }
}