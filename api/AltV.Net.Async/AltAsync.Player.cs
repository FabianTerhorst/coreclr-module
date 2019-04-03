using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static Task<bool> IsConnectedAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsConnected);

        public static Task SetModelAsync(this IPlayer player, uint model) =>
            AltVAsync.Schedule(() => player.Model = model);

        public static async Task<string> GetNameAsync(this IPlayer player)
        {
            var ptr = IntPtr.Zero;
            await AltVAsync.Schedule(
                () =>
                {
                    player.CheckIfEntityExists();
                    AltNative.Player.Player_GetName(player.NativePointer, ref ptr);
                });
            return ptr == IntPtr.Zero ? string.Empty : Marshal.PtrToStringUTF8(ptr);
        }

        public static async Task SetNameAsync(this IPlayer player, string name)
        {
            var namePtr = AltNative.StringUtils.StringToHGlobalUtf8(name);
            await AltVAsync.Schedule(() =>
            {
                player.CheckIfEntityExists();
                AltNative.Player.Player_SetName(player.NativePointer, namePtr);
            });
            Marshal.FreeHGlobal(namePtr);
        }

        public static Task<ushort> GetHealthAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Health);

        public static Task SetHealthAsync(this IPlayer player, ushort health) =>
            AltVAsync.Schedule(() => player.Health = health);

        public static Task<bool> IsDeadAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsDead);

        public static Task<bool> IsJumpingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsJumping);

        public static Task<bool> IsInRagdollAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsInRagdoll);

        public static Task<bool> IsAimingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsAiming);

        public static Task<bool> IsShootingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsShooting);

        public static Task<bool> IsReloadingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsReloading);

        public static Task<ushort> GetArmorAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Armor);

        public static Task SetArmorAsync(this IPlayer player, ushort armor) =>
            AltVAsync.Schedule(() => player.Armor = armor);

        public static Task<float> GetMoveSpeedAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.MoveSpeed);

        public static Task<uint> GetWeaponAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Weapon);

        public static Task<ushort> GetAmmoAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Ammo);

        public static Task<Position> GetAimPositionAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.AimPosition);

        public static Task<Rotation> GetHeadRotationAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.HeadRotation);

        public static Task<bool> IsInVehicleAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsInVehicle);

        public static async Task<IVehicle> GetVehicleAsync(this IPlayer player)
        {
            var entityPointer =
                await AltVAsync.Schedule(() =>
                    !player.Exists ? IntPtr.Zero : AltNative.Player.Player_GetVehicle(player.NativePointer));
            if (entityPointer == IntPtr.Zero) return null;
            return Alt.Module.VehiclePool.GetOrCreate(entityPointer, out var vehicle) ? vehicle : null;
        }

        public static Task<byte> GetSeatAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Seat);

        public static Task<uint> GetPingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Ping);

        public static Task SpawnAsync(this IPlayer player, Position position) =>
            AltVAsync.Schedule(() => player.Spawn(position));

        public static Task DespawnAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.Despawn);

        public static Task SetDateTimeAsync(this IPlayer player, int day, int month, int year, int hour,
            int minute, int second) =>
            AltVAsync.Schedule(() => player.SetDateTime(day, month, year, hour, minute, second));
        
        public static Task SetDateTimeAsync(this IPlayer player, DateTime dateTime) =>
            AltVAsync.Schedule(() => player.SetDateTime(dateTime));

        public static Task SetWeatherAsync(this IPlayer player, uint weather) =>
            AltVAsync.Schedule(() => player.SetWeather(weather));

        public static async Task KickAsync(this IPlayer player, string reason)
        {
            var reasonPtr = AltNative.StringUtils.StringToHGlobalUtf8(reason);
            await AltVAsync.Schedule(() =>
            {
                player.CheckIfEntityExists();
                AltNative.Player.Player_Kick(player.NativePointer, reasonPtr);
            });
            Marshal.FreeHGlobal(reasonPtr);
        }

        public static async Task EmitAsync(this IPlayer player, string eventName, params object[] args)
        {
            var mValueArgs = MValue.Create(MValue.CreateFromObjects(args));
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            await AltVAsync.Schedule(() => Alt.Server.TriggerClientEvent(player, eventNamePtr, ref mValueArgs));
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public static Task<ReadOnlyPlayer> CopyAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.Copy);
    }
}