using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.FunctionParser;
using AltV.Net.Types;

namespace AltV.Net
{
    public partial class Alt
    {
        public static void RegisterEvents(object target)
        {
            ModuleScriptMethodIndexer.Index(target,
                new[] { typeof(ServerEventAttribute), typeof(ClientEventAttribute), typeof(ScriptEventAttribute) },
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
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(ICheckpoint), typeof(IEntity), typeof(bool) });
                                    if (scriptFunction == null) return;
                                    OnCheckpoint += (checkpoint, entity, state) =>
                                    {
                                        scriptFunction.Set(checkpoint);
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(state);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerConnect:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(IPlayer), typeof(string) });
                                    if (scriptFunction == null) return;
                                    OnPlayerConnect += (player, reason) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(reason);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerDamage:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(IEntity), typeof(uint), typeof(ushort),
                                            typeof(ushort)
                                        });
                                    if (scriptFunction == null) return;
                                    OnPlayerDamage += (player, attacker, weapon, healthDamage, armourDamage) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(attacker);
                                        scriptFunction.Set(weapon);
                                        scriptFunction.Set(healthDamage);
                                        scriptFunction.Set(armourDamage);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerDead:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(IPlayer), typeof(IEntity), typeof(uint) });
                                    if (scriptFunction == null) return;
                                    OnPlayerDead += (player, attacker, weapon) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(attacker);
                                        scriptFunction.Set(weapon);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerHeal:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(IPlayer), typeof(ushort), typeof(ushort), typeof(ushort), typeof(ushort) });
                                    if (scriptFunction == null) return;
                                    OnPlayerHeal += (player, oldHealth, newHealth, oldArmour, newArmour) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(oldHealth);
                                        scriptFunction.Set(newHealth);
                                        scriptFunction.Set(oldArmour);
                                        scriptFunction.Set(newArmour);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerDisconnect:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(IPlayer), typeof(string) });
                                    if (scriptFunction == null) return;
                                    OnPlayerDisconnect += (player, reason) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(reason);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerRemove:
                                {
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] { typeof(IPlayer) });
                                    if (scriptFunction == null) return;
                                    OnPlayerRemove += player =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.VehicleRemove:
                                {
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] { typeof(IVehicle) });
                                    if (scriptFunction == null) return;
                                    OnVehicleRemove += vehicle =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PedRemove:
                                {
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate, new[] { typeof(IPed) });
                                    if (scriptFunction == null) return;
                                    OnPedRemove += ped =>
                                    {
                                        scriptFunction.Set(ped);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerChangeVehicleSeat:
                                {
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] { typeof(IVehicle), typeof(IPlayer), typeof(byte), typeof(byte) });
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
                                }
                                case ScriptEventType.PlayerEnterVehicle:
                                {
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] { typeof(IVehicle), typeof(IPlayer), typeof(byte) });
                                    if (scriptFunction == null) return;
                                    OnPlayerEnterVehicle += (vehicle, player, seat) =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(seat);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerEnteringVehicle:
                                {
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] { typeof(IVehicle), typeof(IPlayer), typeof(byte) });
                                    if (scriptFunction == null) return;
                                    OnPlayerEnteringVehicle += (vehicle, player, seat) =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(seat);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerLeaveVehicle:
                                {
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] { typeof(IVehicle), typeof(IPlayer), typeof(byte) });
                                    if (scriptFunction == null) return;
                                    OnPlayerLeaveVehicle += (vehicle, player, seat) =>
                                    {
                                        scriptFunction.Set(vehicle);
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(seat);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerEvent:
                                {
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] { typeof(IPlayer), typeof(string), typeof(object[]) });
                                    if (scriptFunction == null) return;
                                    OnPlayerEvent += (player, name, args) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(args);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerCustomEvent:
                                {
                                    scriptFunction =
                                        ScriptFunction.Create(eventMethodDelegate,
                                            new[] { typeof(IPlayer), typeof(string), typeof(MValueConst[]) });
                                    if (scriptFunction == null) return;
                                    OnPlayerCustomEvent += (player, name, array) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(array);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.ServerEvent:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(string), typeof(object[]) });
                                    if (scriptFunction == null) return;
                                    OnServerEvent += (scriptEventName, scriptEventArgs) =>
                                    {
                                        scriptFunction.Set(scriptEventName);
                                        scriptFunction.Set(scriptEventArgs);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.ServerCustomEvent:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(string), typeof(MValueConst[]) });
                                    if (scriptFunction == null) return;
                                    OnServerCustomEvent += (name, array) =>
                                    {
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(array);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.ConsoleCommand:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(string), typeof(string[]) });
                                    if (scriptFunction == null) return;
                                    OnConsoleCommand += (name, args) =>
                                    {
                                        scriptFunction.Set(name);
                                        scriptFunction.Set(args);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.MetaDataChange:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(IEntity), typeof(string), typeof(object) });
                                    if (scriptFunction == null) return;
                                    OnMetaDataChange += (entity, key, value) =>
                                    {
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(key);
                                        scriptFunction.Set(value);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.SyncedMetaDataChange:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(IEntity), typeof(string), typeof(object) });
                                    if (scriptFunction == null) return;
                                    OnSyncedMetaDataChange += (entity, key, value) =>
                                    {
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(key);
                                        scriptFunction.Set(value);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.ColShape:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[] { typeof(IColShape), typeof(IEntity), typeof(bool) });
                                    if (scriptFunction == null) return;
                                    OnColShape += (shape, entity, state) =>
                                    {
                                        scriptFunction.Set(shape);
                                        scriptFunction.Set(entity);
                                        scriptFunction.Set(state);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.WeaponDamage:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(IEntity), typeof(uint), typeof(ushort),
                                            typeof(Position), typeof(BodyPart)
                                        }, new[] {typeof(WeaponDamageResponse)});
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
                                            if (scriptFunction.Call() is uint uintValue)
                                            {
                                                return uintValue;
                                            }

                                            if (scriptFunction.Call() is bool boolValue)
                                            {
                                                return boolValue;
                                            }

                                            return 0;
                                        };
                                    break;
                                }
                                case ScriptEventType.VehicleDestroy:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IVehicle)
                                        });
                                    if (scriptFunction == null) return;
                                    OnVehicleDestroy +=
                                        vehicle =>
                                        {
                                            scriptFunction.Set(vehicle);
                                            scriptFunction.Call();
                                        };
                                    break;
                                }
                                case ScriptEventType.Explosion:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(ExplosionType), typeof(Position), typeof(uint),
                                            typeof(IEntity)
                                        }, new[] {typeof(bool) });
                                    if (scriptFunction == null) return;
                                    OnExplosion += (player, explosionType, position, explosionFx, targetEntity) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(explosionType);
                                        scriptFunction.Set(position);
                                        scriptFunction.Set(explosionFx);
                                        scriptFunction.Set(targetEntity);
                                        if (scriptFunction.Call() is bool value)
                                        {
                                            return value;
                                        }

                                        return true;
                                    };
                                    break;
                                }
                                case ScriptEventType.Fire:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(FireInfo[])
                                        },  new[] {typeof(bool) });
                                    if (scriptFunction == null) return;
                                    OnFire += (player, fireInfos) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(fireInfos);
                                        if (scriptFunction.Call() is bool value)
                                        {
                                            return value;
                                        }

                                        return true;
                                    };
                                    break;
                                }
                                case ScriptEventType.StartProjectile:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(Position), typeof(Position), typeof(uint),
                                            typeof(uint)
                                        },  new[] {typeof(bool) });
                                    if (scriptFunction == null) return;
                                    OnStartProjectile += (player, startPosition, direction, ammoHash, weaponHash) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(startPosition);
                                        scriptFunction.Set(direction);
                                        scriptFunction.Set(ammoHash);
                                        scriptFunction.Set(weaponHash);
                                        if (scriptFunction.Call() is bool value)
                                        {
                                            return value;
                                        }

                                        return true;
                                    };
                                    break;
                                }
                                case ScriptEventType.PlayerWeaponChange:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(uint), typeof(uint)
                                        });
                                    if (scriptFunction == null) return;
                                    OnPlayerWeaponChange += (player, oldWeapon, newWeapon) =>
                                    {
                                        scriptFunction.Set(player);
                                        scriptFunction.Set(oldWeapon);
                                        scriptFunction.Set(newWeapon);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.NetOwnerChange:
                                {
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
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.VehicleAttach:
                                {
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
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.VehicleDetach:
                                {
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
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.VehicleDamage:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IVehicle), typeof(IEntity), typeof(uint), typeof(uint),
                                            typeof(uint), typeof(uint), typeof(uint)
                                        });
                                    if (scriptFunction == null) return;
                                    OnVehicleDamage +=
                                        (vehicle, targetEntity, bodyHealthDamage, additionalBodyHealthDamage,
                                            engineHealthDamage, petrolTankDamage, weaponHash) =>
                                        {
                                            scriptFunction.Set(vehicle);
                                            scriptFunction.Set(targetEntity);
                                            scriptFunction.Set(bodyHealthDamage);
                                            scriptFunction.Set(additionalBodyHealthDamage);
                                            scriptFunction.Set(engineHealthDamage);
                                            scriptFunction.Set(petrolTankDamage);
                                            scriptFunction.Set(weaponHash);
                                            scriptFunction.Call();
                                        };
                                    break;
                                }
                                case ScriptEventType.VehicleHorn:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IVehicle), typeof(IPlayer), typeof(bool)
                                        },  new[] {typeof(bool) });
                                    if (scriptFunction == null) return;
                                    OnVehicleHorn += (targetVehicle, reporterPlayer, state) =>
                                    {
                                        scriptFunction.Set(targetVehicle);
                                        scriptFunction.Set(reporterPlayer);
                                        scriptFunction.Set(state);
                                        if (scriptFunction.Call() is bool value)
                                        {
                                            return value;
                                        }

                                        return true;
                                    };
                                    break;
                                }
                                case ScriptEventType.VehicleSiren:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IVehicle), typeof(bool)
                                        });
                                    if (scriptFunction == null) return;
                                    OnVehicleSiren += (targetVehicle, state) =>
                                    {
                                        scriptFunction.Set(targetVehicle);
                                        scriptFunction.Set(state);
                                        scriptFunction.Call();
                                    };
                                    break;
                                }
                                case ScriptEventType.ConnectionQueueAdd:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IConnectionInfo)
                                        });
                                    if (scriptFunction == null) return;
                                    OnConnectionQueueAdd +=
                                        (connectionInfo) =>
                                        {
                                            scriptFunction.Set(connectionInfo);
                                            scriptFunction.Call();
                                        };
                                    break;
                                }
                                case ScriptEventType.ConnectionQueueRemove:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IConnectionInfo)
                                        });
                                    if (scriptFunction == null) return;
                                    OnConnectionQueueRemove +=
                                        (connectionInfo) =>
                                        {
                                            scriptFunction.Set(connectionInfo);
                                            scriptFunction.Call();
                                        };
                                    break;
                                }
                                case ScriptEventType.ServerStarted:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        Array.Empty<Type>());
                                    if (scriptFunction == null) return;
                                    OnServerStarted +=
                                        () => { scriptFunction.Call(); };
                                    break;
                                }
                                case ScriptEventType.PlayerRequestControl:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IEntity), typeof(IPlayer)
                                        });
                                    if (scriptFunction == null) return;
                                    OnPlayerRequestControl +=
                                        (entity, player) =>
                                        {
                                            scriptFunction.Set(entity);
                                            scriptFunction.Set(player);
                                            if (scriptFunction.Call() is bool value)
                                            {
                                                return value;
                                            }

                                            return true;
                                        };
                                    break;
                                }
                                case ScriptEventType.PlayerChangeAnimation:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(uint), typeof(uint), typeof(uint), typeof(uint)
                                        });
                                    if (scriptFunction == null) return;
                                    OnPlayerChangeAnimation +=
                                        (entity, oldDict, newDict, oldName, newName) =>
                                        {
                                            scriptFunction.Set(entity);
                                            scriptFunction.Set(oldDict);
                                            scriptFunction.Set(newDict);
                                            scriptFunction.Set(oldName);
                                            scriptFunction.Set(newName);
                                            scriptFunction.Call();
                                        };
                                    break;
                                }
                                case ScriptEventType.PlayerChangeInterior:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(uint), typeof(uint)
                                        });
                                    if (scriptFunction == null) return;
                                    OnPlayerChangeInterior +=
                                        (entity, oldIntLoc, newIntLoc) =>
                                        {
                                            scriptFunction.Set(entity);
                                            scriptFunction.Set(oldIntLoc);
                                            scriptFunction.Set(newIntLoc);
                                            scriptFunction.Call();
                                        };
                                    break;
                                }
                                case ScriptEventType.PlayerDimensionChange:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(int), typeof(int)
                                        });
                                    if (scriptFunction == null) return;
                                    OnPlayerDimensionChange +=
                                        (player, oldDimension, newDimension) =>
                                        {
                                            scriptFunction.Set(player);
                                            scriptFunction.Set(oldDimension);
                                            scriptFunction.Set(newDimension);
                                            scriptFunction.Call();
                                        };
                                    break;
                                }
                                case ScriptEventType.PlayerSpawn:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer)
                                        });
                                    if (scriptFunction == null) return;
                                    OnPlayerSpawn +=
                                        (player) =>
                                        {
                                            scriptFunction.Set(player);
                                            scriptFunction.Call();
                                        };
                                    break;
                                }
                                case ScriptEventType.RequestSyncedScene:
                                {
                                    scriptFunction = ScriptFunction.Create(eventMethodDelegate,
                                        new[]
                                        {
                                            typeof(IPlayer), typeof(int)
                                        },  new[] {typeof(bool) });
                                    if (scriptFunction == null) return;
                                    OnRequestSyncScene += (source, sceneId) =>
                                    {
                                        scriptFunction.Set(source);
                                        scriptFunction.Set(sceneId);
                                        if (scriptFunction.Call() is bool value)
                                        {
                                            return value;
                                        }

                                        return true;
                                    };
                                    break;
                                }
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            break;
                        case ServerEventAttribute @event:
                            var serverEventName = @event.Name ?? eventMethod.Name;
                            CoreImpl.OnServer(serverEventName, Function.Create(Core, eventMethodDelegate));
                            break;
                        case ClientEventAttribute @event:
                            var clientEventName = @event.Name ?? eventMethod.Name;
                            CoreImpl.OnClient(clientEventName, Function.Create(Core, eventMethodDelegate));
                            break;
                    }
                });
        }
    }
}