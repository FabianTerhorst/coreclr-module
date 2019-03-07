using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net
{
    public interface IServer
    {
        /// <summary>
        /// TODO
        /// </summary>
        void LogInfo(string message);

        /// <summary>
        /// TODO
        /// </summary>
        void LogDebug(string message);

        /// <summary>
        /// TODO
        /// </summary>
        void LogWarning(string message);

        /// <summary>
        /// TODO
        /// </summary>
        void LogError(string message);

        /// <summary>
        /// TODO
        /// </summary>
        void LogColored(string message);

        /// <summary>
        /// TODO
        /// </summary>
        uint Hash(string hash);

        void TriggerServerEvent(string eventName, params MValue[] args);

        void TriggerServerEvent(string eventName, params object[] args);
        
        void TriggerServerEvent(string eventName, ref MValue args);

        void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args);

        void TriggerClientEvent(IPlayer player, string eventName, params object[] args);
        
        void TriggerClientEvent(IPlayer player, string eventName, ref MValue args);

        IVehicle CreateVehicle(uint model, Position pos, float heading);

        ICheckpoint CreateCheckpoint(IPlayer player, byte type, Position pos, float radius, float height, Rgba color);

        IBlip CreateBlip(IPlayer player, byte type, Position pos);

        IBlip CreateBlip(IPlayer player, byte type, IEntity entityAttach);

        void RemoveEntity(IEntity entity);
        
        void RemoveBlip(IBlip blip);
        
        void RemoveCheckpoint(ICheckpoint checkpoint);
        
        void RemoveVehicle(IVehicle vehicle);

        ServerNativeResource GetResource(string name);
    }
}