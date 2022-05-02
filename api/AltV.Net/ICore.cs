using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.CApi;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Data;

namespace AltV.Net
{
    public interface ICore : ISharedCore
    {
        new IBaseBaseObjectPool BaseBaseObjectPool { get; }
        new IEntityPool<IPlayer> PlayerPool { get;  }
        new IEntityPool<IVehicle> VehiclePool { get; }
        IBaseObjectPool<IBlip> BlipPool { get; }
        IBaseObjectPool<ICheckpoint> CheckpointPool { get; }
        IBaseObjectPool<IVoiceChannel> VoiceChannelPool { get; }
        IBaseObjectPool<IColShape> ColShapePool { get; }
        INativeResourcePool NativeResourcePool { get; }
        
        int NetTime { get; }

        string RootDirectory { get; }

        INativeResource Resource { get; }
        IBaseEntityPool BaseEntityPool { get; }

        ulong HashPassword(string password);

        void SetPassword(string password);

        public VehicleModelInfo GetVehicleModelInfo(uint hash);

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

        IVehicle CreateVehicle(uint model, Position pos, Rotation rotation);

        ICheckpoint CreateCheckpoint(byte type, Position pos, float radius, float height, Rgba color);

        IBlip CreateBlip(IPlayer player, byte type, Position pos);

        IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach);

        IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance);

        IColShape CreateColShapeCylinder(Position pos, float radius, float height);

        IColShape CreateColShapeSphere(Position pos, float radius);

        IColShape CreateColShapeCircle(Position pos, float radius);

        IColShape CreateColShapeCube(Position pos, Position pos2);

        IColShape CreateColShapeRectangle(float x1, float y1, float x2, float y2, float z);

        IColShape CreateColShapePolygon(float minZ, float maxZ, Vector2[] points);

        void RemoveBlip(IBlip blip);

        void RemoveCheckpoint(ICheckpoint checkpoint);

        void RemoveVehicle(IVehicle vehicle);

        void RemoveVoiceChannel(IVoiceChannel channel);

        void RemoveColShape(IColShape colShape);

        INativeResource GetResource(string name);

        INativeResource GetResource(IntPtr resourcePointer);

        // Only for advanced use cases

        IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation);

        IPlayer[] GetPlayers();

        IVehicle[] GetVehicles();

        IEntity GetEntityById(ushort id);

        void StartResource(string name);

        void StopResource(string name);

        void RestartResource(string name);
        
        void SetSyncedMetaData(string key, object value);

        void DeleteSyncedMetaData(string key);
        
        bool FileExists(string path);
        string FileRead(string path);
        byte[] FileReadBinary(string path);
        IConfig GetServerConfig();
    }
}