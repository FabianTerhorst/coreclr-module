using System;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public interface IVehicleBuilder : IDisposable
    {
        IVehicleBuilder PrimaryColor(byte value);

        IVehicleBuilder NumberPlate(string value);

        Task<IVehicle> Build();
    }
}