using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockBlip : MockEntity, IBlip
    {
        public MockBlip(IntPtr nativePointer, ushort id) : base(nativePointer, EntityType.Blip, id)
        {
        }

        public bool IsGlobal { get; }
        public bool IsAttached { get; set; }
        public IEntity AttachedTo { get; set; }
        public byte BlipType { get; set; }
        public ushort Sprite { get; set; }
        public byte Color { get; set; }
        public bool Route { get; set; }
        public byte RouteColor { get; set; }
    }
}