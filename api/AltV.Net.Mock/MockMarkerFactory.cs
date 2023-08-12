using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockMarkerFactory<TEntity> : IBaseObjectFactory<IMarker> where TEntity : IMarker
    {
        private readonly IBaseObjectFactory<IMarker> markerFactory;

        public MockMarkerFactory(IBaseObjectFactory<IMarker> markerFactory)
        {
            this.markerFactory = markerFactory;
        }

        public IMarker Create(ICore core, IntPtr entityPointer, uint id)
        {
            return MockDecorator<TEntity, IMarker>.Create((TEntity)markerFactory.Create(core, entityPointer, id),
                new MockMarker(core, entityPointer, id));
        }
    }
}