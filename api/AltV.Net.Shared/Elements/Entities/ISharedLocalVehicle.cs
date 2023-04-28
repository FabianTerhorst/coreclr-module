using AltV.Net.Data;

namespace AltV.Net.Shared.Elements.Entities;

public interface ISharedLocalVehicle : ISharedWorldObject
{
    uint Model { get; }
    Rotation Rotation { get; set; }
    uint StreamingDistance { get; }
    bool Visible { get; set; }

}