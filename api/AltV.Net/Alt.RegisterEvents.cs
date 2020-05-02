using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.FunctionParser;

namespace AltV.Net
{
    public partial class Alt
    {
        public static void RegisterEvents(object target)
        {
#pragma warning disable 612, 618
            ModuleScriptMethodIndexer.Index(target, new[] {typeof(EventAttribute), typeof(ServerEventAttribute), typeof(ClientEventAttribute), typeof(ScriptEventAttribute)},
#pragma warning restore 612, 618
                (baseEvent, eventMethod, eventMethodDelegate) =>
                {
                    switch (baseEvent)
                    {
                        case ScriptEventAttribute scriptEvent:
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
                                        scriptFunction.Call();
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
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.PlayerDamage:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(IEntity), typeof(uint), typeof(ushort)});
                                    if (scriptFunction == null) return;
                                    OnPlayerDamage += (player, attacker, weapon, damage) =>
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
                                    OnPlayerDead += (player, attacker, weapon) =>
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
                                    OnPlayerDisconnect += (player, reason) =>
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
                                    OnPlayerRemove += player =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.VehicleRemove:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] {typeof(IVehicle)});
                                    if (scriptFunction == null) return;
                                    OnVehicleRemove += vehicle =>
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
                                    OnPlayerChangeVehicleSeat += (vehicle, player, seat, newSeat) =>
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
                                    OnPlayerEnterVehicle += (vehicle, player, seat) =>
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
                                    OnPlayerLeaveVehicle += (vehicle, player, seat) =>
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
                                    OnPlayerEvent += (player, name, args) =>
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
                                            new[] {typeof(IPlayer), typeof(string), typeof(MValueConst[])});
                                    if (scriptFunction == null) return;
                                    OnPlayerCustomEvent += (player, name, array) =>
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
                                    OnServerEvent += (scriptEventName, scriptEventArgs) =>
                                    {
                                        scriptFunction.Set(scriptEventName);
                                        scriptFunction.Set(scriptEventArgs);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.ServerCustomEvent:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(string), typeof(MValueConst[])});
                                    if (scriptFunction == null) return;
                                    OnServerCustomEvent += (name, array) =>
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
                                    OnConsoleCommand += (name, args) =>
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
                                    OnMetaDataChange += (entity, key, value) =>
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
                                    OnSyncedMetaDataChange += (entity, key, value) =>
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
                                    OnColShape += (shape, entity, state) =>
                                    {
                                        scriptFunction.Set(shape);
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(state);
                                        scriptFunction.Call();
                                    };
                                    break;
                                case ScriptEventType.WeaponDamage:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(IEntity), typeof(uint), typeof(ushort),
                                            typeof(Position), typeof(BodyPart)
                                        });
                                    if (scriptFunction == null) return;
                                    OnWeaponDamage +=
                                        (player, targetEntity, weapon, damage, shotOffset, damageOffset) =>
                                        {
                                            scriptFunction.Set(player);
                                            scriptFunction.Set(targetEntity);
                                            scriptFunction.Set(weapon);
                                            scriptFunction.Set(damage);
                                            scriptFunction.Set(shotOffset);
                                            scriptFunction.Set(damageOffset);
                                            if (scriptFunction.Call() is bool value)
                                            {
                                                return value;
                                            }

                                            return true;
                                        };
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            break;
#pragma warning disable 612, 618
                        case EventAttribute @event:
                            var eventName = @event.Name ?? eventMethod.Name;
                            Module.On(eventName, Function.Create(eventMethodDelegate));
                            break;
#pragma warning restore 612, 618
                        case ServerEventAttribute @event:
                            var serverEventName = @event.Name ?? eventMethod.Name;
                            Module.OnServer(serverEventName, Function.Create(eventMethodDelegate));
                            break;
                        case ClientEventAttribute @event:
                            var clientEventName = @event.Name ?? eventMethod.Name;
                            Module.OnClient(clientEventName, Function.Create(eventMethodDelegate));
                            break;
                    }
                });
        }
    }
}