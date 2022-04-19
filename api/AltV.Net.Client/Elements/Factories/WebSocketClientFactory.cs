using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class WebSocketClientFactory : IBaseObjectFactory<IWebSocketClient>
    {
        public IWebSocketClient Create(ICore core, IntPtr nativePointer)
        {
            return new WebSocketClient(core, nativePointer);
        }
    }
}