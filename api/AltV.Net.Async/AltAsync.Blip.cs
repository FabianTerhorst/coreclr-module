using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static async Task<IBlip> CreateBlip(IPlayer player, byte type, Position pos) =>
            await AltVAsync.Schedule(() => Alt.CreateBlip(player, type, pos)).ConfigureAwait(false);

        public static async Task<IBlip> CreateBlip(IPlayer player, byte type, IEntity entityAttach) =>
            await AltVAsync.Schedule(() => Alt.CreateBlip(player, type, entityAttach)).ConfigureAwait(false);

        public static async Task<IBlip> CreateBlip(IPlayer player, BlipType type, Position pos) =>
            await AltVAsync.Schedule(() => Alt.CreateBlip(player, type, pos)).ConfigureAwait(false);

        public static async Task<IBlip> CreateBlip(IPlayer player, BlipType type, IEntity entityAttach) =>
            await AltVAsync.Schedule(() => Alt.CreateBlip(player, type, entityAttach)).ConfigureAwait(false);

        public static async Task<IBlip> CreateBlip(byte type, Position pos) =>
            await AltVAsync.Schedule(() => Alt.CreateBlip(type, pos)).ConfigureAwait(false);

        public static async Task<IBlip> CreateBlip(byte type, IEntity entityAttach) =>
            await AltVAsync.Schedule(() => Alt.CreateBlip(type, entityAttach)).ConfigureAwait(false);

        public static async Task<IBlip> CreateBlip(BlipType type, Position pos) =>
            await AltVAsync.Schedule(() => Alt.CreateBlip(type, pos)).ConfigureAwait(false);

        public static async Task<IBlip> CreateBlip(BlipType type, IEntity entityAttach) =>
            await AltVAsync.Schedule(() => Alt.CreateBlip(type, entityAttach)).ConfigureAwait(false);

        public static async Task<bool> IsGlobalAsync(this IBlip blip) =>
            await AltVAsync.Schedule(() => blip.IsGlobal).ConfigureAwait(false);

        public static async Task<bool> IsAttachedAsync(this IBlip blip) =>
            await AltVAsync.Schedule(() => blip.IsAttached).ConfigureAwait(false);

        public static async Task<IEntity> AttachedToAsync(this IBlip blip) =>
            await AltVAsync.Schedule(() => blip.AttachedTo).ConfigureAwait(false);

        public static async Task<BlipType> GetBlipTypeAsync(this IBlip blip) =>
            await AltVAsync.Schedule(() => (BlipType) blip.BlipType).ConfigureAwait(false);

        public static async Task SetSpriteAsync(this IBlip blip, ushort sprite) =>
            await AltVAsync.Schedule(() => blip.Sprite = sprite).ConfigureAwait(false);

        public static async Task SetColorAsync(this IBlip blip, byte color) =>
            await AltVAsync.Schedule(() => blip.Color = color).ConfigureAwait(false);

        public static async Task SetRouteAsync(this IBlip blip, bool route) =>
            await AltVAsync.Schedule(() => blip.Route = route).ConfigureAwait(false);

        public static async Task SetRouteColorAsync(this IBlip blip, byte color) =>
            await AltVAsync.Schedule(() => blip.RouteColor = color).ConfigureAwait(false);

        public static async Task RemoveAsync(this IBlip blip) =>
            await AltVAsync.Schedule(blip.RemoveAsync).ConfigureAwait(false);
    }
}