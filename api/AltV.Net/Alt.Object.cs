using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IObject CreateObject(uint model, Position position, Rotation rotation, byte alpha = 255, byte textureVariation = 0, ushort lodDistance = 100, uint streamingDistance = 0) =>
            Core.CreateObject(model, position, rotation, alpha, textureVariation, lodDistance, streamingDistance);

        public static IObject CreateObject(string model, Position position, Rotation rotation, byte alpha = 255, byte textureVariation = 0, ushort lodDistance = 100, uint streamingDistance = 0) =>
            Core.CreateObject(Core.Hash(model), position, rotation, alpha, textureVariation, lodDistance, streamingDistance);
    }
}