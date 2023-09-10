using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        public static Task<IPed> CreatePed(uint model, Position pos, Rotation rot) => AltVAsync.Schedule(() =>
            Alt.Core.CreatePed(model, pos, rot));

        public static Task<IPed> CreatePed(PedModel model, Position pos, Rotation rot) =>
            CreatePed((uint)model, pos, rot);

        public static Task<IPed> CreatePed(string model, Position pos, Rotation rot) =>
            CreatePed(Alt.Hash(model), pos, rot);

    }
}
