using AltV.Net.Client.Elements.Data;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IHttpClient : IBaseObject
    {
        IntPtr HttpClientNativePointer { get; }
        void SetExtraHeader(string key, string value);
        Dictionary<string, string> GetExtraHeaders();
        Task<HttpResponse> Get(string url);
        Task<HttpResponse> Head(string url);
        Task<HttpResponse> Connect(string url, string body);
        Task<HttpResponse> Delete(string url, string body);
        Task<HttpResponse> Options(string url, string body);
        Task<HttpResponse> Patch(string url, string body);
        Task<HttpResponse> Post(string url, string body);
        Task<HttpResponse> Put(string url, string body);
        Task<HttpResponse> Trace(string url, string body);
    }
}