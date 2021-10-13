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
            set { AsyncContext.Enqueue(() => BaseObject.Sprite = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Sprite;
                }
            }
        }

        public byte Color
        {
            set { AsyncContext.Enqueue(() => BaseObject.Color = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Color;
                }
            }
        }

        public bool Route
        {
            set { AsyncContext.Enqueue(() => BaseObject.Route = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Route;
                }
            }
        }

        public Rgba RouteColor
        {
            set { AsyncContext.Enqueue(() => BaseObject.RouteColor = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.RouteColor;
                }
            }
        }

        public Vector2 ScaleXY 
        {
            set { AsyncContext.Enqueue(() => BaseObject.ScaleXY = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ScaleXY;
                }
            }
        }
        
        public short Display 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Display = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Display;
                }
            }
        }
        
        public Rgba SecondaryColor 
        {
            set { AsyncContext.Enqueue(() => BaseObject.SecondaryColor = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.SecondaryColor;
                }
            }
        }
        
        public byte Alpha 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Alpha = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Alpha;
                }
            }
        }
        
        public ushort FlashTimer 
        {
            set { AsyncContext.Enqueue(() => BaseObject.FlashTimer = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.FlashTimer;
                }
            }
        }
        
        public ushort FlashInterval 
        {
            set { AsyncContext.Enqueue(() => BaseObject.FlashInterval = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.FlashInterval;
                }
            }
        }
        
        public bool Friendly 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Friendly = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Friendly;
                }
            }
        }
        
        public bool Bright 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Bright = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Bright;
                }
            }
        }
        
        public ushort Number 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Number = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Number;
                }
            }
        }
        
        public bool ShowCone 
        {
            set { AsyncContext.Enqueue(() => BaseObject.ShowCone = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ShowCone;
                }
            }
        }
        
        public bool Flashes 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Flashes = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Flashes;
                }
            }
        }
        
        public bool FlashesAlternate 
        {
            set { AsyncContext.Enqueue(() => BaseObject.FlashesAlternate = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.FlashesAlternate;
                }
            }
        }
        
        public bool ShortRange 
        {
            set { AsyncContext.Enqueue(() => BaseObject.ShortRange = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.ShortRange;
                }
            }
        }
        
        public ushort Priority
        {
            set { AsyncContext.Enqueue(() => BaseObject.Priority = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Priority;
                }
            }
        }
        
        public float Rotation 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Rotation = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Rotation;
                }
            }
        }
        
        public string GxtName 
        {
            set { AsyncContext.Enqueue(() => BaseObject.GxtName = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.GxtName;
                }
            }
        }
        
        public string Name 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Name = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Name;
                }
            }
        }
        
        public bool Pulse 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Pulse = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Pulse;
                }
            }
        }
        
        public bool MissionCreator 
        {
            set { AsyncContext.Enqueue(() => BaseObject.MissionCreator = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.MissionCreator;
                }
            }
        }
        
        public bool TickVisible 
        {
            set { AsyncContext.Enqueue(() => BaseObject.TickVisible = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.TickVisible;
                }
            }
        }
        
        public bool HeadingIndicatorVisible 
        {
            set { AsyncContext.Enqueue(() => BaseObject.HeadingIndicatorVisible = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HeadingIndicatorVisible;
                }
            }
        }
        
        public bool OutlineIndicatorVisible 
        {
            set { AsyncContext.Enqueue(() => BaseObject.OutlineIndicatorVisible = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.OutlineIndicatorVisible;
                }
            }
        }
        
        public bool CrewIndicatorVisible 
        {
            set { AsyncContext.Enqueue(() => BaseObject.CrewIndicatorVisible = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.CrewIndicatorVisible;
                }
            }
        }
        
        public ushort Category 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Category = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Category;
                }
            }
        }
        
        public bool HighDetail 
        {
            set { AsyncContext.Enqueue(() => BaseObject.HighDetail = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.HighDetail;
                }
            }
        }
        
        public bool Shrinked 
        {
            set { AsyncContext.Enqueue(() => BaseObject.Shrinked = value); }
            get
            {
                AsyncContext.RunAll();
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExists(BaseObject)) return default;
                    return BaseObject.Shrinked;
                }
            }
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