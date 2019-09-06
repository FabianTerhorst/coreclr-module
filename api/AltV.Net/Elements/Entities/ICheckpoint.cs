using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface ICheckpoint : IWorldObject
    {
        bool IsGlobal { get; }
        byte CheckpointType { get; }
        float Height { get; }
        float Radius { get; }
        Rgba Color { get; }
        IPlayer Target { get; }
        bool IsPlayerIn(IPlayer player);
        bool IsVehicleIn(IVehicle vehicle);
        void Remove();
    }
}