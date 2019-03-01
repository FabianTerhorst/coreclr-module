using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Vehicle : Entity, IVehicle
    {
        public new static ushort GetId(IntPtr vehiclePointer) => AltVNative.Vehicle.Vehicle_GetID(vehiclePointer);

        public override Position Position
        {
            get
            {
                var position = Position.Zero;
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_GetPosition(NativePointer, ref position);
                }

                return position;
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetPosition(NativePointer, value);
                }
            }
        }

        public override Rotation Rotation
        {
            get
            {
                var rotation = Rotation.Zero;
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_GetRotation(NativePointer, ref rotation);
                }

                return rotation;
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetRotation(NativePointer, value);
                }
            }
        }

        public override ushort Dimension
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetDimension(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetDimension(NativePointer, value);
                }
            }
        }

        public override void SetMetaData(string key, object value)
        {
            if (Exists)
            {
                var mValue = MValue.CreateFromObject(value);
                AltVNative.Vehicle.Vehicle_SetMetaData(NativePointer, key, ref mValue);
            }
        }

        public override bool GetMetaData<T>(string key, out T result)
        {
            if (!Exists)
            {
                result = default;
                return false;
            }

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
            if (Exists)
            {
                var mValue = MValue.CreateFromObject(value);
                AltVNative.Vehicle.Vehicle_SetSyncedMetaData(NativePointer, key, ref mValue);
            }
        }

        public override bool GetSyncedMetaData<T>(string key, out T result)
        {
            if (!Exists)
            {
                result = default;
                return false;
            }

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
                if (!Exists) return null;
                var entityPointer = AltVNative.Vehicle.Vehicle_GetDriver(NativePointer);
                if (entityPointer == IntPtr.Zero) return null;
                return Alt.Module.PlayerPool.GetOrCreate(entityPointer, out var player) ? player : null;
            }
        }

        public byte ModKit
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetModKit(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetModKit(NativePointer, value);
                }
            }
        }

        public byte ModKitsCount => !Exists ? default : AltVNative.Vehicle.Vehicle_GetModKitsCount(NativePointer);

        public bool IsPrimaryColorRgb => Exists && AltVNative.Vehicle.Vehicle_IsPrimaryColorRGB(NativePointer);

        public byte PrimaryColor
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetPrimaryColor(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetPrimaryColor(NativePointer, value);
            }
        }

        public Rgba PrimaryColorRgb
        {
            get
            {
                var rgba = Rgba.Zero;
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_GetPrimaryColorRGB(NativePointer, ref rgba);
                }

                return rgba;
            }
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetPrimaryColorRGB(NativePointer, value);
            }
        }

        public bool IsSecondaryColorRgb => Exists && AltVNative.Vehicle.Vehicle_IsSecondaryColorRGB(NativePointer);

        public byte SecondaryColor
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetSecondaryColor(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetSecondaryColor(NativePointer, value);
            }
        }

        public Rgba SecondaryColorRgb
        {
            get
            {
                var rgba = Rgba.Zero;
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_GetSecondaryColorRGB(NativePointer, ref rgba);
                }

                return rgba;
            }
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetSecondaryColorRGB(NativePointer, value);
            }
        }

        public byte PearlColor
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetPearlColor(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetPearlColor(NativePointer, value);
            }
        }

        public byte WheelColor
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetWheelColor(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetWheelColor(NativePointer, value);
            }
        }

        public byte InteriorColor
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetInteriorColor(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetInteriorColor(NativePointer, value);
            }
        }

        public byte DashboardColor
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetDashboardColor(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetDashboardColor(NativePointer, value);
            }
        }

        public Rgba TireSmokeColor
        {
            get
            {
                var rgba = Rgba.Zero;
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_GetTireSmokeColor(NativePointer, ref rgba);
                }

                return rgba;
            }
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetTireSmokeColor(NativePointer, value);
            }
        }

        public byte WheelType => !Exists ? default : AltVNative.Vehicle.Vehicle_GetWheelType(NativePointer);

        public byte WheelVariation => !Exists ? default : AltVNative.Vehicle.Vehicle_GetWheelVariation(NativePointer);

        public bool CustomTires
        {
            get => Exists && AltVNative.Vehicle.Vehicle_GetCustomTires(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetCustomTires(NativePointer, value);
            }
        }

        public byte SpecialDarkness
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetSpecialDarkness(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetSpecialDarkness(NativePointer, value);
            }
        }

        public uint NumberPlateIndex
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetNumberPlateIndex(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetNumberPlateIndex(NativePointer, value);
                }
            }
        }

        public string NumberPlateText
        {
            get
            {
                if (!Exists) return string.Empty;
                var ptr = IntPtr.Zero;
                AltVNative.Vehicle.Vehicle_GetNumberPlateText(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetNumberPlateText(NativePointer, value);
                }
            }
        }

        public byte WindowTint
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetWindowTint(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetWindowTint(NativePointer, value);
            }
        }

        public byte DirtLevel
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetDirtLevel(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetDirtLevel(NativePointer, value);
            }
        }

        public Rgba NeonColor
        {
            get
            {
                var rgba = Rgba.Zero;
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_GetNeonColor(NativePointer, ref rgba);
                }

                return rgba;
            }
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetNeonColor(NativePointer, value);
            }
        }

        //TODO: wip vehicle apis

        public bool EngineOn
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_IsEngineOn(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetEngineOn(NativePointer, value);
                }
            }
        }

        public bool IsHandbrakeActive =>
            !Exists ? default : AltVNative.Vehicle.Vehicle_IsHandbrakeActive(NativePointer);

        public byte HeadlightColor
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetHeadlightColor(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetHeadlightColor(NativePointer, value);
            }
        }

        public bool SirenActive
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_IsSirenActive(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetSirenActive(NativePointer, value);
                }
            }
        }

        public byte LockState
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetLockState(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetLockState(NativePointer, value);
            }
        }

        public byte GetDoorState(byte doorId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_GetDoorState(NativePointer, doorId);
        }

        public void SetDoorState(byte doorId, byte state)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetDoorState(NativePointer, doorId, state);
            }
        }

        public bool IsWindowOpened(byte windowId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_IsWindowOpened(NativePointer, windowId);
        }

        public void SetWindowOpened(byte windowId, bool state)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetWindowOpened(NativePointer, windowId, state);
            }
        }

        public bool IsDaylightOn => !Exists ? default : AltVNative.Vehicle.Vehicle_IsDaylightOn(NativePointer);

        public bool IsNightlightOn => !Exists ? default : AltVNative.Vehicle.Vehicle_IsNightlightOn(NativePointer);

        public bool RoofOpened
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_IsRoofOpened(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetRoofOpened(NativePointer, value);
                }
            }
        }

        public bool IsFlamethrowerActive =>
            !Exists ? default : AltVNative.Vehicle.Vehicle_IsFlamethrowerActive(NativePointer);

        public string State
        {
            get
            {
                if (!Exists) return string.Empty;
                var ptr = IntPtr.Zero;
                AltVNative.Vehicle.Vehicle_GetGameStateBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_LoadGameStateFromBase64(NativePointer, value);
                }
            }
        }

        public int EngineHealth
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetEngineHealth(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetEngineHealth(NativePointer, value);
                }
            }
        }

        public int PetrolTankHealth
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetPetrolTankHealth(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetPetrolTankHealth(NativePointer, value);
                }
            }
        }

        public byte WheelsCount => !Exists ? default : AltVNative.Vehicle.Vehicle_GetWheelsCount(NativePointer);

        public bool IsWheelBurst(byte wheelId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_IsWheelBurst(NativePointer, wheelId);
        }

        public void SetWheelBurst(byte wheelId, bool state)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetWheelBurst(NativePointer, wheelId, state);
            }
        }

        public bool DoesWheelHasTire(byte wheelId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_DoesWheelHasTire(NativePointer, wheelId);
        }

        public void SetWheelHasTire(byte wheelId, bool state)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetWheelHasTire(NativePointer, wheelId, state);
            }
        }

        public float GetWheelHealth(byte wheelId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_GetWheelHealth(NativePointer, wheelId);
        }

        public void SetWheelHealth(byte wheelId, float health)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetWheelHealth(NativePointer, wheelId, health);
            }
        }

        public byte RepairsCount => !Exists ? default : AltVNative.Vehicle.Vehicle_GetRepairsCount(NativePointer);

        public uint BodyHealth
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetBodyHealth(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetBodyHealth(NativePointer, value);
                }
            }
        }

        public uint BodyAdditionalHealth
        {
            get => !Exists ? default : AltVNative.Vehicle.Vehicle_GetBodyAdditionalHealth(NativePointer);
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_SetBodyAdditionalHealth(NativePointer, value);
                }
            }
        }

        public string HealthData
        {
            get
            {
                if (!Exists) return string.Empty;
                var ptr = IntPtr.Zero;
                AltVNative.Vehicle.Vehicle_GetHealthDataBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_LoadHealthDataFromBase64(NativePointer, value);
                }
            }
        }

        public byte GetPartDamageLevel(byte partId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_GetPartDamageLevel(NativePointer, partId);
        }

        public void SetPartDamageLevel(byte partId, byte damage)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetPartDamageLevel(NativePointer, partId, damage);
            }
        }

        public byte GetPartBulletHoles(byte partId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_GetPartBulletHoles(NativePointer, partId);
        }

        public void SetPartBulletHoles(byte partId, byte shootsCount)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetPartBulletHoles(NativePointer, partId, shootsCount);
            }
        }

        public bool IsLightDamaged(byte lightId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_IsLightDamaged(NativePointer, lightId);
        }

        public void SetLightDamaged(byte lightId, bool isDamaged)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetLightDamaged(NativePointer, lightId, isDamaged);
            }
        }

        public bool IsWindowDamaged(byte windowId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_IsWindowOpened(NativePointer, windowId);
        }

        public void SetWindowDamaged(byte windowId, bool isDamaged)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetWindowDamaged(NativePointer, windowId, isDamaged);
            }
        }

        public bool IsSpecialLightDamaged(byte specialLightId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_IsSpecialLightDamaged(NativePointer, specialLightId);
        }

        void IVehicle.SetSpecialLightDamaged(byte specialLightId, bool isDamaged)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetSpecialLightDamaged(NativePointer, specialLightId, isDamaged);
            }
        }

        public bool HasArmoredWindows =>
            !Exists ? default : AltVNative.Vehicle.Vehicle_HasArmoredWindows(NativePointer);

        public float GetArmoredWindowHealth(byte windowId)
        {
            return !Exists
                ? default
                : AltVNative.Vehicle.Vehicle_GetArmoredWindowHealth(NativePointer, windowId);
        }

        public void SetArmoredWindowHealth(byte windowId, float health)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetArmoredWindowHealth(NativePointer, windowId, health);
            }
        }

        public byte GetArmoredWindowShootCount(byte windowId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_GetArmoredWindowShootCount(NativePointer, windowId);
        }

        public void SetArmoredWindowShootCount(byte windowId, byte count)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetArmoredWindowShootCount(NativePointer, windowId, count);
            }
        }

        public byte GetBumperDamageLevel(byte bumperId)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_GetBumperDamageLevel(NativePointer, bumperId);
        }

        public void SetBumperDamageLevel(byte bumperId, byte damageLevel)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetBumperDamageLevel(NativePointer, bumperId, damageLevel);
            }
        }

        public string DamageData
        {
            get
            {
                if (!Exists) return string.Empty;
                var ptr = IntPtr.Zero;
                AltVNative.Vehicle.Vehicle_GetDamageDataBase64(NativePointer, ref ptr);
                return Marshal.PtrToStringAnsi(ptr);
            }
            set
            {
                if (Exists)
                {
                    AltVNative.Vehicle.Vehicle_LoadDamageDataFromBase64(NativePointer, value);
                }
            }
        }

        public Vehicle(IntPtr nativePointer, ushort id) : base(nativePointer, EntityType.Vehicle, id)
        {
        }

        public byte GetMod(byte category)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_GetMod(NativePointer, category);
        }

        public byte GetModsCount(byte category)
        {
            return !Exists ? default : AltVNative.Vehicle.Vehicle_GetModsCount(NativePointer, category);
        }

        public bool SetMod(byte category, byte id)
        {
            return Exists && AltVNative.Vehicle.Vehicle_SetMod(NativePointer, category, id);
        }

        public void SetWheels(byte type, byte variation)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetWheels(NativePointer, type, variation);
            }
        }

        public bool IsExtraOn(byte extraId)
        {
            return Exists && AltVNative.Vehicle.Vehicle_IsExtraOn(NativePointer, extraId);
        }

        public void ToggleExtra(byte extraId, bool state)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_ToggleExtra(NativePointer, extraId, state);
            }
        }

        public void SetNeonActive(bool left, bool right, bool top, bool back)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_SetNeonActive(NativePointer, left, right, top, back);
            }
        }

        public void GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_GetNeonActive(NativePointer, ref left, ref right, ref top, ref back);
            }
        }
    }
}