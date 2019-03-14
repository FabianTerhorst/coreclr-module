using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    // Interface of own entity type is only needed when doing mocking, but its also a lot cleaner
    public interface IMyVehicle : IVehicle
    {
        int MyData { get; set; }
    }
}