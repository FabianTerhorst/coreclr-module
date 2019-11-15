using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Elements.Refs
{
    public readonly struct ColShapeRef : IDisposable
    {
        private readonly IColShape colShape;

        public bool Exists => colShape != null;

        public ColShapeRef(IColShape colShape)
        {
            this.colShape = colShape.AddRef() ? colShape : null;
        }

        public void Dispose()
        {
            colShape?.RemoveRef();
        }
    }
}