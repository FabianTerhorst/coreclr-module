using System;
using System.Collections.ObjectModel;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IEntityPool
    {
        bool Get(IntPtr entityPointer, out IEntity entity);
        bool GetOrCreate(IntPtr entityPointer, out IEntity entity);
        void Add(IEntity entity);
        bool Remove(IEntity entity);
        bool Remove(IntPtr entityPointer);
        ReadOnlyCollection<IPlayer> GetPlayers();
        ReadOnlyCollection<IVehicle> GetVehicles();
        ReadOnlyCollection<IBlip> GetBlips();
        ReadOnlyCollection<ICheckpoint> GetCheckpoints();
    }
}