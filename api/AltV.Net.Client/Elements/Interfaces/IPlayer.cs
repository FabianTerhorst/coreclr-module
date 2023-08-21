using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IPlayer : ISharedPlayer, IEntity
    {
        new IVehicle? Vehicle { get; }
        new IEntity? EntityAimingAt { get; }
        bool IsTalking { get; }
        float MicLevel { get; }
        float NonSpatialVolume { get; set; }
        float SpatialVolume { get; set; }
        bool IsLocal { get; }

        void AddFilter(IAudioFilter filter);
        void RemoveFilter();
        IAudioFilter GetFilter();
    }
}