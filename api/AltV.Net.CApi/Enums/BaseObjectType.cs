namespace AltV.Net.Elements.Entities
{
    public enum BaseObjectType : byte
    {
        Player,
        Vehicle,
        Ped,
        NetworkObject,
        Blip,
        Webview,
        VoiceChannel,
        ColShape,
        Checkpoint,
        WebsocketClient,
        HttpClient,
        Audio,
        AudioOutput,
        AudioOutputWorld,
        AudioOutputAttached,
        AudioOutputFrontend,
        RmlElement,
        RmlDocument,
        LocalPlayer,
        Object,
        VirtualEntity,
        VirtualEntityGroup,
        Marker,
        TextLabel,
        LocalPed,
        LocalVehicle,
        AudioFilter,
        ConnectionInfo,
        CustomTexture,
        Font,
        Size,
        Undefined = 255
    }
}