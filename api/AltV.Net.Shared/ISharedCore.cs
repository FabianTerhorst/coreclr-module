using AltV.Net.CApi;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Shared
{
    public interface ISharedCore : ICApiCore
    {
        IReadOnlyEntityPool<ISharedPlayer> PlayerPool { get; }
        IReadOnlyEntityPool<ISharedVehicle> VehiclePool { get; }
        IReadOnlyBaseBaseObjectPool BaseBaseObjectPool { get; }
    }
}