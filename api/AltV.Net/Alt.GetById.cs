using AltV.Net.Elements.Entities;

namespace AltV.Net;

public partial class Alt
{
    public static IPlayer GetPlayerById(uint id) => (IPlayer)Core.GetBaseObject(BaseObjectType.Player, id);
    public static IVehicle GetVehicleById(uint id) => (IVehicle)Core.GetBaseObject(BaseObjectType.Vehicle, id);
    public static IPed GetPedById(uint id) => (IPed)Core.GetBaseObject(BaseObjectType.Ped, id);
    public static IBlip GetBlipById(uint id) => (IBlip)Core.GetBaseObject(BaseObjectType.Blip, id);
    public static IVoiceChannel GetVoiceChannelById(uint id) => (IVoiceChannel)Core.GetBaseObject(BaseObjectType.VoiceChannel, id);
    public static IColShape GetColShapeById(uint id) => (IColShape)Core.GetBaseObject(BaseObjectType.ColShape, id);
    public static ICheckpoint GetCheckpointById(uint id) => (ICheckpoint)Core.GetBaseObject(BaseObjectType.Checkpoint, id);
    public static IVirtualEntity GetVirtualEntityById(uint id) => (IVirtualEntity)Core.GetBaseObject(BaseObjectType.VirtualEntity, id);
    public static IVirtualEntityGroup GetVirtualEntityGroupById(uint id) => (IVirtualEntityGroup)Core.GetBaseObject(BaseObjectType.VirtualEntityGroup, id);
    public static IMarker GetMarkerById(uint id) => (IMarker)Core.GetBaseObject(BaseObjectType.Marker, id);
}