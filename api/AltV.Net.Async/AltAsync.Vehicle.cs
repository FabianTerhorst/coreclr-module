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
            ushort id = default;
            var vehiclePtr = await AltVAsync.Schedule(() =>
                AltNative.Server.Server_CreateVehicle(((Server) Alt.Server).NativePointer, model, pos, heading,
                    ref id));
            Alt.Module.VehiclePool.Create(vehiclePtr, id, out var vehicle);
            return vehicle;
        }

        public static async Task<IVehicle> CreateVehicle(VehicleModel model, Position pos, float heading) =>
            await CreateVehicle((uint) model, pos, heading);

        public static Task<IVehicle> CreateVehicle(string model, Position pos, float heading) =>
            CreateVehicle(Alt.Hash(model), pos, heading);

        public static async Task<IPlayer> GetDriverAsync(this IVehicle vehicle)
        {
            var entityPointer =
                await AltVAsync.Schedule(() =>
                    !vehicle.Exists ? IntPtr.Zero : AltNative.Vehicle.Vehicle_GetDriver(vehicle.NativePointer));
            if (entityPointer == IntPtr.Zero) return null;
            return Alt.Module.PlayerPool.GetOrCreate(entityPointer, out var player) ? player : null;
        }

        public static async Task<byte> GetModKitAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.ModKit);

        public static async Task SetModKitAsync(this IVehicle vehicle, byte modKit) =>
            await AltVAsync.Schedule(() => vehicle.ModKit = modKit);

        public static async Task<bool> IsPrimaryColorRgbAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsPrimaryColorRgb);

        public static async Task<byte> GetPrimaryColorAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.PrimaryColor);

        public static async Task SetPrimaryColorAsync(this IVehicle vehicle, byte primaryColor) =>
            await AltVAsync.Schedule(() => vehicle.PrimaryColor = primaryColor);

        public static async Task<Rgba> GetPrimaryColorRgbAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.PrimaryColorRgb);

        public static async Task SetPrimaryColorRgbAsync(this IVehicle vehicle, Rgba primaryColor) =>
            await AltVAsync.Schedule(() => vehicle.PrimaryColorRgb = primaryColor);

        public static async Task<bool> IsSecondaryColorRgbAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsSecondaryColorRgb);

        public static async Task<byte> GetSecondaryColorAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.SecondaryColor);

        public static async Task SetSecondaryColorAsync(this IVehicle vehicle, byte secondaryColor) =>
            await AltVAsync.Schedule(() => vehicle.SecondaryColor = secondaryColor);

        public static async Task<Rgba> GetSecondaryColorRgbAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.SecondaryColorRgb);

        public static async Task SetSecondaryColorRgbAsync(this IVehicle vehicle, Rgba secondaryColor) =>
            await AltVAsync.Schedule(() => vehicle.SecondaryColorRgb = secondaryColor);

        public static async Task<bool> IsTireSmokeColorCustomAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsTireSmokeColorCustom);

        public static async Task<byte> GetPearlColorAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.PearlColor);

        public static async Task SetPearlColorAsync(this IVehicle vehicle, byte pearlColor) =>
            await AltVAsync.Schedule(() => vehicle.PearlColor = pearlColor);

        public static async Task<byte> GetWheelColorAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.WheelColor);

        public static async Task SetWheelColorAsync(this IVehicle vehicle, byte wheelColor) =>
            await AltVAsync.Schedule(() => vehicle.WheelColor = wheelColor);

        public static async Task<byte> GetInteriorColorAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.InteriorColor);

        public static async Task SetInteriorColorAsync(this IVehicle vehicle, byte interiorColor) =>
            await AltVAsync.Schedule(() => vehicle.InteriorColor = interiorColor);

        public static async Task<byte> GetDashboardColorAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.DashboardColor);

        public static async Task SetDashboardColorAsync(this IVehicle vehicle, byte dashboardColor) =>
            await AltVAsync.Schedule(() => vehicle.DashboardColor = dashboardColor);

        public static async Task<Rgba> GetTireSmokeColorAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.TireSmokeColor);

        public static async Task SetTireSmokeColorAsync(this IVehicle vehicle, Rgba tireSmokeColor) =>
            await AltVAsync.Schedule(() => vehicle.TireSmokeColor = tireSmokeColor);

        public static async Task<byte> GetWheelTypeAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.WheelType);

        public static async Task<byte> GetWheelVariationAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.WheelVariation);

        public static async Task<bool> HasCustomTiresAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.CustomTires);

        public static async Task SetCustomTiresAsync(this IVehicle vehicle, bool customTires) =>
            await AltVAsync.Schedule(() => vehicle.CustomTires = customTires);

        public static async Task<byte> GetSpecialDarknessAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.SpecialDarkness);

        public static async Task SetSpecialDarknessAsync(this IVehicle vehicle, byte specialDarkness) =>
            await AltVAsync.Schedule(() => vehicle.SpecialDarkness = specialDarkness);

        public static async Task<uint> GetNumberplateIndexAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.NumberplateIndex);

        public static async Task SetNumberplateIndexAsync(this IVehicle vehicle, uint numberPlateIndex) =>
            await AltVAsync.Schedule(() => vehicle.NumberplateIndex = numberPlateIndex);

        public static async Task<string> GetNumberplateTextAsync(this IVehicle vehicle)
        {
            var ptr = IntPtr.Zero;
            await AltVAsync.Schedule(
                () =>
                {
                    if (vehicle.Exists)
                    {
                        AltNative.Vehicle.Vehicle_GetNumberplateText(vehicle.NativePointer, ref ptr);
                    }
                });
            return ptr == IntPtr.Zero ? string.Empty : Marshal.PtrToStringAnsi(ptr);
        }

        public static async Task SetNumberplateTextAsync(this IVehicle vehicle, string numberPlateText) =>
            await AltVAsync.Schedule(() => vehicle.NumberplateText = numberPlateText);

        public static async Task<byte> GetWindowTintAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.WindowTint);

        public static async Task SetWindowTintAsync(this IVehicle vehicle, byte windowTint) =>
            await AltVAsync.Schedule(() => vehicle.WindowTint = windowTint);

        public static async Task<byte> GetDirtLevelAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.DirtLevel);

        public static async Task SetDirtLevelAsync(this IVehicle vehicle, byte dirtLevel) =>
            await AltVAsync.Schedule(() => vehicle.DirtLevel = dirtLevel);

        public static async Task<Rgba> GetNeonColorAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.NeonColor);

        public static async Task SetNeonColorAsync(this IVehicle vehicle, Rgba neonColor) =>
            await AltVAsync.Schedule(() => vehicle.NeonColor = neonColor);

        public static async Task<string> GetHealthDataAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.HealthData);

        public static async Task SetHealthDataAsync(this IVehicle vehicle, string healthData) =>
            await AltVAsync.Schedule(() => vehicle.HealthData = healthData);

        public static async Task<bool> IsEngineOnAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.EngineOn);

        public static async Task SetEngineOnAsync(this IVehicle vehicle, bool engineOn) =>
            await AltVAsync.Schedule(() => vehicle.EngineOn = engineOn);

        public static async Task<uint> GetBodyAdditionalHealthAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.BodyAdditionalHealth);

        public static async Task SetBodyAdditionalHealthAsync(this IVehicle vehicle, uint bodyAdditionalHealth) =>
            await AltVAsync.Schedule(() => vehicle.BodyAdditionalHealth = bodyAdditionalHealth);

        public static async Task<uint> GetBodyHealthAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.BodyHealth);

        public static async Task SetBodyHealthAsync(this IVehicle vehicle, uint bodyHealth) =>
            await AltVAsync.Schedule(() => vehicle.BodyHealth = bodyHealth);

        public static async Task<byte> GetRepairsCountAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.RepairsCount);

        public static async Task<byte> GetWheelsCountAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.WheelsCount);

        public static async Task<int> GetPetrolTankHealthAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.PetrolTankHealth);

        public static async Task SetPetrolTankHealthAsync(this IVehicle vehicle, int petrolTankHealth) =>
            await AltVAsync.Schedule(() => vehicle.PetrolTankHealth = petrolTankHealth);

        public static async Task<int> GetEngineHealthAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.EngineHealth);

        public static async Task SetEngineHealthAsync(this IVehicle vehicle, int engineHealth) =>
            await AltVAsync.Schedule(() => vehicle.EngineHealth = engineHealth);

        public static async Task<bool> IsNeonActiveAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsNeonActive);

        public static async Task<string> GetStateAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.State);

        public static async Task SetStateAsync(this IVehicle vehicle, string state) =>
            await AltVAsync.Schedule(() => vehicle.State = state);

        public static async Task<bool> IsRoofOpenAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.RoofOpened);

        public static async Task SetRoofOpenAsync(this IVehicle vehicle, bool roofOpen) =>
            await AltVAsync.Schedule(() => vehicle.RoofOpened = roofOpen);

        public static async Task<bool> IsNightlightOnAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsNightlightOn);

        public static async Task<bool> IsDaylightOnAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsDaylightOn);

        public static async Task<VehicleLockState> GetLockStateAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.LockState);

        public static async Task SetLockStateAsync(this IVehicle vehicle, VehicleLockState lockState) =>
            await AltVAsync.Schedule(() => vehicle.LockState = lockState);

        public static async Task<bool> IsSirenActiveAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.SirenActive);

        public static async Task SetSirenActiveAsync(this IVehicle vehicle, bool sirenActive) =>
            await AltVAsync.Schedule(() => vehicle.SirenActive = sirenActive);

        public static async Task<byte> GetHeadlightColorAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.HeadlightColor);

        public static async Task SetHeadlightColorAsync(this IVehicle vehicle, byte headlightColor) =>
            await AltVAsync.Schedule(() => vehicle.HeadlightColor = headlightColor);

        public static async Task<bool> IsHandbrakeActiveAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsHandbrakeActive);

        public static async Task<bool> IsFlamethrowerActiveAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.IsFlamethrowerActive);

        public static async Task<bool> HasArmoredWindowsAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.HasArmoredWindows);

        public static async Task<string> GetDamageDataAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.DamageData);

        public static async Task SetDamageDataAsync(this IVehicle vehicle, string damageData) =>
            await AltVAsync.Schedule(() => vehicle.DamageData = damageData);

        public static async Task<byte> GetModAsync(this IVehicle vehicle, byte category) =>
            await AltVAsync.Schedule(() => vehicle.GetMod(category));

        public static async Task<byte> GetModsCountAsync(this IVehicle vehicle, byte category) =>
            await AltVAsync.Schedule(() => vehicle.GetModsCount(category));

        public static async Task<bool> SetModAsync(this IVehicle vehicle, byte category, byte id) =>
            await AltVAsync.Schedule(() => vehicle.SetMod(category, id));

        public static async Task<byte> GetModKitsCountAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() => vehicle.ModKitsCount);

        public static async Task SetWheelsAsync(this IVehicle vehicle, byte type, byte variation) =>
            await AltVAsync.Schedule(() => vehicle.SetWheels(type, variation));

        public static async Task<bool> IsExtraOnAsync(this IVehicle vehicle, byte extraId) =>
            await AltVAsync.Schedule(() => vehicle.IsExtraOn(extraId));

        public static async Task ToggleExtraAsync(this IVehicle vehicle, byte extraId, bool state) =>
            await AltVAsync.Schedule(() => vehicle.ToggleExtra(extraId, state));

        public static async Task<Tuple<bool, bool, bool, bool>> GetNeonActiveAsync(this IVehicle vehicle) =>
            await AltVAsync.Schedule(() =>
            {
                bool left = false, right = false, front = false, back = false;
                vehicle.GetNeonActive(ref left, ref right, ref front, ref back);
                return new Tuple<bool, bool, bool, bool>(left, right, front, back);
            });

        public static async Task
            SetNeonActiveAsync(this IVehicle vehicle, bool left, bool right, bool front, bool back) =>
            await AltVAsync.Schedule(() => vehicle.SetNeonActive(left, right, front, back));
    }
}