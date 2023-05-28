using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net
{
    public partial class Alt
    {
        public static INetworkObject CreateNetworkObject(uint model, Position position, Rotation rotation, byte alpha = 255, byte textureVariation = 0, ushort lodDistance = 100) =>
            Core.CreateNetworkObject(model, position, rotation, alpha, textureVariation, lodDistance);

        public static INetworkObject CreateNetworkObject(string model, Position position, Rotation rotation, byte alpha = 255, byte textureVariation = 0, ushort lodDistance = 100) =>
            Core.CreateNetworkObject(Core.Hash(model), position, rotation, alpha, textureVariation, lodDistance);
    }
}