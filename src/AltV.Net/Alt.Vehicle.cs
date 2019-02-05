using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IVehicle CreateVehicle(uint model, Position pos, float heading) =>
            Module.Server.CreateVehicle(model, pos, heading);

        public static IVehicle CreateVehicle(VehicleHash vehicleHash, Position pos, float heading) =>
            Module.Server.CreateVehicle((uint) vehicleHash, pos, heading);
    }
}