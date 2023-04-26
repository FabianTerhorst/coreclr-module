using System.Numerics;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

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
        public static IObject CreateObject(uint modelHash, Position position, Rotation rotation, bool noOffset = false, bool dynamic = false) => Core.CreateObject(modelHash, position, rotation, noOffset, dynamic);
        public static IHttpClient CreateHttpClient() => Core.CreateHttpClient();
        public static IWebSocketClient CreateWebSocketClient(string url) => Core.CreateWebSocketClient(url);
        public static ICheckpoint CreateCheckpoint(CheckpointType type, Vector3 pos, Vector3 nextPos, float radius,
            float height, Rgba color, uint streamingDistance) => Core.CreateCheckpoint(type, pos, nextPos, radius, height, color, streamingDistance);

        public static IVirtualEntityGroup CreateVirtualEntityGroup(uint streamingDistance)
        {
            return new VirtualEntityGroup(Core, streamingDistance);
        }

        public static IVirtualEntity CreateVirtualEntity(IVirtualEntityGroup group, Position position,
            uint streamingDistance, Dictionary<string, object> dataDict)
        {
            return new VirtualEntity(Core, group, position, streamingDistance, dataDict);
        }
    }
}