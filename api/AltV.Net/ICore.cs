using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.CApi;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Data;
using AltV.Net.Shared.Enums;

namespace AltV.Net
{
    public interface ICore : ISharedCore
    {
        new IPoolManager PoolManager { get; }
        INativeResourcePool NativeResourcePool { get; }

        int NetTime { get; }

        string RootDirectory { get; }

        INativeResource Resource { get; }

        ulong HashPassword(string password);

        void SetPassword(string password);

        public VehicleModelInfo GetVehicleModelInfo(uint hash);
        public PedModelInfo? GetPedModelInfo(uint hash);

        void StopServer();

        void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, MValueConst[] args);

        void TriggerClientEvent(IPlayer player, string eventName, MValueConst[] args);

        void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, IntPtr[] args);

        void TriggerClientEvent(IPlayer player, string eventName, IntPtr[] args);

        void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params object[] args);

        void TriggerClientEvent(IPlayer player, string eventName, params object[] args);

        void TriggerClientEventForAll(IntPtr eventNamePtr, MValueConst[] args);

        void TriggerClientEventForAll(string eventName, MValueConst[] args);

        void TriggerClientEventForAll(IntPtr eventNamePtr, IntPtr[] args);

        void TriggerClientEventForAll(string eventName, IntPtr[] args);

        void TriggerClientEventForAll(IntPtr eventNamePtr, params object[] args);

        void TriggerClientEventForAll(string eventName, params object[] args);

        void TriggerClientEventForSome(IPlayer[] clients, IntPtr eventNamePtr, MValueConst[] args);

        void TriggerClientEventForSome(IPlayer[] clients, string eventName, MValueConst[] args);

        void TriggerClientEventForSome(IPlayer[] clients, IntPtr eventNamePtr, IntPtr[] args);

        void TriggerClientEventForSome(IPlayer[] clients, string eventName, IntPtr[] args);

        void TriggerClientEventForSome(IPlayer[] clients, IntPtr eventNamePtr, params object[] args);

        void TriggerClientEventForSome(IPlayer[] clients, string eventName, params object[] args);

        void TriggerClientEventUnreliable(IPlayer player, IntPtr eventNamePtr, MValueConst[] args);

        void TriggerClientEventUnreliable(IPlayer player, string eventName, MValueConst[] args);

        void TriggerClientEventUnreliable(IPlayer player, IntPtr eventNamePtr, IntPtr[] args);

        void TriggerClientEventUnreliable(IPlayer player, string eventName, IntPtr[] args);

        void TriggerClientEventUnreliable(IPlayer player, IntPtr eventNamePtr, params object[] args);

        void TriggerClientEventUnreliable(IPlayer player, string eventName, params object[] args);

        void TriggerClientEventUnreliableForAll(IntPtr eventNamePtr, MValueConst[] args);

        void TriggerClientEventUnreliableForAll(string eventName, MValueConst[] args);

        void TriggerClientEventUnreliableForAll(IntPtr eventNamePtr, IntPtr[] args);

        void TriggerClientEventUnreliableForAll(string eventName, IntPtr[] args);

        void TriggerClientEventUnreliableForAll(IntPtr eventNamePtr, params object[] args);

        void TriggerClientEventUnreliableForAll(string eventName, params object[] args);

        void TriggerClientEventUnreliableForSome(IPlayer[] clients, IntPtr eventNamePtr, MValueConst[] args);

        void TriggerClientEventUnreliableForSome(IPlayer[] clients, string eventName, MValueConst[] args);

        void TriggerClientEventUnreliableForSome(IPlayer[] clients, IntPtr eventNamePtr, IntPtr[] args);

        void TriggerClientEventUnreliableForSome(IPlayer[] clients, string eventName, IntPtr[] args);

        void TriggerClientEventUnreliableForSome(IPlayer[] clients, IntPtr eventNamePtr, params object[] args);

        void TriggerClientEventUnreliableForSome(IPlayer[] clients, string eventName, params object[] args);

        IVehicle CreateVehicle(uint model, Position pos, Rotation rotation);
        IPed CreatePed(uint model, Position pos, Rotation rotation);

        ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height, Rgba color, uint streamingDistance);

        IBlip CreateBlip(IPlayer player, byte type, Position pos);

        IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach);

        IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance);

        IColShape CreateColShapeCylinder(Position pos, float radius, float height);

        IColShape CreateColShapeSphere(Position pos, float radius);

        IColShape CreateColShapeCircle(Position pos, float radius);

        IColShape CreateColShapeCube(Position pos, Position pos2);

        IColShape CreateColShapeRectangle(float x1, float y1, float x2, float y2, float z);

        IColShape CreateColShapePolygon(float minZ, float maxZ, Vector2[] points);

        [Obsolete("Use blip.Destroy() instead")]
        void RemoveBlip(IBlip blip);

        [Obsolete("Use checkpoint.Destroy() instead")]
        void RemoveCheckpoint(ICheckpoint checkpoint);

        [Obsolete("Use vehicle.Destroy() instead")]
        void RemoveVehicle(IVehicle vehicle);

        [Obsolete("Use channel.Destroy() instead")]
        void RemoveVoiceChannel(IVoiceChannel channel);

        [Obsolete("Use colShape.Destroy() instead")]
        void RemoveColShape(IColShape colShape);

        INativeResource GetResource(string name);

        INativeResource GetResource(IntPtr resourcePointer);

        // Only for advanced use cases

        IntPtr CreateVehicleEntity(out uint id, uint model, Position pos, Rotation rotation);
        IntPtr CreatePedEntity(out uint id, uint model, Position pos, Rotation rotation);

        IReadOnlyCollection<IPlayer> GetAllPlayers();
        IReadOnlyCollection<IVehicle> GetAllVehicles();
        IReadOnlyCollection<IBlip> GetAllBlips();
        IReadOnlyCollection<ICheckpoint> GetAllCheckpoints();
        IReadOnlyCollection<IVirtualEntity> GetAllVirtualEntities();
        IReadOnlyCollection<IVirtualEntityGroup> GetAllVirtualEntityGroups();
        IReadOnlyCollection<IPed> GetAllPeds();

        IEntity GetEntityById(uint id);

        void StartResource(string name);

        void StopResource(string name);

        void RestartResource(string name);

        void SetSyncedMetaData(string key, object value);

        void DeleteSyncedMetaData(string key);

        bool FileExists(string path);
        string FileRead(string path);
        byte[] FileReadBinary(string path);
        IConfig GetServerConfig();

        void SetWorldProfiler(bool state);
        IEnumerable<string> GetRegisteredClientEvents();
        IEnumerable<string> GetRegisteredServerEvents();

        IBaseObject[] GetClosestEntities(Position position, int range, int dimension, int limit,
            EntityType allowedTypes);
        IBaseObject[] GetEntitiesInDimension(int dimension, EntityType allowedTypes);
        IBaseObject[] GetEntitiesInRange(Position position, int range, int dimension, EntityType allowedTypes);
        IntPtr CreateVirtualEntityEntity(out uint id, IVirtualEntityGroup group, Position position, uint streamingDistance, Dictionary<string, object> dataDict);
        IntPtr CreateVirtualEntityGroupEntity(out uint id, uint streamingDistance);
        IntPtr CreateMarkerEntity(out uint id, IPlayer player, MarkerType type, Position pos, Rgba color);
        IBaseObject GetBaseObject(BaseObjectType type, uint id);
    }
}