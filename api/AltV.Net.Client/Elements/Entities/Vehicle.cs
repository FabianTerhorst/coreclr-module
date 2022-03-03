using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Entities
{
    public class Vehicle : Entity, IVehicle
    {
        public Vehicle(ICore core, IntPtr entityNativePointer, ushort id) : base(core, entityNativePointer, id)
        {
        }
    }
}