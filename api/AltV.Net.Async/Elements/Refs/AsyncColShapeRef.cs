using System;
using System.Diagnostics;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncColShapeRef : IDisposable
    {
        private readonly IColShape colShape;

        public bool Exists => colShape != null;

        public AsyncColShapeRef(IColShape colShape)
        {
            if (colShape == null)
            {
                this.colShape = null;
            }
            else
            {
                lock (colShape)
                {
                    this.colShape = colShape.AddRef() ? colShape : null;
                }
            }
        }

        [Conditional("DEBUG")]
        public void DebugCountUp()
        {
            Alt.Module.CountUpRefForCurrentThread(colShape);
        }

        [Conditional("DEBUG")]
        public void DebugCountDown()
        {
            Alt.Module.CountDownRefForCurrentThread(colShape);
        }

        public void Dispose()
        {
            colShape?.RemoveRef();
        }
    }
}