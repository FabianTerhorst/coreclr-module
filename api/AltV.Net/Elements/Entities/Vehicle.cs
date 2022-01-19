using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Enums;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Vehicle : Entity, IVehicle
    {
        public static ushort GetId(IntPtr vehiclePointer)
        {
            unsafe
            {
                return Alt.Server.Library.Vehicle_GetID(vehiclePointer);
            }
        }

        public override IPlayer NetworkOwner
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var entityPointer = Server.Library.Vehicle_GetNetworkOwner(NativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.PlayerPool.Get(entityPointer, out var player) ? player : null;
                }
            }
        }

        public override uint Model
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetModel(NativePointer);
                }
            }
            set => throw new NotImplementedException("vehicle doesn't support set model");
        }

        public override Position Position
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Position.Zero;
                    Server.Library.Vehicle_GetPosition(NativePointer, &position);
                    return position;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetPosition(NativePointer, value);
                }
            }
        }

        public override Rotation Rotation
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var rotation = Rotation.Zero;
                    Server.Library.Vehicle_GetRotation(NativePointer, &rotation);
                    return rotation;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetRotation(NativePointer, value);
                }
            }
        }

        public override bool Visible
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetVisible(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetVisible(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public override bool Streamed
        {
            get
            {
                CheckIfEntityExists();
                unsafe
                {
                    return Server.Library.Vehicle_GetStreamed(NativePointer) == 1;
                }
            }
            set
            {
                CheckIfEntityExists();
                unsafe
                {
                    Server.Library.Vehicle_SetStreamed(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public override int Dimension
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetDimension(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetDimension(NativePointer, value);
                }
            }
        }

        public override void SetNetworkOwner(IPlayer player, bool disableMigration)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetNetworkOwner(NativePointer, player?.NativePointer ?? IntPtr.Zero,
                    disableMigration ? (byte) 1 : (byte) 0);
            }
        }

        public override void GetMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Vehicle_GetMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void SetMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Vehicle_SetMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override bool HasMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Vehicle_HasMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public override void DeleteMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Vehicle_DeleteMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void SetSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Vehicle_SetSyncedMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void GetSyncedMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Vehicle_GetSyncedMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override bool HasSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Vehicle_HasSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public override void DeleteSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Vehicle_DeleteSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Vehicle_SetStreamSyncedMetaData(NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Server.Library.Vehicle_GetStreamSyncedMetaData(NativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public override bool HasStreamSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var result = Server.Library.Vehicle_HasStreamSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public override void DeleteStreamSyncedMetaData(string key)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Server.Library.Vehicle_DeleteStreamSyncedMetaData(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public IPlayer Driver
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var entityPointer = Server.Library.Vehicle_GetDriver(NativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.PlayerPool.Get(entityPointer, out var player) ? player : null;
                }
            }
        }

        public bool IsDestroyed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsDestroyed(NativePointer) == 1;
                }
            }
        }

        public byte ModKit
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetModKit(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetModKit(NativePointer, value);
                }
            }
        }

        public byte ModKitsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetModKitsCount(NativePointer);
                }
            }
        }

        public bool IsPrimaryColorRgb
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsPrimaryColorRGB(NativePointer) == 1;
                }
            }
        }

        public byte PrimaryColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetPrimaryColor(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetPrimaryColor(NativePointer, value);
                }
            }
        }

        public Rgba PrimaryColorRgb
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var rgba = Rgba.Zero;
                    Server.Library.Vehicle_GetPrimaryColorRGB(NativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetPrimaryColorRGB(NativePointer, value);
                }
            }
        }

        public bool IsSecondaryColorRgb
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsSecondaryColorRGB(NativePointer) == 1;
                }
            }
        }

        public byte SecondaryColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetSecondaryColor(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetSecondaryColor(NativePointer, value);
                }
            }
        }

        public Rgba SecondaryColorRgb
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var rgba = Rgba.Zero;
                    Server.Library.Vehicle_GetSecondaryColorRGB(NativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetSecondaryColorRGB(NativePointer, value);
                }
            }
        }

        public byte PearlColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetPearlColor(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetPearlColor(NativePointer, value);
                }
            }
        }

        public byte WheelColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetWheelColor(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetWheelColor(NativePointer, value);
                }
            }
        }

        public byte InteriorColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetInteriorColor(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetInteriorColor(NativePointer, value);
                }
            }
        }

        public byte DashboardColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetDashboardColor(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetDashboardColor(NativePointer, value);
                }
            }
        }

        public bool IsTireSmokeColorCustom
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsTireSmokeColorCustom(NativePointer) == 1;
                }
            }
        }

        public Rgba TireSmokeColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var rgba = Rgba.Zero;
                    Server.Library.Vehicle_GetTireSmokeColor(NativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTireSmokeColor(NativePointer, value);
                }
            }
        }

        public byte WheelType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetWheelType(NativePointer);
                }
            }
        }

        public byte WheelVariation
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetWheelVariation(NativePointer);
                }
            }
        }

        public byte RearWheel
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetRearWheelVariation(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetRearWheels(NativePointer, value);
                }
            }
        }

        public bool CustomTires
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetCustomTires(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetCustomTires(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public byte SpecialDarkness
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetSpecialDarkness(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetSpecialDarkness(NativePointer, value);
                }
            }
        }

        public uint NumberplateIndex
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetNumberplateIndex(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetNumberplateIndex(NativePointer, value);
                }
            }
        }

        public string NumberplateText
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var size = 0;
                    return Server.PtrToStringUtf8AndFree(
                        Server.Library.Vehicle_GetNumberplateText(NativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                    Server.Library.Vehicle_SetNumberplateText(NativePointer, stringPtr);
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
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetWindowTint(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetWindowTint(NativePointer, value);
                }
            }
        }

        public byte DirtLevel
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetDirtLevel(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetDirtLevel(NativePointer, value);
                }
            }
        }

        public Rgba NeonColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var rgba = Rgba.Zero;
                    Server.Library.Vehicle_GetNeonColor(NativePointer, &rgba);
                    return rgba;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetNeonColor(NativePointer, value);
                }
            }
        }

        public byte Livery
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetLivery(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetLivery(NativePointer, value);
                }
            }
        }

        public byte RoofLivery
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetRoofLivery(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetRoofLivery(NativePointer, value);
                }
            }
        }

        public string AppearanceData
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var size = 0;
                    return Server.PtrToStringUtf8AndFree(
                        Server.Library.Vehicle_GetAppearanceDataBase64(NativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_LoadAppearanceDataFromBase64(NativePointer, value);
                }
            }
        }

        public bool EngineOn
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsEngineOn(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetEngineOn(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool IsHandbrakeActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsHandbrakeActive(NativePointer) == 1;
                }
            }
        }

        public byte HeadlightColor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetHeadlightColor(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetHeadlightColor(NativePointer, value);
                }
            }
        }

        public uint RadioStation
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetRadioStationIndex(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetRadioStationIndex(NativePointer, value);
                }
            }
        }

        public bool SirenActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsSirenActive(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetSirenActive(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public VehicleLockState LockState
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return (VehicleLockState) Server.Library.Vehicle_GetLockState(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetLockState(NativePointer, (byte) value);
                }
            }
        }

        public byte GetDoorState(byte doorId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_GetDoorState(NativePointer, doorId);
            }
        }

        public void SetDoorState(byte doorId, byte state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetDoorState(NativePointer, doorId, state);
            }
        }

        public bool IsWindowOpened(byte windowId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_IsWindowOpened(NativePointer, windowId) == 1;
            }
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetWindowOpened(NativePointer, windowId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsDaylightOn
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsDaylightOn(NativePointer) == 1;
                }
            }
        }

        public bool IsNightlightOn
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsNightlightOn(NativePointer) == 1;
                }
            }
        }

        public byte RoofState
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetRoofState(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetRoofState(NativePointer, value);
                }
            }
        }

        public bool IsFlamethrowerActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsFlamethrowerActive(NativePointer) == 1;
                }
            }
        }

        public float LightsMultiplier
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetLightsMultiplier(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetLightsMultiplier(NativePointer, value);
                }
            }
        }

        public string State
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var size = 0;
                    return Server.PtrToStringUtf8AndFree(
                        Server.Library.Vehicle_GetGameStateBase64(NativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_LoadGameStateFromBase64(NativePointer, value);
                }
            }
        }

        public int EngineHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetEngineHealth(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetEngineHealth(NativePointer, value);
                }
            }
        }

        public int PetrolTankHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetPetrolTankHealth(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetPetrolTankHealth(NativePointer, value);
                }
            }
        }

        public byte WheelsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetWheelsCount(NativePointer);
                }
            }
        }

        public bool IsWheelBurst(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_IsWheelBurst(NativePointer, wheelId) == 1;
            }
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetWheelBurst(NativePointer, wheelId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_DoesWheelHasTire(NativePointer, wheelId) == 1;
            }
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetWheelHasTire(NativePointer, wheelId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsWheelDetached(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_IsWheelDetached(NativePointer, wheelId) == 1;
            }
        }

        public void SetWheelDetached(byte wheelId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetWheelDetached(NativePointer, wheelId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsWheelOnFire(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_IsWheelOnFire(NativePointer, wheelId) == 1;
            }
        }

        public void SetWheelOnFire(byte wheelId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetWheelOnFire(NativePointer, wheelId, state ? (byte) 1 : (byte) 0);
            }
        }

        public float GetWheelHealth(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_GetWheelHealth(NativePointer, wheelId);
            }
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetWheelHealth(NativePointer, wheelId, health);
            }
        }

        public void SetWheelFixed(byte wheelId)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetWheelFixed(NativePointer, wheelId);
            }
        }

        public byte RepairsCount
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetRepairsCount(NativePointer);
                }
            }
        }

        public uint BodyHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetBodyHealth(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetBodyHealth(NativePointer, value);
                }
            }
        }

        public uint BodyAdditionalHealth
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetBodyAdditionalHealth(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetBodyAdditionalHealth(NativePointer, value);
                }
            }
        }

        public string HealthData
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var size = 0;
                    return Server.PtrToStringUtf8AndFree(
                        Server.Library.Vehicle_GetHealthDataBase64(NativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_LoadHealthDataFromBase64(NativePointer, value);
                }
            }
        }

        public byte GetPartDamageLevel(byte partId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_GetPartDamageLevel(NativePointer, partId);
            }
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetPartDamageLevel(NativePointer, partId, damage);
            }
        }

        public byte GetPartBulletHoles(byte partId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_GetPartBulletHoles(NativePointer, partId);
            }
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetPartBulletHoles(NativePointer, partId, shootsCount);
            }
        }

        public bool IsLightDamaged(byte lightId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_IsLightDamaged(NativePointer, lightId) == 1;
            }
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetLightDamaged(NativePointer, lightId, isDamaged ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsWindowDamaged(byte windowId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_IsWindowDamaged(NativePointer, windowId) == 1;
            }
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetWindowDamaged(NativePointer, windowId, isDamaged ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_IsSpecialLightDamaged(NativePointer, specialLightId) == 1;
            }
        }

        void IVehicle.SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetSpecialLightDamaged(NativePointer, specialLightId, isDamaged ? (byte) 1 : (byte) 0);
            }
        }

        public bool HasArmoredWindows
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_HasArmoredWindows(NativePointer) == 1;
                }
            }
        }

        public float GetArmoredWindowHealth(byte windowId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_GetArmoredWindowHealth(NativePointer, windowId);
            }
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetArmoredWindowHealth(NativePointer, windowId, health);
            }
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_GetArmoredWindowShootCount(NativePointer, windowId);
            }
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetArmoredWindowShootCount(NativePointer, windowId, count);
            }
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_GetBumperDamageLevel(NativePointer, bumperId);
            }
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetBumperDamageLevel(NativePointer, bumperId, damageLevel);
            }
        }

        public string DamageData
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var size = 0;
                    return Server.PtrToStringUtf8AndFree(
                        Server.Library.Vehicle_GetDamageDataBase64(NativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_LoadDamageDataFromBase64(NativePointer, value);
                }
            }
        }

        public bool ManualEngineControl
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsManualEngineControl(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetManualEngineControl(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public string ScriptData
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var size = 0;
                    return Server.PtrToStringUtf8AndFree(
                        Server.Library.Vehicle_GetScriptDataBase64(NativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_LoadScriptDataFromBase64(NativePointer, value);
                }
            }
        }

        public IVehicle Attached
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var entityPointer = Server.Library.Vehicle_GetAttached(NativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.VehiclePool.Get(entityPointer, out var vehicle) ? vehicle : null;
                }
            }
        }

        public IVehicle AttachedTo
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var entityPointer = Server.Library.Vehicle_GetAttachedTo(NativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.VehiclePool.Get(entityPointer, out var vehicle) ? vehicle : null;
                }
            }
        }

        public Vehicle(IServer server, uint model, Position position, Rotation rotation) : this(
            server, server.CreateVehicleEntity(out var id, model, position, rotation), id)
        {
            Alt.Module.VehiclePool.Add(this);
        }

        public Vehicle(IServer server, IntPtr nativePointer, ushort id) : base(server, nativePointer, BaseObjectType.Vehicle, id)
        {
        }

        public byte GetMod(byte category)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_GetMod(NativePointer, category);
            }
        }

        public byte GetModsCount(byte category)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_GetModsCount(NativePointer, category);
            }
        }

        public bool SetMod(byte category, byte id)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_SetMod(NativePointer, category, id) == 1;
            }
        }

        public void SetWheels(byte type, byte variation)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetWheels(NativePointer, type, variation);
            }
        }

        public bool IsExtraOn(byte extraId)
        {
            unsafe
            {
                CheckIfEntityExists();
                return Server.Library.Vehicle_IsExtraOn(NativePointer, extraId) == 1;
            }
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_ToggleExtra(NativePointer, extraId, state ? (byte) 1 : (byte) 0);
            }
        }

        public bool IsNeonActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsNeonActive(NativePointer) == 1;
                }
            }
        }

        public void SetNeonActive(bool left, bool right, bool front, bool back)
        {
            unsafe
            {
                CheckIfEntityExists();
                Server.Library.Vehicle_SetNeonActive(NativePointer, left ? (byte) 1 : (byte) 0, right ? (byte) 1 : (byte) 0, front ? (byte) 1 : (byte) 0, back ? (byte) 1 : (byte) 0);
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
                Server.Library.Vehicle_GetNeonActive(NativePointer, &pLeft, &pRight, &pFront, &pBack);
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
                Server.Library.Vehicle_Repair(NativePointer);
            }
        }

        public override void AttachToEntity(IEntity entity, short otherBone, short ownBone, Position position, Rotation rotation, bool collision, bool noFixedRotation)
        {
            unsafe
            {
                if(entity == null) return;

                if(entity.Type == BaseObjectType.Player) 
                    Server.Library.Vehicle_AttachToEntity_Player(NativePointer, entity.NativePointer, otherBone, ownBone, position, rotation, collision ? (byte) 1 : (byte) 0, noFixedRotation ? (byte) 1 : (byte) 0);
                if(entity.Type == BaseObjectType.Vehicle)
                    Server.Library.Vehicle_AttachToEntity_Vehicle(NativePointer, entity.NativePointer, otherBone, ownBone, position, rotation, collision ? (byte) 1 : (byte) 0, noFixedRotation ? (byte) 1 : (byte) 0);
            }
        }

        public override void Detach()
        {
            unsafe
            {
                Server.Library.Vehicle_Detach(NativePointer);
            }
        }

        public Position Velocity
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Position.Zero;
                    Server.Library.Vehicle_GetVelocity(NativePointer, &position);
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
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsDriftMode(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetDriftMode(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }
        
        public bool SetSearchLight(bool state, IEntity spottedEntity)
        {
            unsafe
            {
                if (spottedEntity == null) return false;
                CheckIfEntityExists();
                
                if (spottedEntity.Type == BaseObjectType.Player)
                    return Server.Library.Vehicle_SetSearchLight_Player(NativePointer, state ? (byte) 1 : (byte) 0, spottedEntity.NativePointer) == 1;
                if (spottedEntity.Type == BaseObjectType.Vehicle)
                    return Server.Library.Vehicle_SetSearchLight_Vehicle(NativePointer, state ? (byte) 1 : (byte) 0, spottedEntity.NativePointer) == 1;

                return false;
            }
        }
        
        public bool IsMissionTrain
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsTrainMissionTrain(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainMissionTrain(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public sbyte TrainTrackId
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetTrainTrackId(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainTrackId(NativePointer, value);
                }
            }
        }

        public IVehicle TrainEngine
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var entityPointer = Server.Library.Vehicle_GetTrainEngineId(NativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.VehiclePool.Get(entityPointer, out var vehicle) ? vehicle : null;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainEngineId(NativePointer, value?.NativePointer ?? IntPtr.Zero);
                }
            }
        }

        public sbyte TrainConfigIndex
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetTrainConfigIndex(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainConfigIndex(NativePointer, value);
                }
            }
        }

        public float TrainDistanceFromEngine
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetTrainDistanceFromEngine(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainDistanceFromEngine(NativePointer, value);
                }
            }
        }

        public bool IsTrainEngine
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsTrainEngine(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainIsEngine(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool IsTrainCaboose
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_IsTrainCaboose(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainIsCaboose(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool TrainDirection
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetTrainDirection(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainDirection(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool TrainPassengerCarriages
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_HasTrainPassengerCarriages(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainHasPassengerCarriages(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool TrainRenderDerailed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetTrainRenderDerailed(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainRenderDerailed(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public bool TrainForceDoorsOpen
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetTrainForceDoorsOpen(NativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainForceDoorsOpen(NativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public float TrainCruiseSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetTrainCruiseSpeed(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainCruiseSpeed(NativePointer, value);
                }
            }
        }

        public sbyte TrainCarriageConfigIndex
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Server.Library.Vehicle_GetTrainCarriageConfigIndex(NativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainCarriageConfigIndex(NativePointer, value);
                }
            }
        }

        public IVehicle TrainLinkedToBackward
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var entityPointer = Server.Library.Vehicle_GetTrainLinkedToBackwardId(NativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.VehiclePool.Get(entityPointer, out var vehicle) ? vehicle : null;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainLinkedToBackwardId(NativePointer, value?.NativePointer ?? IntPtr.Zero);
                }
            }
        }

        public IVehicle TrainLinkedToForward
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var entityPointer = Server.Library.Vehicle_GetTrainLinkedToForwardId(NativePointer);
                    if (entityPointer == IntPtr.Zero) return null;
                    return Alt.Module.VehiclePool.Get(entityPointer, out var vehicle) ? vehicle : null;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Server.Library.Vehicle_SetTrainLinkedToForwardId(NativePointer, value?.NativePointer ?? IntPtr.Zero);
                }
            }
        }
        
        public void Remove()
        {
            Alt.RemoveVehicle(this);
        }

        protected override void InternalAddRef()
        {
            unsafe
            {
                Server.Library.Vehicle_AddRef(NativePointer);
            }
        }

        protected override void InternalRemoveRef()
        {
            unsafe
            {
                Server.Library.Vehicle_RemoveRef(NativePointer);
            }
        }
    }
}