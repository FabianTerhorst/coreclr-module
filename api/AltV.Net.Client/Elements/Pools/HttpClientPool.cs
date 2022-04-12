using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public class HttpClientPool : BaseObjectPool<IHttpClient>
    {
        public HttpClientPool(IBaseObjectFactory<IHttpClient> httpClientFactory) : base(httpClientFactory)
        {
        }
    }
}