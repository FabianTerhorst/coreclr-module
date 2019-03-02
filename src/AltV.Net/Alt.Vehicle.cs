using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IVehicle CreateVehicle(uint model, Position pos, float heading) =>
            Module.Server.CreateVehicle(model, pos, heading);

        public static IVehicle CreateVehicle(VehicleModel model, Position pos, float heading) =>
            Module.Server.CreateVehicle((uint) model, pos, heading);

        public static IVehicle CreateVehicle(string model, Position pos, float heading) =>
            Module.Server.CreateVehicle(Module.Server.Hash(model), pos, heading);
    }
}