using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.Client.CApi.Events;
using AltV.Net.Client.Elements.Args;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Enums;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Client.Events;
using AltV.Net.Client.Extensions;

namespace AltV.Net.Client
{
    public class Module
    {
        internal readonly ICore Core;
        
        internal PlayerPool PlayerPool;
        internal IEntityPool<IVehicle> VehiclePool;

        public List<SafeTimer> RunningTimers { get; } = new();
    
        public Module(ICore core)
        {
            Alt.Init(this);
            Core = core;
        }
        
        internal void InitPools(PlayerPool playerPool, IEntityPool<IVehicle> vehiclePool)
        {
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
        }

        // public bool GetEntityById(ushort id, [MaybeNullWhen(false)] out IEntity entity)
        // {
        //     unsafe
        //     {
        //         byte type = 0;
        //         entity = default;
        //         if (this.Core.Library.Entity_GetTypeByID(this.Core.NativePointer, id, &type) != 1) return false;
        //         
        //         switch ((BaseObjectType) type)
        //         {
        //             case BaseObjectType.Player:
        //             case BaseObjectType.LocalPlayer:
        //             {
        //                 entity = PlayerPool.Get(id);
        //                 return entity is not null;
        //             }
        //             case BaseObjectType.Vehicle:
        //             {
        //                 entity = VehiclePool.Get(id);
        //                 return entity is not null;
        //             }
        //             // todo
        //             default:
        //                 return false;
        //         }
        //     }
        // }

        public HandlingData? GetHandlingByModelHash(uint modelHash)
        {
            unsafe
            {
                var pointer = IntPtr.Zero;
                var success = Core.Library.Vehicle_Handling_GetByModelHash(Core.NativePointer, modelHash, &pointer);
                if (success == 0 || pointer == IntPtr.Zero) return null;
                return new HandlingData(Core, pointer);
            }
        }
    }
}