using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IServer
    {
        int NetTime { get; }

        string RootDirectory { get; }

        INativeResource Resource { get; }

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

        public void TriggerServerEvent(string eventName, params MValueConst[] args);

        public void TriggerServerEvent(IntPtr eventNamePtr, params MValueConst[] args);

        public void TriggerServerEvent(string eventName, IntPtr[] args);

        public void TriggerServerEvent(IntPtr eventNamePtr, IntPtr[] args);

        public void TriggerServerEvent(IntPtr eventNamePtr, params object[] args);

        public void TriggerServerEvent(string eventName, params object[] args);

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params MValueConst[] args);

        public void TriggerClientEvent(IPlayer player, string eventName, params MValueConst[] args);

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, IntPtr[] args);

        public void TriggerClientEvent(IPlayer player, string eventName, IntPtr[] args);

        public void TriggerClientEvent(IPlayer player, IntPtr eventNamePtr, params object[] args);
        public void TriggerClientEvent(IPlayer player, string eventName, params object[] args);

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

        INativeResource GetResource(string name);

        // Only for advanced use cases

        IntPtr CreateVehicleEntity(out ushort id, uint model, Position pos, Rotation rotation);

        IEnumerable<IPlayer> GetPlayers();

        IEnumerable<IVehicle> GetVehicles();

        void StartResource(string name);

        void StopResource(string name);

        void RestartResource(string name);

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

        void CreateMValue(out MValueConst mValue, object obj);

        void CreateMValues(MValueConst[] mValues, object[] objects);
    }
}