using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void RemoveVehicle(IVehicle vehicle) => vehicle.Remove();

        public static void RemoveBlip(IBlip blip) => blip.Remove();

        public static void RemoveCheckpoint(ICheckpoint checkpoint) => checkpoint.Remove();
        
        public static void RemoveColShape(IColShape colShape) => colShape.Remove();
    }
}