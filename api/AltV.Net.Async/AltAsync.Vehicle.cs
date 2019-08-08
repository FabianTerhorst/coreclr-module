using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static Task<IVehicle> CreateVehicle(uint model, Position pos, Rotation rot) => AltVAsync.Schedule(() =>
            Alt.Module.Server.CreateVehicle(model, pos, rot));

        public static Task<IVehicle> CreateVehicle(VehicleModel model, Position pos, Rotation rot) =>
            CreateVehicle((uint) model, pos, rot);

        public static Task<IVehicle> CreateVehicle(string model, Position pos, Rotation rot) =>
            CreateVehicle(Alt.Hash(model), pos, rot);

        public static IVehicleBuilder CreateVehicleBuilder(uint model, Position pos, Rotation rot) =>
            new VehicleBuilder(model, pos, rot);

        public static IVehicleBuilder CreateVehicleBuilder(VehicleModel model, Position pos, Rotation rot) =>
            new VehicleBuilder((uint) model, pos, rot);

        public static IVehicleBuilder CreateVehicleBuilder(string model, Position pos, Rotation rot) =>
            new VehicleBuilder(Alt.Hash(model), pos, rot);

        public static Task<IPlayer> GetDriverAsync(this IVehicle vehicle) => AltVAsync.Schedule(() =>
            !vehicle.Exists ? null : vehicle.Driver);

        public static Task<byte> GetModKitAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.ModKit);

        public static Task SetModKitAsync(this IVehicle vehicle, byte modKit) =>
            AltVAsync.Schedule(() => vehicle.ModKit = modKit);

        public static Task<bool> IsPrimaryColorRgbAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsPrimaryColorRgb);

        public static Task<byte> GetPrimaryColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.PrimaryColor);

        public static Task SetPrimaryColorAsync(this IVehicle vehicle, byte primaryColor) =>
            AltVAsync.Schedule(() => vehicle.PrimaryColor = primaryColor);

        public static Task<Rgba> GetPrimaryColorRgbAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.PrimaryColorRgb);

        public static Task SetPrimaryColorRgbAsync(this IVehicle vehicle, Rgba primaryColor) =>
            AltVAsync.Schedule(() => vehicle.PrimaryColorRgb = primaryColor);

        public static Task<bool> IsSecondaryColorRgbAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsSecondaryColorRgb);

        public static Task<byte> GetSecondaryColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.SecondaryColor);

        public static Task SetSecondaryColorAsync(this IVehicle vehicle, byte secondaryColor) =>
            AltVAsync.Schedule(() => vehicle.SecondaryColor = secondaryColor);

        public static Task<Rgba> GetSecondaryColorRgbAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.SecondaryColorRgb);

        public static Task SetSecondaryColorRgbAsync(this IVehicle vehicle, Rgba secondaryColor) =>
            AltVAsync.Schedule(() => vehicle.SecondaryColorRgb = secondaryColor);

        public static Task<bool> IsTireSmokeColorCustomAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsTireSmokeColorCustom);

        public static Task<byte> GetPearlColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.PearlColor);

        public static Task SetPearlColorAsync(this IVehicle vehicle, byte pearlColor) =>
            AltVAsync.Schedule(() => vehicle.PearlColor = pearlColor);

        public static Task<byte> GetWheelColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WheelColor);

        public static Task SetWheelColorAsync(this IVehicle vehicle, byte wheelColor) =>
            AltVAsync.Schedule(() => vehicle.WheelColor = wheelColor);

        public static Task<byte> GetInteriorColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.InteriorColor);

        public static Task SetInteriorColorAsync(this IVehicle vehicle, byte interiorColor) =>
            AltVAsync.Schedule(() => vehicle.InteriorColor = interiorColor);

        public static Task<byte> GetDashboardColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.DashboardColor);

        public static Task SetDashboardColorAsync(this IVehicle vehicle, byte dashboardColor) =>
            AltVAsync.Schedule(() => vehicle.DashboardColor = dashboardColor);

        public static Task<Rgba> GetTireSmokeColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.TireSmokeColor);

        public static Task SetTireSmokeColorAsync(this IVehicle vehicle, Rgba tireSmokeColor) =>
            AltVAsync.Schedule(() => vehicle.TireSmokeColor = tireSmokeColor);

        public static Task<byte> GetWheelTypeAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WheelType);

        public static Task<byte> GetWheelVariationAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WheelVariation);

        public static Task<bool> HasCustomTiresAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.CustomTires);

        public static Task SetCustomTiresAsync(this IVehicle vehicle, bool customTires) =>
            AltVAsync.Schedule(() => vehicle.CustomTires = customTires);

        public static Task<byte> GetSpecialDarknessAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.SpecialDarkness);

        public static Task SetSpecialDarknessAsync(this IVehicle vehicle, byte specialDarkness) =>
            AltVAsync.Schedule(() => vehicle.SpecialDarkness = specialDarkness);

        public static Task<uint> GetNumberplateIndexAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.NumberplateIndex);

        public static Task SetNumberplateIndexAsync(this IVehicle vehicle, uint numberPlateIndex) =>
            AltVAsync.Schedule(() => vehicle.NumberplateIndex = numberPlateIndex);

        public static async Task<string> GetNumberplateTextAsync(this IVehicle vehicle)
        {
            var ptr = IntPtr.Zero;
            await AltVAsync.Schedule(
                () =>
                {
                    vehicle.CheckIfEntityExists();
                    AltNative.Vehicle.Vehicle_GetNumberplateText(vehicle.NativePointer, ref ptr);
                });
            return ptr == IntPtr.Zero ? string.Empty : Marshal.PtrToStringUTF8(ptr);
        }

        public static async Task SetNumberplateTextAsync(this IVehicle vehicle, string numberPlateText)
        {
            var numberPlateTextPtr = AltNative.StringUtils.StringToHGlobalUtf8(numberPlateText);
            await AltVAsync.Schedule(() =>
            {
                vehicle.CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetNumberplateText(vehicle.NativePointer, numberPlateTextPtr);
            });
            Marshal.FreeHGlobal(numberPlateTextPtr);
        }

        public static Task<byte> GetWindowTintAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WindowTint);

        public static Task SetWindowTintAsync(this IVehicle vehicle, byte windowTint) =>
            AltVAsync.Schedule(() => vehicle.WindowTint = windowTint);

        public static Task<byte> GetDirtLevelAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.DirtLevel);

        public static Task SetDirtLevelAsync(this IVehicle vehicle, byte dirtLevel) =>
            AltVAsync.Schedule(() => vehicle.DirtLevel = dirtLevel);

        public static Task<Rgba> GetNeonColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.NeonColor);

        public static Task SetNeonColorAsync(this IVehicle vehicle, Rgba neonColor) =>
            AltVAsync.Schedule(() => vehicle.NeonColor = neonColor);

        public static Task<string> GetHealthDataAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.HealthData);

        public static Task SetHealthDataAsync(this IVehicle vehicle, string healthData) =>
            AltVAsync.Schedule(() => vehicle.HealthData = healthData);

        public static Task<bool> IsEngineOnAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.EngineOn);

        public static Task SetEngineOnAsync(this IVehicle vehicle, bool engineOn) =>
            AltVAsync.Schedule(() => vehicle.EngineOn = engineOn);

        public static Task<uint> GetBodyAdditionalHealthAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.BodyAdditionalHealth);

        public static Task SetBodyAdditionalHealthAsync(this IVehicle vehicle, uint bodyAdditionalHealth) =>
            AltVAsync.Schedule(() => vehicle.BodyAdditionalHealth = bodyAdditionalHealth);

        public static Task<uint> GetBodyHealthAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.BodyHealth);

        public static Task SetBodyHealthAsync(this IVehicle vehicle, uint bodyHealth) =>
            AltVAsync.Schedule(() => vehicle.BodyHealth = bodyHealth);

        public static Task<byte> GetRepairsCountAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.RepairsCount);

        public static Task<byte> GetWheelsCountAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WheelsCount);

        public static Task<int> GetPetrolTankHealthAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.PetrolTankHealth);

        public static Task SetPetrolTankHealthAsync(this IVehicle vehicle, int petrolTankHealth) =>
            AltVAsync.Schedule(() => vehicle.PetrolTankHealth = petrolTankHealth);

        public static Task<int> GetEngineHealthAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.EngineHealth);

        public static Task SetEngineHealthAsync(this IVehicle vehicle, int engineHealth) =>
            AltVAsync.Schedule(() => vehicle.EngineHealth = engineHealth);

        public static Task<bool> IsNeonActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsNeonActive);

        public static Task<string> GetStateAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.State);

        public static Task SetStateAsync(this IVehicle vehicle, string state) =>
            AltVAsync.Schedule(() => vehicle.State = state);

        public static Task<bool> IsRoofOpenAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.RoofOpened);

        public static Task SetRoofOpenAsync(this IVehicle vehicle, bool roofOpen) =>
            AltVAsync.Schedule(() => vehicle.RoofOpened = roofOpen);

        public static Task<byte> GetDoorStateAsync(this IVehicle vehicle, byte doorId) =>
            AltVAsync.Schedule(() => vehicle.GetDoorState(doorId));

        public static Task SetDoorStateAsync(this IVehicle vehicle, byte doorId, byte state) =>
            AltVAsync.Schedule(() => vehicle.SetDoorState(doorId, state));

        public static Task<VehicleDoorState> GetDoorStateAsync(this IVehicle vehicle, VehicleDoor door) =>
            AltVAsync.Schedule(() => vehicle.GetDoorState(door));

        public static Task SetDoorStateAsync(this IVehicle vehicle, VehicleDoor door, VehicleDoorState state) =>
            AltVAsync.Schedule(() => vehicle.SetDoorState(door, state));

        public static Task<bool> IsWindowOpenedAsync(this IVehicle vehicle, byte windowId) =>
            AltVAsync.Schedule(() => vehicle.IsWindowOpened(windowId));

        public static Task SetWindowOpenedAsync(this IVehicle vehicle, byte windowId, bool state) =>
            AltVAsync.Schedule(() => vehicle.SetWindowOpened(windowId, state));

        public static Task<bool> IsNightlightOnAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsNightlightOn);

        public static Task<bool> IsDaylightOnAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsDaylightOn);

        public static Task<VehicleLockState> GetLockStateAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.LockState);

        public static Task SetLockStateAsync(this IVehicle vehicle, VehicleLockState lockState) =>
            AltVAsync.Schedule(() => vehicle.LockState = lockState);

        public static Task<bool> IsSirenActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.SirenActive);

        public static Task SetSirenActiveAsync(this IVehicle vehicle, bool sirenActive) =>
            AltVAsync.Schedule(() => vehicle.SirenActive = sirenActive);

        public static Task<byte> GetHeadlightColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.HeadlightColor);

        public static Task SetHeadlightColorAsync(this IVehicle vehicle, byte headlightColor) =>
            AltVAsync.Schedule(() => vehicle.HeadlightColor = headlightColor);

        public static Task<bool> IsHandbrakeActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsHandbrakeActive);

        public static Task<bool> IsFlamethrowerActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsFlamethrowerActive);

        public static Task<bool> HasArmoredWindowsAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.HasArmoredWindows);

        public static Task SetSpecialLightDamaged(this IVehicle vehicle, byte specialLightId, bool isDamaged) =>
            AltVAsync.Schedule(() => vehicle.SetSpecialLightDamaged(specialLightId, isDamaged));

        public static Task<bool> IsSpecialLightDamaged(this IVehicle vehicle, byte specialLightId) =>
            AltVAsync.Schedule(() => vehicle.IsSpecialLightDamaged(specialLightId));

        public static Task SetWindowDamaged(this IVehicle vehicle, byte windowId, bool isDamaged) =>
            AltVAsync.Schedule(() => vehicle.SetWindowDamaged(windowId, isDamaged));

        public static Task<bool> IsWindowDamaged(this IVehicle vehicle, byte windowId) =>
            AltVAsync.Schedule(() => vehicle.IsWindowDamaged(windowId));

        // TODO: Add: SetLightDamaged, IsLightDamaged, SetPartBulletHoles, GetPartBulletHoles, SetPartDamageLevel, GetPartDamageLevel
        // TODO: GetArmoredWindowHealth, SetArmoredWindowHealth, GetArmoredWindowShootCount, SetArmoredWindowShootCount
        // TODO: GetBumperDamageLevel, SetBumperDamageLevel

        public static Task<string> GetDamageDataAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.DamageData);

        public static Task SetDamageDataAsync(this IVehicle vehicle, string damageData) =>
            AltVAsync.Schedule(() => vehicle.DamageData = damageData);

        public static Task<byte> GetModAsync(this IVehicle vehicle, byte category) =>
            AltVAsync.Schedule(() => vehicle.GetMod(category));

        public static Task<byte> GetModsCountAsync(this IVehicle vehicle, byte category) =>
            AltVAsync.Schedule(() => vehicle.GetModsCount(category));

        public static Task<bool> SetModAsync(this IVehicle vehicle, byte category, byte id) =>
            AltVAsync.Schedule(() => vehicle.SetMod(category, id));

        public static Task<byte> GetModKitsCountAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.ModKitsCount);

        public static Task SetWheelsAsync(this IVehicle vehicle, byte type, byte variation) =>
            AltVAsync.Schedule(() => vehicle.SetWheels(type, variation));

        public static Task<bool> IsExtraOnAsync(this IVehicle vehicle, byte extraId) =>
            AltVAsync.Schedule(() => vehicle.IsExtraOn(extraId));

        public static Task ToggleExtraAsync(this IVehicle vehicle, byte extraId, bool state) =>
            AltVAsync.Schedule(() => vehicle.ToggleExtra(extraId, state));

        public static Task<Tuple<bool, bool, bool, bool>> GetNeonActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() =>
            {
                bool left = false, right = false, front = false, back = false;
                vehicle.GetNeonActive(ref left, ref right, ref front, ref back);
                return new Tuple<bool, bool, bool, bool>(left, right, front, back);
            });

        public static Task
            SetNeonActiveAsync(this IVehicle vehicle, bool left, bool right, bool front, bool back) =>
            AltVAsync.Schedule(() => vehicle.SetNeonActive(left, right, front, back));

        public static Task<string> GetAppearanceDataAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.AppearanceData);

        public static Task SetAppearanceDataAsync(this IVehicle vehicle, string text) =>
            AltVAsync.Schedule(() => vehicle.AppearanceData = text);

        public static Task<uint> GetRadioStationAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.RadioStation);

        public static Task SetRadioStationAsync(this IVehicle vehicle, uint radioStation) =>
            AltVAsync.Schedule(() => vehicle.RadioStation = radioStation);

        public static Task<bool> GetManualEngineControlAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.ManualEngineControl);

        public static Task SetManualEngineControlAsync(this IVehicle vehicle, bool state) =>
            AltVAsync.Schedule(() => vehicle.ManualEngineControl = state);

        public static Task<string> GetScriptDataAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.ScriptData);

        public static Task SetScriptDataAsync(this IVehicle vehicle, string text) =>
            AltVAsync.Schedule(() => vehicle.ScriptData = text);

        public static Task RemoveAsync(this IVehicle vehicle) => AltVAsync.Schedule(vehicle.Remove);
    }
}