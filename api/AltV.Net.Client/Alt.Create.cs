using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;

namespace AltV.Net.Client
{
    public partial class Alt
    {
        public static IBlip CreatePointBlip(Position position) => Core.CreatePointBlip(position);
        public static IBlip CreateRadiusBlip(Position position, float radius) => Core.CreateRadiusBlip(position, radius);
        public static IBlip CreateAreaBlip(Position position, int width, int height) => Core.CreateAreaBlip(position, width, height);
        public static IWebView CreateWebView(string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null) => Core.CreateWebView(url, isOverlay, pos, size);
        public static IWebView CreateWebView(string url, uint propHash, string targetTexture) => Core.CreateWebView(url, propHash, targetTexture);
        public static IRmlDocument CreateRmlDocument(string url) => Core.CreateRmlDocument(url);
        public static IAudio CreateAudio(string source, float volume, uint category, bool frontend) => Core.CreateAudio(source, volume, category, frontend);
        public static IHttpClient CreateHttpClient() => Core.CreateHttpClient();
        public static IWebSocketClient CreateWebSocketClient(string url) => Core.CreateWebSocketClient(url);
    }
}