using System.Diagnostics.CodeAnalysis;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncBlip : AsyncWorldObject<IBlip>, IBlip
    {
        public bool IsGlobal
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsGlobal;
                }
            }
        }

        public bool IsAttached
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.IsAttached;
                }
            }
        }

        public IEntity AttachedTo
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.AttachedTo;
                }
            }
        }

        public byte BlipType
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.BlipType;
                }
            }
        }

        public ushort Sprite
        {
            set
            {
                AsyncContext.Enqueue(() => BaseObject.Sprite = value);
            }
        }

        public byte Color
        {
            set
            {
                AsyncContext.Enqueue(() => BaseObject.Color = value);
            }
        }

        public bool Route
        {
            set
            {
                AsyncContext.Enqueue(() => BaseObject.Route = value);
            }
        }

        public byte RouteColor
        {
            set
            {
                AsyncContext.Enqueue(() => BaseObject.RouteColor = value);
            }
        }

        public AsyncBlip(IBlip blip, IAsyncContext asyncContext):base(blip, asyncContext)
        {
        }
        
        public void Remove()
        {
            AsyncContext.RunOnMainThreadBlocking(() => BaseObject.Remove());
        }
    }
}