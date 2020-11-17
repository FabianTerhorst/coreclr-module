#include "CSharpResourceImpl.h"

CSharpResourceImpl::CSharpResourceImpl(alt::ICore* server, CoreClr* coreClr, alt::IResource* resource)
        : alt::IResource::Impl() {
    this->resource = resource;
    this->server = server;
    this->invokers = new alt::Array<CustomInvoker*>();
    this->coreClr = coreClr;
}

void CSharpResourceImpl::ResetDelegates() {
    MainDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnClientEventDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnPlayerConnectDelegate = [](auto var, auto var2, auto var3) {};
    OnResourceStartDelegate = [](auto var) {};
    OnResourceStopDelegate = [](auto var) {};
    OnResourceErrorDelegate = [](auto var) {};
    OnPlayerDamageDelegate = [](auto var, auto var2, auto var3, auto var4, auto var5, auto var6) {};
    OnPlayerDeathDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnExplosionDelegate = [](auto var, auto var2, auto var3, auto var4, auto var5, auto var6, auto var7) {};
    OnWeaponDamageDelegate = [](auto var, auto var2, auto var3, auto var4, auto var5, auto var6, auto var7,
                                auto var8) {};
    OnPlayerDisconnectDelegate = [](auto var, auto var2) {};
    OnPlayerRemoveDelegate = [](auto var) {};
    OnVehicleRemoveDelegate = [](auto var) {};
    OnServerEventDelegate = [](auto var, auto var2, auto var3) {};
    OnPlayerChangeVehicleSeatDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnPlayerEnterVehicleDelegate = [](auto var, auto var2, auto var3) {};
    OnPlayerLeaveVehicleDelegate = [](auto var, auto var2, auto var3) {};
    OnStopDelegate = []() {};
    OnTickDelegate = []() {};
    OnCreatePlayerDelegate = [](auto var, auto var2) {};
    OnRemovePlayerDelegate = [](auto var) {};
    OnCreateVehicleDelegate = [](auto var, auto var2) {};
    OnRemoveVehicleDelegate = [](auto var) {};
    OnCreateBlipDelegate = [](auto var) {};
    OnRemoveBlipDelegate = [](auto var) {};
    OnCreateCheckpointDelegate = [](auto var) {};
    OnRemoveCheckpointDelegate = [](auto var) {};
    OnCreateVoiceChannelDelegate = [](auto var) {};
    OnRemoveVoiceChannelDelegate = [](auto var) {};
    OnConsoleCommandDelegate = [](auto var, auto var2, auto var3) {};
    OnMetaChangeDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnSyncedMetaChangeDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnCreateColShapeDelegate = [](auto var) {};
    OnRemoveColShapeDelegate = [](auto var) {};
    OnColShapeDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnVehicleDestroyDelegate = [](auto var) {};
    OnFireDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnStartProjectileDelegate = [](auto var, auto var2, auto var3, auto var4, auto var5, auto var6) {};
    OnPlayerWeaponChangeDelegate = [](auto var, auto var2, auto var3, auto var4) {};
}

bool CSharpResourceImpl::Start() {
    ResetDelegates();

    if (!coreClr->ExecuteManagedResource(this->resource->GetPath().CStr()/*(alt::String(this->server->GetRootDirectory()) + "/resources/" +
             alt::String(this->resource->GetName().CStr())).CStr()*/, this->resource->GetName().CStr(),
                                         this->resource->GetMain().CStr(),
                                         this->resource)) {
        return false;
    }
    if (MainDelegate == nullptr) return false;
    MainDelegate(this->server, this->resource, this->resource->GetName().CStr(), resource->GetMain().CStr());
    return true;
}

bool CSharpResourceImpl::Stop() {
    if (OnStopDelegate == nullptr) return false;
    OnStopDelegate();
    ResetDelegates();
    return coreClr->ExecuteManagedResourceUnload(this->resource->GetPath().CStr(), this->resource->GetMain().CStr());
}

CSharpResourceImpl::~CSharpResourceImpl() {
    //TODO: fix segmentation fault
    /*for (alt::Size i = 0, length = invokers->GetSize(); i < length; i++) {
        auto invoker = (*invokers)[i];
        delete invoker;
    }*/
    //delete[] invokers;
}

bool CSharpResourceImpl::OnEvent(const alt::CEvent* ev) {
    if (ev == nullptr) return true;
    switch (ev->GetType()) {
        case alt::CEvent::Type::META_CHANGE: {
            /*auto event = ((alt::CMetaChangeEvent*) (ev));
            auto entity = event->GetTarget().Get();
            if (entity == nullptr) return true;
            auto key = event->GetKey();
            auto value = event->GetVal();
            const char* keyCStr;
            if (key == nullptr) {
                keyCStr = "";
            } else {
                keyCStr = key.CStr();
                if (keyCStr == nullptr) {
                    keyCStr = "";
                }
            }
            auto constValue = alt::MValueConst(value);
            OnMetaChangeDelegate(GetEntityPointer(entity), entity->GetType(), keyCStr, &constValue);*/
        }
            break;
        case alt::CEvent::Type::SYNCED_META_CHANGE: {
            /*auto event = ((alt::CSyncedMetaDataChangeEvent*) (ev));
            auto entity = event->GetTarget().Get();
            if (entity == nullptr) return true;
            auto key = event->GetKey();
            auto value = event->GetVal();
            const char* keyCStr;
            if (key == nullptr) {
                keyCStr = "";
            } else {
                keyCStr = key.CStr();
                if (keyCStr == nullptr) {
                    keyCStr = "";
                }
            }
            auto constValue = alt::MValueConst(value);
            OnSyncedMetaChangeDelegate(GetEntityPointer(entity), entity->GetType(), keyCStr, &constValue);*/
        }
            break;
        case alt::CEvent::Type::CLIENT_SCRIPT_EVENT: {
            alt::MValueArgs clientArgs = (((alt::CClientScriptEvent*) (ev))->GetArgs());
            uint64_t size = clientArgs.GetSize();
            if (size == 0) {
                OnClientEventDelegate(((alt::CClientScriptEvent*) (ev))->GetTarget().Get(),
                                      ((alt::CClientScriptEvent*) (ev))->GetName().CStr(),
                                      nullptr, 0);
            } else {
#ifdef _WIN32
                auto constArgs = new alt::MValueConst* [size];
#else
                alt::MValueConst* constArgs[size];
#endif
                for (uint64_t i = 0; i < size; i++) {
                    constArgs[i] = &clientArgs[i];
                }
                OnClientEventDelegate(((alt::CClientScriptEvent*) (ev))->GetTarget().Get(),
                                      ((alt::CClientScriptEvent*) (ev))->GetName().CStr(),
                                      constArgs, size);

#ifdef _WIN32
                delete[] constArgs;
#endif
            }
        }
            break;
        case alt::CEvent::Type::PLAYER_CONNECT: {
            auto connectPlayer = reinterpret_cast<const alt::CPlayerConnectEvent*>(ev)->GetTarget().Get();
            OnPlayerConnectDelegate(connectPlayer, connectPlayer->GetID(),
                                    "");//TODO: maybe better solution
        }
            break;
        case alt::CEvent::Type::RESOURCE_START: {
            OnResourceStartDelegate(reinterpret_cast<const alt::CResourceStartEvent*>(ev)->GetResource());
        }
            break;
        case alt::CEvent::Type::RESOURCE_STOP: {
            OnResourceStopDelegate(reinterpret_cast<const alt::CResourceStopEvent*>(ev)->GetResource());
        }
            break;
        case alt::CEvent::Type::RESOURCE_ERROR: {
            OnResourceErrorDelegate(reinterpret_cast<const alt::CResourceErrorEvent*>(ev)->GetResource());
        }
            break;
        case alt::CEvent::Type::PLAYER_DAMAGE: {
            auto damageEvent = (alt::CPlayerDamageEvent*) ev;
            auto entity = damageEvent->GetAttacker().Get();
            auto entityPtr = GetEntityPointer(entity);
            if (entity != nullptr && entityPtr != nullptr) {
                OnPlayerDamageDelegate(damageEvent->GetTarget().Get(),
                                       entityPtr,
                                       entity->GetType(),
                                       entity->GetID(),
                                       damageEvent->GetWeapon(),
                                       damageEvent->GetDamage());
            } else {
                OnPlayerDamageDelegate(damageEvent->GetTarget().Get(),
                                       nullptr,
                                       alt::IBaseObject::Type::PLAYER,
                                       0,
                                       damageEvent->GetWeapon(),
                                       damageEvent->GetDamage());
            }
        }
            break;
        case alt::CEvent::Type::PLAYER_DEATH: {
            auto entity = ((alt::CPlayerDeathEvent*) (ev))->GetKiller().Get();
            if (entity != nullptr) {
                auto entityPtr = GetEntityPointer(entity);
                OnPlayerDeathDelegate(((alt::CPlayerDeathEvent*) (ev))->GetTarget().Get(),
                                      entityPtr,
                                      entity->GetType(),
                                      ((alt::CPlayerDeathEvent*) (ev))->GetWeapon());
            } else {
                OnPlayerDeathDelegate(((alt::CPlayerDeathEvent*) (ev))->GetTarget().Get(),
                                      nullptr,
                                      (alt::IBaseObject::Type) 0,
                                      ((alt::CPlayerDeathEvent*) (ev))->GetWeapon());
            }
        }
            break;
        case alt::CEvent::Type::FIRE_EVENT: {
            auto fireEvent = ((alt::CFireEvent*) (ev));
            auto source = fireEvent->GetSource().Get();
            auto fires = fireEvent->GetFires();
            int length = fires.GetSize();
            if (length == 0) {
                OnFireDelegate(fireEvent, source, nullptr, 0);
            } else {
                auto fireArray = new alt::CFireEvent::FireInfo[length];
                for (int i = 0; i < length; ++i) {
                    auto const fire = fires[i];
                    fireArray[i] = fire;
                }
                OnFireDelegate(fireEvent, source, fireArray, length);
                delete[] fireArray;
            }
        }
            break;
        case alt::CEvent::Type::EXPLOSION_EVENT: {
            auto explosionEvent = ((alt::CExplosionEvent*) (ev));
            auto eventPosition = explosionEvent->GetPosition();
            auto targetEntity = explosionEvent->GetTarget().Get();
            position_t position = {eventPosition.x, eventPosition.y, eventPosition.z};
            OnExplosionDelegate(explosionEvent, explosionEvent->GetSource().Get(), explosionEvent->GetExplosionType(),
                                position,
                                explosionEvent->GetExplosionFX(), GetEntityPointer(targetEntity),
                                GetEntityType(targetEntity));
        }
            break;
        case alt::CEvent::Type::WEAPON_DAMAGE_EVENT: {
            auto weaponDamageEvent = ((alt::CWeaponDamageEvent*) (ev));
            auto targetEntity = weaponDamageEvent->GetTarget().Get();
            if (targetEntity == nullptr) return true;
            auto eventShotOffset = weaponDamageEvent->GetShotOffset();
            position_t shotOffset = {eventShotOffset[0], eventShotOffset[1], eventShotOffset[2]};
            OnWeaponDamageDelegate(ev, weaponDamageEvent->GetSource().Get(), GetEntityPointer(targetEntity),
                                   targetEntity->GetType(), weaponDamageEvent->GetWeaponHash(),
                                   weaponDamageEvent->GetDamageValue(), shotOffset, weaponDamageEvent->GetBodyPart());
        }
            break;
        case alt::CEvent::Type::PLAYER_DISCONNECT: {
            auto disconnectEvent = reinterpret_cast<const alt::CPlayerDisconnectEvent*>(ev);
            auto disconnectPlayer = disconnectEvent->GetTarget().Get();
            /*auto reason = disconnectEvent->GetReason();
            if (reason != nullptr && reason.GetSize() > 0) {
                auto reasonCStr = reason.CStr();
                if (reasonCStr != nullptr) {
                    OnPlayerDisconnectDelegate(disconnectPlayer,
                                               reasonCStr);
                } else {
                    OnPlayerDisconnectDelegate(disconnectPlayer,
                                               "");
                }*/
            //} else {
            OnPlayerDisconnectDelegate(disconnectPlayer,
                                       "");
            //}
        }
            break;
        case alt::CEvent::Type::REMOVE_ENTITY_EVENT: {
            auto removeEntityEntity = ((alt::CRemoveEntityEvent*) (ev))->GetEntity().Get();
            if (removeEntityEntity != nullptr) {
                switch (removeEntityEntity->GetType()) {
                    case alt::IBaseObject::Type::PLAYER:
                        OnPlayerRemoveDelegate(dynamic_cast<alt::IPlayer*>(removeEntityEntity));
                        break;
                    case alt::IBaseObject::Type::VEHICLE:
                        OnVehicleRemoveDelegate(dynamic_cast<alt::IVehicle*>(removeEntityEntity));
                        break;
                }
            }
        }
            break;
        case alt::CEvent::Type::SERVER_SCRIPT_EVENT: {
            auto serverScriptEvent = (alt::CServerScriptEvent*) ev;
            alt::MValueArgs serverArgs = serverScriptEvent->GetArgs();
            uint64_t size = serverArgs.GetSize();
            if (size == 0) {
                OnServerEventDelegate(serverScriptEvent->GetName().CStr(), nullptr, 0);
            } else {
#ifdef _WIN32
                auto constArgs = new alt::MValueConst* [size];
#else
                alt::MValueConst* constArgs[size];
#endif
                for (uint64_t i = 0; i < size; i++) {
                    constArgs[i] = &serverArgs[i];
                }
                OnServerEventDelegate(serverScriptEvent->GetName().CStr(), constArgs, size);
#ifdef _WIN32
                delete[] constArgs;
#endif
            }
        }
            break;
        case alt::CEvent::Type::PLAYER_CHANGE_VEHICLE_SEAT: {
            auto changeSeatEvent = (alt::CPlayerChangeVehicleSeatEvent*) ev;
            OnPlayerChangeVehicleSeatDelegate(changeSeatEvent->GetTarget().Get(),
                                              changeSeatEvent->GetPlayer().Get(),
                                              changeSeatEvent->GetOldSeat(),
                                              changeSeatEvent->GetNewSeat());
        }
            break;
        case alt::CEvent::Type::PLAYER_ENTER_VEHICLE: {
            auto enterEvent = (alt::CPlayerEnterVehicleEvent*) ev;
            OnPlayerEnterVehicleDelegate(enterEvent->GetTarget().Get(),
                                         enterEvent->GetPlayer().Get(),
                                         enterEvent->GetSeat());
        }
            break;
        case alt::CEvent::Type::PLAYER_LEAVE_VEHICLE: {
            auto leaveEvent = (alt::CPlayerLeaveVehicleEvent*) ev;
            OnPlayerLeaveVehicleDelegate(leaveEvent->GetTarget().Get(),
                                         leaveEvent->GetPlayer().Get(),
                                         leaveEvent->GetSeat());
        }
            break;
        case alt::CEvent::Type::CONSOLE_COMMAND_EVENT: {
            alt::Array<alt::StringView> args = ((alt::CConsoleCommandEvent*) (ev))->GetArgs();

            uint64_t size = args.GetSize();
            if (size == 0) {
                OnConsoleCommandDelegate(((alt::CConsoleCommandEvent*) (ev))->GetName().CStr(), nullptr, 0);
            } else {
#ifdef _WIN32
                auto constArgs = new const char* [size];
#else
                const char* constArgs[size];
#endif
                for (uint64_t i = 0; i < size; i++) {
                    constArgs[i] = args[i].CStr();
                }

                OnConsoleCommandDelegate(((alt::CConsoleCommandEvent*) (ev))->GetName().CStr(), constArgs, size);

#ifdef _WIN32
                delete[] constArgs;
#endif
            }
        }
            break;
        case alt::CEvent::Type::COLSHAPE_EVENT: {
            auto entity = ((alt::CColShapeEvent*) (ev))->GetEntity().Get();
            auto entityPointer = GetEntityPointer(entity);
            if (entity != nullptr && entityPointer != nullptr) {
                auto colShapePointer = ((alt::CColShapeEvent*) (ev))->GetTarget().Get();
                if (colShapePointer->GetType() == alt::IBaseObject::Type::COLSHAPE) {
                    OnColShapeDelegate(colShapePointer,
                                       entityPointer,
                                       entity->GetType(),
                                       ((alt::CColShapeEvent*) (ev))->GetState());
                } else if (colShapePointer->GetType() == alt::IBaseObject::Type::CHECKPOINT) {
                    OnCheckpointDelegate(dynamic_cast<alt::ICheckpoint*>(colShapePointer),
                                         entityPointer,
                                         entity->GetType(),
                                         ((alt::CColShapeEvent*) (ev))->GetState());
                }
            }
        }
            break;
        case alt::CEvent::Type::VEHICLE_DESTROY: {
            auto vehicle = ((alt::CVehicleDestroyEvent*) (ev))->GetTarget().Get();
            OnVehicleDestroyDelegate(vehicle);
            break;
        }
        case alt::CEvent::Type::START_PROJECTILE_EVENT: {
            auto startProjectileEvent = ((alt::CStartProjectileEvent*) (ev));
            auto startPosition = startProjectileEvent->GetStartPosition();
            position_t startPositionStruct = {startPosition.x, startPosition.y, startPosition.z};
            auto direction = startProjectileEvent->GetDirection();
            position_t directionStruct = {direction[0], direction[1], direction[2]};
            OnStartProjectileDelegate(startProjectileEvent, startProjectileEvent->GetSource().Get(), startPositionStruct, directionStruct,
                                      startProjectileEvent->GetAmmoHash(), startProjectileEvent->GetWeaponHash());
            break;
        }
        case alt::CEvent::Type::PLAYER_WEAPON_CHANGE: {
            auto playerWeaponChangeEvent = ((alt::CPlayerWeaponChangeEvent*) (ev));
            OnPlayerWeaponChangeDelegate(playerWeaponChangeEvent, playerWeaponChangeEvent->GetTarget().Get(),
                                         playerWeaponChangeEvent->GetOldWeapon(),
                                         playerWeaponChangeEvent->GetNewWeapon());
            break;
        }
    }
    return true;
}

void CSharpResourceImpl::OnCreateBaseObject(alt::Ref<alt::IBaseObject> objectRef) {
    objectRef->AddRef();
    //objectRef->AddWeakRef(new BaseObjectWeakReference(objectRef, this));
    auto object = objectRef.Get();
    if (object != nullptr) {
        switch (object->GetType()) {
            case alt::IBaseObject::Type::PLAYER: {
                auto player = dynamic_cast<alt::IPlayer*>(object);
                OnCreatePlayerDelegate(player, player->GetID());
                break;
            }
            case alt::IBaseObject::Type::VEHICLE: {
                auto vehicle = dynamic_cast<alt::IVehicle*>(object);
                OnCreateVehicleDelegate(vehicle, vehicle->GetID());
                break;
            }
            case alt::IBaseObject::Type::BLIP: {
                auto blip = dynamic_cast<alt::IBlip*>(object);
                OnCreateBlipDelegate(blip);
                break;
            }
            case alt::IBaseObject::Type::VOICE_CHANNEL: {
                auto voiceChannel = dynamic_cast<alt::IVoiceChannel*>(object);
                OnCreateVoiceChannelDelegate(voiceChannel);
                break;
            }
            case alt::IBaseObject::Type::COLSHAPE:
                OnCreateColShapeDelegate(dynamic_cast<alt::IColShape*>(object));
                break;
            case alt::IBaseObject::Type::CHECKPOINT:
                OnCreateCheckpointDelegate(dynamic_cast<alt::ICheckpoint*>(object));
                break;
        }
    }
}

void CSharpResourceImpl::OnRemoveBaseObject(alt::Ref<alt::IBaseObject> objectRef) {
    auto object = objectRef.Get();
    if (object != nullptr) {
        switch (object->GetType()) {
            case alt::IBaseObject::Type::PLAYER:
                OnRemovePlayerDelegate(dynamic_cast<alt::IPlayer*>(object));
                break;
            case alt::IBaseObject::Type::VEHICLE:
                OnRemoveVehicleDelegate(dynamic_cast<alt::IVehicle*>(object));
                break;
            case alt::IBaseObject::Type::BLIP:
                OnRemoveBlipDelegate(dynamic_cast<alt::IBlip*>(object));
                break;
            case alt::IBaseObject::Type::VOICE_CHANNEL:
                OnRemoveVoiceChannelDelegate(dynamic_cast<alt::IVoiceChannel*>(object));
                break;
            case alt::IBaseObject::Type::COLSHAPE:
                OnRemoveColShapeDelegate(dynamic_cast<alt::IColShape*>(object));
                break;
            case alt::IBaseObject::Type::CHECKPOINT:
                OnRemoveCheckpointDelegate(dynamic_cast<alt::ICheckpoint*>(object));
                break;
        }
    }
    objectRef->RemoveRef();
}

void CSharpResourceImpl::OnTick() {
    OnTickDelegate();
}

void CSharpResourceImpl_SetMainDelegate(CSharpResourceImpl* resource,
                                        MainDelegate_t delegate) {
    resource->MainDelegate = delegate;
}

void CSharpResourceImpl_SetStopDelegate(CSharpResourceImpl* resource,
                                        StopDelegate_t delegate) {
    resource->OnStopDelegate = delegate;
}

void CSharpResourceImpl_SetTickDelegate(CSharpResourceImpl* resource,
                                        TickDelegate_t delegate) {
    resource->OnTickDelegate = delegate;
}

void CSharpResourceImpl_SetServerEventDelegate(CSharpResourceImpl* resource,
                                               ServerEventDelegate_t delegate) {
    resource->OnServerEventDelegate = delegate;
}

void CSharpResourceImpl_SetCheckpointDelegate(CSharpResourceImpl* resource,
                                              CheckpointDelegate_t delegate) {
    resource->OnCheckpointDelegate = delegate;
}

void CSharpResourceImpl_SetClientEventDelegate(CSharpResourceImpl* resource,
                                               ClientEventDelegate_t delegate) {
    resource->OnClientEventDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerDamageDelegate(CSharpResourceImpl* resource,
                                                PlayerDamageDelegate_t delegate) {
    resource->OnPlayerDamageDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerConnectDelegate(CSharpResourceImpl* resource,
                                                 PlayerConnectDelegate_t delegate) {
    resource->OnPlayerConnectDelegate = delegate;
}

void CSharpResourceImpl_SetResourceStartDelegate(CSharpResourceImpl* resource, ResourceEventDelegate_t delegate) {
    resource->OnResourceStartDelegate = delegate;
}

void CSharpResourceImpl_SetResourceStopDelegate(CSharpResourceImpl* resource, ResourceEventDelegate_t delegate) {
    resource->OnResourceStopDelegate = delegate;
}

void CSharpResourceImpl_SetResourceErrorDelegate(CSharpResourceImpl* resource, ResourceEventDelegate_t delegate) {
    resource->OnResourceErrorDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerDeathDelegate(CSharpResourceImpl* resource,
                                               PlayerDeathDelegate_t delegate) {
    resource->OnPlayerDeathDelegate = delegate;
}

void CSharpResourceImpl_SetExplosionDelegate(CSharpResourceImpl* resource,
                                             ExplosionDelegate_t delegate) {
    resource->OnExplosionDelegate = delegate;
}

void CSharpResourceImpl_SetWeaponDamageDelegate(CSharpResourceImpl* resource,
                                                WeaponDamageDelegate_t delegate) {
    resource->OnWeaponDamageDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerDisconnectDelegate(CSharpResourceImpl* resource,
                                                    PlayerDisconnectDelegate_t delegate) {
    resource->OnPlayerDisconnectDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerRemoveDelegate(CSharpResourceImpl* resource,
                                                PlayerRemoveDelegate_t delegate) {
    resource->OnPlayerRemoveDelegate = delegate;
}

void CSharpResourceImpl_SetVehicleRemoveDelegate(CSharpResourceImpl* resource,
                                                 VehicleRemoveDelegate_t delegate) {
    resource->OnVehicleRemoveDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(CSharpResourceImpl* resource,
                                                           PlayerChangeVehicleSeatDelegate_t delegate) {
    resource->OnPlayerChangeVehicleSeatDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerEnterVehicleDelegate(CSharpResourceImpl* resource,
                                                      PlayerEnterVehicleDelegate_t delegate) {
    resource->OnPlayerEnterVehicleDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(CSharpResourceImpl* resource,
                                                      PlayerLeaveVehicleDelegate_t delegate) {
    resource->OnPlayerLeaveVehicleDelegate = delegate;
}

void CSharpResourceImpl_SetCreatePlayerDelegate(CSharpResourceImpl* resource,
                                                CreatePlayerDelegate_t delegate) {
    resource->OnCreatePlayerDelegate = delegate;
}

void CSharpResourceImpl_SetRemovePlayerDelegate(CSharpResourceImpl* resource,
                                                RemovePlayerDelegate_t delegate) {
    resource->OnRemovePlayerDelegate = delegate;
}

void CSharpResourceImpl_SetCreateVehicleDelegate(CSharpResourceImpl* resource,
                                                 CreateVehicleDelegate_t delegate) {
    resource->OnCreateVehicleDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveVehicleDelegate(CSharpResourceImpl* resource,
                                                 RemoveVehicleDelegate_t delegate) {
    resource->OnRemoveVehicleDelegate = delegate;
}

void CSharpResourceImpl_SetCreateBlipDelegate(CSharpResourceImpl* resource,
                                              CreateBlipDelegate_t delegate) {
    resource->OnCreateBlipDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveBlipDelegate(CSharpResourceImpl* resource,
                                              RemoveBlipDelegate_t delegate) {
    resource->OnRemoveBlipDelegate = delegate;
}

void CSharpResourceImpl_SetCreateCheckpointDelegate(CSharpResourceImpl* resource,
                                                    CreateCheckpointDelegate_t delegate) {
    resource->OnCreateCheckpointDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveCheckpointDelegate(CSharpResourceImpl* resource,
                                                    RemoveCheckpointDelegate_t delegate) {
    resource->OnRemoveCheckpointDelegate = delegate;
}

void CSharpResourceImpl_SetCreateVoiceChannelDelegate(CSharpResourceImpl* resource,
                                                      CreateVoiceChannelDelegate_t delegate) {
    resource->OnCreateVoiceChannelDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveVoiceChannelDelegate(CSharpResourceImpl* resource,
                                                      RemoveVoiceChannelDelegate_t delegate) {
    resource->OnRemoveVoiceChannelDelegate = delegate;
}

void CSharpResourceImpl_SetConsoleCommandDelegate(CSharpResourceImpl* resource,
                                                  ConsoleCommandDelegate_t delegate) {
    resource->OnConsoleCommandDelegate = delegate;
}

void CSharpResourceImpl_SetMetaChangeDelegate(CSharpResourceImpl* resource,
                                              MetaChangeDelegate_t delegate) {
    resource->OnMetaChangeDelegate = delegate;
}

void CSharpResourceImpl_SetSyncedMetaChangeDelegate(CSharpResourceImpl* resource,
                                                    MetaChangeDelegate_t delegate) {
    resource->OnSyncedMetaChangeDelegate = delegate;
}

void CSharpResourceImpl_SetCreateColShapeDelegate(CSharpResourceImpl* resource,
                                                  CreateColShapeDelegate_t delegate) {
    resource->OnCreateColShapeDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveColShapeDelegate(CSharpResourceImpl* resource,
                                                  RemoveColShapeDelegate_t delegate) {
    resource->OnRemoveColShapeDelegate = delegate;
}

void CSharpResourceImpl_SetColShapeDelegate(CSharpResourceImpl* resource,
                                            ColShapeDelegate_t delegate) {
    resource->OnColShapeDelegate = delegate;
}

void CSharpResourceImpl_SetVehicleDestroyDelegate(CSharpResourceImpl* resource,
                                                  VehicleDestroyDelegate_t delegate) {
    resource->OnVehicleDestroyDelegate = delegate;
}

void CSharpResourceImpl_SetFireDelegate(CSharpResourceImpl* resource,
                                        FireDelegate_t delegate) {
    resource->OnFireDelegate = delegate;
}

void CSharpResourceImpl_SetStartProjectileDelegate(CSharpResourceImpl* resource,
                                                   StartProjectileDelegate_t delegate) {
    resource->OnStartProjectileDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerWeaponChangeDelegate(CSharpResourceImpl* resource,
                                                      PlayerWeaponChangeDelegate_t delegate) {
    resource->OnPlayerWeaponChangeDelegate = delegate;
}

bool CSharpResourceImpl::MakeClient(alt::IResource::CreationInfo* info, alt::Array<alt::String> files) {
    info->type = "js";
    return true;
}

void* CSharpResourceImpl::GetBaseObjectPointer(alt::IBaseObject* baseObject) {
    if (baseObject != nullptr) {
        switch (baseObject->GetType()) {
            case alt::IBaseObject::Type::PLAYER:
                return dynamic_cast<alt::IPlayer*>(baseObject);
            case alt::IBaseObject::Type::VEHICLE:
                return dynamic_cast<alt::IVehicle*>(baseObject);
            case alt::IBaseObject::Type::BLIP:
                return dynamic_cast<alt::IBlip*>(baseObject);
            case alt::IBaseObject::Type::COLSHAPE:
                return dynamic_cast<alt::IColShape*>(baseObject);
            case alt::IBaseObject::Type::CHECKPOINT:
                return dynamic_cast<alt::ICheckpoint*>(baseObject);
            default:
                return nullptr;
        }
    }
    return nullptr;
}

void* CSharpResourceImpl::GetEntityPointer(alt::IEntity* entity) {
    if (entity != nullptr) {
        switch (entity->GetType()) {
            case alt::IBaseObject::Type::PLAYER:
                return dynamic_cast<alt::IPlayer*>(entity);
            case alt::IBaseObject::Type::VEHICLE:
                return dynamic_cast<alt::IVehicle*>(entity);
            default:
                return nullptr;
        }
    }
    return nullptr;
}

alt::IBaseObject::Type CSharpResourceImpl::GetEntityType(alt::IEntity* entity) {
    if (entity != nullptr) {
        return entity->GetType();
    }
    return alt::IBaseObject::Type::PLAYER;// 0
}