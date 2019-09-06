using AltV.Net.FunctionParser;

namespace AltV.Net.Async
{
    public partial class AltAsync
    {
        public static void RegisterEvents(object target)
        {
            MethodIndexer.Index(target, new[] {typeof(AsyncEvent)},
                (baseEvent, eventMethod, eventMethodDelegate) =>
                {
                    if (!(baseEvent is AsyncEvent asyncEvent)) return;
                    var eventName = asyncEvent.Name ?? eventMethod.Name;
                    Module.On(eventName, Function.Create(eventMethodDelegate));
                });
        }
    }
}