using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Shared.Enums;

namespace AltV.Net;

public partial class Alt
{
    public static IMarker CreateMarker(MarkerType type, Position pos, Rgba color) =>
        Core.CreateMarker(null, type, pos, color);

    public static IMarker CreateMarker(IPlayer player, MarkerType type, Position pos, Rgba color) =>
        Core.CreateMarker(player, type, pos, color);
}