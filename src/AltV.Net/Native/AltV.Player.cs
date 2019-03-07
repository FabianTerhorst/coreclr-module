using System;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Native
{
    internal static partial class AltVNative
    {
        internal static class Player
        {
            // Entity
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern ushort Player_GetID(IntPtr entityPointer);
            
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern uint Player_GetModel(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_GetPosition(IntPtr entityPointer, ref Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_SetPosition(IntPtr entityPointer, Position position);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_GetRotation(IntPtr entityPointer, ref Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_SetRotation(IntPtr entityPointer, Rotation rotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern short Player_GetDimension(IntPtr entityPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_SetDimension(IntPtr entityPointer, short dimension);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Player_GetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Player_SetMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Player_GetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void
                Player_SetSyncedMetaData(IntPtr entityPointer, string key, ref MValue value);
            
            // Player
            
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
            internal static extern void Player_GetAimPos(IntPtr playerPointer, ref Position aimPosition);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_GetHeadRotation(IntPtr playerPointer, ref Rotation headRotation);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern bool Player_IsInVehicle(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Player_GetVehicle(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern byte Player_GetSeat(IntPtr playerPointer);

            [DllImport(_dllName, CharSet = CharSet.Ansi, CallingConvention = _callingConvention)]
            internal static extern void Player_Kick(IntPtr playerPointer, string reason);
            
            [DllImport(_dllName,CallingConvention = _callingConvention)]
            internal static extern uint Player_GetPing(IntPtr playerPointer);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern void Player_Copy(IntPtr playerPointer, ref ReadOnlyPlayer readOnlyPlayer);
        }
    }
}