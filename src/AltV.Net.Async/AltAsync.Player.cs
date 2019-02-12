using System;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static async Task<bool> IsConnected(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsConnected);

        public static async Task<string> GetName(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Name);

        public static async Task<ushort> GetHealth(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Health);

        public static async Task<bool> IsDead(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsDead);

        public static async Task<bool> IsJumping(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsJumping);

        public static async Task<bool> IsInRagdoll(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsInRagdoll);

        public static async Task<bool> IsAiming(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsAiming);

        public static async Task<bool> IsShooting(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsShooting);

        public static async Task<bool> IsReloading(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsReloading);

        public static async Task<ushort> GetArmor(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Armor);

        public static async Task SetArmor(this IPlayer player, ushort armor) =>
            await AltVAsync.Schedule(() => { player.Armor = armor; });

        public static async Task<float> GetMoveSpeed(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.MoveSpeed);

        public static async Task<uint> GetWeapon(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Weapon);

        public static async Task<ushort> GetAmmo(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Ammo);

        public static async Task<Position> GetAimPosition(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.AimPosition);

        public static async Task<Rotation> GetHeadRotation(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.HeadRotation);

        public static async Task<bool> IsInVehicle(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.IsInVehicle);

        public static async Task<IVehicle> GetVehicle(this IPlayer player)
        {
            if (!player.Exists) return null;
            var entityPointer =
                await AltVAsync.Schedule(() => AltVNative.Player.Player_GetVehicle(player.NativePointer));
            if (entityPointer == IntPtr.Zero) return null;
            if (Alt.Module.BaseEntityPool.GetOrCreate(entityPointer, out var entity) && entity is IVehicle vehicle)
            {
                return vehicle;
            }

            return null;
        }

        public static async Task<sbyte> GetSeat(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Seat);

        public static async Task Spawn(this IPlayer player, Position position) =>
            await AltVAsync.Schedule(() => { player.Spawn(position); });

        public static async Task Despawn(this IPlayer player) =>
            await AltVAsync.Schedule(player.Despawn);

        public static async Task SetDateTime(this IPlayer player, int day, int month, int year, int hour,
            int minute, int second) =>
            await AltVAsync.Schedule(() => { player.SetDateTime(day, month, year, hour, minute, second); });

        public static async Task SetWeather(this IPlayer player, uint weather) =>
            await AltVAsync.Schedule(() => { player.SetWeather(weather); });

        public static async Task Kick(this IPlayer player, string reason) =>
            await AltVAsync.Schedule(() => { player.Kick(reason); });

        public static async Task Emit(this IPlayer player, string eventName, params object[] args) =>
            await AltVAsync.Schedule(() => { player.Emit(eventName, args); });
    }
}