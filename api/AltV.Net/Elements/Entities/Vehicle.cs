using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Enums;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Vehicle : Entity, IVehicle
    {
        public static ushort GetId(IntPtr vehiclePointer) => AltNative.Vehicle.Vehicle_GetID(vehiclePointer);

        public override uint Model
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetModel(NativePointer);
            }
            set => throw new NotImplementedException("vehicle doesn't support set model");
        }

        public override Position Position
        {
            get
            {
                CheckIfEntityExists();
                var position = Position.Zero;
                AltNative.Vehicle.Vehicle_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetPosition(NativePointer, value);
            }
        }

        public override Rotation Rotation
        {
            get
            {
                CheckIfEntityExists();
                var rotation = Rotation.Zero;
                AltNative.Vehicle.Vehicle_GetRotation(NativePointer, ref rotation);
                return rotation;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetRotation(NativePointer, value);
            }
        }

        public override short Dimension
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetDimension(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetDimension(NativePointer, value);
            }
        }

        public override void GetMetaData(string key, ref MValue value) =>
            AltNative.Vehicle.Vehicle_GetMetaData(NativePointer, key, ref value);

        public override void SetMetaData(string key, ref MValue value) =>
            AltNative.Vehicle.Vehicle_SetMetaData(NativePointer, key, ref value);

        public override void SetSyncedMetaData(string key, ref MValue value) =>
            AltNative.Vehicle.Vehicle_SetSyncedMetaData(NativePointer, key, ref value);

        public override void GetSyncedMetaData(string key, ref MValue value) =>
            AltNative.Vehicle.Vehicle_GetSyncedMetaData(NativePointer, key, ref value);

        public IPlayer Driver
        {
            get
            {
                CheckIfEntityExists();
                var entityPointer = AltNative.Vehicle.Vehicle_GetDriver(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.PlayerPool.GetOrCreate(entityPointer, out var player) ? player : null;
            }
        }

        public byte ModKit
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetModKit(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetModKit(NativePointer, value);
            }
        }

        public byte ModKitsCount
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetModKitsCount(NativePointer);
            }
        }

        public bool IsPrimaryColorRgb
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsPrimaryColorRGB(NativePointer);
            }
        }

        public byte PrimaryColor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetPrimaryColor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetPrimaryColor(NativePointer, value);
            }
        }

        public Rgba PrimaryColorRgb
        {
            get
            {
                CheckIfEntityExists();
                var rgba = Rgba.Zero;
                AltNative.Vehicle.Vehicle_GetPrimaryColorRGB(NativePointer, ref rgba);
                return rgba;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetPrimaryColorRGB(NativePointer, value);
            }
        }

        public bool IsSecondaryColorRgb
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsSecondaryColorRGB(NativePointer);
            }
        }

        public byte SecondaryColor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetSecondaryColor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetSecondaryColor(NativePointer, value);
            }
        }

        public Rgba SecondaryColorRgb
        {
            get
            {
                CheckIfEntityExists();
                var rgba = Rgba.Zero;
                AltNative.Vehicle.Vehicle_GetSecondaryColorRGB(NativePointer, ref rgba);
                return rgba;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetSecondaryColorRGB(NativePointer, value);
            }
        }

        public byte PearlColor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetPearlColor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetPearlColor(NativePointer, value);
            }
        }

        public byte WheelColor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetWheelColor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetWheelColor(NativePointer, value);
            }
        }

        public byte InteriorColor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetInteriorColor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetInteriorColor(NativePointer, value);
            }
        }

        public byte DashboardColor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetDashboardColor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetDashboardColor(NativePointer, value);
            }
        }

        public bool IsTireSmokeColorCustom
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsTireSmokeColorCustom(NativePointer);
            }
        }

        public Rgba TireSmokeColor
        {
            get
            {
                CheckIfEntityExists();
                var rgba = Rgba.Zero;
                AltNative.Vehicle.Vehicle_GetTireSmokeColor(NativePointer, ref rgba);
                return rgba;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetTireSmokeColor(NativePointer, value);
            }
        }

        public byte WheelType
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetWheelType(NativePointer);
            }
        }

        public byte WheelVariation
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetWheelVariation(NativePointer);
            }
        }

        public bool CustomTires
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetCustomTires(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetCustomTires(NativePointer, value);
            }
        }

        public byte SpecialDarkness
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetSpecialDarkness(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetSpecialDarkness(NativePointer, value);
            }
        }

        public uint NumberplateIndex
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetNumberplateIndex(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetNumberplateIndex(NativePointer, value);
            }
        }

        public string NumberplateText
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Vehicle.Vehicle_GetNumberplateText(NativePointer, ref ptr);
                return Marshal.PtrToStringUTF8(ptr);
            }
            set
            {
                CheckIfEntityExists();
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(value);
                AltNative.Vehicle.Vehicle_SetNumberplateText(NativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public byte WindowTint
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetWindowTint(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetWindowTint(NativePointer, value);
            }
        }

        public byte DirtLevel
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetDirtLevel(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetDirtLevel(NativePointer, value);
            }
        }

        public Rgba NeonColor
        {
            get
            {
                CheckIfEntityExists();
                var rgba = Rgba.Zero;
                AltNative.Vehicle.Vehicle_GetNeonColor(NativePointer, ref rgba);
                return rgba;
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetNeonColor(NativePointer, value);
            }
        }

        public string AppearanceData
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Vehicle.Vehicle_GetAppearanceDataBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_LoadAppearanceDataFromBase64(NativePointer, value);
            }
        }

        public bool EngineOn
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsEngineOn(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetEngineOn(NativePointer, value);
            }
        }

        public bool IsHandbrakeActive
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsHandbrakeActive(NativePointer);
            }
        }

        public byte HeadlightColor
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetHeadlightColor(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetHeadlightColor(NativePointer, value);
            }
        }

        public uint RadioStation
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetRadioStationIndex(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetRadioStationIndex(NativePointer, value);
            }
        }

        public bool SirenActive
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsSirenActive(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetSirenActive(NativePointer, value);
            }
        }

        public VehicleLockState LockState
        {
            get
            {
                CheckIfEntityExists();
                return (VehicleLockState) AltNative.Vehicle.Vehicle_GetLockState(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetLockState(NativePointer, (byte) value);
            }
        }

        public byte GetDoorState(byte doorId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_GetDoorState(NativePointer, doorId);
        }

        public void SetDoorState(byte doorId, byte state)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetDoorState(NativePointer, doorId, state);
        }

        public bool IsWindowOpened(byte windowId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_IsWindowOpened(NativePointer, windowId);
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetWindowOpened(NativePointer, windowId, state);
        }

        public bool IsDaylightOn
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsDaylightOn(NativePointer);
            }
        }

        public bool IsNightlightOn
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsNightlightOn(NativePointer);
            }
        }

        public bool RoofOpened
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsRoofOpened(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetRoofOpened(NativePointer, value);
            }
        }

        public bool IsFlamethrowerActive
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsFlamethrowerActive(NativePointer);
            }
        }

        public string State
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Vehicle.Vehicle_GetGameStateBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_LoadGameStateFromBase64(NativePointer, value);
            }
        }

        public int EngineHealth
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetEngineHealth(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetEngineHealth(NativePointer, value);
            }
        }

        public int PetrolTankHealth
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetPetrolTankHealth(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetPetrolTankHealth(NativePointer, value);
            }
        }

        public byte WheelsCount
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetWheelsCount(NativePointer);
            }
        }

        public bool IsWheelBurst(byte wheelId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_IsWheelBurst(NativePointer, wheelId);
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetWheelBurst(NativePointer, wheelId, state);
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_DoesWheelHasTire(NativePointer, wheelId);
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetWheelHasTire(NativePointer, wheelId, state);
        }

        public float GetWheelHealth(byte wheelId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_GetWheelHealth(NativePointer, wheelId);
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetWheelHealth(NativePointer, wheelId, health);
        }

        public byte RepairsCount
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetRepairsCount(NativePointer);
            }
        }

        public uint BodyHealth
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetBodyHealth(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetBodyHealth(NativePointer, value);
            }
        }

        public uint BodyAdditionalHealth
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_GetBodyAdditionalHealth(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetBodyAdditionalHealth(NativePointer, value);
            }
        }

        public string HealthData
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Vehicle.Vehicle_GetHealthDataBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_LoadHealthDataFromBase64(NativePointer, value);
            }
        }

        public byte GetPartDamageLevel(byte partId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_GetPartDamageLevel(NativePointer, partId);
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetPartDamageLevel(NativePointer, partId, damage);
        }

        public byte GetPartBulletHoles(byte partId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_GetPartBulletHoles(NativePointer, partId);
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetPartBulletHoles(NativePointer, partId, shootsCount);
        }

        public bool IsLightDamaged(byte lightId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_IsLightDamaged(NativePointer, lightId);
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetLightDamaged(NativePointer, lightId, isDamaged);
        }

        public bool IsWindowDamaged(byte windowId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_IsWindowDamaged(NativePointer, windowId);
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetWindowDamaged(NativePointer, windowId, isDamaged);
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_IsSpecialLightDamaged(NativePointer, specialLightId);
        }

        void IVehicle.SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetSpecialLightDamaged(NativePointer, specialLightId, isDamaged);
        }

        public bool HasArmoredWindows
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_HasArmoredWindows(NativePointer);
            }
        }

        public float GetArmoredWindowHealth(byte windowId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_GetArmoredWindowHealth(NativePointer, windowId);
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetArmoredWindowHealth(NativePointer, windowId, health);
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_GetArmoredWindowShootCount(NativePointer, windowId);
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetArmoredWindowShootCount(NativePointer, windowId, count);
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_GetBumperDamageLevel(NativePointer, bumperId);
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetBumperDamageLevel(NativePointer, bumperId, damageLevel);
        }

        public string DamageData
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Vehicle.Vehicle_GetDamageDataBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_LoadDamageDataFromBase64(NativePointer, value);
            }
        }

        public bool ManualEngineControl
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsManualEngineControl(NativePointer);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_SetManualEngineControl(NativePointer, value);
            }
        }

        public string ScriptData
        {
            get
            {
                CheckIfEntityExists();
                var ptr = IntPtr.Zero;
                AltNative.Vehicle.Vehicle_GetScriptDataBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckIfEntityExists();
                AltNative.Vehicle.Vehicle_LoadScriptDataFromBase64(NativePointer, value);
            }
        }

        public Vehicle(uint model, Position position, Rotation rotation) : this(
            Alt.Module.Server.CreateVehicleEntity(out var id, model, position, rotation), id)
        {
            Alt.Module.VehiclePool.Add(this);
        }

        public Vehicle(IntPtr nativePointer, ushort id) : base(nativePointer, BaseObjectType.Vehicle, id)
        {
        }

        public byte GetMod(byte category)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_GetMod(NativePointer, category);
        }

        public byte GetModsCount(byte category)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_GetModsCount(NativePointer, category);
        }

        public bool SetMod(byte category, byte id)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_SetMod(NativePointer, category, id);
        }

        public void SetWheels(byte type, byte variation)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetWheels(NativePointer, type, variation);
        }

        public bool IsExtraOn(byte extraId)
        {
            CheckIfEntityExists();
            return AltNative.Vehicle.Vehicle_IsExtraOn(NativePointer, extraId);
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_ToggleExtra(NativePointer, extraId, state);
        }

        public bool IsNeonActive
        {
            get
            {
                CheckIfEntityExists();
                return AltNative.Vehicle.Vehicle_IsNeonActive(NativePointer);
            }
        }

        public void SetNeonActive(bool left, bool right, bool front, bool back)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_SetNeonActive(NativePointer, left, right, front, back);
        }

        public void GetNeonActive(ref bool left, ref bool right, ref bool front, ref bool back)
        {
            CheckIfEntityExists();
            AltNative.Vehicle.Vehicle_GetNeonActive(NativePointer, ref left, ref right, ref front, ref back);
        }

        public void Remove()
        {
            Alt.RemoveVehicle(this);
        }
    }
}