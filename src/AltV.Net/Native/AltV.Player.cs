using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Player
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Player_IsConnected(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_Spawn(IntPtr playerPointer, Position pos);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_Despawn(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_GetName(IntPtr playerPointer, ref IntPtr name);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Player_SetName(IntPtr playerPointer, string name);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Player_GetHealth(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_SetHealth(IntPtr playerPointer, ushort health);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_SetDateTime(IntPtr playerPointer, int day, int month, int year, int hour,
                int minute, int second);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_SetWeather(IntPtr playerPointer, uint weather);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Player_IsDead(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Player_IsJumping(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Player_IsInRagdoll(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Player_IsAiming(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Player_IsShooting(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Player_IsReloading(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Player_GetArmor(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_SetArmor(IntPtr playerPointer, ushort armor);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern float Player_GetMoveSpeed(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Player_GetWeapon(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Player_GetAmmo(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern Position Player_GetAimPos(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern Rotation Player_GetHeadRotation(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Player_IsInVehicle(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Player_GetVehicle(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern sbyte Player_GetSeat(IntPtr playerPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Player_Kick(IntPtr playerPointer, string reason);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_Copy(IntPtr playerPointer, ref ReadOnlyPlayer readOnlyPlayer);
        }
    }
}