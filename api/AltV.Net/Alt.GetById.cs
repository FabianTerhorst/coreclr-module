using AltV.Net.Elements.Entities;

namespace AltV.Net;

public partial class Alt
{
    public static IPlayer GetPlayerById(uint id) => Core.GetBaseObject(BaseObjectType.Player, id) as IPlayer;
    public static IVehicle GetVehicleById(uint id) => Core.GetBaseObject(BaseObjectType.Vehicle, id) as IVehicle;
    public static IPed GetPedById(uint id) => Core.GetBaseObject(BaseObjectType.Ped, id) as IPed;
    public static IBlip GetBlipById(uint id) => Core.GetBaseObject(BaseObjectType.Blip, id) as IBlip;
    public static IVoiceChannel GetVoiceChannelById(uint id) => Core.GetBaseObject(BaseObjectType.VoiceChannel, id) as IVoiceChannel;
    public static IColShape GetColShapeById(uint id) => Core.GetBaseObject(BaseObjectType.ColShape, id) as IColShape;
    public static ICheckpoint GetCheckpointById(uint id) => Core.GetBaseObject(BaseObjectType.Checkpoint, id) as ICheckpoint;
    public static IVirtualEntity GetVirtualEntityById(uint id) => Core.GetBaseObject(BaseObjectType.VirtualEntity, id) as IVirtualEntity;
    public static IVirtualEntityGroup GetVirtualEntityGroupById(uint id) => Core.GetBaseObject(BaseObjectType.VirtualEntityGroup, id) as IVirtualEntityGroup;
    public static IMarker GetMarkerById(uint id) => Core.GetBaseObject(BaseObjectType.Marker, id) as IMarker;
}