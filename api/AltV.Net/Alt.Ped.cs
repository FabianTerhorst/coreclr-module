using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace AltV.Net
{
    public partial class Alt
    {
        public static IPed CreatePed(uint model, Position pos, Rotation rot) =>
            Core.CreatePed(model, pos, rot);

        public static IPed CreatePed(PedModel model, Position pos, Rotation rot) =>
            Core.CreatePed((uint)model, pos, rot);

        public static IPed CreatePed(string model, Position pos, Rotation rot) =>
            Core.CreatePed(Core.Hash(model), pos, rot);
    }
}