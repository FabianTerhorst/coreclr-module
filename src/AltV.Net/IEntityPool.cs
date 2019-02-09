using System;
using System.Collections.Generic;
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
        Dictionary<IntPtr, IPlayer>.ValueCollection GetPlayers();
        Dictionary<IntPtr, IVehicle>.ValueCollection GetVehicles();
        Dictionary<IntPtr, IBlip>.ValueCollection GetBlips();
        Dictionary<IntPtr, ICheckpoint>.ValueCollection GetCheckpoints();
    }
}