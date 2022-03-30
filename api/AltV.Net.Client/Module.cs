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

    }
}