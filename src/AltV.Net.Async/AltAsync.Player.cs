using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

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

        public static async Task SetPosition(this IPlayer player, Position position) =>
            await AltVAsync.Schedule(() => { player.Position = position; });

        public static async Task<Position> GetPosition(this IPlayer player) =>
            await AltVAsync.Schedule(() => player.Position);
    }
}