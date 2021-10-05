using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncColShape<TColShape> : AsyncWorldObject<TColShape>, IColShape where TColShape: class, IColShape
    {
        public ColShapeType ColShapeType { get; }
        public bool IsPlayersOnly { get; set; }
        
        public AsyncColShape(TColShape colShape, IAsyncContext asyncContext):base(colShape, asyncContext)
        {
        }
        
        public bool IsEntityIn(IEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public bool IsPlayerIn(IPlayer entity)
        {
            throw new System.NotImplementedException();
        }

        public bool IsVehicleIn(IVehicle entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove()
        {
            throw new System.NotImplementedException();
        }
    }
}