namespace AltV.Net.Elements.Entities
{
    public enum BaseObjectType : byte
    {
        Player,
        Vehicle,
        Blip,
        Webview,
        VoiceChannel,
        ColShape,
        Checkpoint,
        WebsocketClient,
        HttpClient,
        Audio,
        RmlElement,
        RmlDocument,
        LocalPlayer,
        Undefined = 255
    }
}