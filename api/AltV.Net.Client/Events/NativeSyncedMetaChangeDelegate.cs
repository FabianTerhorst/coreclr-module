using WebAssembly;

namespace AltV.Net.Client.Events
{
    public delegate void NativeSyncedMetaChangeEventDelegate(JSObject entity, string key, object value);
}