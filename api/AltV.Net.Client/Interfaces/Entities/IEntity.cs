namespace AltV.Net.Client.Interfaces.Entities
{
    public interface IEntity : IBaseObject
    {
        uint Id { get; }
        // TODO: Add GetNetworkOwner() const = 0;
        uint Model { get; set; }
        //TODO: Use Rotation / Vector3
        object Rotation { get; set; }

        bool HasSyncedMetaData(string key);
        //TODO: Use MValue
        object GetSyncedMetaData(string key);
        
        bool HasStreamedSyncedMetaData(string key);
        //TODO: Use MValue
        object GetStreamedSyncedMetaData(string key);
        bool Visible { get; }
        
        int ScriptGuid { get; }
    }
}