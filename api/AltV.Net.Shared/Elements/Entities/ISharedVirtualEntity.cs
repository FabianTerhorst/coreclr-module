using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Args;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedVirtualEntity : ISharedWorldObject
    {
        IntPtr VirtualEntityNativePointer { get; }
        uint Id { get; }

        ISharedVirtualEntityGroup Group { get; }

        bool HasStreamSyncedMetaData(string key);

        bool GetStreamSyncedMetaData<T>(string key, out T result);
        void GetStreamSyncedMetaData(string key, out MValueConst value);

        uint StreamingDistance { get; }

        void SetStreamSyncedMetaData(string key, object value);
        void SetStreamSyncedMetaData(string key, in MValueConst value);
        void DeleteStreamSyncedMetaData(string key);
    }
}