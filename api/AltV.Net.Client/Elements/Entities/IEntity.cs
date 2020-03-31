using System.Numerics;

namespace AltV.Net.Client.Elements.Entities
{
    public interface IEntity : IWorldObject
    {
        int Id { get; }
        
        int Model { get; }
        
        int ScriptId { get; }
        
        Vector3 Rotation { get; set; }

        bool TryGetSyncedMetaData<T>(string key, out T value);
    }
}