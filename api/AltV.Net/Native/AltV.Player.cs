using System;
using System.Runtime.InteropServices;
using System.Security;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Native
{
    internal static partial class AltNative
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class Player
        {
            // Entity

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort Player_GetID(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Player_GetNetworkOwner(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern uint Player_GetModel(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetModel(IntPtr player, uint model);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetPosition(IntPtr player, ref Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetPosition(IntPtr player, Position pos);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetRotation(IntPtr player, ref Rotation rotation);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetRotation(IntPtr player, Rotation rot);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern short Player_GetDimension(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetDimension(IntPtr player, short dimension);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetMetaData(IntPtr player, IntPtr key, ref MValue val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetMetaData(IntPtr player, IntPtr key, ref MValue val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetSyncedMetaData(IntPtr player, IntPtr key, ref MValue val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetSyncedMetaData(IntPtr player, IntPtr key, ref MValue val);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Player_IsConnected(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_Spawn(IntPtr player, Position pos, uint delayMs);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_Despawn(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetName(IntPtr player, ref IntPtr name);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetName(IntPtr player, IntPtr name);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong Player_GetSocialID(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong Player_GetHwidHash(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ulong Player_GetHwidExHash(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetAuthToken(IntPtr player, ref IntPtr name);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort Player_GetHealth(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetHealth(IntPtr player, ushort health);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort Player_GetMaxHealth(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetMaxHealth(IntPtr player, ushort maxHealth);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetDateTime(IntPtr player, int day, int month, int year, int hour,
                int minute, int second);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetWeather(IntPtr player, uint weather);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GiveWeapon(IntPtr player, uint weapon, int ammo, bool selectWeapon);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_RemoveWeapon(IntPtr player, uint weapon);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_RemoveAllWeapons(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_AddWeaponComponent(IntPtr player, uint weapon, uint component);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_RemoveWeaponComponent(IntPtr player, uint weapon, uint component);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void
                Player_GetCurrentWeaponComponents(IntPtr player, ref UIntArray weaponComponents);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetWeaponTintIndex(IntPtr player, uint weapon, byte tintIndex);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Player_GetCurrentWeaponTintIndex(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern uint Player_GetCurrentWeapon(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetCurrentWeapon(IntPtr player, uint weapon);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Player_IsDead(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Player_IsJumping(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Player_IsInRagdoll(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Player_IsAiming(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Player_IsShooting(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Player_IsReloading(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort Player_GetArmor(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetArmor(IntPtr player, ushort armor);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort Player_GetMaxArmor(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_SetMaxArmor(IntPtr player, ushort armor);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern float Player_GetMoveSpeed(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern uint Player_GetWeapon(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern ushort Player_GetAmmo(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetAimPos(IntPtr player, ref Position aimPosition);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetHeadRotation(IntPtr player, ref Rotation headRotation);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Player_IsInVehicle(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Player_GetVehicle(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern byte Player_GetSeat(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern IntPtr Player_GetEntityAimingAt(IntPtr player, ref BaseObjectType type);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetEntityAimOffset(IntPtr player, ref Position position);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern bool Player_IsFlashlightActive(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_Kick(IntPtr player, IntPtr reason);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern uint Player_GetPing(IntPtr player);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_GetIP(IntPtr player, ref IntPtr ip);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_Copy(IntPtr player, ref ReadOnlyPlayer player_struct);

            [DllImport(DllName, CallingConvention = NativeCallingConvention)]
            internal static extern void Player_Copy_Dispose(ref ReadOnlyPlayer player_struct);
        }
    }
}