using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static async Task<IVehicle> CreateVehicle(uint model, Position pos, float heading) =>
            await AltVAsync.Schedule(() => Alt.CreateVehicle(model, pos, heading)).ConfigureAwait(false);

        public static async Task<IVehicle> CreateVehicle(VehicleHash vehicleHash, Position pos, float heading) =>
            await AltVAsync.Schedule(() => Alt.CreateVehicle((uint) vehicleHash, pos, heading)).ConfigureAwait(false);
    }
}