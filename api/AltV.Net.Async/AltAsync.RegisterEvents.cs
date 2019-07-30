using AltV.Net.FunctionParser;

namespace AltV.Net.Async
{
    public partial class AltAsync
    {
        public static void RegisterEvents(object target)
        {
            MethodIndexer.Index<AsyncEvent>(target,
                (eventName, eventMethod) => { Module.On(eventName, eventMethod); });
        }
    }
}