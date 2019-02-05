using System;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    internal class Blip : Entity, IBlip
    {
        private uint color;

        public uint Color
        {
            get
            {
                CheckExistence();

                return this.color;
            }
            set
            {
                CheckExistence();
                this.color = value;
                AltVNative.Blip.Blip_SetColor(NativePointer, value);
            }
        }

        internal Blip(IntPtr nativePointer) : base(nativePointer, EntityType.Blip)
        {
        }
    }
}