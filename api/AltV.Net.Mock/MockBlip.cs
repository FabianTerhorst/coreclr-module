using System;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockBlip : MockWorldObject, IBlip
    {
        public MockBlip(ICore core, IntPtr nativePointer) : base(core, nativePointer, BaseObjectType.Blip)
        {
        }

        public IntPtr BlipNativePointer { get; }
        public bool IsGlobal { get; }
        public bool IsAttached { get; set; }
        public IEntity AttachedTo { get; set; }
        public byte BlipType { get; set; }
        public ushort Sprite { get; set; }
        public byte Color { get; set; }
        public bool Route { get; set; }
        public Rgba RouteColor { get; set; }
        public Vector2 ScaleXY { get; set; }
        public short Display { get; set; }
        public Rgba SecondaryColor { get; set; }
        public byte Alpha { get; set; }
        public ushort FlashTimer { get; set; }
        public ushort FlashInterval { get; set; }
        public bool Friendly { get; set; }
        public bool Bright { get; set; }
        public ushort Number { get; set; }
        public bool ShowCone { get; set; }
        public bool Flashes { get; set; }
        public bool FlashesAlternate { get; set; }
        public bool ShortRange { get; set; }
        public ushort Priority { get; set; }
        public float Rotation { get; set; }
        public string GxtName { get; set; }
        public string Name { get; set; }
        public bool Pulse { get; set; }
        public bool MissionCreator { get; set; }
        public bool TickVisible { get; set; }
        public bool HeadingIndicatorVisible { get; set; }
        public bool OutlineIndicatorVisible { get; set; }
        public bool CrewIndicatorVisible { get; set; }
        public ushort Category { get; set; }
        public bool HighDetail { get; set; }
        public bool Shrinked { get; set; }

        public void Fade(uint opacity, uint duration)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            Alt.Core.RemoveBlip(this);
        }
    }
}