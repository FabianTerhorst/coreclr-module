using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Shared.Enums;

namespace AltV.Net.Async;

public partial class AltAsync
{
    public static Task<IMarker> CreateMarker(MarkerType type, Position pos, Rgba color) =>
        AltVAsync.Schedule(() => Alt.CreateMarker(null, type, pos, color));

    public static Task<IMarker> CreateMarker(IPlayer player, MarkerType type, Position pos, Rgba color) =>
        AltVAsync.Schedule(() => Alt.CreateMarker(player, type, pos, color));
}