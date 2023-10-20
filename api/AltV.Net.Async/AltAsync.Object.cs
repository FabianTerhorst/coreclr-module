using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public partial class AltAsync
    {
        public static Task<IObject> CreateObject(uint model, Position position, Rotation rotation, byte alpha = 255, byte textureVariation = 0, ushort lodDistance = 100) =>
            AltVAsync.Schedule(() => Alt.CreateObject(model, position, rotation, alpha, textureVariation, lodDistance));

        public static Task<IObject> CreateObject(string model, Position position, Rotation rotation, byte alpha = 255, byte textureVariation = 0, ushort lodDistance = 100) =>
            AltVAsync.Schedule(() => Alt.CreateObject(Alt.Hash(model), position, rotation, alpha, textureVariation, lodDistance));
    }
}