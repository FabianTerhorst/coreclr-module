using System.Numerics;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Shared.Enums;

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

        public static IVirtualEntityGroup CreateVirtualEntityGroup(uint streamingDistance) => Core.CreateVirtualEntityGroup(streamingDistance);

        public static IVirtualEntity CreateVirtualEntity(IVirtualEntityGroup group, Position position,
            uint streamingDistance, Dictionary<string, object> dataDict) => Core.CreateVirtualEntity(group, position, streamingDistance, dataDict);

        public static ILocalPed CreateLocalPed(uint modelHash, int dimension, Position position, Rotation rotation,
            bool useStreaming, uint streamingDistance) =>
            Core.CreateLocalPed(modelHash, dimension, position, rotation, useStreaming, streamingDistance);

        public static ILocalPed CreateLocalPed(PedModel modelHash, int dimension, Position position, Rotation rotation,
            bool useStreaming, uint streamingDistance) =>
            Core.CreateLocalPed((uint)modelHash, dimension, position, rotation, useStreaming, streamingDistance);

        public static ILocalVehicle CreateLocalVehicle(uint modelHash, int dimension, Position position, Rotation rotation, bool useStreaming, uint streamingDistance) =>
            Core.CreateLocalVehicle(modelHash, dimension, position, rotation, useStreaming, streamingDistance);

        public static ILocalVehicle CreateLocalVehicle(VehicleModel modelHash, int dimension, Position position, Rotation rotation, bool useStreaming, uint streamingDistance) =>
            Core.CreateLocalVehicle((uint)modelHash, dimension, position, rotation, useStreaming, streamingDistance);

        public static IMarker CreateMarker(MarkerType type, Position pos, Rgba color, bool useStreaming,
            uint streamingDistance) => Core.CreateMarker(type, pos, color, useStreaming, streamingDistance);

        public static ITextLabel CreateTextLabel(string name, string fontName, float fontSize, float scale,
            Position pos,
            Rotation rot, Rgba color, float outlineWidth, Rgba outlineColor, bool useStreaming,
            uint streamingDistance) => Core.CreateTextLabel(name, fontName, fontSize, scale, pos,
            rot, color, outlineWidth, outlineColor, useStreaming, streamingDistance);

    }
}