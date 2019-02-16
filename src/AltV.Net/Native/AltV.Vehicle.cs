using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Vehicle
        {
            // Entity
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Vehicle_GetID(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetPosition(IntPtr entityPointer, ref Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetPosition(IntPtr entityPointer, Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetRotation(IntPtr entityPointer, ref Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetRotation(IntPtr entityPointer, Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Vehicle_GetDimension(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetDimension(IntPtr entityPointer, ushort dimension);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Vehicle_GetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Vehicle_SetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);
            
            // Vehicle

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern IntPtr Vehicle_GetDriver(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetMod(IntPtr vehiclePointer, byte category);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetModsCount(IntPtr vehiclePointer, byte category);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_SetMod(IntPtr vehiclePointer, byte category, byte id);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetModKitsCount(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetModKit(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_SetModKit(IntPtr vehiclePointer, byte id);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsPrimaryColorRGB(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetPrimaryColor(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetPrimaryColorRGB(IntPtr vehiclePointer, ref Rgba primaryColor);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetPrimaryColor(IntPtr vehiclePointer, byte color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetPrimaryColorRGB(IntPtr vehiclePointer, Rgba color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsSecondaryColorRGB(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetSecondaryColor(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetSecondaryColorRGB(IntPtr vehiclePointer, ref Rgba secondaryColor);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetSecondaryColor(IntPtr vehiclePointer, byte color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetSecondaryColorRGB(IntPtr vehiclePointer, Rgba color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetPearlColor(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetPearlColor(IntPtr vehiclePointer, byte color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetWheelColor(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetWheelColor(IntPtr vehiclePointer, byte color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetInteriorColor(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetInteriorColor(IntPtr vehiclePointer, byte color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetDashboardColor(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetDashboardColor(IntPtr vehiclePointer, byte color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetTireSmokeColor(IntPtr vehiclePointer, ref Rgba tireSmokeColor);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetTireSmokeColor(IntPtr vehiclePointer, Rgba color);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetWheelType(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetWheelVariation(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetWheels(IntPtr vehiclePointer, byte type, byte variation);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_GetCustomTires(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetCustomTires(IntPtr vehiclePointer, bool state);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetSpecialDarkness(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetSpecialDarkness(IntPtr vehiclePointer, byte value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern uint Vehicle_GetNumberPlateIndex(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetNumberPlateIndex(IntPtr vehiclePointer, uint index);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetNumberPlateText(IntPtr vehiclePointer, ref IntPtr text);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetNumberPlateText(IntPtr vehiclePointer, string text);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetWindowTint(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetWindowTint(IntPtr vehiclePointer, byte tint);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern byte Vehicle_GetDirtLevel(IntPtr vehiclePointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetDirtLevel(IntPtr vehiclePointer, byte level);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern bool Vehicle_IsExtraOn(IntPtr vehiclePointer, byte extraID);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_ToggleExtra(IntPtr vehiclePointer, byte extraID, bool state);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetNeonActive(IntPtr vehiclePointer, ref bool left, ref bool right,
                ref bool top, ref bool back);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetNeonActive(IntPtr vehiclePointer, bool left, bool right, bool top,
                bool back);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_GetNeonColor(IntPtr vehiclePointer, ref Rgba neonColor);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Vehicle_SetNeonColor(IntPtr vehiclePointer, Rgba color);
        }
    }
}