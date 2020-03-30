using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client
{
    public static partial class Alt
    {
        public static IBlip CreateAreaBlip(float x, float y, float z, float width, float height)
        {
            return new Blip(AreaBlip.New(x, y, z, width, height));
        }

        public static IBlip CreateRadiusBlip(float x, float y, float z, float radius)
        {
            return new Blip(RadiusBlip.New(x, y, z, radius));
        }

        public static IBlip CreatePointBlip(float x, float y, float z)
        {
            return new Blip(PointBlip.New(x, y, z));
        }
    }
}