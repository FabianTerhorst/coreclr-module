using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class WebSocketClientPool : BaseObjectPool<IWebSocketClient>
    {
        public WebSocketClientPool(IBaseObjectFactory<IWebSocketClient> webSocketClientFactory) : base(webSocketClientFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.WebSocketClient_GetID(entityPointer);
            }
        }
    }
}