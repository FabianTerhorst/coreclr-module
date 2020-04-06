using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Refs
{
    public readonly struct AsyncColShapeRef : IDisposable
    {
        private readonly IColShape colShape;

        public bool Exists => colShape != null;

        public AsyncColShapeRef(IColShape colShape)
        {
            lock (colShape)
            {
                if (colShape.Exists) {
                    this.colShape = colShape.AddRef() ? colShape : null;
                    Alt.Module.CountUpRefForCurrentThread(colShape);
                }
                else
                {
                    this.colShape = null;
                }
            }
        }

        public void Dispose()
        {
            if (colShape == null) return;
            lock (colShape)
            {
                if (colShape.Exists)
                {
                    colShape.RemoveRef();
                }
            }

            Alt.Module.CountDownRefForCurrentThread(colShape);
        }
    }
}