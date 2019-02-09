using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface ICheckpoint : IEntity
    {
        bool IsGlobal { get; }
        byte CheckpointType { get; }
        float Height { get; }
        float Radius { get; }
        Rgba Color { get; }
    }
}