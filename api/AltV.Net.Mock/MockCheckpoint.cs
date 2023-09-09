using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockCheckpoint : MockColShape, ICheckpoint
    {
        public MockCheckpoint(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, id)
        {
        }


        public IntPtr CheckpointNativePointer { get; }
        public byte CheckpointType { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }
        public Rgba Color { get; set; }

        public Position NextPosition { get; set; }
        public uint StreamingDistance { get; }
        public bool Visible { get; set; }
        public void SetStreamSyncedMetaData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void SetStreamSyncedMetaData(Dictionary<string, object> metaData)
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

        public bool HasStreamSyncedMetaData(string key)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out int result)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out uint result)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData(string key, out float result)
        {
            throw new NotImplementedException();
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            throw new NotImplementedException();
        }

        public bool GetStreamSyncedMetaData<T>(string key, out T result)
        {
            throw new NotImplementedException();
        }
    }
}