using System;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static async Task<bool> IsConnectedAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsConnected);

        public static async Task<string> GetNameAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Name);

        public static async Task<ushort> GetHealthAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Health);

        public static async Task<bool> IsDeadAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsDead);

        public static async Task<bool> IsJumpingAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsJumping);

        public static async Task<bool> IsInRagdollAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsInRagdoll);

        public static async Task<bool> IsAimingAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsAiming);

        public static async Task<bool> IsShootingAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsShooting);

        public static async Task<bool> IsReloadingAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsReloading);

        public static async Task<ushort> GetArmorAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Armor);

        public static async Task SetArmorAsync(this IPlayer player, ushort armor) =>
            await AltVAsync.Schedule(() => { player.Armor = armor; });

        public static async Task<float> GetMoveSpeedAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.MoveSpeed);

        public static async Task<uint> GetWeaponAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Weapon);

        public static async Task<ushort> GetAmmoAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Ammo);

        public static async Task<Position> GetAimPositionAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.AimPosition);

        public static async Task<Rotation> GetHeadRotationAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.HeadRotation);

        public static async Task<bool> IsInVehicleAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsInVehicle);

        public static async Task<IVehicle> GetVehicleAsync(this IPlayer player)
        {
            var entityPointer =
                await AltVAsync.Schedule(() =>
                    !player.Exists ? IntPtr.Zero : AltVNative.Player.Player_GetVehicle(player.NativePointer));
            if (entityPointer == IntPtr.Zero) return null;
            return Alt.Module.VehiclePool.GetOrCreate(entityPointer, out var vehicle) ? vehicle : null;
        }

        public static async Task<byte> GetSeatAsync(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Seat);

        public static async Task SpawnAsync(this IPlayer player, Position position) =>
            await AltVAsync.Schedule(() => { player.Spawn(position); });

        public static async Task DespawnAsync(this IPlayer player) =>
            await AltVAsync.Schedule(player.Despawn);

        public static async Task SetDateTimeAsync(this IPlayer player, int day, int month, int year, int hour,
            int minute, int second) =>
            await AltVAsync.Schedule(() => { player.SetDateTime(day, month, year, hour, minute, second); });

        public static async Task SetWeatherAsync(this IPlayer player, uint weather) =>
            await AltVAsync.Schedule(() => { player.SetWeather(weather); });

        public static async Task KickAsync(this IPlayer player, string reason) =>
            await AltVAsync.Schedule(() => { player.Kick(reason); });

        public static async Task EmitAsync(this IPlayer player, string eventName, params object[] args)
        {
            var mValueArgs = MValue.Create(MValue.CreateFromObjects(args));
            await AltVAsync.Schedule(() => { Alt.Server.TriggerClientEvent(player, eventName, ref mValueArgs); });
        }
    }
}