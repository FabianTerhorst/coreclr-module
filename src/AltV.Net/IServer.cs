using System;
using AltV.Net.Elements.Entities;
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

        void TriggerClientEvent(IPlayer player, string eventName, params MValue[] args);

        IVehicle CreateVehicle(uint model, Position pos, float heading);

        void RemoveEntity(IEntity entity);
    }
}