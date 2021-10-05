using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncBlip : AsyncWorldObject<IBlip>, IBlip
    {
        public bool IsGlobal { get; }
        public bool IsAttached { get; }
        public IEntity AttachedTo { get; }
        public byte BlipType { get; }
        public ushort Sprite { get; set; }
        public byte Color { get; set; }
        public bool Route { get; set; }
        public byte RouteColor { get; set; }

        public AsyncBlip(IBlip blip, IAsyncContext asyncContext):base(blip, asyncContext)
        {
        }
        
        public void Remove()
        {
            throw new System.NotImplementedException();
        }
    }
}