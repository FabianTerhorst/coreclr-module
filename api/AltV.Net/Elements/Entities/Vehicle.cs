using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Enums;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Vehicle : Entity, IVehicle
    {
        public IntPtr VehicleNativePointer { get; private set; }
        public override IntPtr NativePointer => VehicleNativePointer;

        private static IntPtr GetEntityPointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Shared.Vehicle_GetEntity(nativePointer);
            }
        }

        public static uint GetId(IntPtr vehiclePointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Vehicle_GetID(vehiclePointer);
            }
        }

        public override uint Model
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Shared.Entity_GetModel(EntityNativePointer);
                }
            }
            set => throw new NotImplementedException("vehicle doesn't support set model");
        }

        public IPlayer Driver
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var entityPointer = Core.Library.Server.Vehicle_GetDriver(VehicleNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Core.PoolManager.Player.Get(entityPointer);
                }
            }
        }

        public bool IsDestroyed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsDestroyed(VehicleNativePointer) == 1;
                }
            }
        }

        public byte ModKit
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetModKit(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetModKit(VehicleNativePointer, value);
                }
            }
        }

        public byte ModKitsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetModKitsCount(VehicleNativePointer);
                }
            }
        }

        public bool IsPrimaryColorRgb
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsPrimaryColorRGB(VehicleNativePointer) == 1;
                }
            }
        }

        public byte PrimaryColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetPrimaryColor(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetPrimaryColor(VehicleNativePointer, value);
                }
            }
        }

        public Rgba PrimaryColorRgb
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var rgba = Rgba.Zero;
                    Core.Library.Server.Vehicle_GetPrimaryColorRGB(VehicleNativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetPrimaryColorRGB(VehicleNativePointer, value);
                }
            }
        }

        public bool IsSecondaryColorRgb
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsSecondaryColorRGB(VehicleNativePointer) == 1;
                }
            }
        }

        public byte SecondaryColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetSecondaryColor(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetSecondaryColor(VehicleNativePointer, value);
                }
            }
        }

        public Rgba SecondaryColorRgb
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var rgba = Rgba.Zero;
                    Core.Library.Server.Vehicle_GetSecondaryColorRGB(VehicleNativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetSecondaryColorRGB(VehicleNativePointer, value);
                }
            }
        }

        public byte PearlColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetPearlColor(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetPearlColor(VehicleNativePointer, value);
                }
            }
        }

        public byte WheelColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetWheelColor(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetWheelColor(VehicleNativePointer, value);
                }
            }
        }

        public byte InteriorColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetInteriorColor(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetInteriorColor(VehicleNativePointer, value);
                }
            }
        }

        public byte DashboardColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetDashboardColor(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetDashboardColor(VehicleNativePointer, value);
                }
            }
        }

        public bool IsTireSmokeColorCustom
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsTireSmokeColorCustom(VehicleNativePointer) == 1;
                }
            }
        }

        public Rgba TireSmokeColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var rgba = Rgba.Zero;
                    Core.Library.Server.Vehicle_GetTireSmokeColor(VehicleNativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTireSmokeColor(VehicleNativePointer, value);
                }
            }
        }

        public byte WheelType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetWheelType(VehicleNativePointer);
                }
            }
        }

        public byte WheelVariation
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetWheelVariation(VehicleNativePointer);
                }
            }
        }

        public byte RearWheel
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetRearWheelVariation(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetRearWheels(VehicleNativePointer, value);
                }
            }
        }

        public bool CustomTires
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetCustomTires(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetCustomTires(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public byte SpecialDarkness
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetSpecialDarkness(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetSpecialDarkness(VehicleNativePointer, value);
                }
            }
        }

        public uint NumberplateIndex
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetNumberplateIndex(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetNumberplateIndex(VehicleNativePointer, value);
                }
            }
        }

        public string NumberplateText
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Server.Vehicle_GetNumberplateText(VehicleNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    Core.Library.Server.Vehicle_SetNumberplateText(VehicleNativePointer, stringPtr);
                    Marshal.FreeHGlobal(stringPtr);
                }
            }
        }

        public byte WindowTint
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetWindowTint(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetWindowTint(VehicleNativePointer, value);
                }
            }
        }

        public byte DirtLevel
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetDirtLevel(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetDirtLevel(VehicleNativePointer, value);
                }
            }
        }

        public Rgba NeonColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var rgba = Rgba.Zero;
                    Core.Library.Server.Vehicle_GetNeonColor(VehicleNativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetNeonColor(VehicleNativePointer, value);
                }
            }
        }

        public byte Livery
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetLivery(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetLivery(VehicleNativePointer, value);
                }
            }
        }

        public byte LightState
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetLightState(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetLightState(VehicleNativePointer, value);
                }
            }
        }

        public byte RoofLivery
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetRoofLivery(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetRoofLivery(VehicleNativePointer, value);
                }
            }
        }

        public string AppearanceData
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Server.Vehicle_GetAppearanceDataBase64(VehicleNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    if (stringPtr == IntPtr.Zero) throw new ArgumentNullException(nameof(ScriptData));
                    Core.Library.Server.Vehicle_LoadAppearanceDataFromBase64(VehicleNativePointer, stringPtr);
                    Marshal.FreeHGlobal(stringPtr);
                }
            }
        }

        public bool EngineOn
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsEngineOn(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetEngineOn(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool IsHandbrakeActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsHandbrakeActive(VehicleNativePointer) == 1;
                }
            }
        }

        public byte HeadlightColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetHeadlightColor(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetHeadlightColor(VehicleNativePointer, value);
                }
            }
        }

        public uint RadioStation
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetRadioStationIndex(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetRadioStationIndex(VehicleNativePointer, value);
                }
            }
        }

        public IPlayer TimedExplosionCulprit
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var entityPointer = Core.Library.Server.Vehicle_GetTimedExplosionCulprit(VehicleNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Core.PoolManager.Player.Get(entityPointer);
                }
            }
        }

        public uint TimedExplosionTime
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetTimedExplosionTime(VehicleNativePointer);
                }
            }
        }

        public bool SirenActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsSirenActive(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetSirenActive(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public VehicleLockState LockState
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return (VehicleLockState) Core.Library.Server.Vehicle_GetLockState(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetLockState(VehicleNativePointer, (byte) value);
                }
            }
        }

        public byte GetDoorState(byte doorId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_GetDoorState(VehicleNativePointer, doorId);
            }
        }

        public void SetDoorState(byte doorId, byte state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetDoorState(VehicleNativePointer, doorId, state);
            }
        }

        public bool IsWindowOpened(byte windowId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_IsWindowOpened(VehicleNativePointer, windowId) == 1;
            }
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWindowOpened(VehicleNativePointer, windowId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsDaylightOn
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsDaylightOn(VehicleNativePointer) == 1;
                }
            }
        }

        public bool IsNightlightOn
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsNightlightOn(VehicleNativePointer) == 1;
                }
            }
        }

        public bool IsRoofClosed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetRoofState(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetRoofState(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public bool IsFlamethrowerActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsFlamethrowerActive(VehicleNativePointer) == 1;
                }
            }
        }

        public float LightsMultiplier
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetLightsMultiplier(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetLightsMultiplier(VehicleNativePointer, value);
                }
            }
        }

        public string State
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Server.Vehicle_GetGameStateBase64(VehicleNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    if (stringPtr == IntPtr.Zero) throw new ArgumentNullException(nameof(ScriptData));
                    Core.Library.Server.Vehicle_LoadGameStateFromBase64(VehicleNativePointer, stringPtr);
                    Marshal.FreeHGlobal(stringPtr);
                }
            }
        }

        public int EngineHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetEngineHealth(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetEngineHealth(VehicleNativePointer, value);
                }
            }
        }

        public int PetrolTankHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Shared.Vehicle_GetPetrolTankHealth(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetPetrolTankHealth(VehicleNativePointer, value);
                }
            }
        }

        public byte WheelsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Shared.Vehicle_GetWheelsCount(VehicleNativePointer);
                }
            }
        }

        public bool IsWheelBurst(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Server.Vehicle_IsWheelBurst(VehicleNativePointer, wheelId) == 1;
            }
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWheelBurst(VehicleNativePointer, wheelId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Server.Vehicle_DoesWheelHasTire(VehicleNativePointer, wheelId) == 1;
            }
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWheelHasTire(VehicleNativePointer, wheelId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsWheelDetached(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Server.Vehicle_IsWheelDetached(VehicleNativePointer, wheelId) == 1;
            }
        }

        public void SetWheelDetached(byte wheelId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWheelDetached(VehicleNativePointer, wheelId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsWheelOnFire(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Server.Vehicle_IsWheelOnFire(VehicleNativePointer, wheelId) == 1;
            }
        }

        public void SetWheelOnFire(byte wheelId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWheelOnFire(VehicleNativePointer, wheelId, state ? (byte) 1 : (byte) 0);
            }
        }

        public float GetWheelHealth(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Server.Vehicle_GetWheelHealth(VehicleNativePointer, wheelId);
            }
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWheelHealth(VehicleNativePointer, wheelId, health);
            }
        }

        public void SetWheelFixed(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWheelFixed(VehicleNativePointer, wheelId);
            }
        }

        public byte RepairsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetRepairsCount(VehicleNativePointer);
                }
            }
        }

        public uint BodyHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetBodyHealth(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetBodyHealth(VehicleNativePointer, value);
                }
            }
        }

        public uint BodyAdditionalHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetBodyAdditionalHealth(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetBodyAdditionalHealth(VehicleNativePointer, value);
                }
            }
        }

        public string HealthData
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Server.Vehicle_GetHealthDataBase64(VehicleNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    if (stringPtr == IntPtr.Zero) throw new ArgumentNullException(nameof(ScriptData));
                    Core.Library.Server.Vehicle_LoadHealthDataFromBase64(VehicleNativePointer, stringPtr);
                    Marshal.FreeHGlobal(stringPtr);
                }
            }
        }

        public byte GetPartDamageLevel(byte partId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_GetPartDamageLevel(VehicleNativePointer, partId);
            }
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetPartDamageLevel(VehicleNativePointer, partId, damage);
            }
        }

        public byte GetPartBulletHoles(byte partId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_GetPartBulletHoles(VehicleNativePointer, partId);
            }
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetPartBulletHoles(VehicleNativePointer, partId, shootsCount);
            }
        }

        public bool IsLightDamaged(byte lightId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_IsLightDamaged(VehicleNativePointer, lightId) == 1;
            }
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetLightDamaged(VehicleNativePointer, lightId, isDamaged ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsWindowDamaged(byte windowId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_IsWindowDamaged(VehicleNativePointer, windowId) == 1;
            }
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWindowDamaged(VehicleNativePointer, windowId, isDamaged ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_IsSpecialLightDamaged(VehicleNativePointer, specialLightId) == 1;
            }
        }

        void IVehicle.SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetSpecialLightDamaged(VehicleNativePointer, specialLightId, isDamaged ? (byte) 1 : (byte) 0);
            }
        }

        public bool HasArmoredWindows
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_HasArmoredWindows(VehicleNativePointer) == 1;
                }
            }
        }

        public bool TimedExplosion {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_HasTimedExplosion(VehicleNativePointer) == 1;
                }
            }
        }

        public float GetArmoredWindowHealth(byte windowId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_GetArmoredWindowHealth(VehicleNativePointer, windowId);
            }
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetArmoredWindowHealth(VehicleNativePointer, windowId, health);
            }
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_GetArmoredWindowShootCount(VehicleNativePointer, windowId);
            }
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetArmoredWindowShootCount(VehicleNativePointer, windowId, count);
            }
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_GetBumperDamageLevel(VehicleNativePointer, bumperId);
            }
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetBumperDamageLevel(VehicleNativePointer, bumperId, damageLevel);
            }
        }

        public string DamageData
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Server.Vehicle_GetDamageDataBase64(VehicleNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    if (stringPtr == IntPtr.Zero) throw new ArgumentNullException(nameof(ScriptData));
                    Core.Library.Server.Vehicle_LoadDamageDataFromBase64(VehicleNativePointer, stringPtr);
                    Marshal.FreeHGlobal(stringPtr);
                }
            }
        }

        public bool ManualEngineControl
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsManualEngineControl(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetManualEngineControl(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public string ScriptData
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Server.Vehicle_GetScriptDataBase64(VehicleNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    if (stringPtr == IntPtr.Zero) throw new ArgumentNullException(nameof(ScriptData));
                    Core.Library.Server.Vehicle_LoadScriptDataFromBase64(VehicleNativePointer, stringPtr);
                    Marshal.FreeHGlobal(stringPtr);
                }
            }
        }

        public IVehicle Attached
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var entityPointer = Core.Library.Server.Vehicle_GetAttached(VehicleNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Core.PoolManager.Vehicle.Get(entityPointer);
                }
            }
        }

        public IVehicle AttachedTo
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var entityPointer = Core.Library.Server.Vehicle_GetAttachedTo(VehicleNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Core.PoolManager.Vehicle.Get(entityPointer);
                }
            }
        }

        [Obsolete("Use Alt.CreateVehicle instead")]
        public Vehicle(ICore core, uint model, Position position, Rotation rotation) : this(
            core, core.CreateVehicleEntity(out var id, model, position, rotation), id)
        {
            core.PoolManager.Vehicle.Add(this);
        }

        public Vehicle(ICore core, IntPtr nativePointer, uint id) : base(core, GetEntityPointer(core, nativePointer), BaseObjectType.Vehicle, id)
        {
            this.VehicleNativePointer = nativePointer;
        }

        public byte GetMod(byte category)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_GetMod(VehicleNativePointer, category);
            }
        }

        public byte GetModsCount(byte category)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_GetModsCount(VehicleNativePointer, category);
            }
        }

        public bool SetMod(byte category, byte id)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_SetMod(VehicleNativePointer, category, id) == 1;
            }
        }

        public void SetWheels(byte type, byte variation)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWheels(VehicleNativePointer, type, variation);
            }
        }

        public bool IsExtraOn(byte extraId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_IsExtraOn(VehicleNativePointer, extraId) == 1;
            }
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_ToggleExtra(VehicleNativePointer, extraId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsNeonActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsNeonActive(VehicleNativePointer) == 1;
                }
            }
        }

        public void SetNeonActive(bool left, bool right, bool front, bool back)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetNeonActive(VehicleNativePointer, left ? (byte) 1 : (byte) 0, right ? (byte) 1 : (byte) 0, front ? (byte) 1 : (byte) 0, back ? (byte) 1 : (byte) 0);
            }
        }

        public void GetNeonActive(ref bool left, ref bool right, ref bool front, ref bool back)
        {
            unsafe
            {
                CheckIfEntityExists();
                byte pLeft;
                byte pRight;
                byte pFront;
                byte pBack;
                Core.Library.Server.Vehicle_GetNeonActive(VehicleNativePointer, &pLeft, &pRight, &pFront, &pBack);
                left = pLeft == 1;
                right = pRight == 1;
                front = pFront == 1;
                back = pBack == 1;
            }
        }

        public void Repair()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_Repair(VehicleNativePointer);
            }
        }

        public void SetTimedExplosion(bool state, IPlayer culprit, uint time)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetTimedExplosion(VehicleNativePointer, state ? (byte) 1 : (byte) 0, culprit.NativePointer, time);
            }
        }

        public Position Velocity
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var position = Vector3.Zero;
                    Core.Library.Server.Vehicle_GetVelocity(VehicleNativePointer, &position);
                    return position;
                }
            }
        }

        public bool DriftMode
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsDriftMode(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetDriftMode(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool BoatAnchor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetBoatAnchor(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetBoatAnchor(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public bool SetSearchLight(bool state, IEntity spottedEntity)
        {
            unsafe
            {
                if (spottedEntity == null) return false;
                CheckIfEntityExists();

                return Core.Library.Server.Vehicle_SetSearchLight(VehicleNativePointer, state ? (byte) 1 : (byte) 0, spottedEntity.EntityNativePointer) == 1;
            }
        }

        public bool IsMissionTrain
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsTrainMissionTrain(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainMissionTrain(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public sbyte TrainTrackId
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetTrainTrackId(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainTrackId(VehicleNativePointer, value);
                }
            }
        }

        public IVehicle TrainEngine
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var entityPointer = Core.Library.Server.Vehicle_GetTrainEngineId(VehicleNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Core.PoolManager.Vehicle.Get(entityPointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainEngineId(VehicleNativePointer, value?.VehicleNativePointer ?? IntPtr.Zero);
                }
            }
        }

        public sbyte TrainConfigIndex
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetTrainConfigIndex(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainConfigIndex(VehicleNativePointer, value);
                }
            }
        }

        public float TrainDistanceFromEngine
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetTrainDistanceFromEngine(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainDistanceFromEngine(VehicleNativePointer, value);
                }
            }
        }

        public bool IsTrainEngine
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsTrainEngine(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainIsEngine(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool IsTrainCaboose
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsTrainCaboose(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainIsCaboose(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool TrainDirection
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetTrainDirection(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainDirection(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool TrainPassengerCarriages
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_HasTrainPassengerCarriages(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainHasPassengerCarriages(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool TrainRenderDerailed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetTrainRenderDerailed(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainRenderDerailed(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool TrainForceDoorsOpen
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetTrainForceDoorsOpen(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainForceDoorsOpen(VehicleNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public float TrainCruiseSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetTrainCruiseSpeed(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainCruiseSpeed(VehicleNativePointer, value);
                }
            }
        }

        public sbyte TrainCarriageConfigIndex
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetTrainCarriageConfigIndex(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainCarriageConfigIndex(VehicleNativePointer, value);
                }
            }
        }

        public IVehicle TrainLinkedToBackward
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var entityPointer = Core.Library.Server.Vehicle_GetTrainLinkedToBackwardId(VehicleNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Core.PoolManager.Vehicle.Get(entityPointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainLinkedToBackwardId(VehicleNativePointer, value?.VehicleNativePointer ?? IntPtr.Zero);
                }
            }
        }

        public IVehicle TrainLinkedToForward
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    var entityPointer = Core.Library.Server.Vehicle_GetTrainLinkedToForwardId(VehicleNativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Core.PoolManager.Vehicle.Get(entityPointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetTrainLinkedToForwardId(VehicleNativePointer, value?.VehicleNativePointer ?? IntPtr.Zero);
                }
            }
        }

        public uint CounterMeasureCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetCounterMeasureCount(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetCounterMeasureCount(VehicleNativePointer, value);
                }
            }
        }

        public bool HybridExtraActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetHybridExtraActive(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetHybridExtraActive(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public byte HybridExtraState
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetHybridExtraState(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetHybridExtraState(VehicleNativePointer, value);
                }
            }
        }

        public float RocketRefuelSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetRocketRefuelSpeed(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetRocketRefuelSpeed(VehicleNativePointer, value);
                }
            }
        }

        public float ScriptMaxSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetScriptMaxSpeed(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetScriptMaxSpeed(VehicleNativePointer, value);
                }
            }
        }

        public bool IsTowingDisabled
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_IsTowingDisabled(VehicleNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetDisableTowing(VehicleNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public void SetWeaponCapacity(byte index, int capacity)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Server.Vehicle_SetWeaponCapacity(VehicleNativePointer, index, capacity);
            }
        }

        public int GetWeaponCapacity(byte index)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Core.Library.Server.Vehicle_GetWeaponCapacity(VehicleNativePointer, index);
            }
        }

        public Quaternion Quaternion
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExistsOrCached();
                    return Core.Library.Server.Vehicle_GetQuaternion(VehicleNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Vehicle_SetQuaternion(VehicleNativePointer, value);
                }
            }
        }

        public override void SetCached(IntPtr cachedVehicle)
        {
            this.VehicleNativePointer = cachedVehicle;
            base.SetCached(GetEntityPointer(Core, cachedVehicle));
        }
    }
}