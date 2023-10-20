namespace AltV.Net.Elements.Entities
{
    public enum BaseObjectType : byte
    {
        Player,
        Vehicle,
        Ped,
        Object,
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
        LocalObject,
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