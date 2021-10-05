using System.Diagnostics.CodeAnalysis;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncCheckpoint : AsyncColShape<ICheckpoint>, ICheckpoint
    {
        public byte CheckpointType { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }
        public Rgba Color { get; set; }
        public Position NextPosition { get; set; }
        
        public AsyncCheckpoint(ICheckpoint checkpoint, IAsyncContext asyncContext):base(checkpoint, asyncContext)
        {
        }
    }
}