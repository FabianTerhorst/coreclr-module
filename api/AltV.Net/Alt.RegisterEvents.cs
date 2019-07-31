using AltV.Net.FunctionParser;

namespace AltV.Net
{
    public partial class Alt
    {
        public static void RegisterEvents(object target)
        {
            MethodIndexer.Index(target, new[] {typeof(Event), typeof(ScriptEvent)},
                (baseEvent, eventMethod, eventMethodDelegate) =>
                {
                    switch (baseEvent)
                    {
                        case ScriptEvent scriptEvent:
                            var scriptEventType = scriptEvent.EventType;
                            ScriptFunction scriptFunction;
                            switch (scriptEventType)
                            {
                                case ScriptEventType.PlayerConnect:
                                    scriptFunction = ScriptFunction.Create(2, eventMethodDelegate);
                                    Alt.OnPlayerConnect += (player, reason) =>
                                    {
                                        scriptFunction.Args[0] = player;
                                        scriptFunction.Args[1] = reason;
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.ServerEvent:
                                    scriptFunction = ScriptFunction.Create(2, eventMethodDelegate);
                                    Alt.OnServerEvent += (serverEventName, serverEventArgs) =>
                                    {
                                        scriptFunction.Args[0] = serverEventName;
                                        scriptFunction.Args[1] = serverEventArgs;
                                        scriptFunction.Call();
                                    };
                                    break;
                            }

                            break;
                        case Event @event:
                            var eventName = @event.Name ?? eventMethod.Name;
                            Module.On(eventName, Function.Create(eventMethodDelegate));
                            break;
                    }
                });
        }
    }
}