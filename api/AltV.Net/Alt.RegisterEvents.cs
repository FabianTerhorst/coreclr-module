using AltV.Net.FunctionParser;

namespace AltV.Net
{
    public partial class Alt
    {
        public static void RegisterEvents(object target)
        {
            MethodIndexer.Index<Event>(target,
                (eventName, eventMethod) => { Module.On(eventName, eventMethod); });
        }
    }
}