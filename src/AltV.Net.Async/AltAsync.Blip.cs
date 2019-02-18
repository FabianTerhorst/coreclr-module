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
    }
}