using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Shared;

namespace AltV.Net.Client
{
    public interface ICore : ISharedCore
    {
        new IPlayerPool PlayerPool { get; }
        new IEntityPool<IVehicle> VehiclePool { get; }
        IBaseEntityPool BaseEntityPool { get; }
        IBaseBaseObjectPool BaseBaseObjectPool { get; }
        // HandlingData? GetHandlingByModelHash(uint modelHash); todo
    }
}