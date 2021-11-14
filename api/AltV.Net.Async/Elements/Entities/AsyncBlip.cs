using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncBlip<TBlip> : AsyncWorldObject<TBlip>, IBlip where TBlip: class, IBlip
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
                IEntity entity = default;
                AsyncContext.RunOnMainThreadBlocking(() => entity = BaseObject.AttachedTo);
                return entity;
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
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Sprite;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Sprite = value); }
        }

        public byte Color
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Color;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Color = value); }
        }

        public bool Route
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Route;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Route = value); }
        }

        public Rgba RouteColor
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.RouteColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.RouteColor = value); }
        }

        public Vector2 ScaleXY 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ScaleXY;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.ScaleXY = value); }
        }
        
        public short Display 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Display;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Display = value); }
        }
        
        public Rgba SecondaryColor 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.SecondaryColor;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.SecondaryColor = value); }
        }
        
        public byte Alpha 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Alpha;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Alpha = value); }
        }
        
        public ushort FlashTimer 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.FlashTimer;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.FlashTimer = value); }
        }
        
        public ushort FlashInterval 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.FlashInterval;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.FlashInterval = value); }
        }
        
        public bool Friendly 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Friendly;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Friendly = value); }
        }
        
        public bool Bright 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Bright;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Bright = value); }
        }
        
        public ushort Number 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Number;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Number = value); }
        }
        
        public bool ShowCone 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ShowCone;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.ShowCone = value); }
        }
        
        public bool Flashes 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Flashes;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Flashes = value); }
        }
        
        public bool FlashesAlternate 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.FlashesAlternate;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.FlashesAlternate = value); }
        }
        
        public bool ShortRange 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ShortRange;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.ShortRange = value); }
        }
        
        public ushort Priority
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Priority;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Priority = value); }
        }
        
        public float Rotation 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Rotation;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Rotation = value); }
        }
        
        public string GxtName 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.GxtName;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.GxtName = value); }
        }
        
        public string Name 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Name;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Name = value); }
        }
        
        public bool Pulse 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Pulse;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Pulse = value); }
        }
        
        public bool MissionCreator 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.MissionCreator;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.MissionCreator = value); }
        }
        
        public bool TickVisible 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TickVisible;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.TickVisible = value); }
        }
        
        public bool HeadingIndicatorVisible 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HeadingIndicatorVisible;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.HeadingIndicatorVisible = value); }
        }
        
        public bool OutlineIndicatorVisible 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.OutlineIndicatorVisible;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.OutlineIndicatorVisible = value); }
        }
        
        public bool CrewIndicatorVisible 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.CrewIndicatorVisible;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.CrewIndicatorVisible = value); }
        }
        
        public ushort Category 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Category;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Category = value); }
        }
        
        public bool HighDetail 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HighDetail;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.HighDetail = value); }
        }
        
        public bool Shrinked 
        {
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Shrinked;
                }
            }
            set { AsyncContext.Enqueue(() => BaseObject.Shrinked = value); }
        }

        public AsyncBlip(TBlip blip, IAsyncContext asyncContext) : base(blip, asyncContext)
        {
        }

        public void Fade(uint opacity, uint duration)
        {
            AsyncContext.Enqueue(() => BaseObject.Fade(opacity, duration));
        }

        public void Remove()
        {
            AsyncContext.RunOnMainThreadBlocking(() => BaseObject.Remove());
        }
    }
}