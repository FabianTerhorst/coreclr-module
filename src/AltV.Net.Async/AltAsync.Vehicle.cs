using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static async Task<IVehicle> CreateVehicle(uint model, Position pos, float heading)
        {
            var vehiclePtr = await AltVAsync.Schedule(() =>
                AltVNative.Server.Server_CreateVehicle(((Server) Alt.Server).NativePointer, model, pos, heading));
            Alt.Module.VehiclePool.Create(vehiclePtr, out var vehicle);
            return vehicle;
        }

        public static async Task<IVehicle> CreateVehicle(VehicleHash vehicleHash, Position pos, float heading) =>
            await CreateVehicle((uint) vehicleHash, pos, heading);

        public static async Task<IPlayer> GetDriver(this IVehicle vehicle)
        {
            if (!vehicle.Exists) return null;
            var entityPointer =
                await AltVAsync.Schedule(() => AltVNative.Vehicle.Vehicle_GetDriver(vehicle.NativePointer));
            if (entityPointer == IntPtr.Zero) return null;
            if (Alt.Module.BaseEntityPool.GetOrCreate(entityPointer, out var entity) && entity is IPlayer player)
            {
                return player;
            }

            return null;
        }

        public static async Task<byte> GetModKit(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.ModKit);

        public static async Task SetModKit(this IVehicle vehicle, byte modKit) =>
            await AltVAsync.Schedule(() => vehicle.ModKit = modKit);

        public static async Task<bool> IsPrimaryColorRgb(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsPrimaryColorRgb);

        public static async Task<byte> GetPrimaryColor(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.PrimaryColor);

        public static async Task SetPrimaryColor(this IVehicle vehicle, byte primaryColor) =>
            await AltVAsync.Schedule(() => vehicle.PrimaryColor = primaryColor);

        public static async Task<Rgba> GetPrimaryColorRgb(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.PrimaryColorRgb);

        public static async Task SetPrimaryColorRgb(this IVehicle vehicle, Rgba primaryColor) =>
            await AltVAsync.Schedule(() => vehicle.PrimaryColorRgb = primaryColor);

        public static async Task<bool> IsSecondaryColorRgb(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsSecondaryColorRgb);

        public static async Task<byte> GetSecondaryColor(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.SecondaryColor);

        public static async Task SetSecondaryColor(this IVehicle vehicle, byte secondaryColor) =>
            await AltVAsync.Schedule(() => vehicle.SecondaryColor = secondaryColor);

        public static async Task<Rgba> GetSecondaryColorRgb(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.SecondaryColorRgb);

        public static async Task SetSecondaryColorRgb(this IVehicle vehicle, Rgba secondaryColor) =>
            await AltVAsync.Schedule(() => vehicle.SecondaryColorRgb = secondaryColor);

        public static async Task<byte> GetPearlColor(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.PearlColor);

        public static async Task SetPearlColor(this IVehicle vehicle, byte pearlColor) =>
            await AltVAsync.Schedule(() => vehicle.PearlColor = pearlColor);

        public static async Task<byte> GetWheelColor(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.WheelColor);

        public static async Task SetWheelColor(this IVehicle vehicle, byte wheelColor) =>
            await AltVAsync.Schedule(() => vehicle.WheelColor = wheelColor);

        public static async Task<byte> GetInteriorColor(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.InteriorColor);

        public static async Task SetInteriorColor(this IVehicle vehicle, byte interiorColor) =>
            await AltVAsync.Schedule(() => vehicle.InteriorColor = interiorColor);

        public static async Task<byte> GetDashboardColor(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.DashboardColor);

        public static async Task SetDashboardColor(this IVehicle vehicle, byte dashboardColor) =>
            await AltVAsync.Schedule(() => vehicle.DashboardColor = dashboardColor);

        public static async Task<Rgba> GetTireSmokeColor(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.TireSmokeColor);

        public static async Task SetTireSmokeColor(this IVehicle vehicle, Rgba tireSmokeColor) =>
            await AltVAsync.Schedule(() => vehicle.TireSmokeColor = tireSmokeColor);

        public static async Task<byte> GetWheelType(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.WheelType);

        public static async Task<byte> GetWheelVariation(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.WheelVariation);

        public static async Task<bool> HasCustomTires(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.CustomTires);

        public static async Task SetCustomTires(this IVehicle vehicle, bool customTires) =>
            await AltVAsync.Schedule(() => vehicle.CustomTires = customTires);

        public static async Task<byte> GetSpecialDarkness(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.SpecialDarkness);

        public static async Task SetSpecialDarkness(this IVehicle vehicle, byte specialDarkness) =>
            await AltVAsync.Schedule(() => vehicle.SpecialDarkness = specialDarkness);

        public static async Task<uint> GetNumberPlateIndex(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.NumberPlateIndex);

        public static async Task SetNumberPlateIndex(this IVehicle vehicle, uint numberPlateIndex) =>
            await AltVAsync.Schedule(() => vehicle.NumberPlateIndex = numberPlateIndex);

        public static async Task<string> GetNumberPlateText(this IVehicle vehicle)
        {
            if (!vehicle.Exists) return string.Empty;
            var ptr = IntPtr.Zero;
            await AltVAsync.Schedule(
                () => AltVNative.Vehicle.Vehicle_GetNumberPlateText(vehicle.NativePointer, ref ptr));
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static async Task SetNumberPlateText(this IVehicle vehicle, string numberPlateText) =>
            await AltVAsync.Schedule(() => vehicle.NumberPlateText = numberPlateText);

        public static async Task<byte> GetWindowTint(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.WindowTint);

        public static async Task SetWindowTint(this IVehicle vehicle, byte windowTint) =>
            await AltVAsync.Schedule(() => vehicle.WindowTint = windowTint);

        public static async Task<byte> GetDirtLevel(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.DirtLevel);

        public static async Task SetDirtLevel(this IVehicle vehicle, byte dirtLevel) =>
            await AltVAsync.Schedule(() => vehicle.DirtLevel = dirtLevel);

        public static async Task<Rgba> GetNeonColor(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.NeonColor);

        public static async Task SetNeonColor(this IVehicle vehicle, Rgba neonColor) =>
            await AltVAsync.Schedule(() => vehicle.NeonColor = neonColor);

        public static async Task<byte> GetMod(this IVehicle vehicle, byte category) =>
            await AltVAsync.Schedule(() => vehicle.GetMod(category));

        public static async Task<byte> GetModsCount(this IVehicle vehicle, byte category) =>
            await AltVAsync.Schedule(() => vehicle.GetModsCount(category));

        public static async Task<bool> SetMod(this IVehicle vehicle, byte category, byte id) =>
            await AltVAsync.Schedule(() => vehicle.SetMod(category, id));

        public static async Task<byte> GetModKitsCount(this IVehicle vehicle) =>
            await AltVAsync.Schedule(vehicle.GetModKitsCount);

        public static async Task SetWheels(this IVehicle vehicle, byte type, byte variation) =>
            await AltVAsync.Schedule(() => vehicle.SetWheels(type, variation));

        public static async Task<bool> IsExtraOn(this IVehicle vehicle, byte extraId) =>
            await AltVAsync.Schedule(() => vehicle.IsExtraOn(extraId));

        public static async Task ToggleExtra(this IVehicle vehicle, byte extraId, bool state) =>
            await AltVAsync.Schedule(() => vehicle.ToggleExtra(extraId, state));

        public static async Task<Tuple<bool, bool, bool, bool>> GetNeonActive(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() =>
            {
                bool left = false, right = false, front = false, back = false;
                vehicle.GetNeonActive(ref left, ref right, ref front, ref back);
                return new Tuple<bool, bool, bool, bool>(left, right, front, back);
            });

        public static async Task SetNeonActive(this IVehicle vehicle, bool left, bool right, bool front, bool back) =>
            await AltVAsync.Schedule(() => vehicle.SetNeonActive(left, right, front, back));
    }
}