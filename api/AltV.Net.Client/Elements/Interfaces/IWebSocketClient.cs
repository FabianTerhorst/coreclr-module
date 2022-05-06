using AltV.Net.Client.Elements.Data;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IWebSocketClient : IBaseObject
    {
        IntPtr WebSocketClientNativePointer { get; }
        bool AutoReconnect { get; set; }
        bool PerMessageDeflate { get; set; }
        ushort PingInterval { get; set; }
        WebSocketReadyState ReadyState { get; }
        string Url { get; set; }
        void AddSubProtocol(string subProtocol);
        string[] GetSubProtocols();
        bool Send(string message);
        bool Send(byte[] message);
        void SetExtraHeader(string name, string value);
        void Start();
        void Stop();
    }
}