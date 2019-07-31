using AltV.Net.Elements.Entities;
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
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(string)});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerConnect += (player, reason) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(reason);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.ServerEvent:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(string), typeof(object[])});
                                    if (scriptFunction == null) return;
                                    Alt.OnServerEvent += (serverEventName, serverEventArgs) =>
                                    {
                                        scriptFunction.Set(serverEventName);
                                        scriptFunction.Set(serverEventArgs);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.VehicleRemove:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] {typeof(IVehicle)});
                                    if (scriptFunction == null) return;
                                    Alt.OnVehicleRemove += vehicle =>
                                    {
                                        scriptFunction.Set(vehicle);
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