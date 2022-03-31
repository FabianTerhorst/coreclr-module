using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client
{
    public partial class Alt
    {
        public static void RemoveBlip(IBlip blip) => Core.RemoveBlip(blip);
    }
}