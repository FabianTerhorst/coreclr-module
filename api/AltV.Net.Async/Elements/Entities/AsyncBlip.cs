using System;
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
        public IntPtr BlipNativePointer => BaseObject.BlipNativePointer;
        public bool IsGlobal
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsGlobal;
                }
            }
        }

        public bool IsAttached
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.IsAttached;
                }
            }
        }

        public IEntity AttachedTo
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.AttachedTo;
                }
            }
        }

        public byte BlipType
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.BlipType;
                }
            }
        }

        public ushort Sprite
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Sprite;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Sprite = value;
                }
            }
        }

        public byte Color
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Color;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Color = value;
                }
            }
        }

        public bool Route
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Route;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Route = value;
                }
            }
        }

        public Rgba RouteColor
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.RouteColor;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.RouteColor = value;
                }
            }
        }

        public Vector2 ScaleXY 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.ScaleXY;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.ScaleXY = value;
                }
            }
        }
        
        public short Display 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Display;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Display = value;
                }
            }
        }
        
        public Rgba SecondaryColor 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.SecondaryColor;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.SecondaryColor = value;
                }
            }
        }
        
        public byte Alpha 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Alpha;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Alpha = value;
                }
            }
        }
        
        public ushort FlashTimer 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.FlashTimer;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.FlashTimer = value;
                }
            }
        }
        
        public ushort FlashInterval 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.FlashInterval;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.FlashInterval = value;
                }
            }
        }
        
        public bool Friendly 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Friendly;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Friendly = value;
                }
            }
        }
        
        public bool Bright 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Bright;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Bright = value;
                }
            }
        }
        
        public ushort Number 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Number;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Number = value;
                }
            }
        }
        
        public bool ShowCone 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.ShowCone;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.ShowCone = value;
                }
            }
        }
        
        public bool Flashes 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Flashes;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Flashes = value;
                }
            }
        }
        
        public bool FlashesAlternate 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.FlashesAlternate;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.FlashesAlternate = value;
                }
            }
        }
        
        public bool ShortRange 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.ShortRange;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.ShortRange = value;
                }
            }
        }
        
        public ushort Priority
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Priority;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Priority = value;
                }
            }
        }
        
        public float Rotation 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Rotation;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Rotation = value;
                }
            }
        }
        
        public string GxtName 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.GxtName;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.GxtName = value;
                }
            }
        }
        
        public string Name 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Name;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Name = value;
                }
            }
        }
        
        public bool Pulse 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Pulse;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Pulse = value;
                }
            }
        }
        
        public bool MissionCreator 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.MissionCreator;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.MissionCreator = value;
                }
            }
        }
        
        public bool TickVisible 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.TickVisible;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.TickVisible = value;
                }
            }
        }
        
        public bool HeadingIndicatorVisible 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.HeadingIndicatorVisible;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.HeadingIndicatorVisible = value;
                }
            }
        }
        
        public bool OutlineIndicatorVisible 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.OutlineIndicatorVisible;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.OutlineIndicatorVisible = value;
                }
            }
        }
        
        public bool CrewIndicatorVisible 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.CrewIndicatorVisible;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.CrewIndicatorVisible = value;
                }
            }
        }
        
        public ushort Category 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Category;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Category = value;
                }
            }
        }
        
        public bool HighDetail 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.HighDetail;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.HighDetail = value;
                }
            }
        }
        
        public bool Shrinked 
        {
            get
            {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return default;
                    return BaseObject.Shrinked;
                }
            }
            set {
                lock (BaseObject)
                {
                    if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                    BaseObject.Shrinked = value;
                }
            }
        }

        public AsyncBlip(TBlip blip, IAsyncContext asyncContext) : base(blip, asyncContext)
        {
        }

        public void Fade(uint opacity, uint duration)
        {
            lock (BaseObject)
            {
                if (!AsyncContext.CheckIfExistsNullable(BaseObject)) return;
                BaseObject.Fade(opacity, duration);
            }
        }
    }
}