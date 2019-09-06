using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IVoiceChannel CreateVoiceChannel(bool spatial, float maxDistance) =>
            Module.Server.CreateVoiceChannel(spatial, maxDistance);

        public static void RemoveVoiceChannel(IVoiceChannel channel) =>
            Module.Server.RemoveVoiceChannel(channel);
    }
}