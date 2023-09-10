using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class HttpClientPool : BaseObjectPool<IHttpClient>
    {
        public HttpClientPool(IBaseObjectFactory<IHttpClient> httpClientFactory) : base(httpClientFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.HttpClient_GetID(entityPointer);
            }
        }
    }
}