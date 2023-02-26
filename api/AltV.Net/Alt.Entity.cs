using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void RemoveVehicle(IVehicle vehicle) => vehicle.Destroy();

        public static void RemoveBlip(IBlip blip) => blip.Destroy();

        public static void RemoveCheckpoint(ICheckpoint checkpoint) => checkpoint.Destroy();

        public static void RemoveColShape(IColShape colShape) => colShape.Destroy();
    }
}