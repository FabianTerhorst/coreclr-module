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
                                        new[] {typeof(ICheckpoint), typeof(IEntity), typeof(bool)}, true);
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
                                        new[] {typeof(IPlayer), typeof(string)}, true);
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
                                        new[] {typeof(IPlayer), typeof(IEntity), typeof(uint), typeof(ushort)}, true);
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
                                        new[] {typeof(IPlayer), typeof(IEntity), typeof(uint)}, true);
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
                                        new[] {typeof(IPlayer), typeof(string)}, true);
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
                                        ScriptFunction.Create(eventMethodDelegate, new[] {typeof(IPlayer)}, true);
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
                                        ScriptFunction.Create(eventMethodDelegate, new[] {typeof(IVehicle)}, true);
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
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte), typeof(byte)}, true);
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
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte)}, true);
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
                                            new[] {typeof(IVehicle), typeof(IPlayer), typeof(byte)}, true);
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
                                            new[] {typeof(IPlayer), typeof(string), typeof(object[])}, true);
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
                                        new[] {typeof(string), typeof(string[])}, true);
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
                                        new[] {typeof(IEntity), typeof(string), typeof(object)}, true);
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
                                        new[] {typeof(IEntity), typeof(string), typeof(object)}, true);
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
                                        new[] {typeof(IColShape), typeof(IEntity), typeof(bool)}, true);
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
                                        }, true);
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
                                        }, true);
                                    if (scriptFunction == null) return;
                                    OnVehicleDestroy +=
                                        vehicle =>
                                        {
                                            var currScriptFunction = scriptFunction.Clone();
                                            currScriptFunction.Set(vehicle);
                                            return currScriptFunction.CallAsync();
                                        };
                                    break;
                                case ScriptEventType.Explosion:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(ExplosionType), typeof(Position), typeof(uint),
                                            typeof(IEntity)
                                        }, true);
                                    if (scriptFunction == null) return;
                                    OnExplosion += (player, explosionType, position, explosionFx, targetEntity) =>
                                    {
                                        var currScriptFunction = scriptFunction.Clone();
                                        currScriptFunction.Set(player);
                                        currScriptFunction.Set(explosionType);
                                        currScriptFunction.Set(position);
                                        currScriptFunction.Set(explosionFx);
                                        currScriptFunction.Set(targetEntity);
                                        return currScriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.Fire:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(FireInfo[])
                                        }, true);
                                    if (scriptFunction == null) return;
                                    OnFire += (player, fireInfos) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(fireInfos);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.StartProjectile:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(Position), typeof(Position), typeof(uint),
                                            typeof(uint)
                                        }, true);
                                    if (scriptFunction == null) return;
                                    OnStartProjectile += (player, startPosition, direction, ammoHash, weaponHash) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(startPosition);
                                        scriptFunction.Set(direction);
                                        scriptFunction.Set(ammoHash);
                                        scriptFunction.Set(weaponHash);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.PlayerWeaponChange:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(uint), typeof(uint)
                                        }, true);
                                    if (scriptFunction == null) return;
                                    OnPlayerWeaponChange += (player, oldWeapon, newWeapon) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(oldWeapon);
                                        scriptFunction.Set(newWeapon);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                 case ScriptEventType.NetOwnerChange:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IEntity), typeof(IPlayer), typeof(IPlayer)
                                        });
                                    if (scriptFunction == null) return;
                                    OnNetworkOwnerChange += (targetEntity, oldNetOwner, newNetOwner) =>
                                    {
                                        scriptFunction.Set(targetEntity);
                                        scriptFunction.Set(oldNetOwner);
                                        scriptFunction.Set(newNetOwner);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.VehicleAttach:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IVehicle), typeof(IVehicle)
                                        });
                                    if (scriptFunction == null) return;
                                    OnVehicleAttach += (targetVehicle, attachedVehicle) =>
                                    {
                                        scriptFunction.Set(targetVehicle);
                                        scriptFunction.Set(attachedVehicle);
                                        return scriptFunction.CallAsync();
                                    };
                                    break;
                                case ScriptEventType.VehicleDetach:
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IVehicle), typeof(IVehicle)
                                        });
                                    if (scriptFunction == null) return;
                                    OnVehicleDetach += (targetVehicle, detachedVehicle) =>
                                    {
                                        scriptFunction.Set(targetVehicle);
                                        scriptFunction.Set(detachedVehicle);
                                        return scriptFunction.CallAsync();
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