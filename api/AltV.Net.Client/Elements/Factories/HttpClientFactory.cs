using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class HttpClientFactory : IBaseObjectFactory<IHttpClient>
    {
        public IHttpClient Create(ICore core, IntPtr nativePointer)
        {
            return new Entities.HttpClient(core, nativePointer);
        }
    }
}