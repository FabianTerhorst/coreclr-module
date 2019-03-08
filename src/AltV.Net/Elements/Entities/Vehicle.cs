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
        public static ushort GetId(IntPtr vehiclePointer) => AltVNative.Vehicle.Vehicle_GetID(vehiclePointer);

        public override uint Model
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetModel(NativePointer);
            }
        }

        public override Position Position
        {
            get
            {
                CheckExistence();
                var position = Position.Zero;
                AltVNative.Vehicle.Vehicle_GetPosition(NativePointer, ref position);
                return position;
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetPosition(NativePointer, value);
            }
        }

        public override Rotation Rotation
        {
            get
            {
                CheckExistence();
                var rotation = Rotation.Zero;
                AltVNative.Vehicle.Vehicle_GetRotation(NativePointer, ref rotation);
                return rotation;
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetRotation(NativePointer, value);
            }
        }

        public override short Dimension
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetDimension(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetDimension(NativePointer, value);
            }
        }

        public override void SetMetaData(string key, object value)
        {
            CheckExistence();
            var mValue = MValue.CreateFromObject(value);
            AltVNative.Vehicle.Vehicle_SetMetaData(NativePointer, key, ref mValue);
        }

        public override bool GetMetaData<T>(string key, out T result)
        {
            CheckExistence();
            var mValue = MValue.Nil;
            AltVNative.Vehicle.Vehicle_GetMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public override void SetSyncedMetaData(string key, object value)
        {
            CheckExistence();
            var mValue = MValue.CreateFromObject(value);
            AltVNative.Vehicle.Vehicle_SetSyncedMetaData(NativePointer, key, ref mValue);
        }

        public override bool GetSyncedMetaData<T>(string key, out T result)
        {
            CheckExistence();
            var mValue = MValue.Nil;
            AltVNative.Vehicle.Vehicle_GetSyncedMetaData(NativePointer, key, ref mValue);
            if (!(mValue.ToObject() is T cast))
            {
                result = default;
                return false;
            }

            result = cast;
            return true;
        }

        public IPlayer Driver
        {
            get
            {
                CheckExistence();
                var entityPointer = AltVNative.Vehicle.Vehicle_GetDriver(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.PlayerPool.GetOrCreate(entityPointer, out var player) ? player : null;
            }
        }

        public byte ModKit
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetModKit(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetModKit(NativePointer, value);
            }
        }

        public byte ModKitsCount
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetModKitsCount(NativePointer);
            }
        }

        public bool IsPrimaryColorRgb
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsPrimaryColorRGB(NativePointer);
            }
        }

        public byte PrimaryColor
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetPrimaryColor(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetPrimaryColor(NativePointer, value);
            }
        }

        public Rgba PrimaryColorRgb
        {
            get
            {
                CheckExistence();
                var rgba = Rgba.Zero;
                AltVNative.Vehicle.Vehicle_GetPrimaryColorRGB(NativePointer, ref rgba);
                return rgba;
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetPrimaryColorRGB(NativePointer, value);
            }
        }

        public bool IsSecondaryColorRgb
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsSecondaryColorRGB(NativePointer);
            }
        }

        public byte SecondaryColor
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetSecondaryColor(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetSecondaryColor(NativePointer, value);
            }
        }

        public Rgba SecondaryColorRgb
        {
            get
            {
                CheckExistence();
                var rgba = Rgba.Zero;
                AltVNative.Vehicle.Vehicle_GetSecondaryColorRGB(NativePointer, ref rgba);
                return rgba;
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetSecondaryColorRGB(NativePointer, value);
            }
        }

        public byte PearlColor
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetPearlColor(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetPearlColor(NativePointer, value);
            }
        }

        public byte WheelColor
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetWheelColor(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetWheelColor(NativePointer, value);
            }
        }

        public byte InteriorColor
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetInteriorColor(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetInteriorColor(NativePointer, value);
            }
        }

        public byte DashboardColor
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetDashboardColor(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetDashboardColor(NativePointer, value);
            }
        }

        public bool IsTireSmokeColorCustom
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsTireSmokeColorCustom(NativePointer);
            }
        }

        public Rgba TireSmokeColor
        {
            get
            {
                CheckExistence();
                var rgba = Rgba.Zero;
                AltVNative.Vehicle.Vehicle_GetTireSmokeColor(NativePointer, ref rgba);
                return rgba;
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetTireSmokeColor(NativePointer, value);
            }
        }

        public byte WheelType
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetWheelType(NativePointer);
            }
        }

        public byte WheelVariation
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetWheelVariation(NativePointer);
            }
        }

        public bool CustomTires
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetCustomTires(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetCustomTires(NativePointer, value);
            }
        }

        public byte SpecialDarkness
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetSpecialDarkness(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetSpecialDarkness(NativePointer, value);
            }
        }

        public uint NumberPlateIndex
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetNumberPlateIndex(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetNumberPlateIndex(NativePointer, value);
            }
        }

        public string NumberPlateText
        {
            get
            {
                CheckExistence();
                var ptr = IntPtr.Zero;
                AltVNative.Vehicle.Vehicle_GetNumberPlateText(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetNumberPlateText(NativePointer, value);
            }
        }

        public byte WindowTint
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetWindowTint(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetWindowTint(NativePointer, value);
            }
        }

        public byte DirtLevel
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetDirtLevel(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetDirtLevel(NativePointer, value);
            }
        }

        public Rgba NeonColor
        {
            get
            {
                CheckExistence();
                var rgba = Rgba.Zero;
                AltVNative.Vehicle.Vehicle_GetNeonColor(NativePointer, ref rgba);
                return rgba;
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetNeonColor(NativePointer, value);
            }
        }

        public bool EngineOn
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsEngineOn(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetEngineOn(NativePointer, value);
            }
        }

        public bool IsHandbrakeActive
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsHandbrakeActive(NativePointer);
            }
        }

        public byte HeadlightColor
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetHeadlightColor(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetHeadlightColor(NativePointer, value);
            }
        }

        public bool SirenActive
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsSirenActive(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetSirenActive(NativePointer, value);
            }
        }

        public VehicleLockState LockState
        {
            get
            {
                CheckExistence();
                return (VehicleLockState) AltVNative.Vehicle.Vehicle_GetLockState(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetLockState(NativePointer, (byte) value);
            }
        }

        public byte GetDoorState(byte doorId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_GetDoorState(NativePointer, doorId);
        }

        public void SetDoorState(byte doorId, byte state)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetDoorState(NativePointer, doorId, state);
        }

        public bool IsWindowOpened(byte windowId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_IsWindowOpened(NativePointer, windowId);
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetWindowOpened(NativePointer, windowId, state);
        }

        public bool IsDaylightOn
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsDaylightOn(NativePointer);
            }
        }

        public bool IsNightlightOn
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsNightlightOn(NativePointer);
            }
        }

        public bool RoofOpened
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsRoofOpened(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetRoofOpened(NativePointer, value);
            }
        }

        public bool IsFlamethrowerActive
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsFlamethrowerActive(NativePointer);
            }
        }

        public string State
        {
            get
            {
                CheckExistence();
                var ptr = IntPtr.Zero;
                AltVNative.Vehicle.Vehicle_GetGameStateBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_LoadGameStateFromBase64(NativePointer, value);
            }
        }

        public int EngineHealth
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetEngineHealth(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetEngineHealth(NativePointer, value);
            }
        }

        public int PetrolTankHealth
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetPetrolTankHealth(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetPetrolTankHealth(NativePointer, value);
            }
        }

        public byte WheelsCount
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetWheelsCount(NativePointer);
            }
        }

        public bool IsWheelBurst(byte wheelId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_IsWheelBurst(NativePointer, wheelId);
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetWheelBurst(NativePointer, wheelId, state);
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_DoesWheelHasTire(NativePointer, wheelId);
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetWheelHasTire(NativePointer, wheelId, state);
        }

        public float GetWheelHealth(byte wheelId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_GetWheelHealth(NativePointer, wheelId);
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetWheelHealth(NativePointer, wheelId, health);
        }

        public byte RepairsCount
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetRepairsCount(NativePointer);
            }
        }

        public uint BodyHealth
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetBodyHealth(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetBodyHealth(NativePointer, value);
            }
        }

        public uint BodyAdditionalHealth
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_GetBodyAdditionalHealth(NativePointer);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_SetBodyAdditionalHealth(NativePointer, value);
            }
        }

        public string HealthData
        {
            get
            {
                CheckExistence();
                var ptr = IntPtr.Zero;
                AltVNative.Vehicle.Vehicle_GetHealthDataBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_LoadHealthDataFromBase64(NativePointer, value);
            }
        }

        public byte GetPartDamageLevel(byte partId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_GetPartDamageLevel(NativePointer, partId);
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetPartDamageLevel(NativePointer, partId, damage);
        }

        public byte GetPartBulletHoles(byte partId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_GetPartBulletHoles(NativePointer, partId);
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetPartBulletHoles(NativePointer, partId, shootsCount);
        }

        public bool IsLightDamaged(byte lightId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_IsLightDamaged(NativePointer, lightId);
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetLightDamaged(NativePointer, lightId, isDamaged);
        }

        public bool IsWindowDamaged(byte windowId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_IsWindowOpened(NativePointer, windowId);
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetWindowDamaged(NativePointer, windowId, isDamaged);
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_IsSpecialLightDamaged(NativePointer, specialLightId);
        }

        void IVehicle.SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetSpecialLightDamaged(NativePointer, specialLightId, isDamaged);
        }

        public bool HasArmoredWindows
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_HasArmoredWindows(NativePointer);
            }
        }

        public float GetArmoredWindowHealth(byte windowId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_GetArmoredWindowHealth(NativePointer, windowId);
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetArmoredWindowHealth(NativePointer, windowId, health);
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_GetArmoredWindowShootCount(NativePointer, windowId);
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetArmoredWindowShootCount(NativePointer, windowId, count);
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_GetBumperDamageLevel(NativePointer, bumperId);
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetBumperDamageLevel(NativePointer, bumperId, damageLevel);
        }

        public string DamageData
        {
            get
            {
                CheckExistence();
                var ptr = IntPtr.Zero;
                AltVNative.Vehicle.Vehicle_GetDamageDataBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                CheckExistence();
                AltVNative.Vehicle.Vehicle_LoadDamageDataFromBase64(NativePointer, value);
            }
        }

        public Vehicle(IntPtr nativePointer, ushort id) : base(nativePointer, BaseObjectType.Vehicle, id)
        {
        }

        public byte GetMod(byte category)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_GetMod(NativePointer, category);
        }

        public byte GetModsCount(byte category)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_GetModsCount(NativePointer, category);
        }

        public bool SetMod(byte category, byte id)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_SetMod(NativePointer, category, id);
        }

        public void SetWheels(byte type, byte variation)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetWheels(NativePointer, type, variation);
        }

        public bool IsExtraOn(byte extraId)
        {
            CheckExistence();
            return AltVNative.Vehicle.Vehicle_IsExtraOn(NativePointer, extraId);
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_ToggleExtra(NativePointer, extraId, state);
        }

        public bool IsNeonActive
        {
            get
            {
                CheckExistence();
                return AltVNative.Vehicle.Vehicle_IsNeonActive(NativePointer);
            }
        }

        public void SetNeonActive(bool left, bool right, bool front, bool back)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_SetNeonActive(NativePointer, left, right, front, back);
        }

        public void GetNeonActive(ref bool left, ref bool right, ref bool front, ref bool back)
        {
            CheckExistence();
            AltVNative.Vehicle.Vehicle_GetNeonActive(NativePointer, ref left, ref right, ref front, ref back);
        }

        public void Remove()
        {
            Alt.RemoveVehicle(this);
        }
    }
}