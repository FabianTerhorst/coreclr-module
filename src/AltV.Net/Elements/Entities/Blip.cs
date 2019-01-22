using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    internal class Blip : Entity, IBlip
    {
        public uint Color
        {
            /*get//TODO: altv-c-api
            {
                CheckExistence();

                return Rage.Blip.Blip_GetColor(NativePointer);
            }*/
            set
            {
                CheckExistence();

                Alt.Blip.Blip_SetColor(NativePointer, value);
            }
        }
    }
}