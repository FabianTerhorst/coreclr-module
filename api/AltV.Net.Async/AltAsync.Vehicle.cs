using System;
using System.Numerics;
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
            Alt.Core.CreateVehicle(model, pos, rot));

        public static Task<IVehicle> CreateVehicle(VehicleModel model, Position pos, Rotation rot) =>
            CreateVehicle((uint) model, pos, rot);

        public static Task<IVehicle> CreateVehicle(string model, Position pos, Rotation rot) =>
            CreateVehicle(Alt.Hash(model), pos, rot);

        [Obsolete("Use AltAsync.CreateVehicle or Alt.CreateVehicle instead")]
        public static IVehicleBuilder CreateVehicleBuilder(uint model, Position pos, Rotation rot) =>
            new VehicleBuilder(model, pos, rot);

        [Obsolete("Use AltAsync.CreateVehicle or Alt.CreateVehicle instead")]
        public static IVehicleBuilder CreateVehicleBuilder(VehicleModel model, Position pos, Rotation rot) =>
            new VehicleBuilder((uint) model, pos, rot);

        [Obsolete("Use AltAsync.CreateVehicle or Alt.CreateVehicle instead")]
        public static IVehicleBuilder CreateVehicleBuilder(string model, Position pos, Rotation rot) =>
            new VehicleBuilder(Alt.Hash(model), pos, rot);

        [Obsolete("Use async entities instead")]
        public static Task<IPlayer> GetDriverAsync(this IVehicle vehicle) => AltVAsync.Schedule(() =>
            !vehicle.Exists ? null : vehicle.Driver);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetModKitAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.ModKit);

        [Obsolete("Use async entities instead")]
        public static Task SetModKitAsync(this IVehicle vehicle, byte modKit) =>
            AltVAsync.Schedule(() => vehicle.ModKit = modKit);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsPrimaryColorRgbAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsPrimaryColorRgb);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetPrimaryColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.PrimaryColor);

        [Obsolete("Use async entities instead")]
        public static Task SetPrimaryColorAsync(this IVehicle vehicle, byte primaryColor) =>
            AltVAsync.Schedule(() => vehicle.PrimaryColor = primaryColor);

        [Obsolete("Use async entities instead")]
        public static Task<Rgba> GetPrimaryColorRgbAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.PrimaryColorRgb);

        [Obsolete("Use async entities instead")]
        public static Task SetPrimaryColorRgbAsync(this IVehicle vehicle, Rgba primaryColor) =>
            AltVAsync.Schedule(() => vehicle.PrimaryColorRgb = primaryColor);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsSecondaryColorRgbAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsSecondaryColorRgb);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetSecondaryColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.SecondaryColor);

        [Obsolete("Use async entities instead")]
        public static Task SetSecondaryColorAsync(this IVehicle vehicle, byte secondaryColor) =>
            AltVAsync.Schedule(() => vehicle.SecondaryColor = secondaryColor);

        [Obsolete("Use async entities instead")]
        public static Task<Rgba> GetSecondaryColorRgbAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.SecondaryColorRgb);

        [Obsolete("Use async entities instead")]
        public static Task SetSecondaryColorRgbAsync(this IVehicle vehicle, Rgba secondaryColor) =>
            AltVAsync.Schedule(() => vehicle.SecondaryColorRgb = secondaryColor);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsTireSmokeColorCustomAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsTireSmokeColorCustom);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetPearlColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.PearlColor);

        [Obsolete("Use async entities instead")]
        public static Task SetPearlColorAsync(this IVehicle vehicle, byte pearlColor) =>
            AltVAsync.Schedule(() => vehicle.PearlColor = pearlColor);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetWheelColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WheelColor);

        [Obsolete("Use async entities instead")]
        public static Task SetWheelColorAsync(this IVehicle vehicle, byte wheelColor) =>
            AltVAsync.Schedule(() => vehicle.WheelColor = wheelColor);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetInteriorColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.InteriorColor);

        [Obsolete("Use async entities instead")]
        public static Task SetInteriorColorAsync(this IVehicle vehicle, byte interiorColor) =>
            AltVAsync.Schedule(() => vehicle.InteriorColor = interiorColor);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetDashboardColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.DashboardColor);

        [Obsolete("Use async entities instead")]
        public static Task SetDashboardColorAsync(this IVehicle vehicle, byte dashboardColor) =>
            AltVAsync.Schedule(() => vehicle.DashboardColor = dashboardColor);

        [Obsolete("Use async entities instead")]
        public static Task<Rgba> GetTireSmokeColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.TireSmokeColor);

        [Obsolete("Use async entities instead")]
        public static Task SetTireSmokeColorAsync(this IVehicle vehicle, Rgba tireSmokeColor) =>
            AltVAsync.Schedule(() => vehicle.TireSmokeColor = tireSmokeColor);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetWheelTypeAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WheelType);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetWheelVariationAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WheelVariation);

        [Obsolete("Use async entities instead")]
        public static Task<bool> HasCustomTiresAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.CustomTires);

        [Obsolete("Use async entities instead")]
        public static Task SetCustomTiresAsync(this IVehicle vehicle, bool customTires) =>
            AltVAsync.Schedule(() => vehicle.CustomTires = customTires);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetSpecialDarknessAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.SpecialDarkness);

        [Obsolete("Use async entities instead")]
        public static Task SetSpecialDarknessAsync(this IVehicle vehicle, byte specialDarkness) =>
            AltVAsync.Schedule(() => vehicle.SpecialDarkness = specialDarkness);

        [Obsolete("Use async entities instead")]
        public static Task<uint> GetNumberplateIndexAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.NumberplateIndex);

        [Obsolete("Use async entities instead")]
        public static Task SetNumberplateIndexAsync(this IVehicle vehicle, uint numberPlateIndex) =>
            AltVAsync.Schedule(() => vehicle.NumberplateIndex = numberPlateIndex);

        [Obsolete("Use async entities instead")]
        public static async Task<string> GetNumberplateTextAsync(this IVehicle vehicle) => await AltVAsync.Schedule(
                () => vehicle.NumberplateText);

        [Obsolete("Use async entities instead")]
        public static async Task SetNumberplateTextAsync(this IVehicle vehicle, string numberPlateText)
        {
            var numberPlateTextPtr = AltNative.StringUtils.StringToHGlobalUtf8(numberPlateText);
            await AltVAsync.Schedule(() =>
            {
                unsafe
                {
                    vehicle.CheckIfEntityExists();
                    Alt.Core.Library.Server.Vehicle_SetNumberplateText(vehicle.VehicleNativePointer, numberPlateTextPtr);
                }
            });
            Marshal.FreeHGlobal(numberPlateTextPtr);
        }

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetWindowTintAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WindowTint);

        [Obsolete("Use async entities instead")]
        public static Task SetWindowTintAsync(this IVehicle vehicle, byte windowTint) =>
            AltVAsync.Schedule(() => vehicle.WindowTint = windowTint);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetDirtLevelAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.DirtLevel);

        [Obsolete("Use async entities instead")]
        public static Task SetDirtLevelAsync(this IVehicle vehicle, byte dirtLevel) =>
            AltVAsync.Schedule(() => vehicle.DirtLevel = dirtLevel);

        [Obsolete("Use async entities instead")]
        public static Task<Rgba> GetNeonColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.NeonColor);

        [Obsolete("Use async entities instead")]
        public static Task SetNeonColorAsync(this IVehicle vehicle, Rgba neonColor) =>
            AltVAsync.Schedule(() => vehicle.NeonColor = neonColor);

        [Obsolete("Use async entities instead")]
        public static Task<string> GetHealthDataAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.HealthData);

        [Obsolete("Use async entities instead")]
        public static Task SetHealthDataAsync(this IVehicle vehicle, string healthData) =>
            AltVAsync.Schedule(() => vehicle.HealthData = healthData);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsEngineOnAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.EngineOn);

        [Obsolete("Use async entities instead")]
        public static Task SetEngineOnAsync(this IVehicle vehicle, bool engineOn) =>
            AltVAsync.Schedule(() => vehicle.EngineOn = engineOn);

        [Obsolete("Use async entities instead")]
        public static Task<uint> GetBodyAdditionalHealthAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.BodyAdditionalHealth);

        [Obsolete("Use async entities instead")]
        public static Task SetBodyAdditionalHealthAsync(this IVehicle vehicle, uint bodyAdditionalHealth) =>
            AltVAsync.Schedule(() => vehicle.BodyAdditionalHealth = bodyAdditionalHealth);

        [Obsolete("Use async entities instead")]
        public static Task<uint> GetBodyHealthAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.BodyHealth);

        [Obsolete("Use async entities instead")]
        public static Task SetBodyHealthAsync(this IVehicle vehicle, uint bodyHealth) =>
            AltVAsync.Schedule(() => vehicle.BodyHealth = bodyHealth);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetRepairsCountAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.RepairsCount);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetWheelsCountAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.WheelsCount);

        [Obsolete("Use async entities instead")]
        public static Task<int> GetPetrolTankHealthAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.PetrolTankHealth);

        [Obsolete("Use async entities instead")]
        public static Task SetPetrolTankHealthAsync(this IVehicle vehicle, int petrolTankHealth) =>
            AltVAsync.Schedule(() => vehicle.PetrolTankHealth = petrolTankHealth);

        [Obsolete("Use async entities instead")]
        public static Task<int> GetEngineHealthAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.EngineHealth);

        [Obsolete("Use async entities instead")]
        public static Task SetEngineHealthAsync(this IVehicle vehicle, int engineHealth) =>
            AltVAsync.Schedule(() => vehicle.EngineHealth = engineHealth);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsNeonActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsNeonActive);

        [Obsolete("Use async entities instead")]
        public static Task<string> GetStateAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.State);

        [Obsolete("Use async entities instead")]
        public static Task SetStateAsync(this IVehicle vehicle, string state) =>
            AltVAsync.Schedule(() => vehicle.State = state);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetRoofStateAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.RoofState);

        [Obsolete("Use async entities instead")]
        public static Task SetRoofStateAsync(this IVehicle vehicle, byte roofState) =>
            AltVAsync.Schedule(() => vehicle.RoofState = roofState);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetDoorStateAsync(this IVehicle vehicle, byte doorId) =>
            AltVAsync.Schedule(() => vehicle.GetDoorState(doorId));

        [Obsolete("Use async entities instead")]
        public static Task SetDoorStateAsync(this IVehicle vehicle, byte doorId, byte state) =>
            AltVAsync.Schedule(() => vehicle.SetDoorState(doorId, state));

        [Obsolete("Use async entities instead")]
        public static Task<VehicleDoorState> GetDoorStateAsync(this IVehicle vehicle, VehicleDoor door) =>
            AltVAsync.Schedule(() => vehicle.GetDoorStateExt(door));

        [Obsolete("Use async entities instead")]
        public static Task SetDoorStateAsync(this IVehicle vehicle, VehicleDoor door, VehicleDoorState state) =>
            AltVAsync.Schedule(() => vehicle.SetDoorStateExt(door, state));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsWindowOpenedAsync(this IVehicle vehicle, byte windowId) =>
            AltVAsync.Schedule(() => vehicle.IsWindowOpened(windowId));

        [Obsolete("Use async entities instead")]
        public static Task SetWindowOpenedAsync(this IVehicle vehicle, byte windowId, bool state) =>
            AltVAsync.Schedule(() => vehicle.SetWindowOpened(windowId, state));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsNightlightOnAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsNightlightOn);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsDaylightOnAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsDaylightOn);

        [Obsolete("Use async entities instead")]
        public static Task<VehicleLockState> GetLockStateAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.LockState);

        [Obsolete("Use async entities instead")]
        public static Task SetLockStateAsync(this IVehicle vehicle, VehicleLockState lockState) =>
            AltVAsync.Schedule(() => vehicle.LockState = lockState);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsSirenActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.SirenActive);

        [Obsolete("Use async entities instead")]
        public static Task SetSirenActiveAsync(this IVehicle vehicle, bool sirenActive) =>
            AltVAsync.Schedule(() => vehicle.SirenActive = sirenActive);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetHeadlightColorAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.HeadlightColor);

        [Obsolete("Use async entities instead")]
        public static Task SetHeadlightColorAsync(this IVehicle vehicle, byte headlightColor) =>
            AltVAsync.Schedule(() => vehicle.HeadlightColor = headlightColor);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsHandbrakeActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsHandbrakeActive);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsFlamethrowerActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsFlamethrowerActive);

        [Obsolete("Use async entities instead")]
        public static Task<bool> HasArmoredWindowsAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.HasArmoredWindows);

        [Obsolete("Use async entities instead")]
        public static Task SetSpecialLightDamagedAsync(this IVehicle vehicle, byte specialLightId, bool isDamaged) =>
            AltVAsync.Schedule(() => vehicle.SetSpecialLightDamaged(specialLightId, isDamaged));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsSpecialLightDamagedAsync(this IVehicle vehicle, byte specialLightId) =>
            AltVAsync.Schedule(() => vehicle.IsSpecialLightDamaged(specialLightId));

        [Obsolete("Use async entities instead")]
        public static Task SetWindowDamagedAsync(this IVehicle vehicle, byte windowId, bool isDamaged) =>
            AltVAsync.Schedule(() => vehicle.SetWindowDamaged(windowId, isDamaged));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsWindowDamagedAsync(this IVehicle vehicle, byte windowId) =>
            AltVAsync.Schedule(() => vehicle.IsWindowDamaged(windowId));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsLightDamagedAsync(this IVehicle vehicle, byte lightId) =>
            AltVAsync.Schedule(() => vehicle.IsLightDamaged(lightId));
        
        [Obsolete("Use async entities instead")]
        public static Task SetLightDamagedAsync(this IVehicle vehicle, byte lightId, bool isDamaged) =>
            AltVAsync.Schedule(() => vehicle.SetLightDamaged(lightId, isDamaged));
        
        [Obsolete("Use async entities instead")]
        public static Task<byte> GetPartBulletHolesAsync(this IVehicle vehicle, byte partId) =>
            AltVAsync.Schedule(() => vehicle.GetPartBulletHoles(partId));

        [Obsolete("Use async entities instead")]
        public static Task SetPartBulletHolesAsync(this IVehicle vehicle, byte partId, byte shootsCount) =>
            AltVAsync.Schedule(() => vehicle.SetPartBulletHoles(partId, shootsCount));
        
        [Obsolete("Use async entities instead")]
        public static Task<byte> GetPartBulletHolesExtAsync(this IVehicle vehicle, VehiclePart part) =>
            AltVAsync.Schedule(() => vehicle.GetPartBulletHolesExt(part));
        
        [Obsolete("Use async entities instead")]
        public static Task SetPartBulletHolesExtAsync(this IVehicle vehicle, VehiclePart part, byte shootsCount) =>
            AltVAsync.Schedule(() => vehicle.SetPartBulletHolesExt(part, shootsCount));

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetPartDamageLevelAsync(this IVehicle vehicle, byte partId) =>
            AltVAsync.Schedule(() => vehicle.GetPartDamageLevel(partId));

        [Obsolete("Use async entities instead")]
        public static Task SetPartDamageLevelAsync(this IVehicle vehicle, byte partId, byte damage) =>
            AltVAsync.Schedule(() => vehicle.SetPartDamageLevel(partId, damage));
        
        [Obsolete("Use async entities instead")]
        public static Task<VehiclePartDamage> GetPartDamageLevelExtAsync(this IVehicle vehicle, VehiclePart part) =>
            AltVAsync.Schedule(() => vehicle.GetPartDamageLevelExt(part));

        [Obsolete("Use async entities instead")]
        public static Task SetPartDamageLevelExtAsync(this IVehicle vehicle, VehiclePart part, byte damage) =>
            AltVAsync.Schedule(() => vehicle.SetPartDamageLevelExt(part, damage));

        [Obsolete("Use async entities instead")]
        public static Task<float> GetArmoredWindowHealthAsync(this IVehicle vehicle, byte windowId) =>
            AltVAsync.Schedule(() => vehicle.GetArmoredWindowHealth(windowId));

        [Obsolete("Use async entities instead")]
        public static Task SetArmoredWindowHealthAsync(this IVehicle vehicle, byte windowId, float health) =>
            AltVAsync.Schedule(() => vehicle.SetArmoredWindowHealth(windowId, health));

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetArmoredWindowShootCountAsync(this IVehicle vehicle, byte windowId) =>
            AltVAsync.Schedule(() => vehicle.GetArmoredWindowShootCount(windowId));

        [Obsolete("Use async entities instead")]
        public static Task SetArmoredWindowShootCountAsync(this IVehicle vehicle, byte windowId, byte count) =>
            AltVAsync.Schedule(() => vehicle.SetArmoredWindowShootCount(windowId, count));

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetBumperDamageLevelAsync(this IVehicle vehicle, byte bumperId) =>
            AltVAsync.Schedule(() => vehicle.GetBumperDamageLevel(bumperId));

        [Obsolete("Use async entities instead")]
        public static Task SetBumperDamageLevelAsync(this IVehicle vehicle, byte bumperId, byte damageLevel) =>
            AltVAsync.Schedule(() => vehicle.SetBumperDamageLevel(bumperId, damageLevel));

        [Obsolete("Use async entities instead")]
        public static Task<VehicleBumperDamage> GetBumperDamageLevelExtAsync(this IVehicle vehicle, VehicleBumper bumper) =>
            AltVAsync.Schedule(() => vehicle.GetBumperDamageLevelExt(bumper));

        [Obsolete("Use async entities instead")]
        public static Task SetBumperDamageLevelExtAsync(this IVehicle vehicle, VehicleBumper bumper,
            VehicleBumperDamage bumperDamage) =>
            AltVAsync.Schedule(() => vehicle.SetBumperDamageLevelExt(bumper, bumperDamage));
        
        [Obsolete("Use async entities instead")]
        public static Task<string> GetDamageDataAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.DamageData);

        [Obsolete("Use async entities instead")]
        public static Task SetDamageDataAsync(this IVehicle vehicle, string damageData) =>
            AltVAsync.Schedule(() => vehicle.DamageData = damageData);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetModAsync(this IVehicle vehicle, byte category) =>
            AltVAsync.Schedule(() => vehicle.GetMod(category));

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetModsCountAsync(this IVehicle vehicle, byte category) =>
            AltVAsync.Schedule(() => vehicle.GetModsCount(category));

        [Obsolete("Use async entities instead")]
        public static Task<bool> SetModAsync(this IVehicle vehicle, byte category, byte id) =>
            AltVAsync.Schedule(() => vehicle.SetMod(category, id));

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetModKitsCountAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.ModKitsCount);

        [Obsolete("Use async entities instead")]
        public static Task SetWheelsAsync(this IVehicle vehicle, byte type, byte variation) =>
            AltVAsync.Schedule(() => vehicle.SetWheels(type, variation));
      
        [Obsolete("Use async entities instead")]  
        public static Task SetRearWheelAsync(this IVehicle vehicle, byte variation) =>
            AltVAsync.Schedule(() => vehicle.RearWheel = variation);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetRearWheelAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.RearWheel);
        
        [Obsolete("Use async entities instead")]
        public static Task SetLiveryAsync(this IVehicle vehicle, byte livery) =>
            AltVAsync.Schedule(() => vehicle.Livery = livery);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetLiveryAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.Livery);

        [Obsolete("Use async entities instead")]
        public static Task SetRoofLiveryAsync(this IVehicle vehicle, byte roofLivery) =>
            AltVAsync.Schedule(() => vehicle.RoofLivery = roofLivery);

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetRoofLiveryAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.RoofLivery);
        
        [Obsolete("Use async entities instead")]
        public static Task SetLightsMultiplierAsync(this IVehicle vehicle, float multiplier) =>
            AltVAsync.Schedule(() => vehicle.LightsMultiplier = multiplier);

        [Obsolete("Use async entities instead")]
        public static Task<float> GetLightsMultiplierAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.LightsMultiplier);
        
        [Obsolete("Use async entities instead")]
        public static Task<bool> IsExtraOnAsync(this IVehicle vehicle, byte extraId) =>
            AltVAsync.Schedule(() => vehicle.IsExtraOn(extraId));

        [Obsolete("Use async entities instead")]
        public static Task ToggleExtraAsync(this IVehicle vehicle, byte extraId, bool state) =>
            AltVAsync.Schedule(() => vehicle.ToggleExtra(extraId, state));

        [Obsolete("Use async entities instead")]
        public static Task<Tuple<bool, bool, bool, bool>> GetNeonActiveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() =>
            {
                bool left = false, right = false, front = false, back = false;
                vehicle.GetNeonActive(ref left, ref right, ref front, ref back);
                return new Tuple<bool, bool, bool, bool>(left, right, front, back);
            });

        [Obsolete("Use async entities instead")]
        public static Task SetNeonActiveAsync(this IVehicle vehicle, bool left, bool right, bool front, bool back) =>
            AltVAsync.Schedule(() => vehicle.SetNeonActive(left, right, front, back));

        [Obsolete("Use async entities instead")]
        public static Task<string> GetAppearanceDataAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.AppearanceData);

        [Obsolete("Use async entities instead")]
        public static Task SetAppearanceDataAsync(this IVehicle vehicle, string text) =>
            AltVAsync.Schedule(() => vehicle.AppearanceData = text);

        [Obsolete("Use async entities instead")]
        public static Task<uint> GetRadioStationAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.RadioStation);

        [Obsolete("Use async entities instead")]
        public static Task SetRadioStationAsync(this IVehicle vehicle, uint radioStation) =>
            AltVAsync.Schedule(() => vehicle.RadioStation = radioStation);

        [Obsolete("Use async entities instead")]
        public static Task<bool> GetManualEngineControlAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.ManualEngineControl);

        [Obsolete("Use async entities instead")]
        public static Task SetManualEngineControlAsync(this IVehicle vehicle, bool state) =>
            AltVAsync.Schedule(() => vehicle.ManualEngineControl = state);

        [Obsolete("Use async entities instead")]
        public static Task<string> GetScriptDataAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.ScriptData);

        [Obsolete("Use async entities instead")]
        public static Task SetScriptDataAsync(this IVehicle vehicle, string text) =>
            AltVAsync.Schedule(() => vehicle.ScriptData = text);

        [Obsolete("Use async entities instead")]
        public static Task RemoveAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(vehicle.Remove);

        [Obsolete("Use async entities instead")]
        public static Task<bool> GetVisibleAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.Visible);

        [Obsolete("Use async entities instead")]
        public static Task SetVisibleAsync(this IVehicle vehicle, bool visibility) =>
            AltVAsync.Schedule(() => vehicle.Visible = visibility);
        
        [Obsolete("Use async entities instead")]
        public static Task<bool> GetStreamedAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.Streamed);

        [Obsolete("Use async entities instead")]
        public static Task SetStreamedAsync(this IVehicle vehicle, bool isStreamed) =>
            AltVAsync.Schedule(() => vehicle.Streamed = isStreamed);

        [Obsolete("Use async entities instead")]
        public static Task IsDestroyedAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.IsDestroyed);

        [Obsolete("Use async entities instead")]
        public static Task<IVehicle> AttachedAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.Attached);

        [Obsolete("Use async entities instead")]
        public static Task<IVehicle> AttachedToAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.AttachedTo);

        [Obsolete("Use async entities instead")]
        public static Task AttachToEntityAsync(this IVehicle vehicle, IEntity entity, short otherBone, short ownBone,
            Position position, Rotation rotation, bool collision, bool noFixedRotation) =>
            AltVAsync.Schedule(() =>
                vehicle.AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRotation));

        [Obsolete("Use async entities instead")]
        public static Task DetachAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(vehicle.Detach);

        [Obsolete("Use async entities instead")]
        public static Task<bool> DoesWheelHasTireAsync(this IVehicle vehicle, byte wheelId) =>
            AltVAsync.Schedule(() => vehicle.DoesWheelHasTire(wheelId));

        [Obsolete("Use async entities instead")]
        public static Task<float> GetWheelHealthAsync(this IVehicle vehicle, byte wheelId) =>
            AltVAsync.Schedule(() => vehicle.GetWheelHealth(wheelId));

        [Obsolete("Use async entities instead")]
        public static Task SetWheelHealthAsync(this IVehicle vehicle, byte wheelId, float health) =>
            AltVAsync.Schedule(() => vehicle.SetWheelHealth(wheelId, health));

        [Obsolete("Use async entities instead")]
        public static Task RepairAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(vehicle.Repair);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsWheelBurstAsync(this IVehicle vehicle, byte wheelId) =>
            AltVAsync.Schedule(() => vehicle.IsWheelBurst(wheelId));

        [Obsolete("Use async entities instead")]
        public static Task SetWheelBurstAsync(this IVehicle vehicle, byte wheelId, bool state) =>
            AltVAsync.Schedule(() => vehicle.SetWheelBurst(wheelId, state));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsWheelDetachedAsync(this IVehicle vehicle, byte wheelId) =>
            AltVAsync.Schedule(() => vehicle.IsWheelDetached(wheelId));

        [Obsolete("Use async entities instead")]
        public static Task SetWheelDetachedAsync(this IVehicle vehicle, byte wheelId, bool state) =>
            AltVAsync.Schedule(() => vehicle.SetWheelDetached(wheelId, state));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsWheelOnFireAsync(this IVehicle vehicle, byte wheelId) =>
            AltVAsync.Schedule(() => vehicle.IsWheelOnFire(wheelId));

        [Obsolete("Use async entities instead")]
        public static Task SetWheelOnFireAsync(this IVehicle vehicle, byte wheelId, bool state) =>
            AltVAsync.Schedule(() => vehicle.SetWheelOnFire(wheelId, state));

        [Obsolete("Use async entities instead")]
        public static Task SetWheelHasTireAsync(this IVehicle vehicle, byte wheelId, bool state) =>
            AltVAsync.Schedule(() => vehicle.SetWheelHasTire(wheelId, state));

        [Obsolete("Use async entities instead")]
        public static Task<Position> GetVelocityAsync(this IVehicle vehicle) =>
            AltVAsync.Schedule(() => vehicle.Velocity);
    }
}