using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.FunctionParser;

namespace AltV.Net.Async
{
    public partial class AltAsync
    {
        public static void RegisterEvents(object target)
        {
            ModuleScriptMethodIndexer.Index(target,
                new[]
                {
                    typeof(AsyncServerEventAttribute), typeof(AsyncClientEventAttribute),
                    typeof(AsyncScriptEventAttribute)
                },
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
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(checkpoint);
                                        currScriptFunction.Set(entity);
                                        currScriptFunction.Set(state);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerConnect:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(string)});
                                    if (scriptFunction == null) return;
                                    OnPlayerConnect += (player, reason) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(player);
                                        currScriptFunction.Set(reason);
                                        return currScriptFunction.CallAsync();
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
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(player);
                                        currScriptFunction.Set(attacker);
                                        currScriptFunction.Set(weapon);
                                        currScriptFunction.Set(damage);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerDead:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(IEntity), typeof(uint)});
                                    if (scriptFunction == null) return;
                                    OnPlayerDead += (player, attacker, weapon) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(player);
                                        currScriptFunction.Set(attacker);
                                        currScriptFunction.Set(weapon);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerDisconnect:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IPlayer), typeof(string)});
                                    if (scriptFunction == null) return;
                                    OnPlayerDisconnect += (player, reason) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(player);
                                        currScriptFunction.Set(reason);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerRemove:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] {typeof(IPlayer)});
                                    if (scriptFunction == null) return;
                                    OnPlayerRemove += player =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(player);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.VehicleRemove:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] {typeof(IVehicle)});
                                    if (scriptFunction == null) return;
                                    OnVehicleRemove += vehicle =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(vehicle);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerChangeVehicleSeat:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte), typeof(byte)});
                                    if (scriptFunction == null) return;
                                    OnPlayerChangeVehicleSeat += (vehicle, player, seat, newSeat) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(vehicle);
                                        currScriptFunction.Set(player);
                                        currScriptFunction.Set(seat);
                                        currScriptFunction.Set(newSeat);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerEnterVehicle:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte)});
                                    if (scriptFunction == null) return;
                                    OnPlayerEnterVehicle += (vehicle, player, seat) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(vehicle);
                                        currScriptFunction.Set(player);
                                        currScriptFunction.Set(seat);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerLeaveVehicle:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte)});
                                    if (scriptFunction == null) return;
                                    OnPlayerLeaveVehicle += (vehicle, player, seat) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(vehicle);
                                        currScriptFunction.Set(player);
                                        currScriptFunction.Set(seat);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerEvent:
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] {typeof(IPlayer), typeof(string), typeof(object[])});
                                    if (scriptFunction == null) return;
                                    OnPlayerEvent += (player, name, args) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(player);
                                        currScriptFunction.Set(name);
                                        currScriptFunction.Set(args);
                                        return currScriptFunction.CallAsync();
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
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(name);
                                        currScriptFunction.Set(args);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.MetaDataChange:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IEntity), typeof(string), typeof(object)});
                                    if (scriptFunction == null) return;
                                    OnMetaDataChange += (entity, key, value) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(entity);
                                        currScriptFunction.Set(key);
                                        currScriptFunction.Set(value);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.SyncedMetaDataChange:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IEntity), typeof(string), typeof(object)});
                                    if (scriptFunction == null) return;
                                    OnSyncedMetaDataChange += (entity, key, value) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(entity);
                                        currScriptFunction.Set(key);
                                        currScriptFunction.Set(value);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.ColShape:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] {typeof(IColShape), typeof(IEntity), typeof(bool)});
                                    if (scriptFunction == null) return;
                                    OnColShape += (shape, entity, state) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(shape);
                                        currScriptFunction.Set(entity);
                                        currScriptFunction.Set(state);
                                        return currScriptFunction.CallAsync();
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
                                            var currScriptFunction = scriptFunction.Clone();
                                            currScriptFunction.Set(player);
                                            currScriptFunction.Set(targetEntity);
                                            currScriptFunction.Set(weapon);
                                            currScriptFunction.Set(damage);
                                            currScriptFunction.Set(shotOffset);
                                            currScriptFunction.Set(damageOffset);
                                            return currScriptFunction.CallAsync();
                                        };
                                    break;
                                case ScriptEventType.VehicleDestroy:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IVehicle)
                                        });
                                    if (scriptFunction == null) return;
                                    OnVehicleDestroy +=
                                        vehicle =>
                                        {
                                            var currScriptFunction = scriptFunction.Clone();
                                            currScriptFunction.Set(vehicle);
                                            return currScriptFunction.CallAsync();
                                        };
                                    break;
                            }

                            break;
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