namespace AltV.Net.Client.Interfaces.Entities
{
    public enum Type
    {
        Player,
        Vehicle,
        Blip,
        Webview,
        VoiceChannel,
        Colshape,
        Checkpoint,
        WebsocketClient,
        HttpClient,
        Audio,
        LocalPlayer
    }
    
    public interface IBaseObject
    {
        Type GetType();

        bool HasMetaData(string key);
        //TODO: Use MValue
        object GetMetaData(string key);
        void SetMetaData(string key, object value);
        void DeleteMetaData(string key);
    }
}