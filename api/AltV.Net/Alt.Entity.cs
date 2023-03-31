using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public static partial class Alt
    {
        [Obsolete("Use vehicle.Destroy() instead")]
        public static void RemoveVehicle(IVehicle vehicle) => vehicle.Destroy();

        [Obsolete("Use blip.Destroy() instead")]
        public static void RemoveBlip(IBlip blip) => blip.Destroy();

        [Obsolete("Use checkpoint.Destroy() instead")]
        public static void RemoveCheckpoint(ICheckpoint checkpoint) => checkpoint.Destroy();

        [Obsolete("Use colShape.Destroy() instead")]
        public static void RemoveColShape(IColShape colShape) => colShape.Destroy();
    }
}