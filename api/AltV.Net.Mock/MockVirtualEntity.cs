using System;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVirtualEntity : MockWorldObject, IVirtualEntity
    {
        public MockVirtualEntity(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, BaseObjectType.VirtualEntity, id)
        {
        }

        public IntPtr VirtualEntityNativePointer { get; }
        public ISharedVirtualEntityGroup Group { get; }
        public bool HasStreamSyncedMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public uint StreamingDistance { get; }
        public bool Visible { get; set; }

        public void SetStreamSyncedMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            throw new NotImplementedException();
        }

        public void DeleteStreamSyncedMetaData(string key)
        {
            throw new NotImplementedException();
        }
    }
}