using System;
using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncCheckpointRef : IDisposable
    {
        private readonly ICheckpoint checkpoint;

        public bool Exists => checkpoint != null;

        public AsyncCheckpointRef(ICheckpoint checkpoint)
        {
            if (checkpoint == null)
            {
                this.checkpoint = null;
            }
            else
            {
                lock (checkpoint)
                {
                    this.checkpoint = checkpoint.AddRef() ? checkpoint : null;
                }
            }
        }

        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.CoreImpl.CountUpRefForCurrentThread(checkpoint);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.CoreImpl.CountDownRefForCurrentThread(checkpoint);
        }

        public void Dispose()
        {
            checkpoint?.RemoveRef();
        }
    }
}