using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void RemoveVehicle(IVehicle vehicle) =>
            Module.Core.RemoveVehicle(vehicle);

        public static void RemoveBlip(IBlip blip) =>
            Module.Core.RemoveBlip(blip);

        public static void RemoveCheckpoint(ICheckpoint checkpoint) =>
            Module.Core.RemoveCheckpoint(checkpoint);
        
        public static void RemoveColShape(IColShape colShape) =>
            Module.Core.RemoveColShape(colShape);
    }
}