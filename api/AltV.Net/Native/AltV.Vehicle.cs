using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class Vehicle
        {
            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort Vehicle_GetID(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Vehicle_GetNetworkOwner(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern uint Vehicle_GetModel(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetPosition(IntPtr vehicle, ref Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetPosition(IntPtr vehicle, Position pos);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetRotation(IntPtr vehicle, ref Rotation rotation);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetRotation(IntPtr vehicle, Rotation rot);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern int Vehicle_GetDimension(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetDimension(IntPtr vehicle, int dimension);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Vehicle_GetMetaData(IntPtr vehicle, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetMetaData(IntPtr vehicle, IntPtr key, IntPtr val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Vehicle_GetSyncedMetaData(IntPtr vehicle, IntPtr key);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetSyncedMetaData(IntPtr vehicle, IntPtr key, IntPtr val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Vehicle_GetDriver(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetMod(IntPtr vehicle, byte category);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetModsCount(IntPtr vehicle, byte category);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_SetMod(IntPtr vehicle, byte category, byte id);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetModKitsCount(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetModKit(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_SetModKit(IntPtr vehicle, byte id);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsPrimaryColorRGB(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetPrimaryColor(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetPrimaryColorRGB(IntPtr vehicle, ref Rgba primaryColor);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetPrimaryColor(IntPtr vehicle, byte color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetPrimaryColorRGB(IntPtr vehicle, Rgba color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsSecondaryColorRGB(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetSecondaryColor(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetSecondaryColorRGB(IntPtr vehicle, ref Rgba secondaryColor);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetSecondaryColor(IntPtr vehicle, byte color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetSecondaryColorRGB(IntPtr vehicle, Rgba color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetPearlColor(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetPearlColor(IntPtr vehicle, byte color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetWheelColor(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetWheelColor(IntPtr vehicle, byte color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetInteriorColor(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetInteriorColor(IntPtr vehicle, byte color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetDashboardColor(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetDashboardColor(IntPtr vehicle, byte color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsTireSmokeColorCustom(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetTireSmokeColor(IntPtr vehicle, ref Rgba tireSmokeColor);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetTireSmokeColor(IntPtr vehicle, Rgba color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetWheelType(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetWheelVariation(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetWheels(IntPtr vehicle, byte type, byte variation);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_GetCustomTires(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetCustomTires(IntPtr vehicle, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetSpecialDarkness(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetSpecialDarkness(IntPtr vehicle, byte value);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern uint Vehicle_GetNumberplateIndex(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetNumberplateIndex(IntPtr vehicle, uint index);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetNumberplateText(IntPtr vehicle, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetNumberplateText(IntPtr vehicle, IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetWindowTint(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetWindowTint(IntPtr vehicle, byte tint);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetDirtLevel(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetDirtLevel(IntPtr vehicle, byte level);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsExtraOn(IntPtr vehicle, byte extraID);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_ToggleExtra(IntPtr vehicle, byte extraID, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsNeonActive(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetNeonActive(IntPtr vehicle, ref bool left, ref bool right,
                ref bool front, ref bool back);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetNeonActive(IntPtr vehicle, bool left, bool right, bool front,
                bool back);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetNeonColor(IntPtr vehicle, ref Rgba neonColor);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetNeonColor(IntPtr vehicle, Rgba color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetLivery(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetLivery(IntPtr vehicle, byte livery);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetRoofLivery(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetRoofLivery(IntPtr vehicle, byte roofLivery);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetAppearanceDataBase64(IntPtr vehicle, ref IntPtr base64);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_LoadAppearanceDataFromBase64(IntPtr vehicle, string base64);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsEngineOn(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetEngineOn(IntPtr vehicle, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsHandbrakeActive(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetHeadlightColor(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetHeadlightColor(IntPtr vehicle, byte color);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern uint Vehicle_GetRadioStationIndex(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetRadioStationIndex(IntPtr vehicle, uint stationIndex);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsSirenActive(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetSirenActive(IntPtr vehicle, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetLockState(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetLockState(IntPtr vehicle, byte state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetDoorState(IntPtr vehicle, byte doorId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetDoorState(IntPtr vehicle, byte doorId, byte state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsWindowOpened(IntPtr vehicle, byte windowId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetWindowOpened(IntPtr vehicle, byte windowId, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsDaylightOn(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsNightlightOn(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsRoofOpened(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetRoofOpened(IntPtr vehicle, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsFlamethrowerActive(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float Vehicle_GetLightsMultiplier(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetLightsMultiplier(IntPtr vehicle, float multiplier);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetGameStateBase64(IntPtr vehicle, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_LoadGameStateFromBase64(IntPtr vehicle, string base64);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern int Vehicle_GetEngineHealth(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetEngineHealth(IntPtr vehicle, int health);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern int Vehicle_GetPetrolTankHealth(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetPetrolTankHealth(IntPtr vehicle, int health);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetWheelsCount(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsWheelBurst(IntPtr vehicle, byte wheelId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetWheelBurst(IntPtr vehicle, byte wheelId, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_DoesWheelHasTire(IntPtr vehicle, byte wheelId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetWheelHasTire(IntPtr vehicle, byte wheelId, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float Vehicle_GetWheelHealth(IntPtr vehicle, byte wheelId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetWheelHealth(IntPtr vehicle, byte wheelId, float health);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetRepairsCount(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern uint Vehicle_GetBodyHealth(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetBodyHealth(IntPtr vehicle, uint health);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern uint Vehicle_GetBodyAdditionalHealth(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetBodyAdditionalHealth(IntPtr vehicle, uint health);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetHealthDataBase64(IntPtr vehicle, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_LoadHealthDataFromBase64(IntPtr vehicle, string base64);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetPartDamageLevel(IntPtr vehicle, byte partId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetPartDamageLevel(IntPtr vehicle, byte partId, byte damage);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetPartBulletHoles(IntPtr vehicle, byte partId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetPartBulletHoles(IntPtr vehicle, byte partId, byte shootsCount);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsLightDamaged(IntPtr vehicle, byte lightId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetLightDamaged(IntPtr vehicle, byte lightId, bool isDamaged);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsWindowDamaged(IntPtr vehicle, byte windowId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetWindowDamaged(IntPtr vehicle, byte windowId, bool isDamaged);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsSpecialLightDamaged(IntPtr vehicle, byte specialLightId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetSpecialLightDamaged(IntPtr vehicle, byte specialLightId,
                bool isDamaged);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_HasArmoredWindows(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float Vehicle_GetArmoredWindowHealth(IntPtr vehicle, byte windowId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetArmoredWindowHealth(IntPtr vehicle, byte windowId, float health);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetArmoredWindowShootCount(IntPtr vehicle, byte windowId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetArmoredWindowShootCount(IntPtr vehicle, byte windowId, byte count);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Vehicle_GetBumperDamageLevel(IntPtr vehicle, byte bumperId);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetBumperDamageLevel(IntPtr vehicle, byte bumperId, byte damageLevel);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetDamageDataBase64(IntPtr vehicle, ref IntPtr text);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_LoadDamageDataFromBase64(IntPtr vehicle, string base64);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_SetManualEngineControl(IntPtr vehicle, bool state);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Vehicle_IsManualEngineControl(IntPtr vehicle);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_GetScriptDataBase64(IntPtr vehicle, ref IntPtr base64);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Vehicle_LoadScriptDataFromBase64(IntPtr vehicle, string base64);
        }
    }
}