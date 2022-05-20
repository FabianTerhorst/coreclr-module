using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void RemoveVehicle(IVehicle vehicle) =>
            Core.RemoveVehicle(vehicle);

        public static void RemoveBlip(IBlip blip) =>
            Core.RemoveBlip(blip);

        public static void RemoveCheckpoint(ICheckpoint checkpoint) =>
            Core.RemoveCheckpoint(checkpoint);
        
        public static void RemoveColShape(IColShape colShape) =>
            Core.RemoveColShape(colShape);
    }
}