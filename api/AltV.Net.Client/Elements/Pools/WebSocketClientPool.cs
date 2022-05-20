using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class WebSocketClientPool : BaseObjectPool<IWebSocketClient>
    {
        public WebSocketClientPool(IBaseObjectFactory<IWebSocketClient> webSocketClientFactory) : base(webSocketClientFactory)
        {
        }
    }
}