using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async;

public partial class AltAsync
{
    public static Task<IVirtualEntityGroup> CreateVirtualEntityGroup(uint streamingDistance) =>AltVAsync.Schedule(() =>
        Alt.Core.CreateVirtualEntityGroup(streamingDistance));

    public static Task<IVirtualEntity> CreateVirtualEntity(IVirtualEntityGroup group, Position position,
        uint streamingDistance, Dictionary<string, object> dataDict) =>
        AltVAsync.Schedule(() => Alt.CreateVirtualEntity(group, position, streamingDistance, dataDict));
}