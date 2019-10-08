using AltV.Net.Elements.Entities;
using AltV.Net.FunctionParser;
using AltV.Net.Native;

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
                                case ScriptEventType.Checkpoint:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(ICheckpoint), typeof(IEntity), typeof(bool)});
                                    if (scriptFunction == null) return;
                                    Alt.OnCheckpoint += (checkpoint, entity, state) =>
                                    {
                                        scriptFunction.Set(checkpoint);
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(state);
                                        scriptFunction.Call();
                                    };
                                    break;
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
                                case ScriptEventType.PlayerDamage:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(IEntity), typeof(uint), typeof(ushort)});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerDamage += (player, attacker, weapon, damage) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(attacker);
                                        scriptFunction.Set(weapon);
                                        scriptFunction.Set(damage);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.PlayerDead:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(IEntity), typeof(uint)});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerDead += (player, attacker, weapon) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(attacker);
                                        scriptFunction.Set(weapon);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.PlayerDisconnect:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(string)});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerDisconnect += (player, reason) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(reason);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.PlayerRemove:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] {typeof(IPlayer)});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerRemove += player =>
                                    {
                                        scriptFunction.Set(player);
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
                                case ScriptEventType.PlayerChangeVehicleSeat:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte), typeof(byte)});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerChangeVehicleSeat += (vehicle, player, seat, newSeat) =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(seat);
                                        scriptFunction.Set(newSeat);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.PlayerEnterVehicle:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte)});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerEnterVehicle += (vehicle, player, seat) =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(seat);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.PlayerLeaveVehicle:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte)});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerLeaveVehicle += (vehicle, player, seat) =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(seat);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.PlayerEvent:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IPlayer), typeof(string), typeof(object[])});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerEvent += (player, name, args) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(args);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.PlayerCustomEvent:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IPlayer), typeof(string), typeof(MValueArray)});
                                    if (scriptFunction == null) return;
                                    Alt.OnPlayerCustomEvent += (IPlayer player, string name, ref MValueArray array) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(array);
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
                                case ScriptEventType.ServerCustomEvent:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(string), typeof(MValueArray)});
                                    if (scriptFunction == null) return;
                                    Alt.OnServerCustomEvent += (string name, ref MValueArray array) =>
                                    {
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(array);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.ConsoleCommand:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(string), typeof(string[])});
                                    if (scriptFunction == null) return;
                                    Alt.OnConsoleCommand += (name, args) =>
                                    {
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(args);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.MetaDataChange:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IEntity), typeof(string), typeof(object)});
                                    if (scriptFunction == null) return;
                                    Alt.OnMetaDataChange += (entity, key, value) =>
                                    {
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(key);
                                        scriptFunction.Set(value);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.SyncedMetaDataChange:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IEntity), typeof(string), typeof(object)});
                                    if (scriptFunction == null) return;
                                    Alt.OnSyncedMetaDataChange += (entity, key, value) =>
                                    {
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(key);
                                        scriptFunction.Set(value);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.ColShape:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IColShape), typeof(IEntity), typeof(bool)});
                                    if (scriptFunction == null) return;
                                    Alt.OnColShape += (shape, entity, state) =>
                                    {
                                        scriptFunction.Set(shape);
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(state);
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