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
    }
}