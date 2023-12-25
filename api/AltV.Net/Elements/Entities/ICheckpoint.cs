using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public interface ICheckpoint : ISharedCheckpoint, IColShape
    {
        void SetStreamSyncedMetaData(string key, object value);
        void SetStreamSyncedMetaData(Dictionary<string, object> metaData);
        void SetStreamSyncedMetaData(string key, in MValueConst value);
        void DeleteStreamSyncedMetaData(string key);
        bool HasStreamSyncedMetaData(string key);
        void GetStreamSyncedMetaData(string key, out MValueConst value);
        bool GetStreamSyncedMetaData<T>(string key, out T result);
    }
}