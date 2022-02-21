using AltV.Net.Client.CApi.Events;
using AltV.Net.Client.Events;

namespace AltV.Net.Client
{
    public partial class Alt
    {
        public static event TickDelegate OnTick
        {
            add => Module.TickEventHandler.Add(value);
            remove => Module.TickEventHandler.Remove(value);
        }
    }
}