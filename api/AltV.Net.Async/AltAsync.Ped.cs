using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static Task<IPed> CreatePed(uint model, Position pos, Rotation rot, uint streamingDistance = 0) => AltVAsync.Schedule(() =>
            Alt.Core.CreatePed(model, pos, rot, streamingDistance));

        public static Task<IPed> CreatePed(PedModel model, Position pos, Rotation rot, uint streamingDistance = 0) =>
            CreatePed((uint)model, pos, rot, streamingDistance);

        public static Task<IPed> CreatePed(string model, Position pos, Rotation rot, uint streamingDistance = 0) =>
            CreatePed(Alt.Hash(model), pos, rot, streamingDistance);

    }
}
