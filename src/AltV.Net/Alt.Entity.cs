using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public static partial class Alt
    {
        public static void RemoveVehicle(IVehicle vehicle) =>
            Module.Server.RemoveVehicle(vehicle);

        public static void RemoveBlip(IBlip blip) =>
            Module.Server.RemoveBlip(blip);

        public static void RemoveCheckpoint(ICheckpoint checkpoint) =>
            Module.Server.RemoveCheckpoint(checkpoint);
    }
}