using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockBlip : MockWorldObject, IBlip
    {
        public MockBlip(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, BaseObjectType.Blip, id)
        {
        }

        public IntPtr BlipNativePointer { get; }
        public bool IsGlobal { get; set; }
        public void AddTargetPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void RemoveTargetPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IPlayer> GetTargets()
        {
            throw new NotImplementedException();
        }

        public bool IsAttached { get; set; }
        public IEntity AttachedTo { get; set; }
        public byte BlipType { get; set; }
        public uint Sprite { get; set; }
        public uint Color { get; set; }
        public bool Route { get; set; }
        public Rgba RouteColor { get; set; }
        public Vector2 ScaleXY { get; set; }
        public uint Display { get; set; }
        public Rgba SecondaryColor { get; set; }
        public uint Alpha { get; set; }
        public ushort FlashTimer { get; set; }
        public ushort FlashInterval { get; set; }
        public bool Friendly { get; set; }
        public bool Bright { get; set; }
        public ushort Number { get; set; }
        public bool ShowCone { get; set; }
        public bool Flashes { get; set; }
        public bool FlashesAlternate { get; set; }
        public bool ShortRange { get; set; }
        public uint Priority { get; set; }
        public float Rotation { get; set; }
        public string GxtName { get; set; }
        public string Name { get; set; }
        public bool Pulse { get; set; }
        public bool MissionCreator { get; set; }
        public bool TickVisible { get; set; }
        public bool HeadingIndicatorVisible { get; set; }
        public bool OutlineIndicatorVisible { get; set; }
        public bool CrewIndicatorVisible { get; set; }
        public uint Category { get; set; }
        public bool HighDetail { get; set; }
        public bool Shrinked { get; set; }

        public void Fade(uint opacity, uint duration)
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            Alt.Core.RemoveBlip(this);
        }

        public bool Visible { get; set; }
        public bool IsHiddenOnLegend { get; set; }
        public bool IsMinimalOnEdge { get; set; }
        public bool IsUseHeightIndicatorOnEdge { get; set; }
        public bool IsShortHeightThreshold { get; set; }
    }
}