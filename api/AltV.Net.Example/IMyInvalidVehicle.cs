using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    /// <summary>
    /// Type to test script events
    /// </summary>
    public interface IMyInvalidVehicle : IVehicle
    {
        int MyInvalidData { get; set; }
    }
}