using AltV.Net.CApi;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Shared;

namespace AltV.Net.Client
{
    public partial class Core : SharedCore, ICore
    {
        public ILibrary Library { get; }
        public IntPtr NativePointer { get; }
        
        public override IPlayerPool PlayerPool { get; }
        public override IEntityPool<IVehicle> VehiclePool { get; }
        
        public IBaseEntityPool BaseEntityPool { get; }
        public override IBaseBaseObjectPool BaseBaseObjectPool { get; }

        public override INativeResource Resource { get; }
        public ILogger Logger { get; }

        public List<SafeTimer> RunningTimers { get; } = new();

        public Core(ILibrary library, IntPtr nativePointer, IntPtr resourcePointer, IPlayerPool playerPool, IEntityPool<IVehicle> vehiclePool, IBaseBaseObjectPool baseBaseObjectPool, IBaseEntityPool baseEntityPool, INativeResourcePool nativeResourcePool, ILogger logger) : base(nativePointer, library)
        {
            Library = library;
            NativePointer = nativePointer;
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
            Logger = logger;
            BaseBaseObjectPool = baseBaseObjectPool;
            BaseEntityPool = baseEntityPool;
            nativeResourcePool.GetOrCreate(this, resourcePointer, out var resource);
            Resource = resource;
        }

        #region Log
        public new void LogInfo(string message) => Logger.LogInfo(message);
        public new void LogWarning(string message) => Logger.LogWarning(message);
        public new void LogError(string message) => Logger.LogError(message);
        public new void LogDebug(string message) => Logger.LogDebug(message);
        #endregion
        
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
            // unsafe
            // {
            //     var pointer = IntPtr.Zero;
            //     var success = Library.Vehicle_Handling_GetByModelHash(NativePointer, modelHash, &pointer);
            //     if (success == 0 || pointer == IntPtr.Zero) return null;
            //     return new HandlingData(this, pointer);
            // }
            return null;
            // todo
        }
    }
}