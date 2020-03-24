using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client.Events
{
    public delegate void SyncedMetaChangeEventDelegate(IEntity entity, string key, object value);
}