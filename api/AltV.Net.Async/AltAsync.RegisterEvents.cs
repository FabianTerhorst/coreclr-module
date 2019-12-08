using AltV.Net.Elements.Entities;
using AltV.Net.FunctionParser;

namespace AltV.Net.Async
{
    public partial class AltAsync
    {
        public static void RegisterEvents(object target)
        {
#pragma warning disable 612, 618
            ModuleScriptMethodIndexer.Index(target, new[] {typeof(AsyncEventAttribute), typeof(AsyncServerEventAttribute), typeof(AsyncClientEventAttribute), typeof(AsyncScriptEventAttribute)},
#pragma warning restore 612, 618
                (baseEvent, eventMethod, eventMethodDelegate) =>
                {
                    switch (baseEvent)
                    {
                        case AsyncScriptEventAttribute scriptEvent:
                            var scriptEventType = scriptEvent.EventType;
                            ScriptFunction scriptFunction;
                            switch (scriptEventType)
                            {
                                case ScriptEventType.Checkpoint:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(ICheckpoint), typeof(IEntity), typeof(bool)});
                                    if (scriptFunction == null) return;
                                    OnCheckpoint += (checkpoint, entity, state) =>
                                    {
                                        scriptFunction.Set(checkpoint);
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(state);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerConnect:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(string)});
                                    if (scriptFunction == null) return;
                                    OnPlayerConnect += (player, reason) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(reason);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerDamage:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(IEntity), typeof(uint), typeof(ushort)});
                                    if (scriptFunction == null) return;
                                    OnPlayerDamage += (player, attacker, 
                                        oldHealth, oldArmor, 
                                        oldMaxHealth, oldMaxArmor,
                                        weapon, damage) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(attacker);
                                        scriptFunction.Set(weapon);
                                        scriptFunction.Set(damage);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerDead:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(IEntity), typeof(uint)});
                                    if (scriptFunction == null) return;
                                    OnPlayerDead += (player, attacker, weapon) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(attacker);
                                        scriptFunction.Set(weapon);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerDisconnect:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(string)});
                                    if (scriptFunction == null) return;
                                    OnPlayerDisconnect += (player, reason) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(reason);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerRemove:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] {typeof(IPlayer)});
                                    if (scriptFunction == null) return;
                                    OnPlayerRemove += player =>
                                    {
                                        scriptFunction.Set(player);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.VehicleRemove:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] {typeof(IVehicle)});
                                    if (scriptFunction == null) return;
                                    OnVehicleRemove += vehicle =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerChangeVehicleSeat:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte), typeof(byte)});
                                    if (scriptFunction == null) return;
                                    OnPlayerChangeVehicleSeat += (vehicle, player, seat, newSeat) =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(seat);
                                        scriptFunction.Set(newSeat);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerEnterVehicle:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte)});
                                    if (scriptFunction == null) return;
                                    OnPlayerEnterVehicle += (vehicle, player, seat) =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(seat);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerLeaveVehicle:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte)});
                                    if (scriptFunction == null) return;
                                    OnPlayerLeaveVehicle += (vehicle, player, seat) =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(seat);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerEvent:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IPlayer), typeof(string), typeof(object[])});
                                    if (scriptFunction == null) return;
                                    OnPlayerEvent += (player, name, args) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(args);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerCustomEvent:
                                    Alt.Log("PlayerCustomEvent does not exists in async");
                                    break;
                                case ScriptEventType.ServerEvent:
                                    Alt.Log("PlayerCustomEvent does not exists in async");
                                    break;
                                case ScriptEventType.ServerCustomEvent:
                                    Alt.Log("PlayerCustomEvent does not exists in async");
                                    break;
                                case ScriptEventType.ConsoleCommand:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(string), typeof(string[])});
                                    if (scriptFunction == null) return;
                                    OnConsoleCommand += (name, args) =>
                                    {
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(args);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.MetaDataChange:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IEntity), typeof(string), typeof(object)});
                                    if (scriptFunction == null) return;
                                    OnMetaDataChange += (entity, key, value) =>
                                    {
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(key);
                                        scriptFunction.Set(value);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.SyncedMetaDataChange:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IEntity), typeof(string), typeof(object)});
                                    if (scriptFunction == null) return;
                                    OnSyncedMetaDataChange += (entity, key, value) =>
                                    {
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(key);
                                        scriptFunction.Set(value);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.ColShape:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IColShape), typeof(IEntity), typeof(bool)});
                                    if (scriptFunction == null) return;
                                    OnColShape += (shape, entity, state) =>
                                    {
                                        scriptFunction.Set(shape);
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(state);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                            }

                            break;
#pragma warning disable 612, 618
                        case AsyncEventAttribute @event:
                            var eventName = @event.Name ?? eventMethod.Name;
                            Module.On(eventName, Function.Create(eventMethodDelegate));
                            break;
#pragma warning restore 612, 618
                        case AsyncServerEventAttribute @event:
                            var serverEventName = @event.Name ?? eventMethod.Name;
                            Module.OnServer(serverEventName, Function.Create(eventMethodDelegate));
                            break;
                        case AsyncClientEventAttribute @event:
                            var clientEventName = @event.Name ?? eventMethod.Name;
                            Module.OnClient(clientEventName, Function.Create(eventMethodDelegate));
                            break;
                    }
                });
        }
    }
}