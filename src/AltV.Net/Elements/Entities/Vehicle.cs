using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Vehicle : Entity, IVehicle
    {
        public new static ushort GetId(IntPtr vehiclePointer) => AltVNative.Vehicle.Vehicle_GetId(vehiclePointer);
        
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
            get => !Exists ? Rgba.Zero : AltVNative.Vehicle.Vehicle_GetPrimaryColorRGB(NativePointer);
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
            get => !Exists ? Rgba.Zero : AltVNative.Vehicle.Vehicle_GetSecondaryColorRGB(NativePointer);
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
            get => !Exists ? Rgba.Zero : AltVNative.Vehicle.Vehicle_GetTireSmokeColor(NativePointer);
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
            get => !Exists ? Rgba.Zero : AltVNative.Vehicle.Vehicle_GetNeonColor(NativePointer);
            set
            {
                if (!Exists) return;
                AltVNative.Vehicle.Vehicle_SetNeonColor(NativePointer, value);
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

        public byte GetModKitsCount()
        {
            return !Exists ? (byte) 0 : AltVNative.Vehicle.Vehicle_GetModKitsCount(NativePointer);
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

        void IVehicle.GetNeonActive(ref bool left, ref bool right, ref bool top, ref bool back)
        {
            if (Exists)
            {
                AltVNative.Vehicle.Vehicle_GetNeonActive(NativePointer, ref left, ref right, ref top, ref back);
            }
        }
    }
}