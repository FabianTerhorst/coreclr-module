using System.Runtime.InteropServices;
using AltV.Net.CApi.ClientEvents;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client
{
    public class Discord
    {
        private readonly ICore core;

        public Discord(ICore core)
        {
            this.core = core;
        }

        public async Task<string> RequestOAuth2Token(string appId)
        {
            GCHandle handle;
            bool resultSuccess = false;
            string data = null;
            var semaphore = new SemaphoreSlim(0, 1);

            unsafe
            {
                void ResolveTask(bool success, string token)
                {
                    resultSuccess = success;
                    data = token;
                    semaphore.Release();
                }

                DiscordOAuth2TokenResultModuleDelegate resolveTask = ResolveTask;
                handle = GCHandle.Alloc(resolveTask);
                var appIdPtr = MemoryUtils.StringToHGlobalUtf8(appId);
                core.Library.Client.Core_Discord_GetOAuth2Token(core.NativePointer, appIdPtr, resolveTask);
                Marshal.FreeHGlobal(appIdPtr);
            }

            await semaphore.WaitAsync();
            handle.Free();
            semaphore.Dispose();

            if (!resultSuccess) throw new Exception("Failed to request OAuth2 token");

            return data;
        }
    }
}