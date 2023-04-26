using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net;

public partial class Alt
{
    public static IVirtualEntityGroup CreateVirtualEntityGroup(uint streamingDistance)
    {
        return new VirtualEntityGroup(Core, streamingDistance);
    }

    public static IVirtualEntity CreateVirtualEntity(IVirtualEntityGroup group, Position position,
        uint streamingDistance, Dictionary<string, object> dataDict)
    {
        return new VirtualEntity(Core, group, position, streamingDistance, dataDict);
    }
}