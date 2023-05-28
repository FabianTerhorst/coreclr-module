using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public partial class AltAsync
    {
        public static Task<INetworkObject> CreateNetworkObject(uint model, Position position, Rotation rotation, byte alpha = 255, byte textureVariation = 0, ushort lodDistance = 100) =>
            AltVAsync.Schedule(() => Alt.CreateNetworkObject(model, position, rotation, alpha, textureVariation, lodDistance));

        public static Task<INetworkObject> CreateNetworkObject(string model, Position position, Rotation rotation, byte alpha = 255, byte textureVariation = 0, ushort lodDistance = 100) =>
            AltVAsync.Schedule(() => Alt.CreateNetworkObject(Alt.Hash(model), position, rotation, alpha, textureVariation, lodDistance));
    }
}