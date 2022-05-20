using AltV.Net.Client.Elements.Interfaces;
using HttpClient = AltV.Net.Client.Elements.Entities.HttpClient;

namespace AltV.Net.Client.Elements.Factories
{
    public class HttpClientFactory : IBaseObjectFactory<IHttpClient>
    {
        public IHttpClient Create(ICore core, IntPtr nativePointer)
        {
            return new HttpClient(core, nativePointer);
        }
    }
}