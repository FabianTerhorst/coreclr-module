using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static Task<IBlip> CreateBlip(IPlayer player, byte type, Position pos) =>
            AltVAsync.Schedule(() => Alt.CreateBlip(player, type, pos));

        public static Task<IBlip> CreateBlip(IPlayer player, byte type, IEntity entityAttach) =>
            AltVAsync.Schedule(() => Alt.CreateBlip(player, type, entityAttach));

        public static Task<IBlip> CreateBlip(IPlayer player, BlipType type, Position pos) =>
            AltVAsync.Schedule(() => Alt.CreateBlip(player, type, pos));

        public static Task<IBlip> CreateBlip(IPlayer player, BlipType type, IEntity entityAttach) =>
            AltVAsync.Schedule(() => Alt.CreateBlip(player, type, entityAttach));

        public static Task<IBlip> CreateBlip(byte type, Position pos) =>
            AltVAsync.Schedule(() => Alt.CreateBlip(type, pos));

        public static Task<IBlip> CreateBlip(byte type, IEntity entityAttach) =>
            AltVAsync.Schedule(() => Alt.CreateBlip(type, entityAttach));

        public static Task<IBlip> CreateBlip(BlipType type, Position pos) =>
            AltVAsync.Schedule(() => Alt.CreateBlip(type, pos));

        public static Task<IBlip> CreateBlip(BlipType type, IEntity entityAttach) =>
            AltVAsync.Schedule(() => Alt.CreateBlip(type, entityAttach));

        public static Task<bool> IsGlobalAsync(this IBlip blip) =>
            AltVAsync.Schedule(() => blip.IsGlobal);

        public static Task<bool> IsAttachedAsync(this IBlip blip) =>
            AltVAsync.Schedule(() => blip.IsAttached);

        public static Task<IEntity> AttachedToAsync(this IBlip blip) =>
            AltVAsync.Schedule(() => blip.AttachedTo);

        public static Task<BlipType> GetBlipTypeAsync(this IBlip blip) =>
            AltVAsync.Schedule(() => (BlipType) blip.BlipType);

        public static Task SetSpriteAsync(this IBlip blip, ushort sprite) =>
            AltVAsync.Schedule(() => blip.Sprite = sprite);

        public static Task SetColorAsync(this IBlip blip, byte color) =>
            AltVAsync.Schedule(() => blip.Color = color);

        public static Task SetRouteAsync(this IBlip blip, bool route) =>
            AltVAsync.Schedule(() => blip.Route = route);

        public static Task SetRouteColorAsync(this IBlip blip, Rgba color) =>
            AltVAsync.Schedule(() => blip.RouteColor = color);

        public static Task RemoveAsync(this IBlip blip) =>
            AltVAsync.Schedule(blip.RemoveAsync);
    }
}