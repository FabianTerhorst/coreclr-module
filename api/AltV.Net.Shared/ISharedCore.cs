using AltV.Net.CApi;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Shared
{
    public interface ISharedCore : ICApiCore
    {
        public IReadOnlyEntityPool<ISharedPlayer> PlayerPool { get;  }
        public IReadOnlyEntityPool<ISharedVehicle> VehiclePool { get; }
        IReadOnlyBaseBaseObjectPool BaseBaseObjectPool { get; }
    }
}