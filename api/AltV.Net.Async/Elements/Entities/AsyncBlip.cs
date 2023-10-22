using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async.Elements.Entities
{
    [SuppressMessage("ReSharper",
        "InconsistentlySynchronizedField")] // we sometimes use object in lock and sometimes not
    public class AsyncBlip : AsyncWorldObject, IBlip, IAsyncConvertible<IBlip>
    {
        protected readonly IBlip Blip;
        public IntPtr BlipNativePointer => Blip.BlipNativePointer;
        public void AddTargetPlayer(IPlayer player)
        {
            lock (Blip)
            {
                if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                Blip.AddTargetPlayer(player);
            }
        }

        public void RemoveTargetPlayer(IPlayer player)
        {
            lock (Blip)
            {
                if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                Blip.RemoveTargetPlayer(player);
            }
        }

        public IReadOnlyCollection<IPlayer> GetTargets()
        {
            lock (Blip)
            {
                if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                return Blip.GetTargets();
            }
        }

        public bool IsGlobal
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.IsGlobal;
                }
            }
            set
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.IsGlobal = value;
                }
            }
        }

        public bool IsAttached
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.IsAttached;
                }
            }
        }

        public IEntity AttachedTo
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.AttachedTo;
                }
            }
        }

        public byte BlipType
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.BlipType;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.BlipType = value;
                }
            }
        }

        public uint Sprite
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Sprite;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Sprite = value;
                }
            }
        }

        public uint Color
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Color;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Color = value;
                }
            }
        }

        public bool Route
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Route;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Route = value;
                }
            }
        }

        public Rgba RouteColor
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.RouteColor;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.RouteColor = value;
                }
            }
        }

        public Vector2 ScaleXY
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.ScaleXY;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.ScaleXY = value;
                }
            }
        }

        public uint Display
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Display;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Display = value;
                }
            }
        }

        public Rgba SecondaryColor
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.SecondaryColor;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.SecondaryColor = value;
                }
            }
        }

        public uint Alpha
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Alpha;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Alpha = value;
                }
            }
        }

        public ushort FlashTimer
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.FlashTimer;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.FlashTimer = value;
                }
            }
        }

        public ushort FlashInterval
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.FlashInterval;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.FlashInterval = value;
                }
            }
        }

        public bool Friendly
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Friendly;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Friendly = value;
                }
            }
        }

        public bool Bright
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Bright;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Bright = value;
                }
            }
        }

        public ushort Number
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Number;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Number = value;
                }
            }
        }

        public bool ShowCone
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.ShowCone;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.ShowCone = value;
                }
            }
        }

        public bool Flashes
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Flashes;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Flashes = value;
                }
            }
        }

        public bool FlashesAlternate
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.FlashesAlternate;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.FlashesAlternate = value;
                }
            }
        }

        public bool ShortRange
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.ShortRange;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.ShortRange = value;
                }
            }
        }

        public uint Priority
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Priority;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Priority = value;
                }
            }
        }

        public float Rotation
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Rotation;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Rotation = value;
                }
            }
        }

        public string GxtName
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.GxtName;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.GxtName = value;
                }
            }
        }

        public string Name
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Name;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Name = value;
                }
            }
        }

        public bool Pulse
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Pulse;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Pulse = value;
                }
            }
        }

        public bool MissionCreator
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.MissionCreator;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.MissionCreator = value;
                }
            }
        }

        public bool TickVisible
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.TickVisible;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.TickVisible = value;
                }
            }
        }

        public bool HeadingIndicatorVisible
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.HeadingIndicatorVisible;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.HeadingIndicatorVisible = value;
                }
            }
        }

        public bool OutlineIndicatorVisible
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.OutlineIndicatorVisible;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.OutlineIndicatorVisible = value;
                }
            }
        }

        public bool CrewIndicatorVisible
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.CrewIndicatorVisible;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.CrewIndicatorVisible = value;
                }
            }
        }

        public uint Category
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Category;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Category = value;
                }
            }
        }

        public bool HighDetail
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.HighDetail;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.HighDetail = value;
                }
            }
        }

        public bool Shrinked
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Shrinked;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Shrinked = value;
                }
            }
        }

        public AsyncBlip(IBlip blip, IAsyncContext asyncContext) : base(blip, asyncContext)
        {
            Blip = blip;
        }

        public AsyncBlip(ICore core, IntPtr nativePointer, uint id) : this(new Blip(core, nativePointer, id), null)
        {
        }

        public void Fade(uint opacity, uint duration)
        {
            lock (Blip)
            {
                if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                Blip.Fade(opacity, duration);
            }
        }

        public bool Visible
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.Visible;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.Visible = value;
                }
            }
        }

        public bool IsHiddenOnLegend
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.IsHiddenOnLegend;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.IsHiddenOnLegend = value;
                }
            }
        }

        public bool IsMinimalOnEdge
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.IsMinimalOnEdge;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.IsMinimalOnEdge = value;
                }
            }
        }

        public bool IsUseHeightIndicatorOnEdge
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.IsUseHeightIndicatorOnEdge;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.IsUseHeightIndicatorOnEdge = value;
                }
            }
        }

        public bool IsShortHeightThreshold
        {
            get
            {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return default;
                    return Blip.IsShortHeightThreshold;
                }
            }
            set {
                lock (Blip)
                {
                    if (!AsyncContext.CheckIfExistsNullable(Blip)) return;
                    Blip.IsShortHeightThreshold = value;
                }
            }
        }


        [Obsolete("Use new async API instead")]
        public IBlip ToAsync(IAsyncContext asyncContext)
        {
            return this;
        }
    }
}