using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client
{
    public partial class Alt
    {
        public static void RemoveBlip(IBlip blip) => Core.RemoveBlip(blip);
        public static IBlip CreatePointBlip(Position position) => Core.CreatePointBlip(position);
        public static IBlip CreateRadiusBlip(Position position, float radius) => Core.CreateRadiusBlip(position, radius);
        public static IBlip CreateAreaBlip(Position position, int width, int height) => Core.CreateAreaBlip(position, width, height);
    }
}