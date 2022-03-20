using AltV.Net.CApi;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Shared
{
    public interface ISharedCore : ICApiCore
    {
        IReadOnlyEntityPool<ISharedPlayer> PlayerPool { get; }
        IReadOnlyEntityPool<ISharedVehicle> VehiclePool { get; }
        IReadOnlyBaseBaseObjectPool BaseBaseObjectPool { get; }
        
        IntPtr NativePointer { get; }

        void LogInfo(string message);
        
        uint Hash(string hash);

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

        string PtrToStringUtf8AndFree(nint str, int size);
    }
}