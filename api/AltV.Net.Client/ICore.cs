using AltV.Net.Client.CApi;
using AltV.Net.Client.Elements.Args;

namespace AltV.Net.Client
{
    public interface ICore
    {
        public void LogInfo(string message);
        public void LogError(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        ILibrary Library { get; }
        IntPtr NativePointer { get; }
        void CreateMValue(out MValueConst mValue, object? obj);
        uint Hash(string stringToHash);
    }
}