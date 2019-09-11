using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;

namespace AltV.Net
{
    public interface IServer
    {
        int NetTime { get; }

        string RootDirectory { get; }
        
        NativeResource Resource { get; }

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

        uint Hash(string hash);

        void TriggerServerEvent(IntPtr eventNamePtr, params MValue[] args);

        void TriggerServerEvent(IntPtr eventNamePtr, params object[] args);

        void TriggerServerEvent(IntPtr eventNamePtr, ref MValue args);

        void TriggerServerEvent(string eventName, params MValue[] args);

        void TriggerServerEvent(string eventName, params object[] args);

        void TriggerServerEvent(string eventName, ref MValue args);

        void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params MValue[] args);

        void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params object[] args);

        void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, ref MValue args);

        void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args);

        void TriggerClientEvent(IPlayer player, string eventName, params object[] args);

        void TriggerClientEvent(IPlayer player, string eventName, ref MValue args);

        IVehicle CreateVehicle(uint model, Position pos, Rotation rotation);

        ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height, Rgba color);

        IBlip CreateBlip(IPlayer player, byte type, Position pos);

        IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach);

        IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance);

        IColShape CreateColShapeCylinder(Position pos, float radius, float height);

        IColShape CreateColShapeSphere(Position pos, float radius);

        IColShape CreateColShapeCircle(Position pos, float radius);

        IColShape CreateColShapeCube(Position pos, Position pos2);

        IColShape CreateColShapeRectangle(Position pos, Position pos2);

        void RemoveBlip(IBlip blip);

        void RemoveCheckpoint(ICheckpoint checkpoint);

        void RemoveVehicle(IVehicle vehicle);

        void RemoveVoiceChannel(IVoiceChannel channel);

        void RemoveColShape(IColShape colShape);

        NativeResource GetResource(string name);

        // Only for advanced use cases

        IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation);

        IEnumerable<IPlayer> GetPlayers();

        IEnumerable<IVehicle> GetVehicles();
    }
}