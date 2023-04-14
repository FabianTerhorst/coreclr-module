using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Shared
{
    public interface ISharedPoolManager
    {
        IReadOnlyEntityPool<ISharedPlayer> Player { get; }
        IReadOnlyEntityPool<ISharedVehicle> Vehicle { get; }
        IReadOnlyEntityPool<ISharedPed> Ped { get; }
        IReadOnlyEntityPool<ISharedObject> Object { get; }

        IReadOnlyBaseObjectPool<ISharedBlip> Blip { get; }
        IReadOnlyBaseObjectPool<ISharedCheckpoint> Checkpoint { get; }
        IReadOnlyBaseObjectPool<ISharedColShape> ColShape { get; }
        IReadOnlyBaseObjectPool<ISharedVirtualEntity> VirtualEntity { get; }
        IReadOnlyBaseObjectPool<ISharedVirtualEntityGroup> VirtualEntityGroup { get; }
        IReadOnlyBaseObjectPool<ISharedMarker> Marker { get; }

        ISharedBaseObject GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType, uint entityId);
        ISharedBaseObject GetOrCreate(ISharedCore core, IntPtr entityPointer, BaseObjectType baseObjectType);
        ISharedBaseObject Get(IntPtr entityPointer, BaseObjectType baseObjectType);
        void Dispose();
    }
}