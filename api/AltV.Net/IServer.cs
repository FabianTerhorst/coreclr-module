using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net
{
    public interface IServer
    {
        string Version { get; }
        
        string Branch { get; }
        
        public ILibrary Library { get; }
        
        int NetTime { get; }

        string RootDirectory { get; }
        
        bool IsDebug { get; }

        INativeResource Resource { get; }
        
        IntPtr NativePointer { get; }

        void LogInfo(string message);

        /// <summary>
        /// Do NOT use unless you know what you are doing
        /// </summary>
        void LogDebug(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogColored(string message);

        void LogInfo(IntPtr message);

        /// <summary>
        /// Do NOT use unless you know what you are doing
        /// </summary>
        void LogDebug(IntPtr message);

        void LogWarning(IntPtr message);

        void LogError(IntPtr message);

        void LogColored(IntPtr message);

        ulong HashPassword(string password);
        uint Hash(string hash);

        void SetPassword(string password);

        public VehicleModelInfo GetVehicleModelInfo(uint hash);

        void StopServer();

        void TriggerServerEvent(string eventName, MValueConst[] args);

        void TriggerServerEvent(IntPtr eventNamePtr, MValueConst[] args);

        void TriggerServerEvent(string eventName, IntPtr[] args);

        void TriggerServerEvent(IntPtr eventNamePtr, IntPtr[] args);

        void TriggerServerEvent(IntPtr eventNamePtr, params object[] args);

        void TriggerServerEvent(string eventName, params object[] args);

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

        void SetMetaData(string key, object value);

        bool HasMetaData(string key);

        void DeleteMetaData(string key);

        void GetMetaData(string key, out MValueConst value);
        
        void SetSyncedMetaData(string key, object value);

        bool HasSyncedMetaData(string key);

        void DeleteSyncedMetaData(string key);

        void GetSyncedMetaData(string key, out MValueConst value);

        void CreateMValueNil(out MValueConst mValue);

        void CreateMValueBool(out MValueConst mValue, bool value);

        void CreateMValueInt(out MValueConst mValue, long value);

        void CreateMValueUInt(out MValueConst mValue, ulong value);


        void CreateMValueDouble(out MValueConst mValue, double value);


        void CreateMValueString(out MValueConst mValue, string value);


        void CreateMValueList(out MValueConst mValue, MValueConst[] val, ulong size);


        void CreateMValueDict(out MValueConst mValue, string[] keys, MValueConst[] val,
            ulong size);


        void CreateMValueCheckpoint(out MValueConst mValue, ICheckpoint value);


        void CreateMValueBlip(out MValueConst mValue, IBlip value);


        void CreateMValueVoiceChannel(out MValueConst mValue, IVoiceChannel value);


        void CreateMValuePlayer(out MValueConst mValue, IPlayer value);


        void CreateMValueVehicle(out MValueConst mValue, IVehicle value);


        void CreateMValueFunction(out MValueConst mValue, IntPtr value);
        
        void CreateMValueVector3(out MValueConst mValue, Position value);
        
        void CreateMValueVector2(out MValueConst mValue, Vector2 value);
        
        void CreateMValueRgba(out MValueConst mValue, Rgba value);
        
        void CreateMValueByteArray(out MValueConst mValue, byte[] value);

        void CreateMValue(out MValueConst mValue, object obj);

        void CreateMValues(MValueConst[] mValues, object[] objects);

        bool FileExists(string path);

        string FileRead(string path);

        string PtrToStringUtf8AndFree(nint str, int size);
    }
}