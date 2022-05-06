using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class HttpClientPool : BaseObjectPool<IHttpClient>
    {
        public HttpClientPool(IBaseObjectFactory<IHttpClient> httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}