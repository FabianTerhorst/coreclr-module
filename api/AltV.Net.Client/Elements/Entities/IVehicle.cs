using System.Numerics;

namespace AltV.Net.Client.Elements.Entities
{
    public interface IVehicle : IEntity
    {
        int Gear { get; }
        
        int Rpm { get; }
        
        int Speed { get; }
        
        Vector3 SpeedVector { get; }
        
        int WheelsCount { get; }
    }
}