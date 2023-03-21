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
        Object,
        Ped,
        VirtualEntity,
        Marker,
        TextLabel,
        Pickup,
        Undefined = 255
    }
}