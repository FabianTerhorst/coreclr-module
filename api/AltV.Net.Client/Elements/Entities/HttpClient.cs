using System.Runtime.InteropServices;
using AltV.Net.CApi.ClientEvents;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Entities
{
    public class HttpClient : BaseObject, IHttpClient
    {
        public IntPtr HttpClientNativePointer { get; }
        public override IntPtr NativePointer => HttpClientNativePointer;

        private static IntPtr GetBaseObjectNativePointer(ICore core, IntPtr httpClientNativePointer)
        {
            unsafe
            {
                return core.Library.Client.HttpClient_GetBaseObject(httpClientNativePointer);
            }
        }

        public HttpClient(ICore core, IntPtr httpClientNativePointer, uint id) : base(core, GetBaseObjectNativePointer(core, httpClientNativePointer), BaseObjectType.HttpClient, id)
        {
            HttpClientNativePointer = httpClientNativePointer;
        }

        [Obsolete("Use Alt.CreateHttpClient instead")]
        public HttpClient(ICore core) : this(core, core.CreateHttpClientPtr(out var id), id)
        {
            core.PoolManager.HttpClient.Add(this);
        }

        public void SetExtraHeader(string key, string value)
        {
            unsafe
            {
                CheckIfEntityExists();
                var keyPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var valuePtr = MemoryUtils.StringToHGlobalUtf8(value);
                Core.Library.Client.HttpClient_SetExtraHeader(HttpClientNativePointer, keyPtr, valuePtr);
                Marshal.FreeHGlobal(keyPtr);
                Marshal.FreeHGlobal(valuePtr);
            }
        }

        public Dictionary<string, string> GetExtraHeaders()
        {
            unsafe
            {
                CheckIfEntityExists();
                int size = 0;
                var keysPtr = IntPtr.Zero;
                var valuesPtr = IntPtr.Zero;
                Core.Library.Client.HttpClient_GetExtraHeaders(HttpClientNativePointer, &keysPtr, &valuesPtr, &size);
                var keys = Core.MarshalStringArrayPtrAndFree(keysPtr, (uint) size);
                var values = Core.MarshalStringArrayPtrAndFree(valuesPtr, (uint) size);
                return keys
                    .Select((e, i) => new KeyValuePair<string, string>(e, values[i]))
                    .ToDictionary(e => e.Key, e => e.Value);
            }
        }

        private HttpResponse GetHttpResponse(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
        {
            var keys = Core.MarshalStringArrayPtrAndFree(headerKeys, (uint) headerSize);
            var values = Core.MarshalStringArrayPtrAndFree(headerValues, (uint) headerSize);
            var headers = keys
                .Select((e, i) => new KeyValuePair<string, string>(e, values[i]))
                .ToDictionary(e => e.Key, e => e.Value);
            return new HttpResponse
            {
                Body = body,
                StatusCode = statusCode,
                Headers = headers
            };
        }

        public async Task<HttpResponse> Get(string url)
        {
            CheckIfEntityExists();
            GCHandle handle;
            HttpResponse? data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
                {
                    data = GetHttpResponse(statusCode, body, headerKeys, headerValues, headerSize);
                    semaphore.Release();
                }

                HttpResponseModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                Core.Library.Client.HttpClient_Get(NativePointer, urlPtr, resolveTask);
                Marshal.FreeHGlobal(urlPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data.Value;
        }

        public async Task<HttpResponse> Head(string url)
        {
            CheckIfEntityExists();
            GCHandle handle;
            HttpResponse? data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
                {
                    data = GetHttpResponse(statusCode, body, headerKeys, headerValues, headerSize);
                    semaphore.Release();
                }

                HttpResponseModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                Core.Library.Client.HttpClient_Head(NativePointer, urlPtr, resolveTask);
                Marshal.FreeHGlobal(urlPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data.Value;
        }

        public async Task<HttpResponse> Connect(string url, string body)
        {
            CheckIfEntityExists();
            GCHandle handle;
            HttpResponse? data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
                {
                    data = GetHttpResponse(statusCode, body, headerKeys, headerValues, headerSize);
                    semaphore.Release();
                }

                HttpResponseModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var bodyPtr = MemoryUtils.StringToHGlobalUtf8(body);
                Core.Library.Client.HttpClient_Connect(NativePointer, urlPtr, bodyPtr, resolveTask);
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(bodyPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data.Value;
        }

        public async Task<HttpResponse> Delete(string url, string body)
        {
            CheckIfEntityExists();
            GCHandle handle;
            HttpResponse? data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
                {
                    data = GetHttpResponse(statusCode, body, headerKeys, headerValues, headerSize);
                    semaphore.Release();
                }

                HttpResponseModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var bodyPtr = MemoryUtils.StringToHGlobalUtf8(body);
                Core.Library.Client.HttpClient_Delete(NativePointer, urlPtr, bodyPtr, resolveTask);
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(bodyPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data.Value;
        }

        public async Task<HttpResponse> Options(string url, string body)
        {
            CheckIfEntityExists();
            GCHandle handle;
            HttpResponse? data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
                {
                    data = GetHttpResponse(statusCode, body, headerKeys, headerValues, headerSize);
                    semaphore.Release();
                }

                HttpResponseModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var bodyPtr = MemoryUtils.StringToHGlobalUtf8(body);
                Core.Library.Client.HttpClient_Options(NativePointer, urlPtr, bodyPtr, resolveTask);
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(bodyPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data.Value;
        }

        public async Task<HttpResponse> Patch(string url, string body)
        {
            CheckIfEntityExists();
            GCHandle handle;
            HttpResponse? data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
                {
                    data = GetHttpResponse(statusCode, body, headerKeys, headerValues, headerSize);
                    semaphore.Release();
                }

                HttpResponseModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var bodyPtr = MemoryUtils.StringToHGlobalUtf8(body);
                Core.Library.Client.HttpClient_Patch(NativePointer, urlPtr, bodyPtr, resolveTask);
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(bodyPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data.Value;
        }

        public async Task<HttpResponse> Post(string url, string body)
        {
            CheckIfEntityExists();
            GCHandle handle;
            HttpResponse? data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
                {
                    data = GetHttpResponse(statusCode, body, headerKeys, headerValues, headerSize);
                    semaphore.Release();
                }

                HttpResponseModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var bodyPtr = MemoryUtils.StringToHGlobalUtf8(body);
                Core.Library.Client.HttpClient_Post(NativePointer, urlPtr, bodyPtr, resolveTask);
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(bodyPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data.Value;
        }

        public async Task<HttpResponse> Put(string url, string body)
        {
            CheckIfEntityExists();
            GCHandle handle;
            HttpResponse? data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
                {
                    data = GetHttpResponse(statusCode, body, headerKeys, headerValues, headerSize);
                    semaphore.Release();
                }

                HttpResponseModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var bodyPtr = MemoryUtils.StringToHGlobalUtf8(body);
                Core.Library.Client.HttpClient_Put(NativePointer, urlPtr, bodyPtr, resolveTask);
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(bodyPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data.Value;
        }

        public async Task<HttpResponse> Trace(string url, string body)
        {
            CheckIfEntityExists();
            GCHandle handle;
            HttpResponse? data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize)
                {
                    data = GetHttpResponse(statusCode, body, headerKeys, headerValues, headerSize);
                    semaphore.Release();
                }

                HttpResponseModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var bodyPtr = MemoryUtils.StringToHGlobalUtf8(body);
                Core.Library.Client.HttpClient_Trace(NativePointer, urlPtr, bodyPtr, resolveTask);
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(bodyPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            return data.Value;
        }
    }
}