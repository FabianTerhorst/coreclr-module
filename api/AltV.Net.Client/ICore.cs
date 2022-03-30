using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
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
        void RemoveBlip(IBlip blip);
        IBlip CreatePointBlip(Position position);
        IBlip CreateRadiusBlip(Position position, float radius);
        IBlip CreateAreaBlip(Position position, int width, int height);
    }
}