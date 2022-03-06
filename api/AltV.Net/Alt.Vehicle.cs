using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IVehicle CreateVehicle(uint model, Position pos, Rotation rotation) =>
            Module.Core.CreateVehicle(model, pos, rotation);

        public static IVehicle CreateVehicle(VehicleModel model, Position pos, Rotation rotation) =>
            Module.Core.CreateVehicle((uint) model, pos, rotation);

        public static IVehicle CreateVehicle(string model, Position pos, Rotation rotation) =>
            Module.Core.CreateVehicle(Module.Core.Hash(model), pos, rotation);
    }
}